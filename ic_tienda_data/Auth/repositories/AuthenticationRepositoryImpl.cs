using ic_tienda_bussines.Auth.models;
using ic_tienda_bussines.Auth.repositories;
using ic_tienda_bussines.Auth.services;

namespace ic_tienda_data.Auth.repositories {
    public class AuthenticationRepositoryImpl : IAuthenticationRepository
    {
        
        private readonly IAuthenticationService _authService;
        
        public AuthenticationRepositoryImpl(IAuthenticationService authService) {
            _authService = authService;
        }

        public LoginResponse Login(LoginRequest login)
        {
            return _authService.Login(login);
        }

        public void Register(RegisterRequest data)
        {
             _authService.Register(data);
        }
    }
}