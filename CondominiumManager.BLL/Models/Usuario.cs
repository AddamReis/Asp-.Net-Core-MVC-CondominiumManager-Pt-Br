using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace CondominiumManager.BLL.Models
{
    public class Usuario : IdentityUser<string>
    {
        public string CPF { get; set; }

        public string FOTO { get; set; }

        public bool PrimeiroAcesso { get; set; }

        public StatusConta Status { get; set; }

        public virtual ICollection<Apartamento> MoradorApartamentos { get; set; }

        public virtual ICollection<Apartamento> ProprietarioApartamentos { get; set; }

        public virtual ICollection<Veiculo> Veiculos { get; set; }

        public virtual ICollection<Evento> Eventos { get; set; }

        public virtual ICollection<Servico> Servicos { get; set; }

        public virtual ICollection<Pagamento> Pagamentos { get; set; }
    }

    public enum StatusConta
    {
        Analisando = 0,
        Aprovado = 1, 
        Reprovado = 2
    }
}
