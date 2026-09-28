[ApiController]
[Route("api/[controller]")]
public class StudentCRMController : ControllerBase
{
    private readonly IStudentCRMService _crmService;

    public StudentCRMController(IStudentCRMService crmService)
    {
        _crmService = crmService;
    }

    [HttpPost]
    public async Task<IActionResult> UpsertStudent([FromBody] CrmStudent student)
    {
        if (student == null)
            return BadRequest("Student payload is required");

        await _crmService.UpsertStudentAsync(student);

        return Ok();
    }

    [HttpPost("batch")]
    public async Task<IActionResult> UpsertStudents([FromBody] List<CrmStudent> students)
    {
        if (students == null || students.Count == 0)
            return BadRequest("At least one student is required");

        await _crmService.UpsertStudentsAsync(students);

        return Ok();
    }
}