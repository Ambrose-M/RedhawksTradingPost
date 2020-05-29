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
        public JsonFileProductService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

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
        /// Function read data from office suppliesproduct
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

    }
}
