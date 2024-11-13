using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ic_tienda_data.sources.BaseDeDatos.Tables
{
    [Table("imagen_productos", Schema = "Tienda")]
    public class ImagenProductoTable
    {
        [Key]
        public int id { get; set; }
        public int id_producto { get; set; }
        public string url { get; set; }
        public bool estado { get; set; }
    }
}
