using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFilter
{
    public interface IOrderService
    {
        public List<Order> FilterOrders(List<Order> orders, string district, DateTime firstDeliveryDateTime, List<Guid> invalidOrders);
    }

    public class OrderService : IOrderService
    {
        public List<Order> FilterOrders(List<Order> orders, string district, DateTime firstDeliveryDateTime, List<Guid> invalidOrders)
        {
            return orders
                .Where(o => o.District == district &&
                            o.DeliveryTime >= firstDeliveryDateTime &&
                            o.DeliveryTime <= firstDeliveryDateTime.AddMinutes(30) &&
                            !invalidOrders.Contains(o.OrderId))
                .ToList();
        }
    }
}
