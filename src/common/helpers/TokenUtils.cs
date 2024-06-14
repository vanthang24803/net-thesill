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

        public JwtPayload VerifyRefreshToken(string token) {
            return VerifyToken(token, _refreshSecret, validateLifetime: true);
        }

        public JwtPayload VerifyAccessToken(string accessToken) {
            return VerifyToken(accessToken, _authSecret);
        }

        private static List<Claim> ClaimsPayload(UserEntity user) {
            return [
                new("name", $"{user.FirstName} {user.LastName}"),
                new("email", user.Email),
                new("id", user.Id.ToString()),
                new("roles", string.Join(",", MapRoles(user.Roles))),
            ];
        }


        private static List<string> MapRoles(List<RoleEntity> roles) {
            var rolesMap = new List<string>();

            foreach (var role in roles) {
                rolesMap.Add(role.Role.ToString());
            }

            return rolesMap;
        }

        private JwtPayload VerifyToken(string token,
                            SymmetricSecurityKey key,
                            bool validateLifetime = true
          ) {
            var tokenHandler = new JwtSecurityTokenHandler();
            try {
                var claimsPrincipal = tokenHandler.ValidateToken(token, new TokenValidationParameters {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = validateLifetime,
                    ValidIssuer = _configuration["JWT:ValidIssuer"],
                    ValidAudience = _configuration["JWT:ValidAudience"],
                    IssuerSigningKey = key
                }, out SecurityToken validatedToken);

                var payload = new JwtPayload();

                foreach (Claim claim in claimsPrincipal.Claims) {
                    if (claim.Type == "id") {
                        payload.Id = Guid.Parse(claim.Value);
                    } else if (claim.Type == "exp") {
                        payload.Expires = DateTimeOffset.FromUnixTimeSeconds(long.Parse(claim.Value)).DateTime;
                    }
                }

                return payload;

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