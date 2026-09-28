[ApiController]
[Route("api/[controller]")]
public class StudentSISController : ControllerBase
{
    private readonly IStudentSISService _studentSISService;

    public StudentSISController(IStudentSISService studentSISService)
    {
        _studentSISService = studentSISService;
    }

    // GET api/students
    [HttpGet]
    public IActionResult GetStudents()
    {
        // 1. Fetch student records from data source
        List<SisStudent> students = _studentSISService.GetAllStudents();

        // 2. Return 404 if none found, else 200 with list
        if (students == null || students.Count == 0)
            return NotFound("No students found");

        return Ok(students);
    }
}