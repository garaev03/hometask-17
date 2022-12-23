using Microsoft.Build.Framework;

namespace hometask_17.Models
{
    public class WorkProduct
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Path { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public WorkCategory? Category { get; set; }

    }
}
