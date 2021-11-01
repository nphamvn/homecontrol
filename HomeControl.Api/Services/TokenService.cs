using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using HomeControl.Api.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace HomeControl.Api.Services
{
    public class JwtOptions
    {
        public const string Section = "JwtOptions";
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int ExpirationMinutes { get; set; }
        public string Secret { get; set; }
    }
    public class TokenService
    {
        private readonly JwtOptions _jwtOptions;

        public TokenService(IOptions<JwtOptions> options)
        {
            _jwtOptions = options.Value;
        }

        public async Task<AuthToken> GenerateToken(FamilyMember member)
        {
            var claims = new List<Claim>();
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Secret));

            var signingCredentials = new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(issuer: _jwtOptions.Issuer,
            audience: _jwtOptions.Audience,
            expires: System.DateTime.Now.AddMinutes(_jwtOptions.ExpirationMinutes),
            claims: claims,
            signingCredentials: signingCredentials);

            return new AuthToken
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = token.ValidTo
            };
        }
    }
}