﻿using ShopApi.Models;
using System.Net.Http.Json;

namespace ShopApi.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Phương thức lấy tất cả sản phẩm (đồng bộ)
        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Product>>("api/products");
        }

        // Phương thức lấy tất cả sản phẩm (bất đồng bộ)
        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Product>>("api/products");
        }

        // Phương thức lấy một sản phẩm theo ID
        public async Task<Product> GetProduct(int id)
        {
            return await _httpClient.GetFromJsonAsync<Product>($"api/products/{id}");
        }

        // Phương thức thêm sản phẩm mới
        public async Task<Product> AddProduct(Product product)
        {
            var response = await _httpClient.PostAsJsonAsync("api/products", product);
            response.EnsureSuccessStatusCode(); // Kiểm tra nếu không có lỗi
            return await response.Content.ReadFromJsonAsync<Product>(); // Đọc và trả về sản phẩm đã thêm
        }

        // Phương thức cập nhật sản phẩm
        public async Task UpdateProduct(Product product)
        {
            await _httpClient.PutAsJsonAsync($"api/products/{product.Id}", product);
        }

        // Phương thức xóa sản phẩm
        public async Task DeleteProduct(int id)
        {
            await _httpClient.DeleteAsync($"api/products/{id}");
        }
    }
}
