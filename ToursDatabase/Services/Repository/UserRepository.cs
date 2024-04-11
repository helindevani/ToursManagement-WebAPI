using System.Net;
using Microsoft.AspNetCore.Identity;
using ToursDatabase.Domain.Entities;
using ToursDatabase.Domain.Identity;
using ToursDatabase.DTO;
using ToursDatabase.ServiceContracts;
using ToursDatabase.ServiceContracts.Repository;

namespace ToursDatabase.Services.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IJwtService _jwtService;
        private readonly IConfiguration _configuration;
        private readonly IEmailSenderService _emailService;

        public UserRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IJwtService jwtService, IConfiguration configuration, IEmailSenderService emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtService = jwtService;
            _configuration = configuration;
            _emailService = emailSender;
        }

        public async Task<bool> EmailCheckRequest(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
            {
                return true;
            }
            return false;
        }

        public async Task<ForgotPasswordRequest> ForgotPasswordRequest(ForgotPasswordRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
                throw new InvalidOperationException("User not found");

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            var resetLink = $"{_configuration["AppBaseUrl"]}/resetpassword?email={request.Email}&token={WebUtility.UrlEncode(token)}";

            var message = $"Please reset your password by clicking <a href='{resetLink}'>here</a>.";

            await _emailService.SendEmailAsync(request.Email, "reset password Link", message);

            return request;
        }

        public async Task<bool> ResetPasswordRequest(ResetPasswordRequestData request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null)
                throw new InvalidOperationException("User not found");

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = await _userManager.ResetPasswordAsync(user, token, request.NewPassword);

            if (result.Succeeded)
                return true;
            else
                throw new InvalidOperationException("Failed to reset password");
        }

        public async Task<AuthenticationResponse> UserLoginRequest(LoginDTO loginDTO)
        {
            var result = await _signInManager.PasswordSignInAsync(loginDTO.Email, loginDTO.Password, isPersistent: false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                var user = await _userManager.FindByEmailAsync(loginDTO.Email);

                if (user == null)
                    throw new InvalidOperationException("User not found");

                var roles = await _userManager.GetRolesAsync(user);

                if (roles == null)
                    throw new InvalidOperationException("Something went wrong");

                var authenticationResponse = _jwtService.CreateJwtToken(user, roles.ToList());

                await _userManager.UpdateAsync(user);

                return authenticationResponse;
            }
            else
            {
                throw new InvalidOperationException("Invalid email or password");
            }
        }

        public async Task<bool> UserLogoutRequest()
        {
            await _signInManager.SignOutAsync();

            return true;
        }

        public async Task<AuthenticationResponse> UserRegisterRequest(RegisterDTO registerDTO)
        {
            var user = new ApplicationUser
            {
                Email = registerDTO.Email,
                PhoneNumber = registerDTO.PhoneNumber,
                UserName = registerDTO.Email,
                PersonName = registerDTO.PersonName
            };

            var result = await _userManager.CreateAsync(user, registerDTO.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRolesAsync(user, registerDTO.Roles);
                await _signInManager.SignInAsync(user, isPersistent: false);

                var response = _jwtService.CreateJwtToken(user, registerDTO.Roles.ToList());
                await _userManager.UpdateAsync(user);
                return response;
            }

            return null;
        }
    }
}
