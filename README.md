# gn-api-sdk-.net-core

> A .NET Core library for integration of your application with the payment services
provided by [Gerencianet](http://gerencianet.com.br).


## Installation

From Visual Studio package manager: 

```bash
PM> Install-Package Gerencianet.NETCore.SDK -Version 2.0.1
```

From .NET Cli:

```bash
> dotnet add package Gerencianet.NETCore.SDK --version 2.0.1
```

### Tested with
```
dotnet 5.0.202
```
## Basic usage

```c#
using Gerencianet.NETCore.SDK;
...
dynamic endpoints = new Endpoints("client_id", "client_secret", true, "certificate.p12");
            
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

[CHANGELOG](CHANGELOG.md)

## Contributing

Bug reports and pull requests are welcome on GitHub at https://github.com/gerencianet/gn-api-sdk-dotnet-core. This project is intended to be a safe, welcoming space for collaboration.

## License

The library is available as open source under the terms of the [MIT License](LICENSE).