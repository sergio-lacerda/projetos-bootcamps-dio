using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vendas.Models
{
    public class Venda
    {
        public int Id { get; set; }
        [Display(Name = "Pedido")]
        [Required(ErrorMessage = "Informe o número do pedido!")]
        public int codPedido { get; set; }

        [Display(Name = "Produto")]
        [Required(ErrorMessage = "Informe o produto!")]
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }

        [Display(Name = "Quantidade")]
        [Required(ErrorMessage = "Informe a quantidade do produto!")]
        [Range(0, 99999, ErrorMessage = "Valor fora da faixa!")]
        public int quantidade { get; set; }

        [Display(Name = "Preço")]
        [Required(ErrorMessage = "Informe o preço do produto!")]
        [Range(0, 99999, ErrorMessage = "Valor fora da faixa!")]        
        public decimal preco { get; set; }
    }
}
