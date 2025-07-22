using Microsoft.Extensions.DependencyInjection;
using Application.Abstractions;
using Application.Services;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<IChatService, ChatService>();

            return services;
        }
    }
}
