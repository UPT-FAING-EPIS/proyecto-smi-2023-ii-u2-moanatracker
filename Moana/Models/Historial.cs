using Postgrest.Attributes;
using Postgrest.Models;

namespace Moana.Models
{
    [Table("Historial")]
    public class Historial : BaseModel
    {
        [PrimaryKey("IdHistorial")]
        public int IdHistorial { get; set; }

        [Column("IdDetalleReceta")]
        public int IdDetalleReceta { get; set; }

        [Column("IdUsuario")]
        public int IdUsuario { get; set; }

        [Column("FechaToma")]
        public DateTime? FechaToma { get; set; }

        [Column("DetalleReceta")]
        public DetalleReceta DetalleReceta { get; set; }
    }
}
