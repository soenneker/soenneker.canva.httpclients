using Soenneker.Canva.HttpClients.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Canva.HttpClients.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class CanvaOpenApiHttpClientTests : HostedUnitTest
{
    private readonly ICanvaOpenApiHttpClient _httpclient;

    public CanvaOpenApiHttpClientTests(Host host) : base(host)
    {
        _httpclient = Resolve<ICanvaOpenApiHttpClient>(true);
    }

    [Test]
    public void Default()
    {

    }
}
