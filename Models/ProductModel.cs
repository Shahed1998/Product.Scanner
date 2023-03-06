using System;
using System.ComponentModel.DataAnnotations;

namespace Product.Scanner.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Details { get; set; }
        [Required]
        public decimal Price { get; set; }
        public bool IsUsed { get; set; } = false;
        [Required]
        public string QRCode { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
