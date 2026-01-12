using System.Net.Http.Headers;
using UserTask.Tests.Infrastructure;
using Xunit;

namespace UserTask.Tests;

public abstract class ApiTestBase(TestWebAppFactory factory) : IClassFixture<TestWebAppFactory>
{
    protected readonly HttpClient Client = factory.CreateClient();

    protected async Task AuthenticateAsAdmin()
    {
        var token = await TestTokens.GetAdminToken(Client);
        Client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", token);
    }

    protected async Task AuthenticateAsUser()
    {
        var token = await TestTokens.GetUserToken(Client);
        Client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", token);
    }
}
