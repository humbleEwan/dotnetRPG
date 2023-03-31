using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RPG.Utils
{
    public class JWTokenHandler {
        public JWTokenHandler(string payload) {
            _tokenHandler = new JwtSecurityTokenHandler();
            _key = Encoding.ASCII.GetBytes("very-safe-secret");
            _tokenDescriptor = new SecurityTokenDescriptor {
                Subject = new ClaimsIdentity(new[] {
                    new Claim("payload", payload)
                }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(_key), SecurityAlgorithms.HmacSha256Signature)
            };
        }

        public string generateToken() {
            return _tokenHandler.WriteToken(_tokenHandler.CreateToken(_tokenDescriptor));
        }

        private JwtSecurityTokenHandler _tokenHandler;
        private byte[] _key;
        private SecurityTokenDescriptor _tokenDescriptor;
    }
}
