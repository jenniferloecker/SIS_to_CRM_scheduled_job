public interface ICrmApiClient
{
    Task UpsertStudentAsync(CrmStudent student, CancellationToken cancellationToken);
}