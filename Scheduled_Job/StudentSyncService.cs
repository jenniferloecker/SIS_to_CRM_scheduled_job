public class StudentSyncService
{
    private readonly ISisApiClient _sisClient;
    private readonly ICrmApiClient _crmClient;
    public sealed record SyncResult(int Succeeded, List<int> FailedIds);

    public StudentSyncService(ISisApiClient sisClient, ICrmApiClient crmClient)
    {
        _sisClient = sisClient;
        _crmClient = crmClient;
    }

    public async Task<SyncResult> SyncStudentsAsync(CancellationToken cancellationToken)
    {
        // 1. Pull from SIS
        List<SisStudent> sisStudents = await _sisClient.GetStudentsAsync(cancellationToken);
        var successCount = 0;
        var failedIds = new List<int>();

        foreach (var sisStudent in sisStudents)
        {
            try
            {
                var crmStudent = StudentTransformer.ToStudent(sisStudent);

                await _crmClient.UpsertStudentAsync(crmStudent, cancellationToken);

                successCount++;
            }
            catch (StudentRejectedException ex)
            {
                failedIds.Add(sisStudent.Id);
                Console.Error.WriteLine($"Student {sisStudent.Id} rejected: {ex.Message}");
            }
        }

        // TODO: Monitoring system email or notification system
        return new SyncResult(successCount, failedIds);
    }
}