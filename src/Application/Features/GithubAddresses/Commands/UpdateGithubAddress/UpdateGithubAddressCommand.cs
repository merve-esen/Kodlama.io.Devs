using Application.Features.GithubAddresses.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.GithubAddresses.Commands.UpdateGithubAddress
{
    public class UpdateGithubAddressCommand : IRequest<UpdatedGithubAddressDto>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
    }

    public class UpdateGithubAddressCommandHandler : IRequestHandler<UpdateGithubAddressCommand, UpdatedGithubAddressDto>
    {
        private readonly IMapper _mapper;
        private readonly IGithubAddressRepository _githubAddressRepository;

        public UpdateGithubAddressCommandHandler(IMapper mapper, IGithubAddressRepository githubAddressRepository)
        {
            _mapper = mapper;
            _githubAddressRepository = githubAddressRepository;
        }

        public async Task<UpdatedGithubAddressDto> Handle(UpdateGithubAddressCommand request, CancellationToken cancellationToken)
        {
            GithubAddress mappedGithubAddress = _mapper.Map<GithubAddress>(request);
            GithubAddress updateGithubAddress = await _githubAddressRepository.UpdateAsync(mappedGithubAddress);
            UpdatedGithubAddressDto updatedGithubAddressDto = _mapper.Map<UpdatedGithubAddressDto>(updateGithubAddress);
            return updatedGithubAddressDto;
        }
    }
}
