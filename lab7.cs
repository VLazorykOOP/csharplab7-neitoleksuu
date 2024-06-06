using System;
using System.Windows.Forms;
namespace lab7
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }
      
        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string newItem = textBoxInput.Text.Trim();
            if (!string.IsNullOrEmpty(newItem) && !comboBoxItems.Items.Contains(newItem))
            {
                comboBoxItems.Items.Add(newItem);
                textBoxInput.Clear();
            }
            else
            {
                MessageBox.Show("Введіть новий унікальний елемент для додавання.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            string itemToRemove = textBoxInput.Text.Trim();
            if (comboBoxItems.Items.Contains(itemToRemove))
            {
                comboBoxItems.Items.Remove(itemToRemove);
                textBoxInput.Clear();
            }
            else
            {
                MessageBox.Show("Елемент для видалення не знайдено в списку.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
