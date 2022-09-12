using Application.Features.ProgrammingLanguages.Constants;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.ProgrammingLanguages.Rules
{
    public class ProgrammingLanguageBusinessRules
    {
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;

        public ProgrammingLanguageBusinessRules(IProgrammingLanguageRepository programmingLanguageRepository)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
        }

        public async Task ProgrammingLanguageNameCanNotBeDuplicatedWhenInserting(string name)
        {
            IPaginate<ProgrammingLanguage> result = await _programmingLanguageRepository.GetListAsync(p => p.Name == name);
            if (result.Items.Any()) throw new BusinessException(Messages.ProgrammingLanguageNameIsAlreadyExist);
        }

        public void ProgrammingLanguageShouldExist(ProgrammingLanguage programmingLanguage)
        {
            if (programmingLanguage == null) throw new BusinessException(Messages.ProgrammingLanguageNameDoesNotExist);
        }

        public async Task ProgrammingLanguageNameCanNotBeDuplicatedWhenUpdating(int id, string name)
        {
            IPaginate<ProgrammingLanguage> result = await _programmingLanguageRepository.GetListAsync(p => p.Id != id && p.Name == name);
            if (result.Items.Any()) throw new BusinessException(Messages.ProgrammingLanguageNameIsAlreadyExist);
        }
    }
}