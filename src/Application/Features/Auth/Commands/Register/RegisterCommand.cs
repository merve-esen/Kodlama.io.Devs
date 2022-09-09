using Application.Features.Auth.Models;
using Application.Features.Auth.Rules;
using Application.Services.Repositories;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using MediatR;

namespace Application.Features.Auth.Commands.Register
{
    public class RegisterCommand : IRequest<RegisterModel>
    {
        public UserForRegisterDto UserForRegisterDto { get; set; }
    }

    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisterModel>
    {
        private readonly ITokenHelper _tokenHelper;
        private readonly IUserRepository _userRepository;
        private readonly AuthBusinessRules _authBusinessRules;

        public RegisterCommandHandler(ITokenHelper tokenHelper, IUserRepository userRepository, AuthBusinessRules authBusinessRules)
        {
            _tokenHelper = tokenHelper;
            _userRepository = userRepository;
            _authBusinessRules = authBusinessRules;
        }

        public async Task<RegisterModel> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            await _authBusinessRules.UserEmailShouldBeNotExists(request.UserForRegisterDto.Email);

            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(request.UserForRegisterDto.Password, out passwordHash, out passwordSalt);
            User user = new User
            {
                Email = request.UserForRegisterDto.Email,
                FirstName = request.UserForRegisterDto.FirstName,
                LastName = request.UserForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            User addedUser = await _userRepository.AddAsync(user);

            var claims = _userRepository.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims);

            return new()
            {
                Expiration = accessToken.Expiration,
                Token = accessToken.Token
            };
        }
    }
}
