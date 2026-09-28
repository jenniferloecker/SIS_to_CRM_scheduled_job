public sealed class StudentSyncJob
{
    private readonly StudentSyncService _syncService;

    public StudentSyncJob(StudentSyncService syncService)
    {
        _syncService = syncService;
    }

    public async Task RunAsync(CancellationToken cancellationToken)
    {
        try
        {
            var result = await _syncService.SyncStudentsAsync(cancellationToken);
        
            Console.WriteLine(
                $"Sync finished: {result.Succeeded} succeeded; " +
                $"{result.FailedIds.Count} failed.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(
                $"Failed to sync students: {ex.Message}");
            throw;
        }
    }
}