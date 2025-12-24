using MediatR;
using OfflineTicketingSystem.Application.Auth.Commands;
using OfflineTicketingSystem.Application.Auth.DTOs;
using OfflineTicketingSystem.Application.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace OfflineTicketingSystem.Application.Auth.Handlers
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponseDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtService _jwtService;
        private readonly PasswordHasher<object> _passwordHasher;

        public LoginCommandHandler(IUserRepository userRepository, IJwtService jwtService)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
            _passwordHasher = new PasswordHasher<object>();
        }
        public async Task<LoginResponseDto> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email);
            if (user == null) throw new UnauthorizedAccessException("Invalid Credentials");
            var result = _passwordHasher.VerifyHashedPassword(null!, user.PasswordHash, request.Password);
            if (result == PasswordVerificationResult.Failed)
                throw new UnauthorizedAccessException("Invalid Credentials");
            var token = _jwtService.GenerateToken(user);
            return new LoginResponseDto { Token = token, Expiration = DateTime.UtcNow.AddHours(2) };
        }
    }
}
