using demo13.Models;
using Microsoft.EntityFrameworkCore;

namespace demo13.Data;

public class AcademiaContext(DbContextOptions<AcademiaContext> options) : DbContext(options)
{
    public DbSet<Instructor> Instructores => Set<Instructor>();
    public DbSet<Estudiante> Estudiantes => Set<Estudiante>();
    public DbSet<Curso> Cursos => Set<Curso>();
    public DbSet<Matricula> Matriculas => Set<Matricula>();
    public DbSet<Pago> Pagos => Set<Pago>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Instructor>().HasKey(instructor => instructor.IdInstructor);
        modelBuilder.Entity<Estudiante>().HasKey(estudiante => estudiante.IdEstudiante);
        modelBuilder.Entity<Curso>().HasKey(curso => curso.IdCurso);
        modelBuilder.Entity<Matricula>().HasKey(matricula => matricula.IdMatricula);
        modelBuilder.Entity<Pago>().HasKey(pago => pago.IdPago);

        modelBuilder.Entity<Instructor>()
            .HasIndex(instructor => instructor.Email)
            .IsUnique();
        modelBuilder.Entity<Estudiante>()
            .HasIndex(estudiante => estudiante.Email)
            .IsUnique();
        modelBuilder.Entity<Curso>()
            .Property(curso => curso.Precio)
            .HasPrecision(10, 2);
        modelBuilder.Entity<Matricula>()
            .Property(matricula => matricula.MontoTotal)
            .HasPrecision(10, 2);
        modelBuilder.Entity<Pago>()
            .Property(pago => pago.Monto)
            .HasPrecision(10, 2);

        modelBuilder.Entity<Instructor>()
            .HasMany(instructor => instructor.Cursos)
            .WithOne(curso => curso.Instructor)
            .HasForeignKey(curso => curso.IdInstructor)
            .OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<Estudiante>()
            .HasMany(estudiante => estudiante.Matriculas)
            .WithOne(matricula => matricula.Estudiante)
            .HasForeignKey(matricula => matricula.IdEstudiante)
            .OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<Curso>()
            .HasMany(curso => curso.Matriculas)
            .WithOne(matricula => matricula.Curso)
            .HasForeignKey(matricula => matricula.IdCurso)
            .OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<Matricula>()
            .HasMany(matricula => matricula.Pagos)
            .WithOne(pago => pago.Matricula)
            .HasForeignKey(pago => pago.IdMatricula)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
