namespace ic_tienda_bussines.Auth.models {

    public class UserAppProfile {
        public int Id {get; set;}
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public RolApp Rol { get; set; }
    }
}