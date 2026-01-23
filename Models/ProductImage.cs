using WebApplicationTASK14.Models.Base;

namespace WebApplicationTASK14.Models
{
    public class ProductImage:BaseEntity
    {
        public string Image { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

        public bool? IsPrimary { get; set; }
    }
}
