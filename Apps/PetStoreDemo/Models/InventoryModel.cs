using Newtonsoft.Json;

namespace PetStoreDemo.Models
{
    public class InventoryModel
    {
        [JsonProperty("sold")]
        public int Sold { get; set; }

        [JsonProperty("string")]
        public int String { get; set; }

        [JsonProperty("pending")]
        public int Pending { get; set; }

        [JsonProperty("available")]
        public int Available { get; set; }

        [JsonProperty("Present")]
        public int Present { get; set; }
    }
}
