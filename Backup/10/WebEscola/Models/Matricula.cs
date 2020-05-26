using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebEscola.Models
{
    public class Matricula
    {
        public int MatriculaID { get; set; }
        public int AlunoID { get; set; }
        public int CursoID { get; set; }
        public Aluno Aluno { get; set; }
        public Curso Curso { get; set; }
    }
}
