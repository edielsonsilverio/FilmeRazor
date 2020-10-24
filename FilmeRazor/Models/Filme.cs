using System;
using System.ComponentModel.DataAnnotations;

namespace FilmeRazor.Models
{
    public class Filme
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo título é obrigatório")]
        public string Titulo { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data de Lançamento")]
        public DateTime DataLancamento { get; set; }
        public string Genero { get; set; }

        [Display(Name = "Preço")]
        [DataType(DataType.Currency)]
        public decimal Preco { get; set; }
    }
}
