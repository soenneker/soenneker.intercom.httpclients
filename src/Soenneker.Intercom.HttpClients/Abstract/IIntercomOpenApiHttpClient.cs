using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;

namespace Soenneker.Intercom.HttpClients.Abstract;

/// <summary>
/// Provides a cached HTTP client authenticated for Intercom's API.
/// </summary>
public interface IIntercomOpenApiHttpClient: IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Gets the authenticated Intercom HTTP client.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task containing the configured client.</returns>
    ValueTask<HttpClient> Get(CancellationToken cancellationToken = default);
}
