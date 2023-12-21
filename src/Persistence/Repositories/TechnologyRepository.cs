using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class TechnologyRepository : EfRepositoryBase<Technology, int, BaseDbContext>, ITechnologyRepository
{
    public TechnologyRepository(BaseDbContext context) : base(context)
    {
    }
}
