namespace PersonalBudget.Persistence
{
    internal class TagModel
    {
        public static dynamic GetAll()
        {
            var db = PersonalBudget.Persistence.LiteDB.Connect();
            var col = db.GetCollection<Tag>("tags");
            return col.FindAll();
        }

        public static void Insert(Tag tag)
        {
            var db = PersonalBudget.Persistence.LiteDB.Connect();
            var col = db.GetCollection<Tag>("tags");
            col.Insert(tag);
        }

        public static void RemoveAll()
        {
            var db = PersonalBudget.Persistence.LiteDB.Connect();
            var col = db.DropCollection("tags");
        }

        public class Tag
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string Category { get; set; }
            public string Subcategory { get; set; }
        }
    }
}