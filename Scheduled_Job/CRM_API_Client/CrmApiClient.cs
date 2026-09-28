public class CrmApiClient : ICrmApiClient
{
    private readonly HttpClient _httpClient;

    public CrmApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task UpsertStudentAsync(Student student, CancellationToken cancellationToken)
    {
        var response = await _httpClient.PostAsJsonAsync("api/students", student, cancellationToken);
        response.EnsureSuccessStatusCode();
    }

    public async Task PushStudentsAsync(List<Student> students, CancellationToken cancellationToken)
    {
        // POST api/students/batch on CRM_API
        var response = await _httpClient.PostAsJsonAsync("api/students/batch", students, cancellationToken);
        response.EnsureSuccessStatusCode();
    }
}