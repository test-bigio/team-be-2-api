namespace BigioHrServices.Model;

public class BaseModelResponse
{
    public long? CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public long? UpdatedBy { get; set; }
    public DateTime? UpdatedDate { get; set; }
}