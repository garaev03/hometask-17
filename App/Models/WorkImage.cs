using Microsoft.Build.Framework;

namespace hometask_17.Models
{
    public class WorkImage
    {
        public int Id { get; set; }
        public string? Path { get; set; } 
        public bool isMain { get; set; } = false;
        [Required]
        public int ProductId { get; set; }  
        public WorkProduct? Product { get; set; }
    }
}
