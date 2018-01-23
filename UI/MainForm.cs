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

            this.textBox1.Text = @"C:\Users\patrick.tedeschi\Desktop\Financial";
        }

        private void buttonBrowse_Click(object sender, System.EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void buttonGo_Click(object sender, System.EventArgs e)
        {
            string[] files = System.IO.Directory.GetFiles(this.textBox1.Text, "*.ofx");

            List<Transaction> transactions = OFXParserEx.GetTransactions(files, this.checkBoxEnableTagging.Checked);

            DocumentGenerator.GenerateExcel(this.textBox1.Text + "\\Worksheet.xlsx", transactions);

            foreach (Transaction transaction in transactions)
            {
                System.Diagnostics.Debug.WriteLine(transaction.TransactionType + " " + transaction.Date + " " + transaction.Description + " " + transaction.Value);
            }
        }
    }
}