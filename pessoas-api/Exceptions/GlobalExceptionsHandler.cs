using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace pessoas_api.Exceptions
{
    public class GlobalExceptionsHandler : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            Exception exception = context.Exception;
            ErrorResponse response = new();
            
            switch (exception)
            {
                case BusinessRuleException:
                case MultipleMainAddressException:
                case ArgumentException:
                    response.Errors = new List<string> { exception.Message };
                    context.Result = new ObjectResult(response)
                    {
                        StatusCode = (int) System.Net.HttpStatusCode.UnprocessableEntity
                    };
                    break;
                case NotFoundException:
                    context.Result = new ObjectResult(null)
                    {
                        StatusCode = (int)System.Net.HttpStatusCode.NotFound
                    };
                    break;
                default:
                    response.Errors = new List<string> { "An unexpected error occurred." };
                    context.Result = new ObjectResult(response)
                    {
                        StatusCode = (int) System.Net.HttpStatusCode.InternalServerError
                    };
                    break;
            }

            context.ExceptionHandled = true;
        }
    }

}
