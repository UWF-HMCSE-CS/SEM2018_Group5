using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TUTORized.Services;
using TUTORized.Services.Abstract;

namespace TUTORized.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddEmailServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            MessageService.SendGridApiKey = configuration.GetSection("SendGrid")["ApiKey"];
            MessageService.SendGridTutorizedTemplate = configuration.GetSection("SendGrid")["TutorizedTemplate"];
            services.AddTransient<IMessageService, MessageService>();
            return services;
        }
    }
}
