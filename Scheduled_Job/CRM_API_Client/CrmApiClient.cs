public class CrmApiClient : ICrmApiClient
{
    private readonly HttpClient _httpClient;

    public CrmApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task PushStudentsAsync(List<Student> students)
    {
        // POST api/students/batch on CRM_API
        var response = await _httpClient.PostAsJsonAsync("api/students/batch", students);
        response.EnsureSuccessStatusCode();
    }
}