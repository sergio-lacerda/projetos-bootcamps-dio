using Microsoft.Azure.ServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Estoque.Models
{
    public static class MsgUpdateVendaRecebimento
    {
        public static void receber() 
        {
            var connectionStr = Utils.AzureConnStr;
            var topic = "vendarealizada";
            var subscription = "VendaUpdateParaEstoque";

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
            var mensagem = message.Body.ParseJson<MsgUpdateVenda>();

            //Escrever aqui o código para processar a mensagem      
            Context _context = new Context();
            Salvar(_context, mensagem.ProdCod, mensagem.ProdQtd);

            return Task.CompletedTask;
        }

        private static Task ExceptionReceivedHandler(ExceptionReceivedEventArgs arg)
        {
            throw new NotImplementedException();
        }

        private static async void Salvar(Context c, int ProdCod, int qtd)
        {
            var prod = c.Produtos.FirstOrDefault(m => m.codProd == ProdCod);

            if (prod != null)
            {
                //Baixando o estoque (atual - qtd. vendida)
                prod.qtdEstProd -= qtd;
                c.Update(prod);
                await c.SaveChangesAsync();
            }
        }
    }        
}
