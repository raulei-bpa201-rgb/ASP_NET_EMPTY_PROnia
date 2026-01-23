using WebApplicationTASK14.Models;

namespace WebApplicationTASK14.Areas.Admin.ViewModels.Product
{
    public class GetProductVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SKU { get; set; }
        public string CategoryName { get; set; }

        public string Image {  get; set; }
    }
}
