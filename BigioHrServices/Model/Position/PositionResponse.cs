namespace BigioHrServices.Model.Position;

public class PositionResponse: BaseModelResponse
{
    public long Id { get; set; }
    public string Code { get; set; }
    public int Level { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }
}