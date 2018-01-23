using PersonalBudget.Core;
using PersonalBudget.Persistence.VO;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PersonalBudget.UI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            string[] files = System.IO.Directory.GetFiles(@"C:\Users\patrick.tedeschi\Desktop\Financial\", "*.ofx");

            List<Transaction> transactions = OFXParserEx.GetTransactions(files);

            DocumentGenerator.GenerateExcel(@"C:\Users\patrick.tedeschi\Desktop\Financial\Worksheet.xlsx", transactions);

            foreach (Transaction transaction in transactions)
            {
                System.Diagnostics.Debug.WriteLine(transaction.TransactionType + " " + transaction.Date + " " + transaction.Description + " " + transaction.Value);
            }
        }
    }
}