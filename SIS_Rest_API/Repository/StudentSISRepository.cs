public class StudentSISRepository : IStudentSISRepository
{
    private readonly DbContext _dbContext;

    public StudentSISRepository(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<Student> GetAll()
    {
        // Query database for all student rows
        return _dbContext.Students.ToList();
    }
}