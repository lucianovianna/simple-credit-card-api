
using System.ComponentModel.DataAnnotations;

namespace creditCardApi.Models
{


    public class CreditCard
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatorio")]
        [EmailAddress(ErrorMessage = "O email inserido é invalido")]
        public string email { get; set; }
    }
}