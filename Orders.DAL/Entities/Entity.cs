using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.DAL.Entities
{
    public abstract class Entity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
    public abstract class NamedEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;
    }
    [Table(nameof(Buyers))]
    public class Buyers: NamedEntity 
    {
        public string? LastName { get; set; }
        public string? Patronymic { get; set; }
        public DateTime Birthday { get; set; }

        public override string ToString()
        {
            return $"{LastName};{Patronymic};{Birthday};";
        }

    }
    public class Product :NamedEntity
    {
        [Column(TypeName ="money")]
        public decimal Price { get; set; }
        public string? Category { get; set; }
    }
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
