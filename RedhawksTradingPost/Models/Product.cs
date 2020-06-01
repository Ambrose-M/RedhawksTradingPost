using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RedhawksTradingPost.Models
{
    public class Product
    {
        //ID
        public string ID { get; set; }

        //Maker
        public string Maker { get; set; }

        //Image
        [JsonPropertyName("img")]
        public string Image { get; set; }

        //Url
        public string Url { get; set; }

        //Title
        public string Title { get; set; }

        //Description
        public string Description { get; set; }

        //Ratings
        public int[] Ratings { get; set; }

        //Override ToString 
        public override string ToString() => JsonSerializer.Serialize<Product>(this);
    }
}
