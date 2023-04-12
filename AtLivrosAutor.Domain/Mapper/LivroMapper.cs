using AtLivrosAutor.Domain.Models;
using AtLivrosAutor.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtLivrosAutor.Domain.Mapper
{
    public static class LivroMapper
    {
        public static LivroViewModel ToViewModel(this Livro livro)
        {
            return new LivroViewModel
            {
                Id = livro.Id,
                Titulo = livro.Titulo,
                ISBN = livro.ISBN,
                Ano = livro.Ano,
                Autores = livro.Autores?.Select(a => a.ToViewModel()).ToList()
            };
        }

        public static Livro ToEntity(this LivroViewModel livroViewModel)
        {
            return new Livro
            {
                Id = livroViewModel.Id,
                Titulo = livroViewModel.Titulo,
                ISBN = livroViewModel.ISBN,
                Ano = livroViewModel.Ano
            };
        }
    }
}
