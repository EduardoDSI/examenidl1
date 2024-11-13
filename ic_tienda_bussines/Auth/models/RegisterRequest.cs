namespace ic_tienda_bussines.Auth.models {
    public class RegisterRequest {
        public string Email {get; set;}
        public string Password {get; set;}
        public string Name { get; set; }
        public string LastName { get; set; }
        public string DocumentType { get; set; }
        public string DocumentNumber { get; set; }
        // public string telefono { get; set; }
    }
}