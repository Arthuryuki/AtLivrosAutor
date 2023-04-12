using AtLivrosAutor.Domain.Interfaces;
using AtLivrosAutor.Domain.Models;
using AtLivrosAutor.Domain.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtLivrosAutor.Service.Services
{
    public class LivroService : ILivroService
    {
        private readonly AppDbContext _appDbContext;

        public LivroService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public LivroViewModel GetLivro(int id)
        {
            var livro = _appDbContext.Livro
                .Include(l => l.Autores)
                .Where(l => l.Id == id)
                .Select(l => new LivroViewModel
                {
                    Id = l.Id,
                    Titulo = l.Titulo,
                    ISBN = l.ISBN,
                    Ano = l.Ano,
                    Autores = l.Autores.Select(a => new AutorViewModel
                    {
                        Id = a.Id,
                        Nome = a.Nome,
                        Sobrenome = a.Sobrenome,
                        Email = a.Email,
                        DataNascimento = a.DataNascimento
                    }).ToList()
                })
                .FirstOrDefault();

            return livro;
        }

        public IEnumerable<LivroViewModel> GetLivros()
        {
            var livros = _appDbContext.Livro
                .Include(l => l.Autores)
                .Select(l => new LivroViewModel
                {
                    Id = l.Id,
                    Titulo = l.Titulo,
                    ISBN = l.ISBN,
                    Ano = l.Ano,
                    Autores = l.Autores.Select(a => new AutorViewModel
                    {
                        Id = a.Id,
                        Nome = a.Nome,
                        Sobrenome = a.Sobrenome,
                        Email = a.Email,
                        DataNascimento = a.DataNascimento
                    }).ToList()
                })
                .ToList();

            return livros;
        }

        public void AddLivro(LivroViewModel livroViewModel)
        {
            var livro = new Livro
            {
                Titulo = livroViewModel.Titulo,
                ISBN = livroViewModel.ISBN,
                Ano = livroViewModel.Ano
            };

            if (livroViewModel.Autores != null && livroViewModel.Autores.Any())
            {
                livro.Autores = new List<Autor>();

                foreach (var autorViewModel in livroViewModel.Autores)
                {
                    var autor = _appDbContext.Autor.FirstOrDefault(a => a.Id == autorViewModel.Id);

                    if (autor != null)
                    {
                        livro.Autores.Add(autor);
                    }
                }
            }

            _appDbContext.Livro.Add(livro);
            _appDbContext.SaveChanges();
        }

        public void UpdateLivro(LivroViewModel livroViewModel)
        {
            var livro = _appDbContext.Livro
                .Include(l => l.Autores)
                .FirstOrDefault(l => l.Id == livroViewModel.Id);

            if (livro == null)
            {
                throw new Exception("Livro não encontrado.");
            }

            livro.Titulo = livroViewModel.Titulo;
            livro.ISBN = livroViewModel.ISBN;
            livro.Ano = livroViewModel.Ano;

            if (livroViewModel.Autores != null && livroViewModel.Autores.Any())
            {
                livro.Autores.Clear();

                foreach (var autorViewModel in livroViewModel.Autores)
                {
                    var autor = _appDbContext.Autor.FirstOrDefault(a => a.Id == autorViewModel.Id);

                    if (autor != null)
                    {
                        livro.Autores.Add(autor);
                    }
                }
            }
        }

        public void RemoveLivro(int id)
        {
            var livro = _appDbContext.Livro.Find(id);

            if (livro == null)
            {
                throw new ArgumentException("Livro não encontrado.");
            }

            _appDbContext.Livro.Remove(livro);
            _appDbContext.SaveChanges();
        }

    }
}