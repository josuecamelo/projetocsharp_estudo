using Microsoft.EntityFrameworkCore;

using Microsoft.Extensions.DependencyInjection;

using System;

using System.Linq;

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


                var alunos = new Aluno[]

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

                foreach (Aluno a in alunos)

                {

                    context.Aluno.Add(a);

                }

                context.SaveChanges();


                var instrutores = new Instrutor[]

                {

                    new Instrutor{Nome="João",Sobrenome="Miguel",Contratacao=DateTime.Parse("2015-02-5")},

                    new Instrutor{Nome="Maria",Sobrenome="Cecilia",Contratacao=DateTime.Parse("2017-03-10")},

                    new Instrutor{Nome="Ana",Sobrenome="Julia",Contratacao=DateTime.Parse("2013-4-15")},

                    new Instrutor{Nome="Davi",Sobrenome="Lucas",Contratacao=DateTime.Parse("2019-05-20")},

                    new Instrutor{Nome="Laura",Sobrenome="Neves",Contratacao=DateTime.Parse("2020-01-25")}

                };

                foreach (Instrutor i in instrutores)

                {

                    context.Instrutor.Add(i);

                }

                context.SaveChanges();


                var departamentos = new Departamento[]

                {

                    new Departamento{Nome="Treinamento", Orcamento=100000,  Inicio=DateTime.Parse("1993-09-25"),

                        InstrutorID  = instrutores.Single( i => i.Sobrenome == "Julia").InstrutorID},

                    new Departamento{Nome="Desenvolvimento", Orcamento=250000,  Inicio=DateTime.Parse("1993-09-25"),

                        InstrutorID  = instrutores.Single( i => i.Sobrenome == "Neves").InstrutorID},

                    new Departamento{Nome="Consultoria", Orcamento=50000,  Inicio=DateTime.Parse("1993-09-25"),

                        InstrutorID  = instrutores.Single( i => i.Sobrenome == "Lucas").InstrutorID}

                };

                foreach (Departamento d in departamentos)

                {

                    context.Departamento.Add(d);

                }

                context.SaveChanges();


                var cursos = new Curso[]

                {

                    new Curso{Titulo="Blazor Avançado",Credito=4,

                        DepartamentoID=departamentos.Single(s => s.Nome == "Consultoria").DepartamentoID},

                    new Curso{Titulo="Blazor",Credito=3,

                        DepartamentoID=departamentos.Single(s => s.Nome == "Consultoria").DepartamentoID},

                    new Curso{Titulo="ASP NET Core - API e SignalR",Credito=4,

                        DepartamentoID=departamentos.Single(s => s.Nome == "Consultoria").DepartamentoID},

                    new Curso{Titulo="ASP NET Core MVC Avançado",Credito=4,

                        DepartamentoID=departamentos.Single(s => s.Nome == "Desenvolvimento").DepartamentoID},

                    new Curso{Titulo="ASP NET Core MVC",Credito=3,

                        DepartamentoID=departamentos.Single(s => s.Nome == "Treinamento").DepartamentoID},

                    new Curso{Titulo="ASP NET Core",Credito=2,

                        DepartamentoID=departamentos.Single(s => s.Nome == "Treinamento").DepartamentoID},

                    new Curso{Titulo="C# básico",Credito=1,

                        DepartamentoID=departamentos.Single(s => s.Nome == "Treinamento").DepartamentoID}

                };

                foreach (Curso c in cursos)

                {

                    context.Curso.Add(c);

                }

                context.SaveChanges();


                var escritorios = new Escritorio[]

                {

                new Escritorio {

                    InstrutorID = instrutores.Single( i => i.Sobrenome == "Julia").InstrutorID,

Localizacao = "Paulista" },

                new Escritorio {

                    InstrutorID = instrutores.Single( i => i.Sobrenome == "Neves").InstrutorID,

Localizacao = "Berrini" },

                new Escritorio {

                    InstrutorID = instrutores.Single( i => i.Sobrenome == "Lucas").InstrutorID,

Localizacao = "Faria Lima" }

                };


                foreach (Escritorio e in escritorios)

                {

                    context.Escritorio.Add(e);

                }

                context.SaveChanges();


                var cursosInstrutor = new CursoInstrutor[]

                 {

                new CursoInstrutor {

                    InstrutorID = instrutores.Single( i => i.Sobrenome == "Miguel").InstrutorID,

                    CursoID = cursos.Single( i => i.Titulo == "C# básico").CursoID },

                new CursoInstrutor {

                    InstrutorID = instrutores.Single( i => i.Sobrenome == "Cecilia").InstrutorID,

                    CursoID = cursos.Single( i => i.Titulo == "ASP NET Core").CursoID },

                new CursoInstrutor {

                    InstrutorID = instrutores.Single( i => i.Sobrenome == "Cecilia").InstrutorID,

                    CursoID = cursos.Single( i => i.Titulo == "ASP NET Core MVC").CursoID },

                new CursoInstrutor {

                    InstrutorID = instrutores.Single( i => i.Sobrenome == "Cecilia").InstrutorID,

                    CursoID = cursos.Single( i => i.Titulo == "ASP NET Core MVC Avançado").CursoID },

                new CursoInstrutor {

                    InstrutorID = instrutores.Single( i => i.Sobrenome == "Julia").InstrutorID,

                    CursoID = cursos.Single( i => i.Titulo == "ASP NET Core - API e SignalR").CursoID },

                new CursoInstrutor {

                    InstrutorID = instrutores.Single( i => i.Sobrenome == "Lucas").InstrutorID,

                    CursoID = cursos.Single( i => i.Titulo == "Blazor").CursoID },

                new CursoInstrutor {

                    InstrutorID = instrutores.Single( i => i.Sobrenome == "Lucas").InstrutorID,

                    CursoID = cursos.Single( i => i.Titulo == "Blazor Avançado").CursoID }

                  };

                foreach (CursoInstrutor ci in cursosInstrutor)

                {

                    context.CursoInstrutor.Add(ci);

                }

                context.SaveChanges();


                var matriculas = new Matricula[]

                {

                    new Matricula {

                    AlunoID = alunos.Single(i => i.Sobrenome == "Almeida").AlunoID,

                        CursoID = cursos.Single(c => c.Titulo == "C# básico" ).CursoID},

                    new Matricula {

                    AlunoID = alunos.Single(i => i.Sobrenome == "Almeida").AlunoID,

                        CursoID = cursos.Single(c => c.Titulo == "ASP NET Core" ).CursoID},

                    new Matricula {

                    AlunoID = alunos.Single(i => i.Sobrenome == "Almeida").AlunoID,

                        CursoID = cursos.Single(c => c.Titulo == "ASP NET Core MVC" ).CursoID},

                    new Matricula {

                    AlunoID = alunos.Single(i => i.Sobrenome == "Barros").AlunoID,

                        CursoID = cursos.Single(c => c.Titulo == "ASP NET Core" ).CursoID},

                    new Matricula {

                    AlunoID = alunos.Single(i => i.Sobrenome == "Barros").AlunoID,

                        CursoID = cursos.Single(c => c.Titulo == "ASP NET Core MVC" ).CursoID},

                    new Matricula {

                    AlunoID = alunos.Single(i => i.Sobrenome == "Barros").AlunoID,

                        CursoID = cursos.Single(c => c.Titulo == "Blazor" ).CursoID},

                    new Matricula {

                    AlunoID = alunos.Single(i => i.Sobrenome == "Carvalho").AlunoID,

                        CursoID = cursos.Single(c => c.Titulo == "ASP NET Core" ).CursoID},

                    new Matricula {

                    AlunoID = alunos.Single(i => i.Sobrenome == "Carvalho").AlunoID,

                        CursoID = cursos.Single(c => c.Titulo == "ASP NET Core MVC" ).CursoID},

                    new Matricula {

                    AlunoID = alunos.Single(i => i.Sobrenome == "Carvalho").AlunoID,

                        CursoID = cursos.Single(c => c.Titulo == "ASP NET Core MVC Avançado" ).CursoID

                    },

                    new Matricula {

                    AlunoID = alunos.Single(i => i.Sobrenome == "Carvalho").AlunoID,

                        CursoID = cursos.Single(c => c.Titulo == "ASP NET Core - API e SignalR" ).CursoID},

                    new Matricula {

                    AlunoID = alunos.Single(i => i.Sobrenome == "Freitas").AlunoID,

                        CursoID = cursos.Single(c => c.Titulo == "Blazor" ).CursoID},

                    new Matricula {

                    AlunoID = alunos.Single(i => i.Sobrenome == "Freitas").AlunoID,

                        CursoID = cursos.Single(c => c.Titulo == "Blazor Avançado" ).CursoID},

                    new Matricula {

                    AlunoID = alunos.Single(i => i.Sobrenome == "Henrique").AlunoID,

                        CursoID = cursos.Single(c => c.Titulo == "ASP NET Core MVC" ).CursoID},

                    new Matricula {

                    AlunoID = alunos.Single(i => i.Sobrenome == "Machado").AlunoID,

                        CursoID = cursos.Single(c => c.Titulo == "ASP NET Core MVC Avançado" ).CursoID},

                    new Matricula {

                    AlunoID = alunos.Single(i => i.Sobrenome == "Miranda").AlunoID,

                        CursoID = cursos.Single(c => c.Titulo == "ASP NET Core" ).CursoID},


                };

                foreach (Matricula m in matriculas)

                {

                    context.Matricula.Add(m);

                }

                context.SaveChanges();

            }

        }

    }

}
