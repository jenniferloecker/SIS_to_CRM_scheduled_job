public class StudentSISService : IStudentSISService
{
    private readonly IStudentSISRepository _repository;

    public StudentSISService(IStudentSISRepository repository)
    {
        _repository = repository;
    }

    public List<Student> GetAllStudents()
    {
        return _repository.GetAll();
    }
}