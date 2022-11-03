using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Vendas.Models;

namespace Estoque.Models
{
    public static class MsgUpdateProdutoRecebimento
    {
        public static void receber()
        {
            var connectionStr = Utils.AzureConnStr;
            var topic = "produtoatualizado";
            var subscription = "ProdutoUpdateParaVendas";

            var serviceBusClient = new SubscriptionClient(connectionStr, topic, subscription);

            var messageHandlerOptions = new MessageHandlerOptions(ExceptionReceivedHandler)
            {
                MaxConcurrentCalls = 1,
                AutoComplete = false
            };

            serviceBusClient.RegisterMessageHandler(ProcessMessageAsync, messageHandlerOptions);
        }

        private static Task ProcessMessageAsync(Message message, CancellationToken arg2)
        {
            var mensagem = message.Body.ParseJson<MsgUpdateProduto>();

            //Escrever aqui o código para processar a mensagem      
            Context _context = new Context();
            Produto p = new Produto 
            {                
                codProd = mensagem.ProdCod,
                nomeProd = mensagem.ProdNome,
                precoProd = mensagem.ProdPreco,
                qtdEstProd = mensagem.ProdQtd
            };

            Salvar(_context, p, mensagem.ProdCod);            

            return Task.CompletedTask;
        }

        private static Task ExceptionReceivedHandler(ExceptionReceivedEventArgs arg)
        {
            throw new NotImplementedException();
        }

        private static async void Salvar(Context c, Produto p, int ProdCod)
        {
            //bool ProdutoExists = c.Produtos.Any(e => e.codProd == ProdCod);
            //var produto = c.Produtos.Any(e => e.codProd == ProdCod);

            var produto = await c.Produtos.FirstOrDefaultAsync(m => m.codProd == ProdCod);
            if (produto == null)
            {
                c.Add(p);
            }
            else
            {
                produto.codProd = p.codProd;
                produto.nomeProd = p.nomeProd;
                produto.precoProd = p.precoProd;
                produto.qtdEstProd = p.qtdEstProd;
                c.Update(produto);
            }
            await c.SaveChangesAsync();         
        }
    }
}
