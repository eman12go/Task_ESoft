using System.ComponentModel.DataAnnotations;

namespace Elmeya_Soft.Models
{
    public class Type
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Category> categories { get; set; }
    }
}
