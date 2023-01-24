using Application.Features.GithubAddresses.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.GithubAddresses.Queries.GetByUserIdGithubAddress;

public class GetByUserIdGithubAddressQuery : IRequest<GithubAddressGetByUserIdDto>
{
    public int UserId { get; set; }
}

public class GetByUserIdGithubAddressQueryHandler : IRequestHandler<GetByUserIdGithubAddressQuery, GithubAddressGetByUserIdDto>
{
    private readonly IMapper _mapper;
    private readonly IGithubAddressRepository _githubAddressRepository;

    public GetByUserIdGithubAddressQueryHandler(IMapper mapper, IGithubAddressRepository githubAddressRepository)
    {
        _mapper = mapper;
        _githubAddressRepository = githubAddressRepository;
    }

    public async Task<GithubAddressGetByUserIdDto> Handle(GetByUserIdGithubAddressQuery request, CancellationToken cancellationToken)
    {
        GithubAddress? githubAddress = await _githubAddressRepository.GetAsync(x => x.UserId == request.UserId);
        GithubAddressGetByUserIdDto githubAddressGetByUserIdDto = _mapper.Map<GithubAddressGetByUserIdDto>(githubAddress);
        return githubAddressGetByUserIdDto;
    }
}
