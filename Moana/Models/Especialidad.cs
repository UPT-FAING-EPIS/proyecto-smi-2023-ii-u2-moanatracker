using Postgrest.Attributes;
using Postgrest.Models;

namespace Moana.Models
{
    [Table("Especialidad")]
    public class Especialidad : BaseModel
    {
        [PrimaryKey("id")]
        public int Id { get; set; }

        [Column("nombre")]
        public string Nombre { get; set; }
    }
}
