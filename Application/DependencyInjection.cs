using Microsoft.Extensions.DependencyInjection;
using Domain.Interfaces;
using Infrastructure.Ai;

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
