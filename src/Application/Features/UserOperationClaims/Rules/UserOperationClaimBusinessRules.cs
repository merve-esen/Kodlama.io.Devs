using Application.Features.UserOperationClaims.Constants;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;

namespace Application.Features.UserOperationClaims.Rules
{
    public class UserOperationClaimBusinessRules
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;

        public UserOperationClaimBusinessRules(IUserOperationClaimRepository userOperationClaimRepository)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
        }

        public async Task UserOperationClaimCanNotBeDuplicatedWhenInserted(int userId, int operationClaimId)
        {
            UserOperationClaim? userUperationClaim = await _userOperationClaimRepository.GetAsync(u => u.UserId == userId && u.OperationClaimId == operationClaimId);
            if (userUperationClaim != null) throw new BusinessException(UserOperationClaimMessages.UserOperationClaimIsAlreadyExist);
        }

        public void UserOperationClaimShouldExistWhenRequested(UserOperationClaim userOperationClaim)
        {
            if (userOperationClaim == null) throw new BusinessException(UserOperationClaimMessages.UserOperationClaimDoesNotExist);
        }
    }
}
