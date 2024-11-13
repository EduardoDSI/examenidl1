using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ic_tienda_data.sources.BaseDeDatos.Tables
{
    [Table("app_operadores", Schema = "Citas")]
    public class OperadorTable
    {
        [Key]
        public int id { get; set; }
        public int id_persona { get; set; }
        [StringLength(50)]
        public string correo { get; set; }
        [StringLength(15)]
        public string telefono { get; set; }
        // public RolTable rol {get; set;}
        // public PersonaTable persona { get; set; }
    }
}
