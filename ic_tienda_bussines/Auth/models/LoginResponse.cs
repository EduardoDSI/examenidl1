namespace ic_tienda_bussines.Auth.models {
    public class LoginResponse {
        public string token {get; set;}
        public UserAppProfile profile {get; set;}
    }
}