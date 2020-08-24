using CondominiumManager.BLL.Models;
using CondominiumManager.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CondominiumManager.DAL.Repositorios
{
    public class ServicoPredioRepositorio : RepositorioGenerico<ServicoPredio>, IServicoPredioRepositorio
    {
        public ServicoPredioRepositorio(Contexto contexto) : base(contexto)
        {
        }
    }
}
