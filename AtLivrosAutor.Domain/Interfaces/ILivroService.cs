using AtLivrosAutor.Domain.Models;
using AtLivrosAutor.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtLivrosAutor.Domain.Interfaces
{
    public interface ILivroService
    {
        LivroViewModel GetLivro(int id);
        IEnumerable<LivroViewModel> GetLivros();
        void AddLivro(LivroViewModel livroViewModel);
        void UpdateLivro(LivroViewModel livroViewModel);
        void RemoveLivro(int id);
    }
}
