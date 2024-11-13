using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace ic_tienda_data.sources.BaseDeDatos.Tables
{
    [Table("Citas", Schema = "Citas")]
    public class CitaTable
    {
        [Key]
        public int id { get; set; }
        [Required]
        public int id_carga_horaria { get; set; }
        [Required]
        public int id_usuario { get; set; }
        [Required]
        public TimeSpan hora_inicio { get; set; }
        [Required]
        public string estado { get; set; }
    }
}
