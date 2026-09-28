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

}