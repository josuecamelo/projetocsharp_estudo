using System.Collections.Generic;

namespace WebEscola.Models.ViewModels
{
    public class InstrutorIndexData
    {
        public IEnumerable<Instrutor> Instrutores { get; set; }
        public IEnumerable<Curso> Cursos { get; set; }
        public IEnumerable<Matricula> Matriculas { get; set; }
    }
}