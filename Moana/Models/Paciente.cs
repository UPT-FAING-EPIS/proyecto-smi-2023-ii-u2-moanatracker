using Postgrest.Attributes;
using Postgrest.Models;

namespace Moana.Models
{
    [Table("Paciente")]
    public class Paciente : BaseModel
    {
        [PrimaryKey("IdPaciente")]
        public int IdPaciente { get; set; }

        [Column("Nombre")]
        public string Nombre { get; set; }

        [Column("Apellido")]
        public string Apellido { get; set; }

        [Column("fkidUsuario")]
        public int FkIdUsuario { get; set; }

        [Column("CodigoSeguro")]
        public string CodigoSeguro { get; set; }

        [Column("DNI")]
        public string DNI { get; set; }

        [Column("Edad")]
        public int? Edad { get; set; }

        [Column("HistoriaClinica")]
        public string HistoriaClinica { get; set; }

        [Column("Usuario")]
        public User Usuario { get; set; }

        public string NombreCompleto => $"{Nombre} {Apellido}";
    }
}
