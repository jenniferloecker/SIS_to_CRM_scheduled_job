public class StudentCRMService : IStudentCRMService
{
    private readonly IStudentCRMRepository _repository;

    public StudentCRMService(IStudentCRMRepository repository)
    {
        _repository = repository;
    }

    public async Task UpsertStudentAsync(Student student)
    {
        await _repository.UpsertAsync(student);
    }

    public async Task UpsertStudentsAsync(List<Student> students)
    {
        foreach (var student in students)
        {
            await _repository.UpsertAsync(student);
        }
    }
}