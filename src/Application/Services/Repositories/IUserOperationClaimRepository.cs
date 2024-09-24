using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories;

public interface IUserOperationClaimRepository : IAsyncRepository<UserOperationClaim, Guid>, IRepository<UserOperationClaim, Guid>
{
    Task<IList<OperationClaim>> GetOperationClaimsByUserIdAsync(Guid userId);
}
