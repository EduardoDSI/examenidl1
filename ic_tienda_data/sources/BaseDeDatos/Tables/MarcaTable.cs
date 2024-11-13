using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ic_tienda_data.sources.BaseDeDatos.Tables
{
    [Table("marcas", Schema = "Tienda")]
    public class MarcaTable
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string nombre { get; set; }
        [Required]
        public string descripcion { get; set; }
        [Required]
        public bool estado { get; set; }
    }
}
