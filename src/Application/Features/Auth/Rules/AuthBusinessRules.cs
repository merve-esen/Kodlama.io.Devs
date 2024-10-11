using Application.Features.Auth.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Hashing;
using Domain.Entities;

namespace Application.Features.Auth.Rules;

public class AuthBusinessRules : BaseBusinessRules
{
    private readonly IUserRepository _userRepository;

    public AuthBusinessRules(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task UserEmailShouldBeNotExists(string email)
    {
        User? user = await _userRepository.GetAsync(u => u.Email == email);
        if (user != null) throw new BusinessException(AuthMessages.UserMailIsAlreadyExist);
    }

    public async Task UserShouldBeExists(User? user)
    {
        if (user == null) throw new BusinessException(AuthMessages.UserDoesNotExist);
    }

    public async Task UserPasswordShouldBeMatch(string password, byte[] passwordHash, byte[] passwordSalt)
    {
        bool result = HashingHelper.VerifyPasswordHash(password, passwordHash, passwordSalt);
        if (!result)
            throw new BusinessException(AuthMessages.PasswordDoesNotMatch);

    }
}
