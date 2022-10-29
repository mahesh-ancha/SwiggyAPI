using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SwiggyAPI.Models
{
    public class JwtService
    {
        public string SecretyKey { get; set; }
        public string TokenDuration { get; set; }
        private readonly IConfiguration config;
        public JwtService(IConfiguration _config)
        {
            config = _config;
            this.SecretyKey = config.GetSection("jwt" +
                "Config").GetSection("Key").Value;
            this.TokenDuration = (config.GetSection("jwtConfig").GetSection("Duration").Value);
        }
        public string GenerateToken(string id, string firstname, string lastname, string email, string mobile, string gender)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.SecretyKey));
            var signature = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var payload = new[]
            {
                new Claim("id",id),
                new Claim("firstname",firstname),
                new Claim("lastname",lastname),
                new Claim("email",email),
                new Claim("mobile",mobile),
                new Claim("gender",gender)
        };

            var jwtToken = new JwtSecurityToken(
                issuer: "localhost",
                audience: "localhost",
                claims: payload,
                expires: DateTime.Now.AddMinutes(Double.Parse(TokenDuration)),
                signingCredentials: signature
               );
            return new JwtSecurityTokenHandler().WriteToken(jwtToken);
        }

        internal object? GenerateToken(object value, object firstName, object lastName, object email, object mobile, object gender)
        {
            throw new NotImplementedException();
        }
    }
}
