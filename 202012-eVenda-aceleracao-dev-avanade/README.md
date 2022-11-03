# eVenda: Aceleração Global DEV 3 Avanade

Repositório para projeto referente ao programa Aceleração Global Dev #3 Avanade, através da plataforma Digital Innovation One. O projeto foca a integração entre sistemas (Estoque e Vendas) através de recurso do Azure Service Bus.

## Começando

Este projeto foi desenvolvido no Visual Studio 2019, segundo o modelo de aplicação web MVC, utilizando Entity Framework e Migrations, com uma abordagem Code First.

## Configuração

Para que o projeto funcione corretamente, é importante configurar previamente os Tópicos e Subscrições utilizadas no Azure Service Bus, obtendo uma string de conexão com esse ambiente. 

#### Tópicos e Subscrições Azure Service Bus

###### Mensagem de Estoque para Venda

- **Tópico**: produtoatualizado
- **Subscrição**: ProdutoUpdateParaVendas

###### Mensagem de Venda para Estoque

- **Tópico**: vendarealizada
- **Subscrição**: VendaUpdateParaEstoque

#### Tópicos e Subscrições Azure Service Bus

Após configurar seu recurso Azure Service Bus, otenha a respectiva string de conexão e insira a mesma em ambos os módulos (Estoque e Vendas), nos arquivos das classes Util.cs, linha 29, completando a instrução *__public static readonly string AzureConnStr = "Insira sua string de conexão aqui";__*

## Licença

Não se aplica