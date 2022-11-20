using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Orders.DAL.Entities
{
    [Table(nameof(OrderItem))]
    public class OrderItem : Entity
    {
        [Required]
        public Product Product { get; set; } = null!;

        public int Quantity { get; set; }

        [Required]
        public Order Orders { get; set; } = null!;
    }

}
