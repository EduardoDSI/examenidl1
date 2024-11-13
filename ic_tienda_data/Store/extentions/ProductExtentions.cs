// using ic_tienda_bussines.Auth.models;
using ic_tienda_bussines.Store.models;
using ic_tienda_data.sources.BaseDeDatos.Tables;

namespace ic_tienda_data.Store.extentions
{
  
  public static class ProductExtentions {
    public static Product ToModel(this ProductoTable rt) {
      return new Product {
        Id = rt.id,
        Name = rt.nombre,
        Description = rt.descripcion,
        CategoryId = rt.id_categoria,
        BrandId = rt.id_marca,
        Code = rt.codigo,
        Price = rt.precio_venta,
        Stock = rt.stock,
        State = true
      };
    }

    public static ProductoTable ToTable(this Product r) {
      return new ProductoTable {
        id = r.Id,
        nombre = r.Name,
        descripcion = r.Description,
        id_categoria = r.CategoryId,
        id_marca = r.BrandId,
        codigo = r.Code,
        precio_venta = r.Price,
        stock = r.Stock,
        estado = true
      };
    }
  }
}