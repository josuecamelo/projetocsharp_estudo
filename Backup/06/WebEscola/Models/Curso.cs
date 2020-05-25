using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebEscola.Models
{
    public class Curso
    {
        public int CursoID { get; set; }
        public string Titulo { get; set; }
        public int Credito { get; set; }
        public virtual ICollection<Matricula> Matriculas { get; set; }
    }
}
