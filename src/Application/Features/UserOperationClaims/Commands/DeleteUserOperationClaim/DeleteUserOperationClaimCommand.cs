using Application.Features.UserOperationClaims.Rules;
using Application.Services.Repositories;
using Core.Security.Entities;
using MediatR;

namespace Application.Features.UserOperationClaims.Commands.DeleteUserOperationClaim
{
    public class DeleteUserOperationClaimCommand : IRequest
    {
        public int Id { get; set; }

        public class DeleteUserOperationClaimCommandHandler : IRequestHandler<DeleteUserOperationClaimCommand>
        {
            private readonly IUserOperationClaimRepository _userOperationClaimRepository;
            private readonly UserOperationClaimBusinessRules _userOperationClaimBusinessRules;

            public DeleteUserOperationClaimCommandHandler(IUserOperationClaimRepository userOperationClaimRepository, UserOperationClaimBusinessRules userOperationClaimBusinessRules)
            {
                _userOperationClaimRepository = userOperationClaimRepository;
                _userOperationClaimBusinessRules = userOperationClaimBusinessRules;
            }

            public async Task<Unit> Handle(DeleteUserOperationClaimCommand request, CancellationToken cancellationToken)
            {
                UserOperationClaim? userOperationClaim = await _userOperationClaimRepository.GetAsync(u => u.Id == request.Id);

                _userOperationClaimBusinessRules.UserOperationClaimShouldExistWhenRequested(userOperationClaim);

                await _userOperationClaimRepository.DeleteAsync(userOperationClaim!);

                return Unit.Value;
            }
        }
    }
}
