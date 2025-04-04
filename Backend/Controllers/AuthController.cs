namespace Backend.Controllers;

[ApiController, Route("api/auth")]
public class AuthController : ControllerBase
{
	[HttpPost("login")]
	public IActionResult Login(LoginRequest request)
	{
		if (request.Password == Program.Config.Password)
		{
			return Ok(new {message = "Success"});
		}

		return Unauthorized(new {message = "Invalid password"});
	}
}

public sealed class LoginRequest
{
	[JsonPropertyName("password")]
	public string Password { get; set; }
}