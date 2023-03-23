namespace BigioHrServices.Model.LeaveApplication
{
    public class ReviewRequest
    {
        public bool IsApproved { get; set; }
        public string DigitalSignature { get; set; } = string.Empty;
    }
}
