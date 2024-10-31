using PlanItUp.Common.CustomExceptions.GenericResponsesExceptions;
using System.Data.SqlClient;
using System.Net;

namespace PlanItUp.API.Middlewares
{
    public class GlobalErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalErrorHandlingMiddleware(RequestDelegate next)
        {

            _next = next;

        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);

            }
            catch (UnauthorizedException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);

                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                await context.Response.WriteAsJsonAsync(ex.Message);
            }
            catch (ForbiddenException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);

                context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                await context.Response.WriteAsJsonAsync(ex.Message);
            }
            catch (BadRequestException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);

                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                await context.Response.WriteAsJsonAsync(ex.Message);
            }
            catch (ConflictException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);

                context.Response.StatusCode = (int)HttpStatusCode.Conflict;
                await context.Response.WriteAsJsonAsync(ex.Message);
            }
            catch (NotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);

                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                await context.Response.WriteAsJsonAsync(ex.Message);
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Exception: {ex.Message} {ex.StackTrace}");

                if (ex.Number == 547)
                {
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    await context.Response.WriteAsJsonAsync("No se puede eliminar una categoría o marca asociada a un producto");

                }

                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await context.Response.WriteAsJsonAsync("Algo salió mal. Por favor contacte al soporte.");

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);

                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await context.Response.WriteAsJsonAsync("Algo salió mal. Por favor contacte al soporte.");
            }
        }
    }
}
