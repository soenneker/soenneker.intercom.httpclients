using Soenneker.Intercom.HttpClients.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Intercom.HttpClients.Tests;

[Collection("Collection")]
public sealed class IntercomOpenApiHttpClientTests : FixturedUnitTest
{
    private readonly IIntercomOpenApiHttpClient _httpclient;

    public IntercomOpenApiHttpClientTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _httpclient = Resolve<IIntercomOpenApiHttpClient>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
