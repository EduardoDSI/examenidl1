using ic_tienda_bussines.Errors;
using ic_tienda_bussines.Store.models;
using ic_tienda_bussines.Store.services;
using ic_tienda_data.sources.BaseDeDatos;
using ic_tienda_data.sources.BaseDeDatos.Tables;
using ic_tienda_data.Store.extentions;

namespace  ic_tienda_data.Store.services {
    public class ProductServiceDbImpl : IProductService
    {
        private readonly IcTiendaDbContext _db;
        public ProductServiceDbImpl(IcTiendaDbContext db) {
            _db = db;
        }
        public Product Create(Product entity)
        {
            ProductoTable productoTable = entity.ToTable();
            _db.productos.Add(productoTable);
            int r = _db.SaveChanges();
            if (r == 1)
            {
                entity.Id = productoTable.id;
                return entity;
            }
            else
            {
                throw new MessageExeption("No se pudo insertar esta marca");
            }
        }

        public void Delete(int id)
        {
            ProductoTable? productoTable = _db.productos.FirstOrDefault(r => r.id == id && r.estado);
            if (productoTable == null) throw new MessageExeption("No se encontro el producto");
            //_db.roles.Remove(rolTable);
            productoTable.estado = false;
            int r = _db.SaveChanges();
            if (r == 1) return;
            else throw new MessageExeption("No se pudo eliminar el producto");
        }

        public List<Product> GetAll()
        {
            List<Product> roles = _db.productos
                .Where(r => r.estado)
                .Select<ProductoTable, Product>(
                    rt => rt.ToModel()
                ).ToList();
            return roles;
        }

        public Product? GetById(int id)
        {
            ProductoTable? marca = _db.productos
                .FirstOrDefault(r => r.id == id && r.estado);
            if (marca == null) return null;
            return marca.ToModel();
        }

        public void Update(int id, Product body)
        {
            ProductoTable? marca = _db.productos
                .FirstOrDefault(r => r.id == id && r.estado);
            if (marca == null) throw new MessageExeption("No se encontro el producto");
            marca.nombre = body.Name;
            marca.descripcion = body.Description;
            int r = _db.SaveChanges();
            if (r == 1) return;
            else throw new MessageExeption("No se pudo eliminar el producto");
        }
    }
}