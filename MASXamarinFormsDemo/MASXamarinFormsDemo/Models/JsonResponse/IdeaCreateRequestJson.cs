using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace MASXamarinFormsDemo.Models.JsonResponse
{
    public class IdeaCreateRequestJson
    {
        [JsonProperty("department")]
        public string Department { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
