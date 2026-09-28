public interface ISisApiClient
{
    Task<List<SisStudent>> GetStudentsAsync(CancellationToken cancellationToken);
}
