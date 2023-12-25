using System.ComponentModel.DataAnnotations;

namespace CustomerOrderWebApi.Features.Orders.Queries.GetAllOrders
{
    public class GetAllOrdersQueryResponse
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? ProductName { get; set; }
        [Required]
        public string? Address { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int CustomerId { get; set; }
    }
}
