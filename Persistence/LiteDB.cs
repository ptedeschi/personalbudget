using LiteDB;

namespace PersonalBudget.Persistence
{
    internal class LiteDB
    {
        public static dynamic Connect()
        {
            return new LiteDatabase(@"PersonalBudgetData.db");
        }
    }
}