using Postgrest.Attributes;
using Postgrest.Models;
namespace Moana.Models;


[Table("Prescripcion")]

public class Prescripcion : BaseModel
{
    [PrimaryKey("id")]
    public int Id { get; set; }

    [Column("Fecha_inicio")]
    public string Fecha_inicio { get; set; }
    
    [Column("Fecha_fin")]
    public string Fecha_fin { get; set; }

    [Column("fkIdMedico")]
    public string fkIdMedico { get; set; }

    [Column("fkIdPaciente")]
    public string fkIdPaciente { get; set; }

}
