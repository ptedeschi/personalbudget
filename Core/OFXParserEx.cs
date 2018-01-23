using OFXParser.Entities;
using PersonalBudget.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalBudget.Core
{
    internal class OFXParserEx
    {
        public static List<Persistence.VO.Transaction> GetTransactions(string[] files)
        {
            List<Persistence.VO.Transaction> transactions = new List<Persistence.VO.Transaction>();

            if (files != null && files.Length > 0)
            {
                foreach (string file in files)
                {
                    Extract extract = OFXParser.Parser.GenerateExtract(file);

                    if (extract != null)
                    {
                        foreach (var trans in extract.Transactions)
                        {
                            Persistence.VO.Transaction transaction = new Persistence.VO.Transaction();
                            transaction.Id = trans.Id;
                            transaction.Bank = extract.BankAccount.Bank.Code.ToString();
                            transaction.Agency = extract.BankAccount.AgencyCode;
                            transaction.Account = extract.BankAccount.AccountCode;
                            transaction.TransactionType = trans.Type;
                            transaction.Date = trans.Date;
                            transaction.Description = Encode(trans.Description);
                            transaction.Value = trans.TransactionValue;
                            transaction.ValueAbs = Math.Abs(trans.TransactionValue);
                            transaction.Category = RecommendationSystem.GetRecommendedCategory(transaction);

                            if (transaction.Category == null)
                            {
                                CategoryForm form = new CategoryForm();
                                form.ShowDialog(ref transaction);
                            }

                            transaction.SubCategory = RecommendationSystem.GetRecommendedSubCategory(transaction);

                            System.Diagnostics.Debug.WriteLine(trans.Description + " > " + Encode(trans.Description));

                            // Fix Banco do Brasil transaction type
                            if (transaction.Bank.Equals("1") && transaction.TransactionType.Equals("OTHER"))
                            {
                                if (transaction.Value > 0)
                                {
                                    transaction.TransactionType = "CREDIT";
                                }
                                else
                                {
                                    transaction.TransactionType = "DEBIT";
                                }
                            }

                            // Fix Banco do Brasil account because of Power BI
                            if (transaction.Bank.Equals("1"))
                            {
                                transaction.Account = transaction.Account.Replace("-", "");
                            }

                            transactions.Add(transaction);
                        }
                    }
                }
            }

            return transactions;
        }

        private static string Encode(string text)
        {
            byte[] bytes = Encoding.Default.GetBytes(text);
            return Encoding.UTF8.GetString(bytes);
        }
    }
}