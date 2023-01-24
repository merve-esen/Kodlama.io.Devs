using FluentValidation;

namespace Application.Features.OperationClaims.Commands.UpdateOperationClaim;

public class UpdateOperationClaimCommandValidator : AbstractValidator<UpdateOperationClaimCommand>
{
    public UpdateOperationClaimCommandValidator()
    {
        RuleFor(o => o.Id).NotNull().GreaterThanOrEqualTo(0);
        RuleFor(o => o.Name).NotEmpty();
    }
}
