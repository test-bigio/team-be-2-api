namespace BigioHrServices.Model.Employee
{
    public class LeaveAddRequest
    {
        public string TaskDetail { get; set; } = string.Empty;
        public string LeaveDate { get; set; }
        public long EmployeeId { get; set; }
    }
}
