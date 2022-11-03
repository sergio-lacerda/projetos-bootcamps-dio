using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Vendas.Models
{
    public class Produto
    {        
        public int Id { get; set; }
        [Display(Name = "Código")]
        [Required(ErrorMessage = "Informe o código do produto!")]
        public int codProd { get; set; }
        [Display(Name = "Produto")]
        [Required(ErrorMessage = "Informe o nome do produto!")]
        public string nomeProd { get; set; }
        [Display(Name = "Preço")]
        [Required(ErrorMessage = "Informe o preço do produto!")]
        [Range(0, 99999, ErrorMessage = "Valor fora da faixa!")]
        public decimal precoProd { get; set; }
        [Display(Name = "Quant. Estoque")]
        [Required(ErrorMessage = "Informe a quantidade do produto em estoque!")]
        [Range(0, 99999, ErrorMessage = "Valor fora da faixa!")]
        public int qtdEstProd { get; set; }

        public List<Venda> Vendas { get; set; }
    }
}
