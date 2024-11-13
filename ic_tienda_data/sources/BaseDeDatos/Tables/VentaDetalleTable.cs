using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ic_tienda_data.sources.BaseDeDatos.Tables
{
    [Table("ventas_detalle", Schema = "Movimientos")]
    public class VentaDetalleTable
    {
        [Key]
        public int id { get; set; }
        public int id_venta { get; set; }
        public int id_producto { get; set; }
        public int? id_oferta { get; set; }
        public int cantidad { get; set; }
        [Precision(10, 2)]
        public decimal precio { get; set; }
        [Precision(5, 2)]
        public decimal descuento { get; set; }
    }
}
