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
    public partial class AddWineForm : Form
    {
        public Wine wine;
        public AddWineForm()
        {
            InitializeComponent();

            country.Items.AddRange(new string[] {"Франция", "Италия", "Испания", "Россия", "Аргентина"});
            type.Items.AddRange(new string[] { "Белое", "Красное" });
            sugar.Items.AddRange(new string[] {"Сладкое", "Полусладкое", "Сухое", "Полусухое"});
        }
        

        private void addBtn_Click(object sender, EventArgs e)
        {
            if ((nameWine.Text != "" && nameWine.Text != "Название") && type.SelectedItem != null &&
                sugar.SelectedItem != null && country.SelectedItem != null)
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
