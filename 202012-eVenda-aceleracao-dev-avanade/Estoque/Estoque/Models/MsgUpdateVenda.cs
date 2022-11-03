using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estoque.Models
{
    public class MsgUpdateVenda
    {
        public int VendaId { get; set; }
        public int ProdCod { get; set; }
        public int ProdQtd { get; set; }
    }
}
