using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFilter
{
    public interface IOrderProcessor
    {
        void ProcessOrders(string filePath, string district, DateTime firstDeliveryDateTime, string resultFilePath);
    }

    public class OrderProcessor : IOrderProcessor
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderService _orderService;
        private readonly OrderValidator _orderValidator;
        private readonly IOrderLogger _orderLogger;

        public OrderProcessor(IOrderRepository orderRepository, IOrderService orderService, OrderValidator orderValidator, IOrderLogger orderLogger)
        {
            _orderRepository = orderRepository;
            _orderService = orderService;
            _orderValidator = orderValidator;
            _orderLogger = orderLogger;
        }

        public void ProcessOrders(string filePath, string district, DateTime firstDeliveryDateTime, string resultFilePath)
        {
            try
            {
                _orderLogger.LogInfo("Загрузка заказов...\n");
                var orders = _orderRepository.LoadOrders(filePath);
                List<Guid> invalidOrders = new List<Guid>(); 

                foreach (var order in orders)
                {
                    var result = _orderValidator.Validate(order);
                    if (!result.IsValid)
                    {
                        _orderLogger.LogError($"Ошибка валидации заказа {order.OrderId}: {string.Join(", ", result.Errors.Select(e => e.ErrorMessage))}\n", null);
                        invalidOrders.Add(order.OrderId); 
                        continue;
                    }
                }

                _orderLogger.LogInfo("Фильтрация заказов...\n");
                var filteredOrders = _orderService.FilterOrders(orders, district, firstDeliveryDateTime, invalidOrders);

                _orderLogger.LogInfo("Сохранение отфильтрованных заказов...\n");
                _orderRepository.SaveOrders(filteredOrders, resultFilePath);
            }
            catch (Exception ex)
            {
                _orderLogger.LogError("Ошибка при обработке заказов.\n", ex);
            }
        }
    }
}
