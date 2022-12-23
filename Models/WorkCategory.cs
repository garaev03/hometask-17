using System.ComponentModel.DataAnnotations;

namespace hometask_17.Models
{
    public class WorkCategory
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }

        public List<WorkProduct>? Products { get; set; }
    }
}
