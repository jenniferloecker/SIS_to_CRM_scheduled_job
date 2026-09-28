public interface IStudentCRMService
{
    Task UpsertStudentAsync(Student student);
    Task UpsertStudentsAsync(List<Student> students);
}
