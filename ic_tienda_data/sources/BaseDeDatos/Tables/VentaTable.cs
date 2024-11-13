using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ic_tienda_data.sources.BaseDeDatos.Tables
{
    [Table("ventas", Schema = "Movimientos")]
    public class VentaTable
    {
        [Key]
        public int id { get; set; }
        public int id_cliente { get; set; }
        public string tipo_comprobante { get; set; }
        public string serie_comprobante { get; set; }
        public string numero_comprobante { get; set; }
        public DateTime fecha { get; set; }
        [Precision(10, 2)]
        public decimal total { get; set; }
        [Precision(5, 2)]
        public decimal impuesto { get; set; }
        public bool estado { get; set; }
    }
}
