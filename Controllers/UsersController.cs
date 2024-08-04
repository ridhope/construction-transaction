using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    private readonly PasswordService _passwordService;
    private readonly ILogger<UsersController> _logger;

    public UsersController(IUserRepository userRepository, PasswordService passwordService, ILogger<UsersController> logger)
    {
        _userRepository = userRepository;
        _passwordService = passwordService;
        _logger = logger;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var user = await _userRepository.GetUserByUsernameAsync(request.Username);

        // Log the user.PasswordHash and request.Password
        _logger.LogInformation("User PasswordHash: {PasswordHash}", user?.PasswordHash);
        _logger.LogInformation("Request Password: {Password}", request.Password);

        if (user == null || !_passwordService.VerifyPassword(user.PasswordHash, request.Password))
        {
            return Unauthorized(new { message = "Invalid username or password" });
        }

        await _userRepository.AddLoginHistoryAsync(user.UserID);

        return Ok(new { message = "Login successful", userId = user.UserID });
    }

    [HttpPost("hash-password")]
    public IActionResult HashPassword([FromBody] HashPasswordRequest request)
    {
        _logger.LogInformation("Fetching login history for user ID: ");
        if (string.IsNullOrEmpty(request.Password))
        {
            return BadRequest(new { message = "Password cannot be empty" });
        }

        var hashedPassword = _passwordService.HashPassword(request.Password);
        return Ok(new { hashedPassword });
    }

    [HttpGet("login-history/{userId}")]
    public async Task<IActionResult> GetLoginHistory(Guid userId)
    {
        _logger.LogInformation("Fetching login history for user ID: {UserId}", userId);
        var loginHistory = await _userRepository.GetLoginHistoryByUserIdAsync(userId);
        return Ok(loginHistory);
    }
}

public class LoginRequest
{
    public string Username { get; set; }
    public string Password { get; set; }
}

public class HashPasswordRequest
{
    public string Password { get; set; }
}