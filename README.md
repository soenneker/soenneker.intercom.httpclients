[![](https://img.shields.io/nuget/v/soenneker.intercom.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.intercom.httpclients/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.intercom.httpclients/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.intercom.httpclients/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.intercom.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.intercom.httpclients/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.intercom.httpclients/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.intercom.httpclients/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Intercom.HttpClients

Reuse an authenticated HTTP client for Intercom's API, with configurable base URL and authentication header formatting.

## Install

```bash
dotnet add package Soenneker.Intercom.HttpClients
```

## Configure

```json
{
  "Intercom": {
    "ApiKey": "<access token>"
  }
}
```

`ApiKey` is required. The defaults target `https://api.intercom.io` and send `Authorization: Bearer <access token>`.

Optional overrides:

```json
{
  "Intercom": {
    "ClientBaseUrl": "https://api.intercom.io",
    "AuthHeaderName": "Authorization",
    "AuthHeaderValueTemplate": "Bearer {token}"
  }
}
```

`AuthHeaderValueTemplate` must contain `{token}` where the API key should be inserted.

## Register

```csharp
using Soenneker.Intercom.HttpClients.Registrars;

services.AddIntercomOpenApiHttpClientAsSingleton();
```

Use `AddIntercomOpenApiHttpClientAsScoped()` only when each scope should own its transport. Provider instances use isolated cache keys, so disposing one scope removes only its own client.

## Usage

```csharp
using Soenneker.Intercom.HttpClients.Abstract;

HttpClient client = await intercomHttpClient.Get(cancellationToken);

HttpResponseMessage response = await client.GetAsync(
    "contacts",
    cancellationToken);
response.EnsureSuccessStatusCode();
```

Repeated `Get()` calls on the same provider reuse its client. The provider owns that client; let the service container dispose the provider rather than disposing the returned instance directly.
