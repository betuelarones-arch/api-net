using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace demo13.Models;

public class Matricula
{
    public int IdMatricula { get; set; }

    public int IdEstudiante { get; set; }

    public int IdCurso { get; set; }

    public DateTime FechaMatricula { get; set; } = DateTime.UtcNow;

    [Required, StringLength(50)]
    public string Estado { get; set; } = string.Empty;

    public decimal MontoTotal { get; set; }

    [JsonIgnore]
    public Estudiante? Estudiante { get; set; }

    [JsonIgnore]
    public Curso? Curso { get; set; }

    [JsonIgnore]
    public ICollection<Pago> Pagos { get; set; } = new List<Pago>();
}
