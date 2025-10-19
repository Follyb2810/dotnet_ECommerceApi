using System.ComponentModel.DataAnnotations;


namespace ECommerceApi.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Username { get; set; } = string.Empty;
        public required byte[] PasswordHash { get; set; }
        public required byte[] PasswordSalt { get; set; }
        public string Role { get; set; } = "Customer";


        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}