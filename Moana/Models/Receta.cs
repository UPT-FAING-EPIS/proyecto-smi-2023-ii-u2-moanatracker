using Postgrest.Attributes;
using Postgrest.Models;

namespace Moana.Models
{
    [Table("Receta")]
    public class Receta : BaseModel
    {
        [PrimaryKey("IdReceta")]
        public int IdReceta { get; set; }

        [Column("IdPaciente")]
        public int IdPaciente { get; set; }

        [Column("FechaCreacion")]
        public DateTime FechaCreacion { get; set; }

        [Column("ValidoHasta")]
        public DateTime ValidoHasta { get; set; }

        [Column("EstadoReceta")]
        public string EstadoReceta { get; set; }

        [Column("TipoAtencion")]
        public string TipoAtencion { get; set; }

        [Column("CIE10")]
        public string CIE10 { get; set; }

        [Column("Diagnostico")]
        public string Diagnostico { get; set; }

        [Column("IdMedico")]
        public int IdMedico { get; set; }

        public Medico Medico { get; set; }

        public Paciente Paciente { get; set; }
    }
}
