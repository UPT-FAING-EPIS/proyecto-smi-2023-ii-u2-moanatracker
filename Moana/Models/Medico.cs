using Postgrest.Attributes;
using Postgrest.Models;

namespace Moana.Models
{
    [Table("Medico")]
    public class Medico : BaseModel
    {
        [PrimaryKey("IdMedico")]
        public int IdMedico { get; set; }

        [Column("Nombre")]
        public string Nombre { get; set; }

        [Column("Apellido")]
        public string Apellido { get; set; }

        [Column("Direccion")]
        public string Direccion { get; set; }

        [Column("Contacto")]
        public string Contacto { get; set; }

        [Column("FkIdEspecialidad")]
        public int FkIdEspecialidad { get; set; }

        [Column("FkIdUsuario")]
        public int? FkIdUsuario { get; set; }

        [Column("Especialidad")]
        public Especialidad Especialidad { get; set; }

        [Column("Usuario")]
        public User Usuario { get; set; }
    }
}
