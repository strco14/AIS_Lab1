using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;
using Shared;

namespace аис_лаба_1
{
    public partial class EditWineForm : Form
    {
        public WineDto WineDto { get; private set; }
        private WineDto _originalWine;
        public EditWineForm(WineDto wineToEdit)
        {
            InitializeComponent();

            if (wineToEdit == null)
                throw new ArgumentNullException(nameof(wineToEdit));

            _originalWine = wineToEdit;
            LoadWineData();
            country.Items.AddRange(new string[] { "Франция", "Италия", "Испания", "Россия", "Аргентина" });
            type.Items.AddRange(new string[] { "Белое", "Красное" });
            sugar.Items.AddRange(new string[] { "Сладкое", "Полусладкое", "Сухое", "Полусухое" });
            this.BackColor = Color.FromArgb(128, 0, 0);
        }
        private void LoadWineData()
        {
            nameWine.Text = _originalWine.Name;

            type.SelectedItem = _originalWine.Type;
            sugar.SelectedItem = _originalWine.Sugar;
            country.SelectedItem = _originalWine.Homeland;


            if (type.SelectedItem == null)
                type.Items.Add(_originalWine.Type);
            if (sugar.SelectedItem == null)
                sugar.Items.Add(_originalWine.Sugar);
            if (country.SelectedItem == null)
                country.Items.Add(_originalWine.Homeland);


            type.SelectedItem = _originalWine.Type;
            sugar.SelectedItem = _originalWine.Sugar;
            country.SelectedItem = _originalWine.Homeland;
        }
        /// <summary>
        /// Проверка значений
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
        private void ChangeBtn_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                WineDto = new WineDto(
                id: _originalWine.Id,
                name: nameWine.Text.Trim(),
                type: type.SelectedItem.ToString(),
                sugar: sugar.SelectedItem.ToString(),
                homeland: country.SelectedItem.ToString(),
                rating: _originalWine.Rating);

                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show(
                    "Пожалуйста, заполните все поля правильно.",
                    "Ошибка ввода",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }
    }
}
