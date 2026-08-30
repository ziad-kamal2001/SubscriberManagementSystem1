using SubscriberManagementSystem.Data.Models;
using SubscriberManagementSystem.Infrastructure.Services.UserPermissions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace SubscriberManagementSystem.Web.Middleware
{
    public class GeneralMiddleware
    {
        private readonly RequestDelegate _next;

        public GeneralMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, UserManager<User> userManager, IUserPermissionsService userPermissionsService)
        {
            var endpoint = context.GetEndpoint();

            if (IsAllowAnonymous(endpoint))
            {
                await _next(context);
                return;
            }

            var user = await userManager.GetUserAsync(context.User);
            if (user == null)
            {
                context.Response.StatusCode = 401; // Unauthorized
                await context.Response.WriteAsync("You are not authenticated.");
                return;
            }

            var routeValuesFeature = context.Features.Get<Microsoft.AspNetCore.Http.Features.IRouteValuesFeature>();

            if (routeValuesFeature?.RouteValues != null)
            {
                var controllerName = routeValuesFeature.RouteValues["controller"]?.ToString();
                var actionName = routeValuesFeature.RouteValues["action"]?.ToString();

                if (controllerName != null && actionName != null)
                {
                    var url = $"{controllerName}/{actionName}".Trim('/').ToLower();

                    if (!await userPermissionsService.HasPermissionAsync(user, url))
                    {
                        context.Response.StatusCode = 403; // Forbidden
                        await context.Response.WriteAsync("You do not have permission to access this resource.");
                        return;
                    }
                }
            }

            await _next(context);
        }

        private static bool IsAllowAnonymous(Endpoint endpoint)
        {
            return endpoint?.Metadata?.GetMetadata<IAllowAnonymous>() != null;
        }

    }
}
