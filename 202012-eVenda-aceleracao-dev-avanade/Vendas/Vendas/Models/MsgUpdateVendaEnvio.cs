using Microsoft.Azure.ServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Vendas.Models;

namespace Estoque.Models
{
    public static class MsgUpdateVendaEnvio
    {
        public static void enviar(int idVenda, int codProduto, int qtdProduto)
        {
            MsgUpdateVenda mensagem = new MsgUpdateVenda { VendaId = idVenda, ProdCod = codProduto, ProdQtd = qtdProduto };

            var connectionStr = Utils.AzureConnStr; 
            var topic = "vendarealizada";

            var serviceBusClient = new TopicClient(connectionStr, topic);

            var message = new Message(mensagem.ToJsonBytes());
            message.ContentType = "application/json";
            message.UserProperties.Add("CorrelationId", Guid.NewGuid().ToString());

            serviceBusClient.SendAsync(message);
        }
    }        
}
