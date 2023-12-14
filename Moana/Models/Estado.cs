using Postgrest.Attributes;
using Postgrest.Models;

namespace Moana.Models
{
    [Table("Estado")]
    public class Estado : BaseModel
    {
        [PrimaryKey("id")]
        [Column("id")]
        public int Id { get; set; }

        [Column("nombre")]
        public string Nombre { get; set; }
    }
}
