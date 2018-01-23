using PersonalBudget.Persistence;
using PersonalBudget.Persistence.VO;
using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace PersonalBudget.UI
{
    public partial class CategoryForm : Form
    {
        public CategoryForm()
        {
            InitializeComponent();
        }

        public DialogResult ShowDialog(ref Transaction transaction)
        {
            this.textBoxDescription.Text = transaction.Description;
            this.textBoxValue.Text = transaction.Description;
            this.textBoxAccount.Text = transaction.Account;
            this.textBoxTransactionValue.Text = FormatCurrency(transaction.Value);

            return base.ShowDialog();
        }

        private void CategoryForm_Load(object sender, EventArgs e)
        {
            FillCategory();
        }

        private void FillCategory()
        {
            var res = CategoryModel.GetAll();

            foreach (CategoryModel.Category x in res)
            {
                this.comboBoxCategory.Items.Add(x.Name);
            }

            if (this.comboBoxCategory.Items.Count > 0)
            {
                this.comboBoxCategory.SelectedIndex = 0;
            }

            this.comboBoxCategory.DisplayMember = "Name";
            this.comboBoxCategory.ValueMember = "Name";
        }

        private void FillSubcategory(String category)
        {
            this.comboBoxSubCategory.Items.Clear();

            var res = CategoryModel.GetAll();

            foreach (CategoryModel.Category x in res)
            {
                if (x.Name.Equals(category))
                {
                    foreach (CategoryModel.Subcategory y in x.Subcategory)
                    {
                        this.comboBoxSubCategory.Items.Add(y.Name);
                    }

                    if (this.comboBoxSubCategory.Items.Count > 0)
                    {
                        this.comboBoxSubCategory.SelectedIndex = 0;
                    }

                    break;
                }
            }

            this.comboBoxSubCategory.DisplayMember = "Name";
            this.comboBoxSubCategory.ValueMember = "Name";
        }

        private void comboBoxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            string categoryName = (string)(this.comboBoxCategory.SelectedItem);

            FillSubcategory(categoryName);
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            string data = this.textBoxValue.Text;
            string category = (string)this.comboBoxCategory.SelectedItem;
            string subcategory = (string)this.comboBoxSubCategory.SelectedItem;

            if (!String.IsNullOrEmpty(data) && !String.IsNullOrEmpty(category) && !String.IsNullOrEmpty(subcategory))
            {
                TagModel.Tag tag = new TagModel.Tag();
                tag.Id = Guid.NewGuid().ToString();
                tag.Name = data;
                tag.Category = category;
                tag.Subcategory = subcategory;

                TagModel.Insert(tag);
                this.Close();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private string FormatCurrency(double value)
        {
            // obtém a cultura local
            var cultureInfo = Thread.CurrentThread.CurrentCulture;
            // faz uma cópia das informações de formatação de número da cultura local
            var numberFormatInfo = (NumberFormatInfo)cultureInfo.NumberFormat.Clone();
            // fixa o símbolo da moeda estrangeira
            numberFormatInfo.CurrencySymbol = "R$ ";
            // obtém o valor em moeda estrangeira formatado conforme a cultura local
            var valorFormatado = string.Format(numberFormatInfo, "{0:C}", value);

            return valorFormatado;
        }
    }
}