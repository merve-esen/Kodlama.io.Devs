using Application.Features.UserOperationClaims.Rules;
using Application.Services.Repositories;
using Core.Application.Pipelines.Authorization;
using Core.Security.Entities;
using MediatR;

namespace Application.Features.UserOperationClaims.Commands.DeleteUserOperationClaim;

public class DeleteUserOperationClaimCommand : IRequest, ISecuredRequest
{
    public int Id { get; set; }
    public string[] Roles { get; } = new string[1] { "admin" };

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
