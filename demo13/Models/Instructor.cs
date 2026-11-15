using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace demo13.Models;

public class Instructor
{
    public int IdInstructor { get; set; }

    [Required, StringLength(100)]
    public string Nombres { get; set; } = string.Empty;

    [Required, StringLength(100)]
    public string Apellidos { get; set; } = string.Empty;

    [Required, StringLength(100)]
    public string Especialidad { get; set; } = string.Empty;

    [Required, EmailAddress, StringLength(256)]
    public string Email { get; set; } = string.Empty;

    public bool Activo { get; set; } = true;

    [JsonIgnore]
    public ICollection<Curso> Cursos { get; set; } = new List<Curso>();
}
