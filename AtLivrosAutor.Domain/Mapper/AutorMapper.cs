using AtLivrosAutor.Domain.Models;
using AtLivrosAutor.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtLivrosAutor.Domain.Mapper
{
    public static class AutorMapper
    {
        public static AutorViewModel ToViewModel(this Autor autor)
        {
            return new AutorViewModel
            {
                Id = autor.Id,
                Nome = autor.Nome,
                Sobrenome = autor.Sobrenome,
                Email = autor.Email,
                DataNascimento = autor.DataNascimento,
                Livros = autor.Livros.Select(l => l.ToViewModel()).ToList()
            };
        }
        public static Autor ToModel(this AutorViewModel autorViewModel)
        {
            return new Autor
            {
                Id = autorViewModel.Id,
                Nome = autorViewModel.Nome,
                Sobrenome = autorViewModel.Sobrenome,
                Email = autorViewModel.Email,
                DataNascimento = autorViewModel.DataNascimento
            };
        }
    } 
}
