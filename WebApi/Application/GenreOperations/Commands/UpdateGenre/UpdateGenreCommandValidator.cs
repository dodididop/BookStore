using System;
using System.Linq;
using AutoMapper;
using FluentValidation;
using WebApi.DbOperations;

namespace WebApi.Application.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommandValidator : AbstractValidator<UpdateGenreCommand> 
    {
        public UpdateGenreCommandValidator()
        {
            RuleFor(command => command.Model.Name).MinimumLength(4).When(x=>x.Model.Name.Trim()!= string.Empty);//koşul ile minlen verildi.
        }
    }
}