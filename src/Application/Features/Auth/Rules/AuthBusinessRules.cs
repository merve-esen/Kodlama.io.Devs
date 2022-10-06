using Application.Features.Auth.Constants;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Core.Security.Hashing;

namespace Application.Features.Auth.Rules
{
    public class AuthBusinessRules
    {
        private readonly IUserRepository _userRepository;

        public AuthBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task UserEmailShouldBeNotExists(string email)
        {
            User? user = await _userRepository.GetAsync(u => u.Email == email);
            if (user != null) throw new BusinessException(Messages.UserMailIsAlreadyExist);
        }

        public async Task UserShouldBeExists(User? user)
        {
            if (user == null) throw new BusinessException(Messages.UserDoesNotExist);
        }

        public async Task UserPasswordShouldBeMatch(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            bool result = HashingHelper.VerifyPasswordHash(password, passwordHash, passwordSalt);
            if (!result)
                throw new BusinessException(Messages.PasswordDoesNotMatch);

        }
    }
}
