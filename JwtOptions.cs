﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Jwt
{
    public class JwtOptions
    {
        public string SecKey { get; set; } = "";
        public int ExpiresMinutes { get; set; }
        public int RefreshTokenExpiresHours { get; set; }
        public string? Issuer { get; set; }
        public string? Audience { get; set; }

    }
}
