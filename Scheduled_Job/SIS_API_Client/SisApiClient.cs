public class SisApiClient : ISisApiClient
{
    private readonly HttpClient _httpClient;

    public SisApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Student>> GetStudentsAsync()
    {
        // GET api/students on SIS_Rest_API
        var response = await _httpClient.GetAsync("api/students");
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<List<Student>>();
    }
}