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
    }
}
