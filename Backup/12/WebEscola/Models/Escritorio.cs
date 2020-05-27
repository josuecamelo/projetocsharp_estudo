using System.ComponentModel.DataAnnotations;

namespace WebEscola.Models
{
    public class Escritorio
    {
        public int EscritorioID { get; set; }

        public int InstrutorID { get; set; }


        [Display(Name = "Localização do Escritório")]
        [StringLength(40, ErrorMessage = "A localização deve ter no máximo 40 caracteres")]
        public string Localizacao { get; set; }


        public virtual Instrutor Instrutor { get; set; }
    }
}
