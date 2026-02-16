using DYS.Devyard.Web.Shared.Models;
using DYS.Devyard.Web.Shared.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MvvmBlazor;
using System.Net.Http.Json;
using System.Text.Json;
using static System.Net.WebRequestMethods;

namespace DYS.Devyard.Web.Features.Home.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        private readonly HttpClient _httpClient;
        public HomeViewModel(HttpClient httpClient, NavigationManager navigationManager, IJSRuntime jsRuntime) 
            : base(navigationManager, jsRuntime)
        {
            _httpClient = httpClient;
        }

        #region PROPERTIES
        private List<Product> _products = new List<Product>();
        public List<Product> Products
        {
            get => _products;
            set => Set(ref _products, value);
        }

        private List<Product> _filteredProducts = new List<Product>();
        public List<Product> FilteredProducts
        {
            get => _filteredProducts;
            set => Set(ref _filteredProducts, value);
        }
        #endregion

        public override async Task OnInitializedAsync()
        {
            await ReadProductsAsync();
            await base.OnInitializedAsync();
        }

        public async Task ReadProductsAsync()
        {
            var filePath = "data/products.json";
            var products = await _httpClient.GetFromJsonAsync<List<Product>>(filePath);
            Products = products ?? new List<Product>();
            FilteredProducts = Products;
        }

        public async Task FitlerProductsAsync(string category)
        {
            var products = Products.Where(p => p.Category.Equals(category, StringComparison.OrdinalIgnoreCase)).ToList();
            FilteredProducts = products;
        }
    }
}
