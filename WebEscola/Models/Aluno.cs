using System;

using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;

namespace WebEscola.Models
{
    public class Aluno
    {
        public int AlunoID { get; set; }

        [Display(Name = "Primeiro Nome")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "O nome deve ter de 3 a 40 caracteres")]
        [Required(ErrorMessage = "O nome é obrigatório")]
        public string Nome { get; set; }

        [StringLength(40, MinimumLength = 3, ErrorMessage = "O sobrenome deve ter de 3 a 40 caracteres")]
        [Required(ErrorMessage = "O sobrenome é obrigatório")]
        public string Sobrenome { get; set; }


        [DataType(DataType.Date)]
        [Display(Name = "Nascimento")]
        [Required(ErrorMessage = "A data de nascimento é obrigatória")]
        public DateTime Data { get; set; }
        
        public virtual ICollection<Matricula> Matriculas { get; set; }
    }
}
