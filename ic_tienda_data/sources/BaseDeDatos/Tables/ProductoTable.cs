using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ic_tienda_data.sources.BaseDeDatos.Tables
{
    [Table("productos", Schema = "Tienda")]
    public class ProductoTable
    {
        [Key]
        public int id { get; set; }
        [Required]
        public int id_categoria { get; set; }
        [Required]
        public int id_marca { get; set; }
        [Required]
        public string codigo { get; set; }
        [Required]
        public string nombre { get; set; }
        [Required]
        public string descripcion { get; set; }
        [Required]
        [Precision(10, 2)]
        public decimal precio_venta { get; set; }
        [Required]
        public int stock { get; set; }
        [Required]
        public bool estado { get; set; }
    }
}
