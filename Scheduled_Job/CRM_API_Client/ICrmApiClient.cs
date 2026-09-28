public interface ICrmApiClient
{
    Task PushStudentsAsync(List<Student> students);
}