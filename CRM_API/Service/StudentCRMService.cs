public class StudentCRMService : IStudentCRMService
{

    public StudentCRMService()
    {
        
    }

    public async Task UpsertStudentAsync(CrmStudent student)
    {
        //Add logic to upsert a single student into the CRM system
    }

    public async Task UpsertStudentsAsync(List<CrmStudent> students)
    {
        //Add logic to upsert each student into the CRM system
    }
}