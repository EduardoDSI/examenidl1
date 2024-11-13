// using ic_tienda_bussines.Auth.models;
using ic_tienda_bussines.Store.models;
using ic_tienda_data.sources.BaseDeDatos.Tables;

namespace ic_tienda_data.Store.extentions
{
  
  public static class CategoryExtentions {
    public static Category ToModel(this CategoriaTable rt) {
      return new Category {
        Id = rt.id,
        CategoryId = rt.id_categoria,
        Name = rt.nombre,
        Description = rt.descripcion
      };
    }

    public static CategoriaTable ToTable(this Category r) {
      return new CategoriaTable {
        id = r.Id,
        id_categoria = r.CategoryId,
        nombre = r.Name,
        descripcion = r.Description,
        estado = true
      };
    }
  }
}