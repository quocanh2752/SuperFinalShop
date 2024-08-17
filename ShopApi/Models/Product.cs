﻿namespace ShopApi.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public int Quantity { get; set; } // Số lượng hàng tồn kho
        public string Category { get; set; } // Loại sản phẩm
    }
}
