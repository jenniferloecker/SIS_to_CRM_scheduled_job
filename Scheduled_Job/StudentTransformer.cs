public static class StudentTransformer
{
    public static CrmStudent ToStudent(SisStudent sisStudent)
    {
        // Map properties from SisStudent to CrmStudent
        // Example mapping logic, adjust as needed
        return new CrmStudent
        {
            Id = sisStudent.Id,
            Name = sisStudent.Name
        };
    }
}