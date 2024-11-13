using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ic_tienda_data.sources.BaseDeDatos.Tables
{
    [Table("app_usuarios", Schema = "Security")]
    public class UsuarioTable
    {
        [Key]
        public int id { get; set; }
        public int id_persona { get; set; }
        public int id_rol { get; set; }
        [StringLength(50)]
        public string correo { get; set; }
        [StringLength(512)]
        public string clave { get; set; }
        [StringLength(128)]
        public string salt {get; set;}
        public bool estado { get; set; }

        // public RolTable rol {get; set;}
        // public PersonaTable persona { get; set; }
    }
}
