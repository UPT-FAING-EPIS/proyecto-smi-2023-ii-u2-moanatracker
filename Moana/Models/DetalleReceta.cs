using Postgrest.Attributes;
using Postgrest.Models;

namespace Moana.Models
{
    [Table("DetalleReceta")]
    public class DetalleReceta : BaseModel
    {
        [PrimaryKey("IdDetalleReceta")]
        public int IdDetalleReceta { get; set; }

        [Column("IdReceta")]
        public int IdReceta { get; set; }

        [Column("ProductoFarmaceutico")]
        public string ProductoFarmaceutico { get; set; }

        [Column("Concentracion")]
        public string Concentracion { get; set; }

        [Column("FormaFarmaceutica")]
        public string FormaFarmaceutica { get; set; }

        [Column("Cantidad")]
        public string Cantidad { get; set; }
    }
}
