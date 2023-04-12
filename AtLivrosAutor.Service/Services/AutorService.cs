using AtLivrosAutor.Domain.Interfaces;
using AtLivrosAutor.Domain.Models;
using AtLivrosAutor.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtLivrosAutor.Service.Service
{
    public class AutorService : IAutorService
    {
        private readonly AppDbContext _context;

        public AutorService(AppDbContext context)
        {
            _context = context;
        }

        public AutorViewModel GetAutor(int id)
        {
            var autor = _context.Autor.Find(id);
            return new AutorViewModel()
            {
                Id = autor.Id,
                Nome = autor.Nome,
                Sobrenome = autor.Sobrenome,
                Email = autor.Email,
                DataNascimento = autor.DataNascimento
            };
        }

        public IEnumerable<AutorViewModel> GetAutores()
        {
            var autores = _context.Autor.ToList();
            return autores.Select(a => new AutorViewModel()
            {
                Id = a.Id,
                Nome = a.Nome,
                Sobrenome = a.Sobrenome,
                Email = a.Email,
                DataNascimento = a.DataNascimento
            });
        }

        public void AddAutor(AutorViewModel autorViewModel)
        {
            var autor = new Autor()
            {
                Nome = autorViewModel.Nome,
                Sobrenome = autorViewModel.Sobrenome,
                Email = autorViewModel.Email,
                DataNascimento = autorViewModel.DataNascimento
            };

            _context.Autor.Add(autor);
            _context.SaveChanges();
        }

        public void UpdateAutor(AutorViewModel autorViewModel)
        {
            var autor = _context.Autor.Find(autorViewModel.Id);

            if (autor == null)
            {
                throw new Exception("Autor não encontrado");
            }

            autor.Nome = autorViewModel.Nome;
            autor.Sobrenome = autorViewModel.Sobrenome;
            autor.Email = autorViewModel.Email;
            autor.DataNascimento = autorViewModel.DataNascimento;

            _context.SaveChanges();
        }

        public void RemoveAutor(int id)
        {
            var autor = _context.Autor.Find(id);

            if (autor == null)
            {
                throw new Exception("Autor não encontrado");
            }

            _context.Autor.Remove(autor);
            _context.SaveChanges();
        }
    }
}
