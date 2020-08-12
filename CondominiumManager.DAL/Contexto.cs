using CondominiumManager.BLL.Models;
using CondominiumManager.DAL.Mapeamentos;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace CondominiumManager.DAL
{
    public class Contexto : IdentityDbContext<Usuario, Funcao, string>
    {
        public Microsoft.EntityFrameworkCore.DbSet<Aluguel> Alugueis { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Apartamento> Apartamentos { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Evento> Eventos { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Funcao> Funcoes { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<HistoricoRecursos> HistoricoRecursos { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Mes> Meses { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Pagamento> Pagamentos { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Servico> Servicos { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<ServicoPredio> ServicoPredios { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Usuario> Usuarios { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Veiculo> Veiculos { get; set; }

        public Contexto(DbContextOptions<Contexto> opcoes) : base(opcoes)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new AluguelMap());
            builder.ApplyConfiguration(new ApartamentoMap());
            builder.ApplyConfiguration(new EventoMap());
            builder.ApplyConfiguration(new FuncaoMap());
            builder.ApplyConfiguration(new HistoricoRecursosMap());
            builder.ApplyConfiguration(new MesMap());
            builder.ApplyConfiguration(new ServicoMap());
            builder.ApplyConfiguration(new ServicoPrediosMap());
            builder.ApplyConfiguration(new UsuarioMap());
            builder.ApplyConfiguration(new VeiculoMap());
        }
    }
}

