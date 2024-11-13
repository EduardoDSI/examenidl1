using ic_tienda_bussines.Errors;
using ic_tienda_bussines.Store.models;
using ic_tienda_bussines.Store.services;
using ic_tienda_data.sources.BaseDeDatos;
using ic_tienda_data.sources.BaseDeDatos.Tables;
using ic_tienda_data.Store.extentions;


namespace  ic_tienda_data.Store.services {
    public class BrandServiceDbImpl : IBrandService
    {
        private readonly IcTiendaDbContext _db;
        public BrandServiceDbImpl(IcTiendaDbContext db) {
            _db = db;
        }
        public Brand Create(Brand entity)
        {
            MarcaTable marcaTable = entity.ToTable();
            _db.marcas.Add(marcaTable);
            int r = _db.SaveChanges();
            if (r == 1)
            {
                entity.Id = marcaTable.id;
                return entity;
            }
            else
            {
                throw new MessageExeption("No se pudo insertar esta marca");
            }
        }

        public void Delete(int id)
        {
            MarcaTable? marcaTable = _db.marcas.FirstOrDefault(r => r.id == id && r.estado);
            if (marcaTable == null) throw new MessageExeption("No se encontro la marca");
            //_db.roles.Remove(rolTable);
            marcaTable.estado = false;
            int r = _db.SaveChanges();
            if (r == 1) return;
            else throw new MessageExeption("No se pudo eliminar la marca");
        }

        public List<Brand> GetAll()
        {
            List<Brand> roles = _db.marcas
                .Where(r => r.estado)
                .Select<MarcaTable, Brand>(
                    rt => rt.ToModel()
                ).ToList();
            return roles;
        }

        public Brand? GetById(int id)
        {
            MarcaTable? marca = _db.marcas
                .FirstOrDefault(r => r.id == id && r.estado);
            if (marca == null) return null;
            return marca.ToModel();
        }

        public void Update(int id, Brand body)
        {
            MarcaTable? marca = _db.marcas
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