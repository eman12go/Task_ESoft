using System.ComponentModel.DataAnnotations.Schema;

namespace Elmeya_Soft.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }
        public int Quantity { get; set; }
        [ForeignKey("Type")]
        public int TypeId { get; set; }
        public Type Type { get; set; }
    }
}
