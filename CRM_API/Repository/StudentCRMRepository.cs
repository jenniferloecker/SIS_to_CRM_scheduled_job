public class StudentCRMRepository : IStudentCRMRepository
{
    private readonly DbContext _dbContext;

    public StudentCRMRepository(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task UpsertAsync(Student student)
    {
        // Update if record with matching Id exists, else insert
        var existing = await _dbContext.Students.FindAsync(student.Id);

        if (existing == null)
            _dbContext.Students.Add(student);
        else
            _dbContext.Entry(existing).CurrentValues.SetValues(student);

        await _dbContext.SaveChangesAsync();
    }
}