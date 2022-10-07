using Application.Features.OperationClaims.Constants;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;

namespace Application.Features.OperationClaims.Rules
{
    public class OperationClaimBusinessRules
    {
        private readonly IOperationClaimRepository _operationClaimRepository;

        public OperationClaimBusinessRules(IOperationClaimRepository operationClaimRepository)
        {
            _operationClaimRepository = operationClaimRepository;
        }

        public async Task OperationClaimCanNotBeDuplicatedWhenInserted(string name)
        {
            OperationClaim? operationClaim = await _operationClaimRepository.GetAsync(o => o.Name == name);
            if (operationClaim != null) throw new BusinessException(Messages.OperationClaimIsAlreadyExist);
        }

        public void OperationClaimShouldExistWhenRequested(OperationClaim operationClaim)
        {
            if (operationClaim == null) throw new BusinessException(Messages.OperationClaimDoesNotExist);
        }
    }
}
