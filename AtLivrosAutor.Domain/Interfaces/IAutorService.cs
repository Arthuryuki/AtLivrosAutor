using AtLivrosAutor.Domain.Models;
using AtLivrosAutor.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtLivrosAutor.Domain.Interfaces
{
    public interface IAutorService
    {
        AutorViewModel GetAutor(int id);
        IEnumerable<AutorViewModel> GetAutores();
        void AddAutor(AutorViewModel autorViewModel);
        void UpdateAutor(AutorViewModel autorViewModel);
        void RemoveAutor(int id);
    }
}
