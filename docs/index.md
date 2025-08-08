WeChooz.Aspire.Hosting.MailDev documentation
===

This .NET Aspire Integration runs [MailDev](https://maildev.github.io/maildev/) in a container.

## Get started

To get started, install the install the [📦 WeChooz.Aspire.Hosting.MailDev](https://nuget.org/packages/WeChooz.Aspire.Hosting.MailDev) NuGet package in the AppHost project.

### [.NET CLI](#tab/dotnet-cli)

```dotnetcli
dotnet add package WeChooz.Aspire.Hosting.MailDev
```
## Usage

To add the [MailDev](https://maildev.github.io/maildev/) resource, call the `AddMailDev` method on a `IDistributedApplicationBuilder` instance representing the .NET Aspire host:

```csharp
builder.AddMailDev("mailer");
```
The integration exposes a connection string with the format `Endpoint=smtp://<host>:<port>`. This connection string can be used to with a DbConnectionStringBuilder to get the smtp endpoint.

## More options
You can specify the port for the SMTP and HTTP endpoint:


```csharp
builder.AddMailDev("mailer", httpPort: 1234, smtpPort: 4321);
```

You can also specify a username and a password to secure the connection to the SMTP (local) server (learn [how to work with parameter in .NET Aspire](https://learn.microsoft.com/en-us/dotnet/aspire/fundamentals/external-parameters)):


```csharp
builder.AddMailDev("mailer", credentials: new CredentialsResourceParameterBuilder(builder.AddParameter(...), builder.AddParameter(...));
```
When credentials are specified, the format of the connection string becomes:
`Endpoint=smtp://<host>:<port>;Username=<username>;Password=<password>`


## Lovingly inspired by .NET Aspire documentation

This project is lovingly inspired by the [integration samples in the .NET Aspire documentation](https://learn.microsoft.com/en-us/dotnet/aspire/extensibility/custom-hosting-integration).

It has been improved to meet our internal needs.
