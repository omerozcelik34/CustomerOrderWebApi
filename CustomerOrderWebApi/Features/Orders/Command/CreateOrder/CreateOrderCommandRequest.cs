using MediatR;
using System.ComponentModel.DataAnnotations;

namespace CustomerOrderWebApi.Features.Orders.Command.CreateOrder
{
    public class CreateOrderCommandRequest : IRequest
    {
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
