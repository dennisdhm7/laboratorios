using PracticaCalifica_ChristianHinojosa.Models;
using System.Data.Entity;

public class ConsejeriaContext : DbContext
{
    public ConsejeriaContext() : base("ConsejeriaDB") { }

    public DbSet<Docente> Docentes { get; set; }
    public DbSet<Estudiante> Estudiantes { get; set; }
    public DbSet<Atencion> Atenciones { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
}
