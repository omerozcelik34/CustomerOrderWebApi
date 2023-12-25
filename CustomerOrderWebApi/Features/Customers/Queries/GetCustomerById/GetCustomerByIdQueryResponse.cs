using System.ComponentModel.DataAnnotations;

namespace CustomerOrderWebApi.Features.Customers.Queries.GetCustomerById
{
    public class GetCustomerByIdQueryResponse
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
    }
}
