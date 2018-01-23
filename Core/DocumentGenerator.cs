using Microsoft.Office.Interop.Excel;
using PersonalBudget.Persistence;
using System;
using System.Collections.Generic;

namespace PersonalBudget.Core
{
    internal class DocumentGenerator
    {
        public static void GenerateExcel(string path, List<TransactionEx> transactions)
        {
            var excel = new Application();
            excel.Visible = false;
            excel.DisplayAlerts = false;
            var worKbooK = excel.Workbooks.Add(Type.Missing);

            var worKsheeT = (Worksheet)worKbooK.ActiveSheet;
            worKsheeT.Name = "FinancialReport";

            if (transactions != null && transactions.Count > 0)
            {
                worKsheeT.Cells[1, 1].value = "Id";
                worKsheeT.Cells[1, 2].value = "Bank";
                worKsheeT.Cells[1, 3].value = "Agency";
                worKsheeT.Cells[1, 4].value = "Account";
                worKsheeT.Cells[1, 5].value = "Transaction Type";
                worKsheeT.Cells[1, 6].value = "Date";
                worKsheeT.Cells[1, 7].value = "Description";
                worKsheeT.Cells[1, 8].value = "Value";
                worKsheeT.Cells[1, 9].value = "Value Mod";
                worKsheeT.Cells[1, 10].value = "Category";
                worKsheeT.Cells[1, 11].value = "SubCategory";

                int row = 2;

                foreach (TransactionEx transaction in transactions)
                {
                    worKsheeT.Cells[row, 1].value = transaction.Id;
                    worKsheeT.Cells[row, 2].value = transaction.Bank;
                    worKsheeT.Cells[row, 3].value = transaction.Agency;
                    worKsheeT.Cells[row, 4].value = transaction.Account;
                    worKsheeT.Cells[row, 5].value = transaction.TransactionType;
                    worKsheeT.Cells[row, 6].value = transaction.Date;
                    worKsheeT.Cells[row, 7].value = transaction.Description;
                    worKsheeT.Cells[row, 8].value = transaction.Value;
                    worKsheeT.Cells[row, 9].value = transaction.ValueAbs;
                    worKsheeT.Cells[row, 10].value = transaction.Category;
                    worKsheeT.Cells[row, 11].value = transaction.SubCategory;

                    row++;
                }

                worKbooK.SaveAs(path);
                worKbooK.Close();
                excel.Quit();
            }
        }
    }
}