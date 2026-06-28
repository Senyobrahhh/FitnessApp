using FitnessApp.Application.DTOs.Auth;

namespace FitnessApp.Application.Interfaces.Services;

public interface IAuthService
{
    Task<AuthResponseDto> RegisterAsync(RegisterRequestDto request);
    
    Task<AuthResponseDto> LoginAsync(LoginRequestDto request);
}