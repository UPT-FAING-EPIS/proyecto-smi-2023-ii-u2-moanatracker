using Postgrest.Attributes;
using Postgrest.Models;
namespace Moana.Models;

[Table("usuarios")]
public class User : BaseModel
{

    [Column("name")]
    public string Name { get; set; }

    [Column("email")]
    public string Email { get; set; }

    [Column("password")]
    public string Password { get; set; }

    [Column("token")]
    public string Token { get; set; }

    [Column("rolid")]
    public int rolId { get; set; }

    [Column("estadoid")]
    public int Estado { get; set; }

}