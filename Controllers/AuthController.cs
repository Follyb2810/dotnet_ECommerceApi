using Microsoft.AspNetCore.Mvc;
using ECommerceApi.Models;
using ECommerceApi.Services;
using ECommerceApi.DTOs;
using ECommerceApi.Data;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;


namespace ECommerceApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly TokenService _tokenService;


        public AuthController(AppDbContext db, TokenService tokenService)
        {
            _db = db;
            _tokenService = tokenService;
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            if (await _db.Users.AnyAsync(u => u.Username == dto.Username))
                return BadRequest("Username already exists");


            using var hmac = new HMACSHA512();


            var user = new User
            {
                Username = dto.Username,
                PasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(dto.Password)),
                PasswordSalt = hmac.Key,
                // Role = dto.Role
            };


            _db.Users.Add(user);
            await _db.SaveChangesAsync();


            var token = _tokenService.CreateToken(user);
            return Ok(new { token });
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var user = await _db.Users.SingleOrDefaultAsync(u => u.Username == dto.Username);
            if (user == null) return Unauthorized("Invalid username or password");


            using var hmac = new HMACSHA512(user.PasswordSalt);
            var computed = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(dto.Password));
            if (!computed.SequenceEqual(user.PasswordHash)) return Unauthorized("Invalid username or password");


            var token = _tokenService.CreateToken(user);
            return Ok(new { token });
        }
    }
}