using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFilter
{
    public static class ServiceCollectionExtensions
    {
        public static void AddServices(IServiceCollection services, string logFilePath)
        {
            services.AddSingleton<IOrderService, OrderService>();
            services.AddSingleton<IOrderRepository, OrderRepository>();
            services.AddSingleton<IOrderLogger>(provider => new OrderLogger(logFilePath));
            services.AddSingleton<OrderValidator>();
            services.AddSingleton<IOrderProcessor, OrderProcessor>();

        }
    }
}
