# API Previsao do Tempo

## Softwares utilizados neste projeto:

- Visual Studio Community 2019
- MySql Community 5.6

## O que esta API faz?
Esta API retorna a temperatura atual, minima e maxima da cidade que você endicar no endpoint: /api/Cidades

## Como utilizar esta API?

Primeiramente será necessário configurar suas informações de conexão ao MySql no arquivo appsettings.json. 
Após isso você poderá rodar a API, ela abre a interface do swagger no navegador tornado mais fácil sua utilização.
Com a página do swagger aberta você poderá passar a cidade que você deseja obter informações como parametro GET.

Você só poderá obter novos dados atualizados sobre esta cidade novamente após 20 minutos. As consultas feitas repetidamente 
em um intervalo de 20 minutos sobre uma cidade retornaram dados armazenados no banco de dados da API.

Caso você não passe nenhuma cidade como parametro GET, a API retornará dados da cidade de São Paulo.

## Autor
Gabriel Leal www.linkedin.com/in/g-abrielleal/
