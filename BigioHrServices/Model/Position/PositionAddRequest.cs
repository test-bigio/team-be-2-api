namespace BigioHrServices.Model.Position;

public class PositionAddRequest
{
    public string Code { get; set; } = string.Empty;
    public int Level { get; set; } = 1;
    public string Name { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;
}