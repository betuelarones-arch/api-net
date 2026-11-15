using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace demo13.Models;

public class Curso
{
    public int IdCurso { get; set; }

    [Required, StringLength(150)]
    public string Nombre { get; set; } = string.Empty;

    [Required, StringLength(1000)]
    public string Descripcion { get; set; } = string.Empty;

    public decimal Precio { get; set; }

    public int DuracionHoras { get; set; }

    public int IdInstructor { get; set; }

    public bool Activo { get; set; } = true;

    [JsonIgnore]
    public Instructor? Instructor { get; set; }

    [JsonIgnore]
    public ICollection<Matricula> Matriculas { get; set; } = new List<Matricula>();
}
