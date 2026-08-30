using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;

namespace Soenneker.Canva.HttpClients.Abstract;

/// <summary>
/// Provides a cached <see cref="HttpClient"/> configured for Canva's Connect API.
/// </summary>
public interface ICanvaOpenApiHttpClient: IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Gets the configured client.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task containing the configured client.</returns>
    ValueTask<HttpClient> Get(CancellationToken cancellationToken = default);
}
