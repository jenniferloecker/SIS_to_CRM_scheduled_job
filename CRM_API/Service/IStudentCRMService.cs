public interface IStudentCRMService
{
    Task UpsertStudentAsync(CrmStudent student);
    Task UpsertStudentsAsync(List<CrmStudent> students);
}
