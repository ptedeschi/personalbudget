using Newtonsoft.Json;

namespace PersonalBudget.Persistence
{
    [JsonObject(Title = "Rootobject")]
    public class Categories
    {
        public Category[] Category { get; set; }
    }

    public class Category
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Subcategory[] Subcategory { get; set; }
    }

    public class Subcategory
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}