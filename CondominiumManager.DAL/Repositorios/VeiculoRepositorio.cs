using CondominiumManager.BLL.Models;
using CondominiumManager.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondominiumManager.DAL.Repositorios
{
   public class VeiculoRepositorio : RepositorioGenerico<Veiculo>, IVeiculoRepositorio
    {
        private readonly Contexto _contexto;

        public VeiculoRepositorio(Contexto contexto) : base(contexto)
        {
            _contexto = contexto;
        }

        public async Task<IEnumerable<Veiculo>> PegarVeiculosPorUsuarios(string usuarioId)
        {
            try
            {
                return await _contexto.Veiculos.Where(v => v.UsuarioId == usuarioId).ToListAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
