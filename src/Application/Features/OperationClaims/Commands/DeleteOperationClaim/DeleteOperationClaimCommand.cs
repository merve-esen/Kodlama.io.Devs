﻿using Application.Features.OperationClaims.Dtos;
using Application.Features.OperationClaims.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Security.Entities;
using MediatR;

namespace Application.Features.OperationClaims.Commands.DeleteOperationClaim;

public class DeleteOperationClaimCommand : IRequest<DeletedOperationClaimDto>, ISecuredRequest
{
    public int Id { get; set; }
    public string[] Roles { get; } = new string[1] { "admin" };

    public class DeleteOperationClaimCommandHandler : IRequestHandler<DeleteOperationClaimCommand, DeletedOperationClaimDto>
    {
        private readonly IOperationClaimRepository _operationClaimRepository;
        private readonly IMapper _mapper;
        private readonly OperationClaimBusinessRules _operationClaimBusinessRules;

        public DeleteOperationClaimCommandHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper, OperationClaimBusinessRules operationClaimBusinessRules)
        {
            _operationClaimRepository = operationClaimRepository;
            _mapper = mapper;
            _operationClaimBusinessRules = operationClaimBusinessRules;
        }

        public async Task<DeletedOperationClaimDto> Handle(DeleteOperationClaimCommand request, CancellationToken cancellationToken)
        {
            OperationClaim? operationClaim = await _operationClaimRepository.GetAsync(o => o.Id == request.Id);

            _operationClaimBusinessRules.OperationClaimShouldExistWhenRequested(operationClaim);

            OperationClaim deletedOperationClaim = await _operationClaimRepository.DeleteAsync(operationClaim!);
            DeletedOperationClaimDto deletedOperationClaimDto = _mapper.Map<DeletedOperationClaimDto>(deletedOperationClaim);

            return deletedOperationClaimDto;
        }
    }
}
