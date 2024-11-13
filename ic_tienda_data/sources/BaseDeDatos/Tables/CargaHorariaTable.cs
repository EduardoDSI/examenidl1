using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace ic_tienda_data.sources.BaseDeDatos.Tables
{
    [Table("CargasHorarias", Schema = "Citas")]
    public class CargaHorariaTable
    {
        [Key]
        public int id { get; set; }
        [Required]
        public int id_operador { get; set; }
        [Required]
        public DateTime fecha { get; set; }
        [Required]
        public TimeSpan hora_inicio { get; set; }
        [Required]
        public TimeSpan hora_fin { get; set; }
    }
}
