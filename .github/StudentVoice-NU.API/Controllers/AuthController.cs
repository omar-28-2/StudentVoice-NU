using Microsoft.AspNetCore.Mvc;
using StudentVoiceNU.Application.Interfaces.Services;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("firebase")]
    public async Task<IActionResult> AuthenticateWithFirebase([FromBody] string firebaseToken)
    {
        var nuId = await _authService.AuthenticateWithFirebaseAsync(firebaseToken);
        return Ok(new { NU_ID = nuId });
    }
    //public IActionResult GetTest()
    //{
    //    return Ok("The project is running! sherif");
    //}
}
