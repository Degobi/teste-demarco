📝 teste-demarco

API REST desenvolvida em .NET 8 com persistência de dados no MongoDB.
Inclui endpoints para cadastro e listagem de clientes, além de logs de
operações.
A solução conta com testes unitários para garantir a qualidade do
código.

------------------------------------------------------------------------

🚀 Funcionalidades

-   POST /clientes → Cadastra um cliente (Id, Nome, Email).
-   GET /clientes → Lista todos os clientes.
-   Validação de e-mail único → Não permite cadastrar e-mails
    duplicados.
-   Registro de log no MongoDB → Salva DataHora, Ação e IdCliente a cada
    cadastro.
-   Swagger → Documentação interativa disponível em /swagger.

------------------------------------------------------------------------

📦 Pré-requisitos

Antes de rodar a aplicação, você precisa ter instalado:

-   .NET SDK 8.0
-   MongoDB (local ou em nuvem, ex: MongoDB Atlas)

------------------------------------------------------------------------


▶️ Como rodar a aplicação

1.  Clone o repositório:

        git clone https://github.com/Degobi/teste-demarco
        cd teste-demarco

2.  Restaure as dependências:

        dotnet restore

3.  Rode a aplicação:

        dotnet run --project src/TesteDemarco.Api

4.  Acesse no navegador:

    -   API: http://localhost:5000
    -   Swagger: http://localhost:5000/swagger

------------------------------------------------------------------------

🧪 Executando os testes

Para rodar os testes unitários:

    dotnet test
