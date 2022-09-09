using Application.Features.GithubAddresses.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.GithubAddresses.Models
{
    public class GithubAddressListModel : BasePageableModel
    {
        public IList<GithubAddressListDto> Items { get; set; }
    }
}
