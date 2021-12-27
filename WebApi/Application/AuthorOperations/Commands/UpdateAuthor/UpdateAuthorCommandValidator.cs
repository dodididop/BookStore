using System;
using FluentValidation;

namespace WebApi.Application.AuthorOperations.UpdateAuthor
{
    public class UpdateAuthorCommandValidator: AbstractValidator<UpdateAuthorCommand>
    {
        public UpdateAuthorCommandValidator()
        {
            RuleFor(command => command.AuthorId).GreaterThan(0);
            RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(3);
            RuleFor(command => command.Model.Surname).NotEmpty().MinimumLength(3);
            RuleFor(command => command.Model.Birthday).NotEmpty().LessThan(DateTime.Now.Date.AddYears(-7));
        }
    }
}