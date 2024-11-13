using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ic_tienda_data.sources.BaseDeDatos.Tables
{
    [Table("categorias", Schema = "Tienda")]
    public class CategoriaTable
    {
        [Key]
        public int id { get; set; }
        public int? id_categoria { get; set; }
        [Required]
        public string nombre { get; set; }
        [Required]
        public string descripcion { get; set; }
        [Required]
        public bool estado { get; set; }
    }
}
