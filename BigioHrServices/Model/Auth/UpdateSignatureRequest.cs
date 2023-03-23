namespace BigioHrServices.Model.Auth;

public class UpdateSignatureRequest
{
    public string NIK { get; set; } = string.Empty;
    public string lastSignature { get; set; } = string.Empty;
    public string newSignature { get; set; } = string.Empty;
}