using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerOrderWebApi.Models
{
    public class Order
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
        [ForeignKey("CustomerId")]
        public Customer? Customer { get; set; }
    }
}
