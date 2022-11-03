using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace Estoque.Models
{
    public static class MsgUpdateProdutoEnvio
    {
        public static void enviar(int codProduto, string nomeProduto, decimal precoProduto, int qtdProduto) 
        {
            MsgUpdateProduto mensagem = new MsgUpdateProduto {                 
                ProdCod = codProduto,
                ProdNome = nomeProduto,
                ProdPreco = precoProduto,
                ProdQtd = qtdProduto 
            };

            var connectionStr = Utils.AzureConnStr;
            var topic = "produtoatualizado";

            var serviceBusClient = new TopicClient(connectionStr, topic);

            var message = new Message(mensagem.ToJsonBytes());
            message.ContentType = "application/json";
            message.UserProperties.Add("CorrelationId", Guid.NewGuid().ToString());            

            serviceBusClient.SendAsync(message);             
        }
    }
}
