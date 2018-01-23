using Newtonsoft.Json;
using PersonalBudget.Persistence;
using System.IO;

namespace PersonalBudget.Core
{
    internal class RecommendationSystem
    {
        public static string GetRecommendedCategory(TransactionEx transaction)
        {
            var categories = JsonConvert.DeserializeObject<Categories>(File.ReadAllText(@"C:\Users\patrick.tedeschi\Desktop\Financial\categories.json"));
            var tags = JsonConvert.DeserializeObject<Tags>(File.ReadAllText(@"C:\Users\patrick.tedeschi\Desktop\Financial\tags.json"));

            foreach (Tag x in tags.Tag)
            {
                if (transaction.Description.Contains(x.Name))
                {
                    return x.Category;
                }
            }

            return null;
        }

        public static string GetRecommendedSubCategory(TransactionEx transaction)
        {
            var categories = JsonConvert.DeserializeObject<Categories>(File.ReadAllText(@"C:\Users\patrick.tedeschi\Desktop\Financial\categories.json"));
            var tags = JsonConvert.DeserializeObject<Tags>(File.ReadAllText(@"C:\Users\patrick.tedeschi\Desktop\Financial\tags.json"));

            foreach (Tag x in tags.Tag)
            {
                if (transaction.Description.Contains(x.Name))
                {
                    return x.Subcategory;
                }
            }

            return null;
        }
    }
}