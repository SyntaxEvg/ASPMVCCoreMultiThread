using System.ComponentModel.DataAnnotations;

namespace Orders.DAL.Entities
{
    public class Order : Entity
    {
        public DateTime OrderDate { get; set; }
        [Required]
        public string Adress { get; set; } = null!;
        [Required]
        public string Phone { get; set; } = null!;
        [Required]
        public Buyers Buyers { get; set; }

        public ICollection<OrderItem> Items { get; set; } = new HashSet<OrderItem>();

    }

}
