Here’s a clear and professional `README.md` for your GitHub project, showcasing your easy-to-use JWT authentication implementation, including Swagger integration and usage example:

---

# 🔐 EasyJWT – Simplify JWT Authentication in ASP.NET Core

**EasyJWT** makes it easier to implement JWT authentication in your ASP.NET Core projects. With built-in support for access/refresh tokens, easy DI setup, and Swagger integration, it's designed for quick and secure authentication setup.

---

## ✨ Features

* ✅ Easy setup with `appsettings.json` configuration
* 🔐 Built-in support for **Access Token** and **Refresh Token**
* ♻️ Configurable expiration for both tokens
* 🔄 Simple integration into your controller logic
* 📘 **Swagger authentication** support included
* 📦 Ready to be packaged as a NuGet library

---

## 📦 Installation

Coming soon as a NuGet package!

For now, clone or copy the code and reference it directly in your solution.

---

## ⚙️ Token Response Class

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

## 🛠️ Setup

### Step 1: Add configuration in `appsettings.json`

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

### Step 2: Register JWT in `Program.cs`

```csharp
builder.Services.AddJWTAuthentication(builder.Configuration);
```

---

### Step 3: Inject and Use in Controller

```csharp
public class LoginController
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

## 📌 Usage Summary

* Add JWT section to `appsettings.json`
* Call `AddJWTAuthentication` in `Program.cs`
* Inject `AuthenticationTokenResponse` to generate tokens

---

---

## 💬 Feedback / Contributing

Feel free to open issues or submit pull requests to improve functionality or add features.

