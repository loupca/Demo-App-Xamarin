using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace MASXamarinFormsDemo.Models.JsonResponse
{
    /// <summary>
    /// Represents an Idea.
    /// </summary>
    public class IdeaResponseJson
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("department")]
        public string Department { get; set; }

        [JsonProperty("user_id")]
        public string UserId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
