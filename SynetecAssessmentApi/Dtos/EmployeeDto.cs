namespace SynetecAssessmentApi.Dtos
{
    public class EmployeeDto
    {   
        //Added Employee Id for rendering employee ids in the page when the API GET request made /api/BonusPool
        public int EmployeeId { get; set; }
        public string Fullname { get; set; }
        public string JobTitle { get; set; }
        public int Salary { get; set; }      
        public DepartmentDto Department { get; set; }
    }
}
