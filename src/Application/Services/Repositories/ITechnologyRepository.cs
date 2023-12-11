using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories;

public interface ITechnologyRepository : IAsyncRepository<Technology, int>, IRepository<Technology, int>
{

}
