using Postgrest.Attributes;
using Postgrest.Models;
namespace Moana.Models;


[Table("Medico")]

public class Medico : BaseModel
{
    [PrimaryKey("id")]
    public int Id { get; set; }

    [Column("nombre")]
    public string nombre { get; set; }
    
    [Column("apellido")]
    public string apellido { get; set; }

    [Column("Direccion")]
    public string Direccion { get; set; }

    [Column("Contacto")]
    public string Contacto { get; set; }

    [Column("FkIdEspecialidad")]
    public string FkIdEspecialidad { get; set; }

    [Column("FkIdUsuario")]
    public string FkIdUsuario { get; set; }

}
