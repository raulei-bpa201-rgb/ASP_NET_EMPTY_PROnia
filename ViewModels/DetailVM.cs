using WebApplicationTASK14.Models;

namespace WebApplicationTASK14.ViewModels
{
    public class DetailVM
    {
        public Product Product { get; set; }

        public List<Product> RelatedProducts { get; set; }
    }
}
