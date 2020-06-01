using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using RedhawksTradingPost.Models;
using RedhawksTradingPost.Services;

namespace RedhawksTradingPost.Pages
{
    public class CreatePostPageModel : PageModel
    {
        // ILogger
        private readonly ILogger<UserPageModel> _logger;
        // JsonFileProductService for interacting with products.json
        public JsonFileProductService ProductService;
        // Product list for us to populate, relevant get/set functions
        public IEnumerable<Product> Products { get; private set; }
        // Creates a logger and JsonFileProductService for us to use
        public CreatePostPageModel(
            ILogger<UserPageModel> logger,
            JsonFileProductService productService)
        {
            _logger = logger;
            ProductService = productService;
        }
        // Initializes the page
        public void OnGet()
        {
            // Generates the list of products from the json file
            Products = ProductService.GetProducts();
        }
    }
}