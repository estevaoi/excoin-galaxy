# ExCoinGalaxy 

Desafio "Merchant's Guide to Galaxy" implementada em C# com o ASP.NET Core na versão 0.1.

![Alt text](Screenshot_ExCoinGalaxy.jpg "ExCoin Galaxy")


## Requisitos

[Angular CLI](https://github.com/angular/angular-cli) versão 1.7.0.
[NodeJS](https://nodejs.org/en/) versão 8.12 LTS.
[.Net Core](https://www.microsoft.com/net/download/dotnet-core/2.1) versão 2.1.

## Executando a Aplicação

Primeiro será necessário navegar para a pasta **ExCoinGalaxy**, depois fazer o *restore* dos pacotes e o *publish* da solução.

```sh
$ cd Console
/Console$ dotnet restore
/Console$ dotnet publish -o bin
```
Após os comandos acima terem sido executados o build será gerado na pasta **bin**.

Para executar a aplicação basta chamar a DLL ExCoinGalaxy informando o path do arquivo de entrada.

```sh
/Console$ dotnet ./bin/Debug/netcoreapp2.1/ExCoinGalaxy.dll
```