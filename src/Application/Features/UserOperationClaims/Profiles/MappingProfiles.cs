using Application.Features.UserOperationClaims.Commands.CreateUserOperationClaim;
using Application.Features.UserOperationClaims.Dtos;
using Application.Features.UserOperationClaims.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;

namespace Application.Features.UserOperationClaims.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<UserOperationClaim, CreateUserOperationClaimCommand>().ReverseMap();
        CreateMap<UserOperationClaim, CreatedUserOperationClaimDto>().ReverseMap();
        CreateMap<UserOperationClaim, UserOperationClaimGetByUserIdDto>().ReverseMap();
        CreateMap<IPaginate<UserOperationClaim>, UserOperationClaimGetByUserIdModel>().ReverseMap();
    }
}
