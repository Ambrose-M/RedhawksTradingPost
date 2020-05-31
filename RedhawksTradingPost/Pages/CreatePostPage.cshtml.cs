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
        private readonly ILogger<UserPageModel> _logger;
        public JsonFileProductService ProductService;
        public IEnumerable<Product> Products { get; private set; }
        public CreatePostPageModel(
            ILogger<UserPageModel> logger,
            JsonFileProductService productService)
        {
            _logger = logger;
            ProductService = productService;
        }
        public void OnGet()
        {
            Products = ProductService.GetProducts();
        }
    }
}