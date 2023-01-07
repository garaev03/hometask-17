using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hometask_17.Models
{
    public class WorkProduct
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Title { get; set; }
        public string? TitleDescription { get; set; }
        public string? Description { get; set; }
        public string? Quote { get; set; }
        public string? Link { get; set; } 
        public int CategoryId { get; set; }
        public bool isDeleted { get; set; }
        public WorkCategory Category { get; set; }
        public List<WorkImage> Images { get; set; }
        [NotMapped]
        public List<IFormFile>? FormFiles { get; set; }

        public WorkProduct()
        {
            Category = new WorkCategory();
            Images = new List<WorkImage>();
        }
    }
}
