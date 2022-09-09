using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class GithubAddressRepository : EfRepositoryBase<GithubAddress, BaseDbContext>, IGithubAddressRepository
    {
        public GithubAddressRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
