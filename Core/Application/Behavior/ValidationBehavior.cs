﻿using MediatR;
using FluentValidation;

namespace Application.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse>: IPipelineBehavior<TRequest, TResponse> where TRequest: IRequest<TResponse>
    {
      private readonly IValidator<TRequest> _validator;

      public ValidationBehavior(IValidator<TRequest> validator){
        _validator = validator;
      }

      public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken){
        var validationResult = await _validator.ValidateAsync(request);

        if (!validationResult.IsValid)
        {
          throw new Exceptions.ValidationException(validationResult.Errors); 
        }
        return await next();
      } 
    }
}
