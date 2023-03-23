namespace BigioHrServices.Model.Auth;

public class AddSignatureRequest
{
    public string NIK { get; set; } = string.Empty;
    public string newSignature { get; set; } = string.Empty;
}