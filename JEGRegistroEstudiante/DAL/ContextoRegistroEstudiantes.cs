using JEGRegistroEstudiante.Models;
using Microsoft.EntityFrameworkCore;


namespace JEGRegistroEstudiante.DAL
{
    public class ContextoRegistroEstudiantes : DbContext
    {
        public ContextoRegistroEstudiantes(DbContextOptions<ContextoRegistroEstudiantes> options) : base(options)
        {

        }
        public DbSet<Estudiantes> Estudiantes { get; set; }
        public DbSet<Asignaturas> Asignaturas { get; set; }

    }
}
