using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace OrderFilter
{
    public interface IOrderRepository
    {
        public List<Order> LoadOrders(string filePath);
        public void SaveOrders(List<Order> orders, string filePath);
    }

    public class OrderRepository : IOrderRepository
    {
        public List<Order> LoadOrders(string filePath)
        {
            var jsonData = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<Order>>(jsonData);
        }

        public void SaveOrders(List<Order> orders, string filePath)
        {
            var jsonData = JsonConvert.SerializeObject(orders, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(filePath, jsonData);
        }
    }
}
