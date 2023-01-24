using Application.Features.OperationClaims.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.OperationClaims.Models;

public class OperationClaimListModel : BasePageableModel
{
    public List<OperationClaimListDto>? Items { get; set; }
}
