````md
# 🔐 EasyJWT – Simplify JWT Authentication in ASP.NET Core

**EasyJWT** is a lightweight library that simplifies the implementation of JWT (JSON Web Tokens) authentication in ASP.NET Core. It supports both **access** and **refresh tokens**, and includes seamless Swagger integration for testing secured APIs.

---

## ✨ Features

- ✅ Minimal configuration required
- 🔐 Supports **Access** and **Refresh** tokens
- ⏱️ Customizable expiration settings
-  support custom claims by passing other claims as a dictionary
- 🧪 Out-of-the-box Swagger support with `Bearer` scheme
- 📦 Available as a NuGet package: `Andrew.CommonUse.JWT`

---

## 📦 Installation

Install via NuGet:

### Using .NET CLI

```bash
dotnet add package Andrew.CommonUse.JWT
````

### Using Package Manager

```powershell
NuGet\Install-Package Andrew.CommonUse.JWT
```

---

## 🛠️ Setup Instructions

### 1. Configure `appsettings.json`

```json
"JWT": {
  "SecKey": "your-secret-key-goes-here",
  "ExpiresMinutes": 60,
  "RefreshTokenExpiresHours": 189,
  "Issuer": "your-issuer",
  "Audience": "your-audience"
}
```

---

### 2. Register in `Program.cs`

```csharp
builder.Services.AddJWTAuthentication(builder.Configuration);
```

---

### 3. Inject and Use in Your Controller

```csharp
[ApiController]
[Route("api/[controller]")]
public class LoginController : ControllerBase
{
    private readonly AuthenticationTokenResponse _authTokenResponse;

    public LoginController(AuthenticationTokenResponse authTokenResponse)
    {
        _authTokenResponse = authTokenResponse;
    }

    [HttpPost("login")]
    public IActionResult Login(User user)
    {
        var token = _authTokenResponse.GetResponseToken(user.Id, user.UserName);
        return Ok(token);
    }
}
```

> `GetResponseToken` also accepts optional `roles` and `Others` for custom claims:

```csharp
TokenWithExpireResponse GetResponseToken(
    long userId,
    string userName,
    List<string>? roles = null,
    Dictionary<string, string>? others = null
);
```

---

## 🧾 Token Response Structure

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

## 📄 License

This project is licensed under the **MIT License**.

