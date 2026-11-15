using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace demo13.Models;

public class Estudiante
{
    public int IdEstudiante { get; set; }

    [Required, StringLength(100)]
    public string Nombres { get; set; } = string.Empty;

    [Required, StringLength(100)]
    public string Apellidos { get; set; } = string.Empty;

    [Required, EmailAddress, StringLength(256)]
    public string Email { get; set; } = string.Empty;

    [Required, StringLength(30)]
    public string Telefono { get; set; } = string.Empty;

    public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;

    public bool Activo { get; set; } = true;

    [JsonIgnore]
    public ICollection<Matricula> Matriculas { get; set; } = new List<Matricula>();
}
