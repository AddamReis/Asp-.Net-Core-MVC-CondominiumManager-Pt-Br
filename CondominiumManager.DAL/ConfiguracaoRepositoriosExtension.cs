using CondominiumManager.DAL.Interfaces;
using CondominiumManager.DAL.Repositorios;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace CondominiumManager.DAL
{
    public static class ConfiguracaoRepositoriosExtension
    {
        public static void ConfigurarRepositorios(this IServiceCollection services)
        {
            services.AddTransient<IUsuarioRepositorio, UsuarioRepositorio>();
            services.AddTransient<IFuncaoRepositorio, FuncaoRepositorio>();
            services.AddTransient<IVeiculoRepositorio, VeiculoRepositorio>();
            services.AddTransient<IEventoRepositorio, EventoRepositorio>();
        }
    }
}
