using System;

using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;
namespace WebEscola.Models
{
    public class Instrutor
    {
        public int InstrutorID { get; set; }


        [Display(Name = "Primeiro Nome")]

        [StringLength(40, MinimumLength = 3, ErrorMessage = "O nome deve ter de 3 a 40 caracteres")]

        [Required(ErrorMessage = "O nome é obrigatório")]

        public string Nome { get; set; }


        [StringLength(40, MinimumLength = 3, ErrorMessage = "O sobrenome deve ter de 3 a 40 caracteres")]

        [Required(ErrorMessage = "O sobrenome é obrigatório")]

        public string Sobrenome { get; set; }


        [DataType(DataType.Date)]

        [Display(Name = "Contratação")]

        [Required(ErrorMessage = "A data de contratação é obrigatória")]

        public DateTime Contratacao { get; set; }


        public virtual Escritorio Escritorio { get; set; }

        public virtual ICollection<CursoInstrutor> CursosInstrutor { get; set; }

        public virtual ICollection<Departamento> Departamentos { get; set; }
    }
}
