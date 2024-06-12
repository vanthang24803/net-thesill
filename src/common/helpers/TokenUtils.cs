using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Api.TheSill.src.common.exceptions;
using Api.TheSill.src.domain.models;
using Microsoft.IdentityModel.Tokens;

namespace Api.TheSill.src.common.helpers {
    public class TokenUtils {
        private readonly IConfiguration _configuration;

        private readonly SymmetricSecurityKey _authSecret;

        private readonly SymmetricSecurityKey _refreshSecret;

        public TokenUtils(IConfiguration configuration) {
            _configuration = configuration;
            _authSecret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]!));
            _refreshSecret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration["JWT:Refresh"]!
            ));
        }

        public string GenerateAccessToken(UserEntity user) {
            var payload = ClaimsPayload(user);
            return GenerateToken(payload, _authSecret, DateTime.Now.AddMinutes(15));
        }

        public string GenerateRefreshToken(UserEntity user) {
            var payload = ClaimsPayload(user);
            return GenerateToken(payload, _refreshSecret, DateTime.Now.AddMonths(1));
        }

        public bool VerifyRefreshToken(string token) {
            return VerifyToken(token, _refreshSecret);
        }

        public bool VerifyAccessToken(string accessToken) {
            return VerifyToken(accessToken, _authSecret);
        }

        private static List<Claim> ClaimsPayload(UserEntity user) {
            var payload = new List<Claim> {
                new("name", $"{user.FirstName} {user.LastName}"),
                new("email", user.Email),
                new("id", user.Id.ToString()),
            };
            return payload;
        }


        private bool VerifyToken(string token, SymmetricSecurityKey key) {
            var tokenHandler = new JwtSecurityTokenHandler();
            try {
                tokenHandler.ValidateToken(token, new TokenValidationParameters {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = _configuration["JWT:ValidIssuer"],
                    ValidAudience = _configuration["JWT:ValidAudience"],
                    IssuerSigningKey = key
                }, out SecurityToken validatedToken);

                return true;
            } catch {
                throw new UnauthorizedException();
            }
        }

        private string GenerateToken(
            List<Claim> claims, SymmetricSecurityKey key, DateTime expires
        ) {
            var tokenObject = new JwtSecurityToken(
                              issuer: _configuration["JWT:ValidIssuer"],
                              audience: _configuration["JWT:ValidAudience"],
                              expires: expires,
                              claims: claims,
                              signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));

            string token = new JwtSecurityTokenHandler().WriteToken(tokenObject);

            return token;
        }

    }
}