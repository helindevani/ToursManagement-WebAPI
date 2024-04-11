using ToursDatabase.Domain.Entities;
using ToursDatabase.DTO;

namespace ToursDatabase.ServiceContracts.Repository
{
    public interface IUserRepository
    {
        Task<AuthenticationResponse> UserRegisterRequest(RegisterDTO registerDTO);
        Task<bool> EmailCheckRequest(string email);
        Task<AuthenticationResponse> UserLoginRequest(LoginDTO loginDTO);
        Task<ForgotPasswordRequest> ForgotPasswordRequest(ForgotPasswordRequest request);
        Task<bool> ResetPasswordRequest(ResetPasswordRequestData request);
        Task<bool> UserLogoutRequest();
    }
}
