using Soenneker.Intercom.HttpClients.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Intercom.HttpClients.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class IntercomOpenApiHttpClientTests : HostedUnitTest
{
    private readonly IIntercomOpenApiHttpClient _httpclient;

    public IntercomOpenApiHttpClientTests(Host host) : base(host)
    {
        _httpclient = Resolve<IIntercomOpenApiHttpClient>(true);
    }

    [Test]
    public void Default()
    {

    }
}
