using CondominiumManager.BLL.Models;
using CondominiumManager.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CondominiumManager.DAL.Repositorios
{
    public class FuncaoRepositorio : RepositorioGenerico<Funcao>, IFuncaoRepositorio
    {
        public FuncaoRepositorio(Contexto contexto) : base(contexto)
        {
        }
    }
}
