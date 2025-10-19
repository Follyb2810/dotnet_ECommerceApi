namespace ECommerceApi.DTOs
{
    public class OrderCreateDto
    {
        public List<OrderItemDto> Items { get; set; } = new List<OrderItemDto>();
    }


    public class OrderItemDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}