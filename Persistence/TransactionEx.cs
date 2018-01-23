using System;

namespace PersonalBudget.Persistence
{
    public class TransactionEx
    {
        private string id;
        private string bank;
        private string agency;
        private string account;
        private string transactionType;
        private DateTime date;
        private string description;
        private double value;
        private double valueAbs;
        private string category;
        private string subCategory;

        public TransactionEx()
        {
        }

        public TransactionEx(string id, string bank, string agency, string account, string transactionType, DateTime date, string description, double value, double valueAbs, string category, string subCategory)
        {
            this.id = id;
            this.bank = bank;
            this.agency = agency;
            this.account = account;
            this.transactionType = transactionType;
            this.date = date;
            this.description = description;
            this.value = value;
            this.valueAbs = valueAbs;
            this.category = category;
            this.subCategory = subCategory;
        }

        public string Id { get => id; set => id = value; }
        public string Bank { get => bank; set => bank = value; }
        public string Agency { get => agency; set => agency = value; }
        public string Account { get => account; set => account = value; }
        public string TransactionType { get => transactionType; set => transactionType = value; }
        public DateTime Date { get => date; set => date = value; }
        public string Description { get => description; set => description = value; }
        public double Value { get => value; set => this.value = value; }
        public double ValueAbs { get => valueAbs; set => valueAbs = value; }
        public string Category { get => category; set => category = value; }
        public string SubCategory { get => subCategory; set => subCategory = value; }
    }
}