using System.ComponentModel.DataAnnotations;
using System;

namespace Product.Scanner.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public decimal Price { get; set; }
        public bool IsUsed { get; set; } = false;
        public string QRCode { get; set; }
        public string Image { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
