using Microsoft.EntityFrameworkCore;

namespace WebEscola.Data
{
    public class WebEscolaContext : DbContext
    {
        public WebEscolaContext (DbContextOptions<WebEscolaContext> options)
            : base(options)
        {
        }

        public DbSet<WebEscola.Models.Aluno> Aluno { get; set; }
        public DbSet<WebEscola.Models.Curso> Curso { get; set; }
        public DbSet<WebEscola.Models.Matricula> Matricula { get; set; }
        public DbSet<WebEscola.Models.CursoInstrutor> CursoInstrutor { get; set; }
        public DbSet<WebEscola.Models.Departamento> Departamento { get; set; }
        public DbSet<WebEscola.Models.Escritorio> Escritorio { get; set; }
        public DbSet<WebEscola.Models.Instrutor> Instrutor { get; set; }
    }
}
