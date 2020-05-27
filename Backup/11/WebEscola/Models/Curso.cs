using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;

namespace WebEscola.Models
{
    public class Curso
    {
        public int CursoID { get; set; }


        [Display(Name = "Curso")]
        [StringLength(40, ErrorMessage = "O nome do curso deve ter de até 40 caracteres")]
        [Required(ErrorMessage = "O nome do curso é obrigatório")]
        public string Titulo { get; set; }


        [Display(Name = "Crédito")]
        [Range(0, 5, ErrorMessage = "Apenas valores de 0 a 5")]
        public int Credito { get; set; }

        public int DepartamentoID { get; set; }


        public virtual ICollection<Matricula> Matriculas { get; set; }

        public virtual ICollection<CursoInstrutor> CursosInstrutor { get; set; }

        public virtual Departamento Departamento { get; set; }
    }
}
