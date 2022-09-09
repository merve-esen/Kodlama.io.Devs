using Application.Features.Auth.Models;
using Application.Features.Auth.Rules;
using Application.Services.Repositories;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.JWT;
using MediatR;

namespace Application.Features.Auth.Commands.Login
{
    public class LoginCommand : IRequest<LoginModel>
    {
        public UserForLoginDto UserForLoginDto { get; set; }
    }

    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginModel>
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenHelper _tokenHelper;
        private readonly AuthBusinessRules _authBusinessRules;

        public LoginCommandHandler(ITokenHelper tokenHelper, IUserRepository userRepository, AuthBusinessRules authBusinessRules)
        {
            _tokenHelper = tokenHelper;
            _userRepository = userRepository;
            _authBusinessRules = authBusinessRules;
        }

        public async Task<LoginModel> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            User? user = await _userRepository.GetAsync(c => c.Email == request.UserForLoginDto.Email);
            await _authBusinessRules.UserShouldBeExists(user);
            await _authBusinessRules.UserPasswordShouldBeMatch(user.Id, request.UserForLoginDto.Password);

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
