using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Server.Models.UserAccount;
using Server.Models.UserRoles;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Server.Services.Foundation.JwtService
{
    public class JwtService : IJwtService
    {
        public readonly IConfiguration configuration;

        public readonly UserManager<User> _userManager;

        public JwtService(IConfiguration configuration, UserManager<User> _userManager)
        {
            this.configuration = configuration;
            this._userManager = _userManager;

        }


        public string GenerateTokenRefresh()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

        public string Generitedtoken(User user, List<Role> userRoles)
        {
            var keysecurity = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var credential = new SigningCredentials(keysecurity, SecurityAlgorithms.HmacSha256);
            string RoleName = null;

            var claim = new[]
            {

                new Claim(ClaimTypes.Name, user.Email), // NOTE: this will be the "UserAccount.Identity.Name" value
				new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, user.Email),




            };
            foreach (var item in userRoles)
            {
                claim.Append(new Claim(ClaimTypes.Role, item.Name));
            }




            var token = new JwtSecurityToken(configuration["Jwt:Issuer"], configuration["Jwt:Audience"], claim, expires: DateTime.Now.AddMinutes(720), signingCredentials: credential);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public ClaimsPrincipal GetClaimPrincepale(string Token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false, //you might want to validate the audience and issuer depending on your use case
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:key"])),
                ValidateLifetime = false //here we are saying that we don't care about the token's expiration date
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            var principal = tokenHandler.ValidateToken(Token, tokenValidationParameters, out securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");
            return principal;
        }
    }
}
