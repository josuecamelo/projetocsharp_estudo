using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebEscola.Models;

namespace WebEscola.Data
{
    public class Seed
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new WebEscolaContext(
                    serviceProvider.GetRequiredService<
                    DbContextOptions<WebEscolaContext>>()))
            {
                context.Database.EnsureCreated();

                if (context.Aluno.Any())
                {
                    return;
                }

                var Alunos = new Aluno[]
                {
                    new Aluno{Nome="Alberto",Sobrenome="Almeida",Data=DateTime.Parse("1970-09-21")},
                    new Aluno{Nome="Marcelo",Sobrenome="Barros",Data=DateTime.Parse("2001-04-07")},
                    new Aluno{Nome="Henrique",Sobrenome="Carvalho",Data=DateTime.Parse("1994-12-10")},
                    new Aluno{Nome="Daniel",Sobrenome="Freitas",Data=DateTime.Parse("1974-02-01")},
                    new Aluno{Nome="Fábio",Sobrenome="Henrique",Data=DateTime.Parse("1978-07-10")},
                    new Aluno{Nome="Fernanda",Sobrenome="Machado",Data=DateTime.Parse("1994-12-15")},
                    new Aluno{Nome="Cristina",Sobrenome="Miranda",Data=DateTime.Parse("2003-09-01")},
                    new Aluno{Nome="Roberto",Sobrenome="Santos",Data=DateTime.Parse("1998-03-17")}
                };
                foreach (Aluno s in Alunos)
                {
                    context.Aluno.Add(s);
                }

                context.SaveChanges();

                var Cursos = new Curso[]
                {
                    new Curso{Titulo="Blazor Avançado",Credito=4},
                    new Curso{Titulo="Blazor",Credito=3},
                    new Curso{Titulo="ASP NET Core - API e SignalR",Credito=4},
                    new Curso{Titulo="ASP NET Core MVC Avançado",Credito=4},
                    new Curso{Titulo="ASP NET Core MVC",Credito=3},
                    new Curso{Titulo="ASP NET Core",Credito=2},
                    new Curso{Titulo="C# básico",Credito=1}
                };

                foreach (Curso c in Cursos)
                {
                    context.Curso.Add(c);
                }

                context.SaveChanges();

                var Matriculas = new Matricula[]
                {
                    new Matricula{AlunoID=1,CursoID=1},
                    new Matricula{AlunoID=1,CursoID=2},
                    new Matricula{AlunoID=1,CursoID=3},
                    new Matricula{AlunoID=2,CursoID=2},
                    new Matricula{AlunoID=2,CursoID=3},
                    new Matricula{AlunoID=2,CursoID=6},
                    new Matricula{AlunoID=3,CursoID=2},
                    new Matricula{AlunoID=3,CursoID=3},
                    new Matricula{AlunoID=3,CursoID=4},
                    new Matricula{AlunoID=3,CursoID=5},
                    new Matricula{AlunoID=4,CursoID=6},
                    new Matricula{AlunoID=4,CursoID=7},
                    new Matricula{AlunoID=5,CursoID=3},
                    new Matricula{AlunoID=6,CursoID=4},
                    new Matricula{AlunoID=7,CursoID=2},
                };

                foreach (Matricula e in Matriculas)
                {
                    context.Matricula.Add(e);
                }

                context.SaveChanges();
            }
        }
    }
}
