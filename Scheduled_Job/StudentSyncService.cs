public class StudentSyncService : IStudentSyncService
{
    private readonly ISisApiClient _sisClient;
    private readonly ICrmApiClient _crmClient;

    public StudentSyncService(ISisApiClient sisClient, ICrmApiClient crmClient)
    {
        _sisClient = sisClient;
        _crmClient = crmClient;
    }

    public async Task SyncStudentsAsync()
    {
        // 1. Pull from SIS
        List<Student> sisStudents = await _sisClient.GetStudentsAsync();

        if (sisStudents == null || sisStudents.Count == 0)
            return;

        // 2. Transform to CRM shape
        List<Student> crmStudents = sisStudents
            .Select(StudentTransformer.ToStudent)
            .ToList();

        // 3. Push to CRM
        await _crmClient.PushStudentsAsync(crmStudents);
    }
}