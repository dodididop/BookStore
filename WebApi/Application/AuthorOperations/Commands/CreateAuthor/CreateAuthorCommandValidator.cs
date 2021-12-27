using System;
using FluentValidation;
using WebApi.Application.AuthorOperations.Commands.CreateAuthor;

namespace WebApi.Application.AuthorOperations.GetAuthors
{
    public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorCommandValidator()
        {
            RuleFor(command => command.Model.Birthday).NotEmpty().LessThan(DateTime.Now.Date.AddYears(-7));
            RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(3);
            RuleFor(command => command.Model.Surname).NotEmpty().MinimumLength(3);
        }
    }
}