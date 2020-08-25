﻿using CondominiumManager.BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CondominiumManager.DAL.Interfaces
{
    public interface IMesRepositorio : IRepositorioGenerico<Mes>
    {
        new Task<IEnumerable<Mes>> PegarTodos();
    }
}
