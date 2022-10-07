using Application.Features.UserOperationClaims.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.UserOperationClaims.Models
{
    public class UserOperationClaimGetByUserIdModel : BasePageableModel
    {
        public List<UserOperationClaimGetByUserIdDto>? Items { get; set; }
    }
}
