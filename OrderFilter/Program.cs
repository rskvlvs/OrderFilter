
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using OrderFilter;

const string filterParamsFilePath = "FilterParams.json";
const string ordersFilePath = "orders.json";

var jsondata = File.ReadAllText(filterParamsFilePath);
var orderParams = JsonConvert.DeserializeObject<OrderFilterParams>(jsondata);

if (!DateTime.TryParse(orderParams.firstDeliveryDateTimeStr, out DateTime firstDeliveryDateTime))
{
    Console.WriteLine("Некорректный формат времени для первого заказа.");
    return;
}

IServiceCollection service = new ServiceCollection(); 
ServiceCollectionExtensions.AddServices(service, orderParams.logFilePath);

var serviceProvider = service.BuildServiceProvider(); 

var orderProcessor = serviceProvider.GetService<IOrderProcessor>();

if(orderProcessor != null)
    orderProcessor.ProcessOrders(ordersFilePath, orderParams.district, firstDeliveryDateTime, orderParams.resultFilePath);
else
    Console.WriteLine("Не удалось получить сервис OrderProcessor.");