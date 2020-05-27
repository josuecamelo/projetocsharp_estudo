using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebEscola.Models
{
    public class CursoInstrutor
    {
        public int CursoInstrutorID { get; set; }
        public Nullable<int> InstrutorID { get; set; }
        public Nullable<int> CursoID { get; set; }
        public virtual Instrutor Instrutor { get; set; }
        public virtual Curso Curso { get; set; }
    }
}
