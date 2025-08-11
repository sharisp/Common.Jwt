namespace Common.Jwt
{
    /// <summary>
    /// jwt configuration options.
    /// </summary>
    public class JwtOptions
    {
        public string SecKey { get; set; } = "";
        public int ExpiresMinutes { get; set; }
        public int RefreshTokenExpiresHours { get; set; }
        public string? Issuer { get; set; }
        public string? Audience { get; set; }

    }
}
