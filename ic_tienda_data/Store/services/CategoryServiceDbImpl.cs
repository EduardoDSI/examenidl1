using ic_tienda_bussines.Errors;
using ic_tienda_bussines.Store.models;
using ic_tienda_bussines.Store.services;
using ic_tienda_data.sources.BaseDeDatos;
using ic_tienda_data.sources.BaseDeDatos.Tables;
using ic_tienda_data.Store.extentions;

namespace  ic_tienda_data.Store.services {
    public class CategoryServiceDbImpl : ICategoryService
    {
        private readonly IcTiendaDbContext _db;
        public CategoryServiceDbImpl(IcTiendaDbContext db) {
            _db = db;
        }
        public Category Create(Category entity)
        {
            CategoriaTable categoriaTable = entity.ToTable();
            _db.categorias.Add(categoriaTable);
            int r = _db.SaveChanges();
            if (r == 1)
            {
                entity.Id = categoriaTable.id;
                return entity;
            }
            else
            {
                throw new MessageExeption("No se pudo insertar esta marca");
            }
        }

        public void Delete(int id)
        {
            CategoriaTable? categoriaTable = _db.categorias.FirstOrDefault(r => r.id == id && r.estado);
            if (categoriaTable == null) throw new MessageExeption("No se encontro la marca");
            //_db.roles.Remove(rolTable);
            categoriaTable.estado = false;
            int r = _db.SaveChanges();
            if (r == 1) return;
            else throw new MessageExeption("No se pudo eliminar la marca");
        }

        public List<Category> GetAll()
        {
            List<Category> roles = _db.categorias
                .Where(r => r.estado)
                .Select<CategoriaTable, Category>(
                    rt => rt.ToModel()
                ).ToList();
            return roles;
        }

        public Category? GetById(int id)
        {
            CategoriaTable? marca = _db.categorias
                .FirstOrDefault(r => r.id == id && r.estado);
            if (marca == null) return null;
            return marca.ToModel();
        }

        public void Update(int id, Category body)
        {
            CategoriaTable? marca = _db.categorias
                .FirstOrDefault(r => r.id == id && r.estado);
            if (marca == null) throw new MessageExeption("No se encontro la marca");
            marca.nombre = body.Name;
            marca.descripcion = body.Description;
            int r = _db.SaveChanges();
            if (r == 1) return;
            else throw new MessageExeption("No se pudo eliminar la marca");
        }
    }
}