using FluentValidation;

namespace Application.Features.Clients.Commands.DeleteClientCommand;

public class DeleteClientCommandValidator: AbstractValidator<DeleteClientCommand>
{
 public DeleteClientCommandValidator()
 {
   RuleFor(p => p.ClientId).NotEmpty()
     .WithMessage("{PropertyName} was not empty");
 }
}
