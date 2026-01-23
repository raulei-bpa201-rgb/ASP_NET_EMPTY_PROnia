using System.ComponentModel.DataAnnotations;
using WebApplicationTASK14.Models.Base;

namespace WebApplicationTASK14.Models
{
    public class Category:BaseEntity
    {
        [MaxLength(30,ErrorMessage = "30 dan cox olmaz!")]
        public string Name { get; set; }

        public List<Product>? Products { get; set; }
    }
}
