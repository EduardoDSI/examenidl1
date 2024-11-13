using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ic_tienda_data.sources.BaseDeDatos.Tables
{
    [Table("ingreso_detalle", Schema = "Movimientos")]
    public class IngresoDetalleTable
    {
        [Key]
        public int id { get; set; }
        public int id_ingreso { get; set; }
        public int id_producto { get; set; }
        public int cantidad { get; set; }
        [Precision(10, 2)]
        public decimal costo { get; set; }
    }
}
