using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMGBank
{
    public static class Utils
    {
        public static readonly Dictionary<string, string> SaleStatus = new Dictionary<string, string>
        {
            { "AGUARDANDO_PAGAMENTO", "AGUARDANDO PAGAMENTO" },
            { "PAGAMENTO_APROVADO", "PAGAMENTO APROVADO" },
            { "ENVIADO_PARA_TRANSPORTADORA", "ENVIADO PARA TRANSPORTADORA" },
            { "ENTREGUE", "ENTREGUE" },
            { "CANCELADA", "CANCELADA" }
        };
    }
}
