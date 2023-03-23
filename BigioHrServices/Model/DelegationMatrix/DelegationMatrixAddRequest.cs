namespace BigioHrServices.Model.DelegationMatrix
{
    public class DelegationMatrixAddRequest
    {
        public long EmployeeId { get; set; } = 1;
        public long EmployeeBackupId { get; set; } = 1;
        public int priority { get; set; } = 1;
    }
}