# Controle de Estoque API

Este é um projeto de API RESTful para controle de estoque e geração de relatórios de pedidos por dia. A API permite gerenciar clientes, produtos, pedidos e faturamentos, além de fornecer um endpoint para recuperar relatórios de pedidos por dia.

## Funcionalidades

- CRUD de Clientes
- CRUD de Produtos
- CRUD de Pedidos
- CRUD de Faturamentos
- Relatório de Pedidos por Dia

## Documentação da API

A API foi documentada utilizando o Swagger, uma ferramenta de código aberto que ajuda os desenvolvedores a projetar, criar, documentar e consumir serviços da Web RESTful. Para acessar a documentação da API, basta iniciar a aplicação e navegar para `/swagger` no navegador.

## Como Baixar o Código

Você pode baixar ou clonar este repositório usando o seguinte comando:

```
git clone https://github.com/paulozuchini/ControleDeEstoque.git
```

## Requisitos

- .NET 8.0 SDK ou superior
- SQL Server (ou outro banco de dados compatível com o Entity Framework Core)

## Preparando o Ambiente

1. **Configuração do Banco de Dados**: Certifique-se de que possui um servidor SQL Server disponível e crie um novo banco de dados para a aplicação.

2. **Executar Scripts do Banco de Dados**: No diretório `ControleDeEstoque\DbScripts`, você encontrará os scripts SQL necessários para criar as tabelas e os dados iniciais do banco de dados. Execute esses scripts no seu servidor SQL Server para configurar o banco de dados.

3. **Configuração da Conexão com o Banco de Dados**: Abra o arquivo `appsettings.json` no projeto e atualize a string de conexão com o banco de dados para apontar para o banco que você configurou.

## Executando a Aplicação

Após preparar o ambiente e configurar a conexão com o banco de dados, você pode executar a aplicação. Navegue até o diretório raiz do projeto e execute o seguinte comando:

```
dotnet run
```

A aplicação será iniciada e estará disponível em `https://localhost:5000` (ou `http://localhost:5001`).

## Tecnologias Utilizadas

- ASP.NET Core
- Entity Framework Core
- SQL Server
- C#
- RESTful API
- Swagger

## Contribuindo

Se você encontrar algum problema ou tiver alguma sugestão, sinta-se à vontade para abrir uma issue ou enviar um pull request. Estamos abertos a contribuições!

---

Este projeto foi desenvolvido como parte de um exercício prático e pode não refletir todas as melhores práticas de desenvolvimento. Use-o como referência ou ponto de partida para seus próprios projetos.