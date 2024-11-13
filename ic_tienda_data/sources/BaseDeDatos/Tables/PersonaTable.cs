using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ic_tienda_data.sources.BaseDeDatos.Tables
{
    [Table("personas", Schema = "Security")]
    public class PersonaTable
    {
        [Key]
        public int id { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string tipo_documento { get; set; }
        public string numero_documento { get; set; }
        public string telefono { get; set; }
        public bool estado { get; set; }

        //public UsuarioTable? usuario { get; set;}
    }
}
