namespace BigioHrServices.Model.Auth;

public class ResetPassword
{
    public string NIK { get; set; } = string.Empty;
    public string password { get; set; } = string.Empty;
}