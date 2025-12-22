using WebApplicationTASK14.Models.Base;
namespace WebApplicationTASK14.Models
{
    public class Slide:BaseEntity
    {
        public string Title { get; set; }
        public int Discount { get; set; } 
        public string Description { get; set; }
        public string Image { get; set; }
        public int Order { get; set; }
    }
}
