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
        
        //handle a validation error from the CRM API
        if (response.StatusCode == HttpStatusCode.UnprocessableEntity)
        {
            throw new StudentRejectedException(
                $"CRM rejected student {student.Id} due to validation.");
        }

        response.EnsureSuccessStatusCode();
    }
}