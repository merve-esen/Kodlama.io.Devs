﻿using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguage;

public partial class DeleteProgrammingLanguageCommand : IRequest<DeletedProgrammingLanguageDto>
{
    public int Id { get; set; }

    public class DeleteProgrammingLanguageCommandHandler : IRequestHandler<DeleteProgrammingLanguageCommand, DeletedProgrammingLanguageDto>
    {
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
        private readonly IMapper _mapper;
        private readonly ProgrammingLanguageBusinessRules _programmingLanguageBusinessRules;

        /*public DeleteProgrammingLanguageCommandHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper, ProgrammingLanguageBusinessRules programmingLanguageBusinessRules)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
            _mapper = mapper;
            _programmingLanguageBusinessRules = programmingLanguageBusinessRules;
        }*/

        public DeleteProgrammingLanguageCommandHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper, ProgrammingLanguageBusinessRules programmingLanguageBusinessRules)
            => (_programmingLanguageRepository, _mapper, _programmingLanguageBusinessRules) = (programmingLanguageRepository, mapper, programmingLanguageBusinessRules);

        public async Task<DeletedProgrammingLanguageDto> Handle(DeleteProgrammingLanguageCommand request, CancellationToken cancellationToken)
        {
            //ProgrammingLanguage mappedProgrammingLanguage = _mapper.Map<ProgrammingLanguage>(request);
            ProgrammingLanguage? programmingLanguage = await _programmingLanguageRepository.GetAsync(p => p.Id == request.Id);

            _programmingLanguageBusinessRules.ProgrammingLanguageShouldExist(programmingLanguage);

            ProgrammingLanguage deletedProgrammingLanguage = await _programmingLanguageRepository.DeleteAsync(programmingLanguage);
            DeletedProgrammingLanguageDto deletedProgrammingLanguageDto = _mapper.Map<DeletedProgrammingLanguageDto>(deletedProgrammingLanguage);

            return deletedProgrammingLanguageDto;

        }
    }
}
