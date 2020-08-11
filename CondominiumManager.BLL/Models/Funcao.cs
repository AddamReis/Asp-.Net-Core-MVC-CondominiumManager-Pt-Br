using Microsoft.AspNetCore.Identity;

namespace CondominiumManager.BLL.Models
{
    public class Funcao : IdentityRole<string>
    {
        public string Descricao { get; set; }
    }
}
