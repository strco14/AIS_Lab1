using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace аис_лаба_1
{
    public partial class EditWineForm : Form
    {
        public Wine wine;
        public EditWineForm(Wine wine)
        {
            InitializeComponent();
            country.Items.AddRange(new string[] { "Франция", "Италия", "Испания", "Россия", "Аргентина" });
            type.Items.AddRange(new string[] { "Белое", "Красное" });
            sugar.Items.AddRange(new string[] { "Сладкое", "Полусладкое", "Сухое", "Полусухое" });

            nameWine.Text = wine.Name;
            country.SelectedItem = wine.Homeland;
            type.SelectedItem = wine.Type;
            sugar.SelectedItem = wine.Sugar;
            this.BackColor = Color.FromArgb(128, 0, 0);
        }

        private void ChangeBtn_Click(object sender, EventArgs e)
        {
            if (nameWine.Text != "")
            {
                wine = new Wine(nameWine.Text.ToString(), type.SelectedItem.ToString(),
                    sugar.SelectedItem.ToString(), country.SelectedItem.ToString());
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                DialogResult = DialogResult.Cancel; Close();
            }
        }
    }
}
