using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtLivrosAutor.Domain.ViewModel
{
    public class AutorViewModel
    {
        public int Id { get; set; }
        [MaxLength(250)]
        [Required]
        public string Nome { get; set; }
        [MaxLength(250)]
        [Required]
        public string Sobrenome { get; set; }
        [MaxLength(250)]
        [Required]
        public string Email { get; set; }
        [Required]
        public DateTime DataNascimento { get; set; }
        public List<LivroViewModel> Livros { get; set; }
    }
}
