namespace BigioHrServices.Model.DelegationMatrix
{
    public class DelegationMatrixResponse : BaseModelResponse
    {
        public long id { get; set; } = 0;
        public Db.Entities.Employee Employee { get; set; } = new Db.Entities.Employee();
        public Db.Entities.Employee EmployeeBackup { get; set; } = new Db.Entities.Employee();
        public int priority { get; set; } = 1;
    }
}