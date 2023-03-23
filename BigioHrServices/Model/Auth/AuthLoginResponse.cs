namespace BigioHrServices.Model.Auth;

public class AuthLoginResponse
{
    public string AccessToken { get; set; } = string.Empty;
    public AuthLoginResponse(string accessToken)
    {
        this.AccessToken = accessToken;
    }

}