using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtLivrosAutor.Domain.Models
{
    public class Livro
    {
        public int Id { get; set; }
        [MaxLength(250)]
        [Required]
        public string Titulo { get; set; }
        [MaxLength(250)]
        [Required]
        public string ISBN { get; set; }
        [MaxLength(250)]
        [Required]
        public int Ano { get; set; }
        public virtual ICollection<Autor> Autores { get; set; }
    }
}
