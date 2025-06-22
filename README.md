# 🔐 EasyJWT – Simplify JWT Authentication in ASP.NET Core

**EasyJWT** is a lightweight utility that makes it easier to use JWT (JSON Web Tokens) in your ASP.NET Core applications. It supports both access and refresh tokens, and integrates seamlessly with Swagger for secure API testing.

---

## ✨ Features

- ✅ Minimal configuration
- 🔐 Access & Refresh token support
- 🔄 Configurable expiration settings
- 📘 Built-in Swagger support for `Bearer` authentication
- 📦 Published as a NuGet package: `Andrew.CommonUse.JWT`

---

## 📦 Installation

Install it directly from NuGet:

### .NET CLI

```bash
dotnet add package Andrew.CommonUse.JWT --version 1.0.0
````

### Package Manager

```powershell
NuGet\Install-Package Andrew.CommonUse.JWT -Version 1.0.0
```

---

## 🛠️ Setup

### 1. `appsettings.json`

```json
"JWT": {
  "SecKey": "ssssaa@!#$!#$!#%TGadADFASDfasdfasdfaddfadfdfgagagadadfasdfafafawsfdaf12adfasfdadfsdadfsadsf",
  "ExpiresMinutes": 60,
  "RefreshTokenExpiresHours": 189,
  "Issuer": "test",
  "Audience": "test"
}
```

---

### 2. Register in `Program.cs`

```csharp
builder.Services.AddJWTAuthentication(builder.Configuration);
```

---

### 3. Inject & Use in Controller

```csharp
public class LoginController : ControllerBase
{
    private readonly AuthenticationTokenResponse _authenticationTokenResponse;

    public LoginController(AuthenticationTokenResponse authenticationTokenResponse)
    {
        _authenticationTokenResponse = authenticationTokenResponse;
    }

    [HttpPost("login")]
    public IActionResult Login(User user)
    {
        var token = _authenticationTokenResponse.GetResponseToken(user.Id, user.UserName);
        return Ok(token);
    }
}
```

---

## 🧾 Token Response Class

```csharp
public class TokenResponse
{
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
    public DateTimeOffset AccessTokenExpiresAt { get; set; }
    public DateTimeOffset RefreshTokenExpiresAt { get; set; }
}
```

---

## 📘 Swagger Integration

### Add to `Program.cs`:

```csharp
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter: Bearer {your JWT token}"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});
```

---

## 📄 License

MIT License

---

## 💬 Feedback / Contributing

Feel free to open issues or submit pull requests to improve functionality or add new features.
