using FluentValidation;

namespace Application.Features.Clients.Commands.UpdateClientCommand;

public class UpdateClientCommandValidator: AbstractValidator<UpdateClientCommand>
{
 public UpdateClientCommandValidator()
 {
  RuleFor(p => p.Id)
    .NotEmpty().WithMessage("{PropertyName} was not empty");

  RuleFor(p => p.FirstName)
    .NotEmpty().WithMessage("{PropertyName} was not empty")
    .MaximumLength(80).WithMessage("{PropertyName} was max length {MaxLength} characters");

  RuleFor(p => p.LastName)
    .NotEmpty().WithMessage("{PropertyName} was not empty")
    .MaximumLength(80).WithMessage("{PropertyName} was max length {MaxLength} characters");

  RuleFor(p => p.BirthDate)
    .NotEmpty().WithMessage("{PropertyName} was not empty");

  RuleFor(p => p.Phone)
    .NotEmpty().WithMessage("{PropertyName} was not empty")
    // .Matches(@"^\d{4}-\d{4}#")
    .MaximumLength(9).WithMessage("{PropertyName} was max length {MaxLength} characters");

  RuleFor(p => p.Email)
    .NotEmpty().WithMessage("{PropertyName} was not empty")
    .EmailAddress().WithMessage("{PropertyName} was valid email")
    .MaximumLength(100).WithMessage("{PropertyName} was max length {MaxLength} characters");

  RuleFor(p => p.Address)
    .NotEmpty().WithMessage("{PropertyName} was not empty")
    .MaximumLength(120).WithMessage("{PropertyName} was max length {MaxLength} characters");
 }
}
