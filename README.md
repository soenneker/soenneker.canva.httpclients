[![](https://img.shields.io/nuget/v/soenneker.canva.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.canva.httpclients/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.canva.httpclients/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.canva.httpclients/actions/workflows/publish-package.yml)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.canva.httpclients/codeql.yml?style=for-the-badge&label=codeql)](https://github.com/soenneker/soenneker.canva.httpclients/actions/workflows/codeql.yml)
[![](https://img.shields.io/nuget/dt/soenneker.canva.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.canva.httpclients/)

# Soenneker.Canva.HttpClients

A cached, authenticated `HttpClient` for Canva's Connect API.

## Installation

```bash
dotnet add package Soenneker.Canva.HttpClients
```

## Configuration

```json
{
  "Canva": {
    "AccessToken": "your-oauth-access-token"
  }
}
```

The access token is sent as `Authorization: Bearer {token}`. `Canva:ClientBaseUrl`, `Canva:AuthHeaderName`, and `Canva:AuthHeaderValueTemplate` can override those defaults for a compatible gateway; the template must contain `{token}`.

## Registration and usage

```csharp
using Soenneker.Canva.HttpClients.Abstract;
using Soenneker.Canva.HttpClients.Registrars;

services.AddCanvaOpenApiHttpClientAsSingleton();

public sealed class CanvaService(ICanvaOpenApiHttpClient clientProvider)
{
    public async Task<string> GetCurrentUser(CancellationToken cancellationToken)
    {
        HttpClient client = await clientProvider.Get(cancellationToken);
        return await client.GetStringAsync("v1/users/me", cancellationToken);
    }
}
```

The provider owns its named cache entry. Disposing it removes the entry and disposes the cached client. Prefer singleton registration for normal application-wide use.
