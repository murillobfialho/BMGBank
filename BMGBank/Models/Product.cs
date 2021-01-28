using System.ComponentModel.DataAnnotations;

namespace BMGBank.Models
{
    public class Product
    {
        [Required]
        [MaxLength(100, ErrorMessage = "O campo status suporta até {1} caracteres")]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}
