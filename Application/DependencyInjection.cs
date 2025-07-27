using Microsoft.Extensions.DependencyInjection;
using Domain.Interfaces;
using Infrastructure.Ai;
using Infrastructure.Todoist;
using Application.UseCases;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<IChatService, ChatService>();
            services.AddTransient<ITodoistService, TodoistService>();
            services.AddScoped<ScheduleTaskHandler>();

            return services;
        }
    }
}
