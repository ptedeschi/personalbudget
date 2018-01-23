using PersonalBudget.Persistence;
using PersonalBudget.Persistence.VO;

namespace PersonalBudget.Core
{
    internal class RecommendationSystem
    {
        public static string GetRecommendedCategory(Transaction transaction)
        {
            var categories = CategoryModel.GetAll();
            var tags = TagModel.GetAll();

            foreach (TagModel.Tag x in tags)
            {
                if (transaction.Description.Contains(x.Name))
                {
                    return x.Category;
                }
            }

            return null;
        }

        public static string GetRecommendedSubCategory(Transaction transaction)
        {
            var categories = CategoryModel.GetAll();
            var tags = TagModel.GetAll();

            foreach (TagModel.Tag x in tags)
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