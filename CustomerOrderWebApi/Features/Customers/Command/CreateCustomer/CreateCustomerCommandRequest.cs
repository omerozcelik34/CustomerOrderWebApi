using MediatR;
using System.ComponentModel.DataAnnotations;

namespace CustomerOrderWebApi.Features.Customers.Command.CreateCustomer
{
    public class CreateCustomerCommandRequest : IRequest
    {
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
    }
}
