using Core.Persistence.Repositories;

namespace Domain.Entities;

public class ProgrammingLanguage : Entity<int>
{
    public string Name { get; set; }

    public ProgrammingLanguage()
    {
    }

    public ProgrammingLanguage(int id, string name) : this()
    {
        Id = id;
        Name = name;
    }
}
