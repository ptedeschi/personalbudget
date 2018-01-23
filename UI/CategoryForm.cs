using Newtonsoft.Json;
using PersonalBudget.Persistence;
using System;
using System.IO;
using System.Windows.Forms;

namespace PersonalBudget.UI
{
    public partial class CategoryForm : Form
    {
        public CategoryForm()
        {
            InitializeComponent();
        }

        public DialogResult ShowDialog(ref TransactionEx transaction)
        {
            this.textBoxDescription.Text = transaction.Description;
            this.textBoxValue.Text = transaction.Description;

            return base.ShowDialog();
        }

        private void CategoryForm_Load(object sender, EventArgs e)
        {
            FillCategory();
        }

        private void FillCategory()
        {
            var res = JsonConvert.DeserializeObject<Categories>(File.ReadAllText(@"C:\Users\patrick.tedeschi\Desktop\Financial\categories.json"));

            this.comboBoxCategory.DataSource = res.Category;
            this.comboBoxCategory.DisplayMember = "Name";
            this.comboBoxCategory.ValueMember = "Name";
        }

        private void FillSubcategory(String category)
        {
            this.comboBoxSubCategory.Items.Clear();

            var res = JsonConvert.DeserializeObject<Categories>(File.ReadAllText(@"C:\Users\patrick.tedeschi\Desktop\Financial\categories.json"));

            foreach (Category x in res.Category)
            {
                if (x.Name.Equals(category))
                {
                    foreach (Subcategory y in x.Subcategory)
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
            string categoryName = ((Category)(this.comboBoxCategory.SelectedItem)).Name;

            FillSubcategory(categoryName);
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}