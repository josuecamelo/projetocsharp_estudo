using System;

using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations.Schema;

namespace WebEscola.Models
{
    public class Departamento
    {
        public int DepartamentoID { get; set; }

        public Nullable<int> InstrutorID { get; set; }


        [StringLength(40, MinimumLength = 3, ErrorMessage = "O nome do departamento deve ter de 3 a 40 caracteres")]
        public string Nome { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal Orcamento { get; set; }


        [DataType(DataType.Date)]
        [Display(Name = "Início")]
        public System.DateTime Inicio { get; set; }

        public virtual Instrutor Instrutor { get; set; }
        public virtual ICollection<Curso> Cursos { get; set; }
    }
}
