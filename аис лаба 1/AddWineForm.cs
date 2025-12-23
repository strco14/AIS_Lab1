using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using Shared;

namespace аис_лаба_1
{
    public partial class AddWineForm : Form
    {
        public WineDTO WineDto { get; private set; }
        public AddWineForm()
        {
            InitializeComponent();
            


            country.Items.AddRange(new string[] { "Франция", "Италия", "Испания", "Россия", "Аргентина" });
            type.Items.AddRange(new string[] { "Белое", "Красное" });
            sugar.Items.AddRange(new string[] { "Сладкое", "Полусладкое", "Сухое", "Полусухое" });
            this.BackColor = Color.FromArgb(128, 0, 0);
        }
        private void addBtn_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                WineDto = new WineDTO(
            name: nameWine.Text.Trim(),
            type: type.SelectedItem.ToString(),
            sugar: sugar.SelectedItem.ToString(),
            homeland: country.SelectedItem.ToString());

                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show(
                    "Пожалуйста, заполните все поля правильно.\nНазвание не должно быть пустым.",
                    "Ошибка ввода",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                nameWine.Focus();
            }
        }
        /// <summary>
        /// Проверка на правильность данных
        /// </summary>
        /// <returns></returns>
        private bool ValidateInput()
        {

            if (string.IsNullOrWhiteSpace(nameWine.Text))
            {
                nameWine.BackColor = Color.LightPink;
                return false;
            }

            nameWine.BackColor = Color.White;


            if (type.SelectedItem == null ||
                sugar.SelectedItem == null ||
                country.SelectedItem == null)
            {
                return false;
            }

            return true;
        }
    }
}
