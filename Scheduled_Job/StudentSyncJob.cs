public sealed class StudentSyncJob
{
    private readonly ISisApiClient _sisApiClient;
    private readonly ICrmApiClient _crmApiClient;

    public StudentSyncJob(ISisApiClient sisApiClient, ICrmApiClient crmApiClient)
    {
        _sisApiClient = sisApiClient;
        _crmApiClient = crmApiClient;
    }

    public async Task RunAsync(CancellationToken cancellationToken)
    {
        try
        {
            StudentSyncService syncService = new StudentSyncService(_sisApiClient, _crmApiClient);
            await syncService.SyncStudentsAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(
                $"Failed to sync students: {ex.Message}");
        }
    }
}