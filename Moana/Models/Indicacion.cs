using Postgrest.Attributes;
using Postgrest.Models;

namespace Moana.Models
{
    [Table("Indicacion")]
    public class Indicacion : BaseModel
    {
        [PrimaryKey("IdIndicacion")]
        public int IdIndicacion { get; set; }

        [Column("IdDetalleReceta")]
        public int IdDetalleReceta { get; set; }

        [Column("Dosis")]
        public string Dosis { get; set; }

        [Column("Via")]
        public string Via { get; set; }

        [Column("Frecuencia")]
        public int Frecuencia { get; set; }

        [Column("TiempoFrecuencia")]
        public string TiempoFrecuencia { get; set; }

        [Column("Duracion")]
        public int Duracion { get; set; }

        [Column("TiempoDuracion")]
        public string TiempoDuracion { get; set; }

        [Column("ComentarioMedico")]
        public string ComentarioMedico { get; set; }
    }
}
