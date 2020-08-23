using CondominiumManager.BLL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CondominiumManager.DAL.Interfaces
{
    public interface IEventoRepositorio : IRepositorioGenerico<Evento>
    {
        Task<IEnumerable<Evento>> PegarEventosPeloId(string usuarioId);
    }
}
