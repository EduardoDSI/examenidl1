namespace ic_tienda_bussines.Store.models {
    public class Product {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public bool State { get; set; }   
    }

    public class ProductBody {
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        public static implicit operator Product(ProductBody rb) {
            if (rb == null) return null;
            return new Product {
                Id = 0,
                Name = rb.Name,
                CategoryId = rb.CategoryId,
                Description = rb.Description,
                BrandId = rb.BrandId,
                Code = rb.Code,
                Price = rb.Price,
                Stock = rb.Stock,
                State = true,
            };
        }
    }
}