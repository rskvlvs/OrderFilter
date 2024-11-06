namespace OrderFilter
{
    public class Order
    {
        public Guid OrderId { get; set; }
        public double Weight { get; set; }
        public string District { get; set; }
        public DateTime DeliveryTime { get; set; }
    }  
}
