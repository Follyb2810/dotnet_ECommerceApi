```bash

dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer --version 8.0.10
dotnet add package Microsoft.IdentityModel.Tokens --version 8.0.10
dotnet add package System.IdentityModel.Tokens.Jwt --version 8.0.10
dotnet add package Microsoft.EntityFrameworkCore --version 8.0.10
dotnet add package Microsoft.EntityFrameworkCore.Sqlite --version 8.0.10
dotnet add package Microsoft.EntityFrameworkCore.Tools --version 8.0.10

```

```bash
/api/auth/register — register user

/api/auth/login — authenticate and return JWT token

Product Management

Endpoints:

GET /api/products — list all products

GET /api/products/{id} — product details

POST /api/products — add new product (admin only)

PUT /api/products/{id} — update product (admin only)

DELETE /api/products/{id} — delete product (admin only)

🧾 Step 7 — Order Handling

Endpoints:

POST /api/orders — create new order from cart

GET /api/orders — view user’s orders

GET /api/orders/{id} — order details
```
# dotnet_ECommerceApi
