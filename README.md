# Apresentação 
Site desenvolvido com o intuito de aprendizado.

# Configuração do ambiente

## Requisitos
1.  [Docker] (https://www.docker.com/products/docker-desktop)
2.  [.NET Core 3.1] (https://dotnet.microsoft.com/download)

## Comandos
1.  Inicialização do SqlServer no Docker através do docker-compose existente na raiz da aplicação
    ``` bash
    docker-compose up -d
    ```
2.  Instalação do Dotnet ef tool (dotnet ef tool não faz parte mais do .NET Core SDK)
    ``` bash
    dotnet tool install --global dotnet-ef
    ```
3.  Execução do migrations para criação do banco de dados da aplicação no SqlServer
    Acesse o diretório do projeto até o projeto Leilao.Data.SqlServer através do terminal/powershell:
    ```
    MZLeilao\Leilao\src\Leilao.Data.SqlServer
    ```
    Em seguida, execute
    ``` bash
    dotnet ef database update
    ```

# Executando a aplicação
-   Para a aplicação reconhecer o 'localhost' definido no docker, é necessário iniciar a instância do SqlServer e executar o projeto via IIS.
