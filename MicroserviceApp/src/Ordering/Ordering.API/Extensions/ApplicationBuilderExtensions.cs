using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Ordering.API.RabbitMQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ordering.API.Extensions
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ApplicationBuilderExtensions
    {
        private readonly RequestDelegate _next;

        public ApplicationBuilderExtensions(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {

            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class UseRabbitListnerExtensions
    {
        public static EventBusRabbitMQConsumer Listner { get; set; }
        public static IApplicationBuilder UseUseRabbitListner(this IApplicationBuilder builder)
        {
            Listner = builder.ApplicationServices.GetService<EventBusRabbitMQConsumer>();
            var life = builder.ApplicationServices.GetService<IHostApplicationLifetime>();

            life.ApplicationStarted.Register(OnStarted);
            life.ApplicationStopping.Register(OnStopping);

            return builder;
        }

        private static void OnStarted()
        {
            Listner.Consume();
        }

        private static void OnStopping()
        {
            Listner.Disconnect();
        }
    }
}
