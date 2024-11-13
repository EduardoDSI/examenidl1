using ic_tienda_bussines.Store.repositories;
using ic_tienda_bussines.Store.services;

namespace ic_tienda_data.Store.repositories {
    public class ProductRepositryImpl : IProductRepository
    {
        private readonly IBrandService _brand;
        private readonly ICategoryService _category;
        private readonly IProductService _product;
        private readonly ICargaHorariaService _product;
        private readonly IProductService _product;
        public ProductRepositryImpl(
            IBrandService brand
            , ICategoryService category
            , IProductService product
            
        ) {
            _brand = brand;
            _category = category;
            _product = product;
        }

        public IBrandService brand()
        {
            return _brand;
        }

        public ICategoryService category()
        {
            return _category;
        }

        public IProductService product()
        {
            return _product;
        }
        public ICargaHorariaService product()
        {
            return _cargahoraria;
        }
        public ICitaService product()
        {
            return _cita;
        }
    }
}