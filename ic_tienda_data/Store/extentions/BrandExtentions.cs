// using ic_tienda_bussines.Auth.models;
using ic_tienda_bussines.Store.models;
using ic_tienda_data.sources.BaseDeDatos.Tables;

namespace ic_tienda_data.Store.extentions
{
  
  public static class BrandExtentions {
    public static Brand ToModel(this MarcaTable rt) {
      return new Brand {
        Id = rt.id,
        Name = rt.nombre,
        Description = rt.descripcion
      };
    }

    public static MarcaTable ToTable(this Brand r) {
      return new MarcaTable {
        id = r.Id,
        nombre = r.Name,
        descripcion = r.Description,
        estado = true
      };
    }
  }
}