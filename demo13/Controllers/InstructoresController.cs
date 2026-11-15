using demo13.Data;
using demo13.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace demo13.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InstructoresController(AcademiaContext context) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Instructor>>> GetInstructores()
    {
        return await context.Instructores.AsNoTracking().ToListAsync();
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Instructor>> GetInstructor(int id)
    {
        var instructor = await context.Instructores
            .AsNoTracking()
            .FirstOrDefaultAsync(item => item.IdInstructor == id);
        return instructor is null ? NotFound() : instructor;
    }

    [HttpPost]
    public async Task<ActionResult<Instructor>> PostInstructor(Instructor instructor)
    {
        context.Instructores.Add(instructor);
        await context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetInstructor), new { id = instructor.IdInstructor }, instructor);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutInstructor(int id, Instructor instructor)
    {
        if (id != instructor.IdInstructor)
        {
            return BadRequest("El ID de la ruta no coincide con el ID del instructor.");
        }

        if (!await context.Instructores.AnyAsync(item => item.IdInstructor == id))
        {
            return NotFound();
        }

        context.Entry(instructor).State = EntityState.Modified;
        await context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteInstructor(int id)
    {
        var instructor = await context.Instructores.FindAsync(id);
        if (instructor is null)
        {
            return NotFound();
        }

        if (await context.Cursos.AnyAsync(curso => curso.IdInstructor == id))
        {
            return Conflict("No se puede eliminar el instructor porque tiene cursos asociados.");
        }

        context.Instructores.Remove(instructor);
        await context.SaveChangesAsync();
        return NoContent();
    }
}
