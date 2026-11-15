using demo13.Data;
using demo13.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace demo13.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EstudiantesController(AcademiaContext context) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Estudiante>>> GetEstudiantes()
    {
        return await context.Estudiantes.AsNoTracking().ToListAsync();
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Estudiante>> GetEstudiante(int id)
    {
        var estudiante = await context.Estudiantes
            .AsNoTracking()
            .FirstOrDefaultAsync(item => item.IdEstudiante == id);
        return estudiante is null ? NotFound() : estudiante;
    }

    [HttpPost]
    public async Task<ActionResult<Estudiante>> PostEstudiante(Estudiante estudiante)
    {
        context.Estudiantes.Add(estudiante);
        await context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetEstudiante), new { id = estudiante.IdEstudiante }, estudiante);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutEstudiante(int id, Estudiante estudiante)
    {
        if (id != estudiante.IdEstudiante)
        {
            return BadRequest("El ID de la ruta no coincide con el ID del estudiante.");
        }

        if (!await context.Estudiantes.AnyAsync(item => item.IdEstudiante == id))
        {
            return NotFound();
        }

        context.Entry(estudiante).State = EntityState.Modified;
        await context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteEstudiante(int id)
    {
        var estudiante = await context.Estudiantes.FindAsync(id);
        if (estudiante is null)
        {
            return NotFound();
        }

        if (await context.Matriculas.AnyAsync(matricula => matricula.IdEstudiante == id))
        {
            return Conflict("No se puede eliminar el estudiante porque tiene matrículas asociadas.");
        }

        context.Estudiantes.Remove(estudiante);
        await context.SaveChangesAsync();
        return NoContent();
    }
}
