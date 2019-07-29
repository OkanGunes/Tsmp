using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Tsmp.User.API.Filters
{
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is ValidationException validationException)
            {
                context.HttpContext.Response.ContentType = "application/json";
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Result = new JsonResult(GetValidateExpcetionFailures(validationException));
                return;
            }

            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        }

        public Dictionary<string, string[]> GetValidateExpcetionFailures(ValidationException validationException)
        {
            var failures = new Dictionary<string, string[]>();

            var propertyNames = validationException.Errors
                .Select(e => e.PropertyName)
                .Distinct();

            foreach (var propertyName in propertyNames)
            {
                var propertyFailures = validationException.Errors
                    .Where(e => e.PropertyName == propertyName)
                    .Select(e => e.ErrorMessage)
                    .ToArray();

                failures.Add(propertyName, propertyFailures);
            }

            return failures;
        }
    }
}
