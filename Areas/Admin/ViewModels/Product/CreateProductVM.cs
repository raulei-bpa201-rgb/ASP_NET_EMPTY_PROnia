using WebApplicationTASK14.Models;

namespace WebApplicationTASK14.Areas.Admin.ViewModels.Product
{
    public class CreateProductVM
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public string SKU { get; set; }

        public int CategoryId { get; set; }

        public List<Category>? Categorys { get; set; }
    }
}
