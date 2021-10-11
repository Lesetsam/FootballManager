using FluentValidation;
using FootballManager.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FootballManager.Application.Features.Players.Commands.CreatePlayer
{
    public class CreatePlayerCommandValidator : AbstractValidator<CreatePlayerCommand>
    {
        private readonly IPlayerRepositoryAsync _playerRepository;

        public CreatePlayerCommandValidator(IPlayerRepositoryAsync playerRepository)
        {
            this._playerRepository = playerRepository;

            RuleFor(p => p.IdNo)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                //.MaximumLength(50).WithMessage("{PropertyName} must not exceed 10 characters.")
                .MustAsync(IsUniqueIdNo).WithMessage("{PropertyName} already exists.");

            RuleFor(p => p.FirstName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.Surname)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

        }

        private async Task<bool> IsUniqueIdNo(Int64 IdNo, CancellationToken cancellationToken)
        {
            return await _playerRepository.IsUniqueIdNoAsync(IdNo);
        }
    }
}
