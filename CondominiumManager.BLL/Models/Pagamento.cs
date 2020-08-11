using System;

namespace CondominiumManager.BLL.Models
{
    public class Pagamento
    {
        public int PagamentoId { get; set; }

        public string UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }

        public int AluguelId { get; set; }
        public Aluguel Aluguel { get; set; }

        public DateTime? DataPagamento { get; set; }

        public StatusPagamento Status { get; set; }
    }

    public enum StatusPagamento
    {
        Pago = 0, 
        Pendente = 1, 
        Atrasado = 2
    }
}
