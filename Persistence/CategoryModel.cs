namespace PersonalBudget.Persistence
{
    internal class CategoryModel
    {
        public static dynamic GetAll()
        {
            var db = PersonalBudget.Persistence.LiteDB.Connect();
            var col = db.GetCollection<Category>("categories");
            return col.FindAll();
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
}