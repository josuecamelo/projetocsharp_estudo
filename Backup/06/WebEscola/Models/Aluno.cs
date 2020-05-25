using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebEscola.Models
{
    public class Aluno
    {
        public int AlunoID { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        [DataType(DataType.Date)]
        public DateTime Data { get; set; }
        
        public virtual ICollection<Matricula> Matriculas { get; set; }
    }
}
