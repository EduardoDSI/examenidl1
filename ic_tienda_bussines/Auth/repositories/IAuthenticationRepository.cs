using ic_tienda_bussines.Auth.models;

namespace ic_tienda_bussines.Auth.repositories {

    public interface IAuthenticationRepository {
        public LoginResponse Login(LoginRequest login);

        public void Register(RegisterRequest data);
    }
}