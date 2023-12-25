using System.ComponentModel.DataAnnotations;

namespace CustomerOrderWebApi.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        public List<Order>? Orders { get; set; }       
    }
}
