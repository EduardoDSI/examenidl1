using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using ic_tienda_bussines.Auth.models;
using ic_tienda_bussines.Auth.services;
using ic_tienda_bussines.Errors;
using ic_tienda_data.sources.BaseDeDatos;
using ic_tienda_data.sources.BaseDeDatos.Tables;
using ic_tienda_data.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace ic_tienda_data.Auth.services {

    public class AuthenticationServiceDbImpl : IAuthenticationService
    {
        private readonly IcTiendaDbContext _db;
        public readonly ILogger _logger;
        //private readonly IConfigurationRoot  _conf;
        public AuthenticationServiceDbImpl(
            ILogger<AuthenticationServiceDbImpl> logger,
            IcTiendaDbContext db
            ) {
            _db = db;
            _logger = logger;
        }

        public LoginResponse Login(LoginRequest login)
        {
            var user = _db.usuarios.Where(u => u.correo == login.email).FirstOrDefault();
            if (user == null) {
                throw new MessageExeption("Credenciales incorrectas.");
            }
            // Hashear el password
            login.password = GenerateSaltedHash(login.password, user.salt);
            _logger.LogInformation($"HASHED PASSWORD ====> u{login.password}");

            var userData = _db.usuarios.Join(
                _db.personas,
                u => u.id_persona,
                p => p.id,
                (u, p) => new { u=u, p=p}
            ).Join(
                _db.roles,
                (up) => up.u.id_rol,
                r => r.id,
                (up, r) => new {u=up.u, p=up.p, r=r }
            ).Where(
                (upr) => upr.u.correo == login.email && upr.u.clave == login.password && upr.u.estado
            ).FirstOrDefault();

            if (userData == null) {
                throw new MessageExeption("Credenciales incorrectas.");
            }
            var profile = new UserAppProfile {
                Id = userData.u.id,
                Name = userData.p.nombres,
                LastName = userData.p.apellidos,
                Email = userData.u.correo,
                Rol = new RolApp {
                    name = userData.r.nombre,
                    id = userData.r.id
                }
            };

            return new LoginResponse {
                token = JwtUtils.Encode(profile),
                profile = profile,
            };


            // con tres queries independientes
            // // select top 5 from usuarios were email = "asdsa@sads.com" and clave = '1234' and estado =  true
            // var user = _db.usuarios.Where(
            //     (u) => u.correo == login.email && u.clave == login.password && u.estado
            // ).FirstOrDefault();

            // if (user != null) {
            //     var persona = _db.personas.Where( p=> p.id == user.id_persona ).FirstOrDefault();
            //     var rol = _db.roles.Where(r => r.id == user.id_rol).FirstOrDefault();

            // }

        }
    
        public void Register(RegisterRequest data)
        {
            int CLIENTE_ROL = 3;
            // CREAR persona
            var person = new PersonaTable{
                nombres = data.Name,
                apellidos = data.LastName,
                tipo_documento = data.DocumentType,
                numero_documento = data.DocumentNumber,
                telefono = "",
                estado = true
            };
            _db.personas.Add(person);
            _db.SaveChanges();

            //CREAR USUARIO
            // -> creamos el salt
            string salt = CreateSalt();
            //-> Remplazar la contraseña
            data.Password = GenerateSaltedHash(data.Password, salt);
        
            var user = new UsuarioTable{
                id_persona = person.id,
                id_rol = CLIENTE_ROL,
                correo = data.Email,
                clave = data.Password,
                salt = salt,
                estado = true
            };

            _db.usuarios.Add(user);
            _db.SaveChanges();

        }

        private static string GenerateSaltedHash(string passwordStr, string saltStr)
        {
            //var utf8 = new UTF8Encoding();

            byte[] password = Encoding.ASCII.GetBytes(passwordStr);
            byte[] salt = Encoding.ASCII.GetBytes(saltStr);
            



            HashAlgorithm algorithm = new SHA256Managed();

            byte[] plainTextWithSaltBytes = 
                new byte[password.Length + salt.Length];

            for (int i = 0; i < password.Length; i++)
            {
                plainTextWithSaltBytes[i] = password[i];
            }
            for (int i = 0; i < salt.Length; i++)
            {
                plainTextWithSaltBytes[password.Length + i] = salt[i];
            }

            byte[] hashedPwd = algorithm.ComputeHash(plainTextWithSaltBytes);            
            return Convert.ToBase64String(hashedPwd);
        }

        private static string CreateSalt(int size = 64)
        {
            //Generate a cryptographic random number.
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buff = new byte[size];
            rng.GetBytes(buff);

            // Return a Base64 string representation of the random number.
            return Convert.ToBase64String(buff);
        }
    

      

    }
}