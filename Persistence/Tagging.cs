using Newtonsoft.Json;

namespace PersonalBudget.Persistence
{
    [JsonObject(Title = "Rootobject")]
    public class Tags
    {
        public Tag[] Tag { get; set; }
    }

    public class Tag
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Subcategory { get; set; }
    }
}