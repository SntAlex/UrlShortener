using AlexGolikov.UrlShortener.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace AlexGolikov.UrlShortener.WebApi.Filters
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ModelState.IsValid)
            {
                return;
            }

            var messages = string.Join("", context.ModelState.Values
                .SelectMany(x => x.Errors)
                .Select(x => x.ErrorMessage));
            context.Result = new BadRequestObjectResult(new ErrorDetails(messages, StatusCodes.Status400BadRequest));
        }
    }
}
