namespace ic_tienda_bussines.Store.models {
    public class Category {
        public int Id { get; set; }
        public int? CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool State { get; set; }   
    }

    public class CategoryBody {
        public int? CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public static implicit operator Category(CategoryBody rb) {
            if (rb == null) return null;
            return new Category {
                Id = 0,
                Name = rb.Name,
                CategoryId = rb.CategoryId,
                Description = rb.Description
            };
        }
    }
}