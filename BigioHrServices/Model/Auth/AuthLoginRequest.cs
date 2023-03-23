namespace BigioHrServices.Model.Auth;

public class AuthLoginRequest
{
    public string NIK { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}