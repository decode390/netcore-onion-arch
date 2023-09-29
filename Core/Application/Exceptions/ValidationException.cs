﻿using System;
using System.Collections.Generic;
using FluentValidation.Results;

namespace Application.Exceptions
{
    public class ValidationException: Exception
    {
      public List<string> Errors{get;}
      public ValidationException(): base("Se han producido uno o más errores de validación")
      {
        Errors = new List<string>();
      } 

      public ValidationException(IEnumerable<ValidationFailure> failures): this()
      {
        foreach (var failure in failures)
        {
          Errors.Add(failure.ErrorMessage); 
        } 
      }
    }
}
