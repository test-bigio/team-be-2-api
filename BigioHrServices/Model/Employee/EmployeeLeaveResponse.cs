using BigioHrServices.Db.Entities;

namespace BigioHrServices.Model.Employee
{
    public class EmployeeLeaveResponse
    {
        public string NIK { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Sex { get; set; } = string.Empty;
        public DateOnly JoinDate { get; set; } = new DateOnly();
        public string WorkLength { get; set; } = string.Empty;
        public long? PositionId { get; set; }
        public Db.Entities.Position Position { get; set; }
        public bool IsActive { get; set; } = true;
        public string DigitalSignature { get; set; } = "101010";
        public List<Leave> Leaves { get; set; }
     }
}
