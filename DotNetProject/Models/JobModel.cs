using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetProject.Models
{
    public class JobModel
    {

        [JsonProperty("id")]
        public int Id { get; set; }
        
        [JsonProperty("title")]

        public string Title { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }
        
        [JsonProperty("company_name")]
        public string Company { get; set; }
        
        [JsonProperty("url")]
        public string Url { get; set; }
        
        [JsonProperty("publication_date")]
        public string PublicationDate { get; set; }
    }
}
