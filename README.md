# gn-api-sdk-dotnet-core

> A .NET Core library for integration of your application with the payment services
provided by [Gerencianet](http://gerencianet.com.br).


## Installation

From Visual Studio package manager: 

```bash
PM> Install-Package Gerencianet.NETCore.SDK -Version 2.0.2
```

From .NET Cli:

```bash
> dotnet add package Gerencianet.NETCore.SDK --version 2.0.2
```

### Tested with
```
.NET 5.0

```
O .NET 5.0 é a versão principal do .NET Core após a versão 3.1. O "Core" foi removido do nome para enfatizar que essa é a implementação principal do .NET no futuro. O .NET 5.0 dá suporte a mais tipos de aplicativos e mais plataformas do que o .NET Core ou .NET Framework.

## Basic usage

```c#
using Gerencianet.NETCore.SDK;
...
dynamic endpoints = new Endpoints("client_id", "client_secret", true, "production.p12");
            
var body = new 
{
    calendario = new {
        expiracao = 3600
    },
    devedor = new {
        cpf = "12345678909",
        nome = "Francisco da Silva"
    },
    valor = new {
        original = "1.45"
    },
    chave = "71cdf9ba-c695-4e3c-b010-abb521a3f1be",
    solicitacaoPagador = "Informe o número ou identificador do pedido."
};

var response = endpoints.PixCreateImmediateCharge(null, body);
Console.WriteLine(response);
```

## Examples

You can run the examples contained in the project `Gerencianet.NETCore.SDK.Examples` by uncommenting the lines in `Program.cs` file.

Just remember to set the correct credentials inside `Gerencianet.NETCore.SDK.Examples/credentials.json` before running.

## Additional documentation

The full documentation with all available endpoints is in https://dev.gerencianet.com.br/.

## Changelog

[CHANGELOG](CHANGELOG.MD)

## Contributing

Bug reports and pull requests are welcome on GitHub at https://github.com/gerencianet/gn-api-sdk-dotnet-core. This project is intended to be a safe, welcoming space for collaboration.

## License

The library is available as open source under the terms of the [MIT License](LICENSE).
