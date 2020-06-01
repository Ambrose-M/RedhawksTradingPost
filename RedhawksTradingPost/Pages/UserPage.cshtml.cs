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
    public class UserPageModel : PageModel
    {
        //create logger
        private readonly ILogger<UserPageModel> _logger;

        //json file
        public JsonFileProductService ProductService;

        //json file list
        public IEnumerable<Product> Products { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="productService"></param>
        public UserPageModel(
            ILogger<UserPageModel> logger,
            JsonFileProductService productService)
        {
            _logger = logger;
            ProductService = productService;
        }

        /// <summary>
        /// Get json element in Products list 
        /// </summary>
        public void OnGet()
        {
            Products = ProductService.GetProducts();
        }
 
    }
}