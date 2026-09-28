public class SisApiClient : ISisApiClient
{
    private readonly HttpClient _httpClient;

    public SisApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<SisStudent>> GetStudentsAsync(CancellationToken cancellationToken)
    {
        // GET api/students on SIS_Rest_API
        var response = await _httpClient.GetAsync("api/students", cancellationToken);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<List<SisStudent>>(cancellationToken: cancellationToken);
    }
}