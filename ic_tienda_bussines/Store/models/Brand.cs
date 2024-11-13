namespace ic_tienda_bussines.Store.models {
    public class Brand {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool State { get; set; }   
    }

    public class BrandBody {
        public string Name { get; set; }
        public string Description { get; set; }

        public static implicit operator Brand(BrandBody rb) {
            if (rb == null) return null;
            return new Brand {
                Id = 0,
                Name = rb.Name,
                Description = rb.Description
            };
        }
    }
}