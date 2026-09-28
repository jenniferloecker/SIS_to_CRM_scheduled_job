public static class StudentTransformer
{
    public static CrmStudent ToStudent(SisStudent sisStudent)
    {
        // Map properties from SisStudent to CrmStudent
        return new CrmStudent
        {
            Id = sisStudent.Id,
            FirstName = sisStudent.FirstName,
            LastName = sisStudent.LastName,
            Email = sisStudent.Email
        };
    }
}