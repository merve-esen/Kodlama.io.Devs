namespace Domain.Entities;

public class OtpAuthenticator : Core.Security.Entities.OtpAuthenticator<Guid>
{
    public virtual User User { get; set; } = default!;
}