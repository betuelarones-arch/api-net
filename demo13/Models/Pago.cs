using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace demo13.Models;

public class Pago
{
    public int IdPago { get; set; }

    public int IdMatricula { get; set; }

    public decimal Monto { get; set; }

    public DateTime FechaPago { get; set; } = DateTime.UtcNow;

    [Required, StringLength(50)]
    public string MetodoPago { get; set; } = string.Empty;

    [Required, StringLength(50)]
    public string EstadoPago { get; set; } = string.Empty;

    [JsonIgnore]
    public Matricula? Matricula { get; set; }
}
