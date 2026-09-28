public class CrmApiClient : ICrmApiClient
{
    private readonly HttpClient _httpClient;

    public CrmApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task UpsertStudentAsync(CrmStudent student, CancellationToken cancellationToken)
    {
        var response = await _httpClient.PostAsJsonAsync("api/studentcrm", student, cancellationToken);
        response.EnsureSuccessStatusCode();
    }
}