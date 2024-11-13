using ic_tienda_bussines.Auth.models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ic_tienda_data.Utils
{
    public static class JwtUtils
    {
        public static string Encode(UserAppProfile profile)
        {
            // CREAR los CLAIMS (crear PAYLOAD)
            ClaimsIdentity claims = GenerateClaims(profile);
            //definir el tiemp de expiracion
            int expireInMinuts = 30; // TODO: debe venir de la configuracion
            DateTime expire = DateTime.UtcNow.AddMinutes(expireInMinuts);
            string LLAVE = "saflkcbnxz,w342349324#$#$sdfsafdashw4h3kln34,234$%#$%$#%$#%$#fdsfsdfdsfdsfdsfdsfdsfdsfdsfdsfdsf"; // TODO: debe venir de la configuracion 
            // Generar el token
            return GenerateToken(claims, expire, LLAVE);
        }

        public static UserAppProfile Decode(string token)
        {
            string LLAVE = "saflkcbnxz,w342349324#$#$sdfsafdashw4h3kln34,234$%#$%$#%$#%$#fdsfsdfdsfdsfdsfdsfdsfdsfdsfdsfdsf"; // TODO: debe venir de la configuracion 
            JwtSecurityToken jwt = DecodeJwtToken(token, LLAVE);
            return GetProfile(jwt);
        }

        private static JwtSecurityToken DecodeJwtToken(String token, string strKey)
        {
            JwtSecurityTokenHandler tokenHandler = new();

            byte[] key = Encoding.ASCII.GetBytes(strKey);
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                // set clockskew to zero so tokens expire exactly
                // at token expiration time (instead of 5 minutes later)
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);

            JwtSecurityToken jwt = (JwtSecurityToken)validatedToken;
            return jwt;
        }

        private static UserAppProfile GetProfile(JwtSecurityToken jwt)
        {
            string rolId = jwt.Claims.FirstOrDefault(x => x.Type == "role")?.Value ?? "";
            string id = jwt.Claims.FirstOrDefault(x => x.Type == "nameid")?.Value ?? "";
            string email = jwt.Claims.FirstOrDefault(x => x.Type == "email")?.Value ?? "";
            string name = jwt.Claims.FirstOrDefault(x => x.Type == "unique_name")?.Value ?? "";
            string lastname = jwt.Claims.FirstOrDefault(x => x.Type == "given_name")?.Value ?? "";
            string loquesea = jwt.Claims.FirstOrDefault(x => x.Type == "LOQUESEA")?.Value ?? "";

            return new UserAppProfile
            {
                Id = int.Parse(id),
                Email = email,
                Name = name,
                LastName = lastname,
                Rol = new RolApp
                {
                    id = int.Parse(rolId)
                }
            };

        }

        private static ClaimsIdentity GenerateClaims(UserAppProfile profile)
        {
            ClaimsIdentity claimsIdentity = new ClaimsIdentity();
            // rolid
            claimsIdentity.AddClaim(
                new Claim(ClaimTypes.Role, profile.Rol.id.ToString())
                );
            // id
            claimsIdentity.AddClaim(
                new Claim(ClaimTypes.NameIdentifier, profile.Id.ToString()));
            // email
            claimsIdentity.AddClaim(
                new Claim(ClaimTypes.Email, profile.Email));
            // name
            claimsIdentity.AddClaim(
                new Claim(ClaimTypes.Name, profile.Name));
            // surname
            claimsIdentity.AddClaim(
                new Claim(ClaimTypes.GivenName, profile.LastName));
            // loque SEA
            claimsIdentity.AddClaim(
                new Claim("LOQUESEA", "LOQUESEA"));

            return claimsIdentity;
        }

        private static string GenerateToken(ClaimsIdentity claimsIdentity, DateTime expires, string secret)
        {
            //var settings = _configuration. .GetValue<object>("AppSettings");
            var key = Encoding.ASCII.GetBytes(secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                Expires = expires,
                // Credenciales para generar el token
                // usando nuestro secretykey y el algoritmo hash 256
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var createdToken = tokenHandler.CreateToken(tokenDescriptor);
            string token = tokenHandler.WriteToken(createdToken);
            return token;
        }

    }
}
