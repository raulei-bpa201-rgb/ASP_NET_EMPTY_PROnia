using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationTASK14.Areas.Admin.ViewModels
{
    public class UpdateSlideVM
    {
        public string Title { get; set; }
        public int Discount { get; set; }
        public string Description { get; set; }
        public string? Image { get; set; }
        public int Order { get; set; }

        public IFormFile? Photo { get; set; }
    }
}
