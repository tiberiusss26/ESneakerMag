using System;
using System.IdentityModel.Tokens.Jwt;
using proiect.Models;

namespace proiect.Helpers.JwtUtils
{
	public class JwtUtils: IJwtUtils
	{
        public string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
        }

        public Guid ValidateJwtToken(string token)
        {
            throw new NotImplementedException();
        }
    }
}

