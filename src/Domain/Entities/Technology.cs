using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Technology : Entity<int>
{
    public int ProgrammingLanguageId { get; set; }
    public string Name { get; set; }

    public virtual ProgrammingLanguage ProgrammingLanguage { get; set; }

    public Technology()
    {
        Name = string.Empty;
    }

    public Technology(int id, int programmingLanguageId, string name) : this()
    {
        Id = id;    
        ProgrammingLanguageId = programmingLanguageId;
        Name = name;
    }
}
