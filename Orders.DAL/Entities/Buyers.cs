using System.ComponentModel.DataAnnotations.Schema;

namespace Orders.DAL.Entities
{
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

}
