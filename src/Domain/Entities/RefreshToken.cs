namespace Domain.Entities;

public class RefreshToken : Core.Security.Entities.RefreshToken<Guid, Guid>
{
    public virtual User User { get; set; } = default!;
}