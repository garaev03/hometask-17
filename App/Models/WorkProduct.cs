using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace hometask_17.Models
{
    public class WorkProduct
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? Title { get; set; }
        public string? TitleDescription { get; set; }
        public string? Description { get; set; }
        public string? Quote { get; set; }
        public string? Link { get; set; } 
        [Required]
        public int CategoryId { get; set; }
        public bool isDeleted { get; set; }
        public WorkCategory? Category { get; set; }
        public List<WorkImage>? Images { get; set; }

    }
}
