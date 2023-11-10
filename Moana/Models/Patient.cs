using Postgrest.Attributes;
using Postgrest.Models;
namespace Moana.Models;


[Table("Paciente")]

public class Paciente : BaseModel
{
    [PrimaryKey("id")]
    public int Id { get; set; }

    [Column("nombre")]
    public string nombre { get; set; }
    
    [Column("apellido")]
    public string apellido { get; set; }

    [Column("fkidUsuario")]
    public string fkidUsuario { get; set; }

}
