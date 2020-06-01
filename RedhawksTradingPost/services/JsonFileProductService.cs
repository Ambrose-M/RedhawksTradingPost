using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using RedhawksTradingPost.Models;
using Microsoft.AspNetCore.Hosting;

namespace RedhawksTradingPost.Services
{
    public class JsonFileProductService
    {   
        /// <summary>
        /// Path to webhostEnvirommmnet
        /// </summary>
        /// <param name="webHostEnvironment"></param>
        public JsonFileProductService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        /// <summary>
        /// function to get webhostenviroment
        /// </summary>
        public IWebHostEnvironment WebHostEnvironment { get; }

        /// <summary>
        /// Path to product.json
        /// </summary>
        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "products.json"); }
        }

        /// <summary>
        /// path to office Supplies Product json 
        /// </summary>
        private string OfficeSuppliesJsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "OfficeSuppliesProduct.json"); }
        }

        /// <summary>
        /// get all the product from product.json
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Product> GetProducts()
        {
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<Product[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }
        }

        /// <summary>
        /// Function read data from officesuppliesproduct.json
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Product> GetOfficeSuppliesProducts()
        {
            using (var jsonFileReader = File.OpenText(OfficeSuppliesJsonFileName))
            {
                return JsonSerializer.Deserialize<Product[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }
        }

        public void AddProduct(Product Listing)
        {
            List<Product> Temporary = this.GetProducts().ToList();
            Temporary.Insert(0, Listing);
            string ConvertedListing = JsonSerializer.Serialize<List<Product>>(Temporary);
            File.WriteAllText(JsonFileName, ConvertedListing);

        }
    }
}
