public interface IStudentCRMRepository
{
    Task UpsertAsync(Student student);
}
