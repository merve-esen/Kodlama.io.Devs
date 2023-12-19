using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ProgrammingLanguageRepository : EfRepositoryBase<ProgrammingLanguage, int, BaseDbContext>, IProgrammingLanguageRepository
{
    public ProgrammingLanguageRepository(BaseDbContext context) : base(context)
    {
    }
}