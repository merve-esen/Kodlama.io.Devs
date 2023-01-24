namespace Application.Features.UserOperationClaims.Dtos;

public class UserOperationClaimGetByUserIdDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int OperationClaimId { get; set; }
    public string Name { get; set; }
}
