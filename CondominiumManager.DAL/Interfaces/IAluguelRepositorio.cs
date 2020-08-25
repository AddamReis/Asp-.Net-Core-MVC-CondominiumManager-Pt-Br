using CondominiumManager.BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CondominiumManager.DAL.Interfaces
{
    public interface IAluguelRepositorio : IRepositorioGenerico<Aluguel>
    {
        bool AluguelJaExiste(int mesId, int ano);

        new Task<IEnumerable<Aluguel>> PegarTodos();

        Task<IEnumerable<int>> PegarTodosAnos();
    }
}
