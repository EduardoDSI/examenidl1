using ic_tienda_bussines.Auth.models;

namespace ic_tienda_bussines.Auth.services {

    public interface IAuthenticationService {
        public LoginResponse Login(LoginRequest login);
        public void Register(RegisterRequest data);
    }
}