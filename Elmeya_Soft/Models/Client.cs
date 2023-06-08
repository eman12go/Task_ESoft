using System.ComponentModel.DataAnnotations;

namespace Elmeya_Soft.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
    }
}
