using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estoque.Models
{
    public class MsgUpdateProduto                 
    {        
        public int ProdCod { get; set; }
        public string ProdNome { get; set; }
        public decimal ProdPreco { get; set; }
        public int ProdQtd { get; set; }
    }
}
