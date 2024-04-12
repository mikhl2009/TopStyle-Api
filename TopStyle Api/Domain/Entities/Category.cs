using System.ComponentModel.DataAnnotations;

namespace TopStyle_Api.Domain.Entities
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        
        public virtual ICollection<Product> Products { get; set; }

        public Category() 
        { 
            Products = new List<Product>();
        }
    }
}
