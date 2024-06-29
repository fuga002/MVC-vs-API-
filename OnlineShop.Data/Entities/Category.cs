using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Data.Entities;

    public class Category
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        public virtual List<Product>? Products { get; set; }
        
    }

