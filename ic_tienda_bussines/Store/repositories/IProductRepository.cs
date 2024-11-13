using ic_tienda_bussines.Store.services;

namespace ic_tienda_bussines.Store.repositories {
    public interface IProductRepository {
        public IBrandService brand();
        public ICategoryService category();
        public IProductService product();
    }
}