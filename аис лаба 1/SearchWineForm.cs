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
    public partial class SearchWineForm : Form
    {
        public Wine wine;
        public SearchWineForm()
        {
            InitializeComponent();
            country.Items.AddRange(new string[] { "Франция", "Италия", "Испания", "Россия", "Аргентина" });
            type.Items.AddRange(new string[] { "Белое", "Красное" });
            sugar.Items.AddRange(new string[] { "Сладкое", "Полусладкое", "Сухое", "Полусухое" });
            this.BackColor = Color.FromArgb(128, 0, 0);
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            wine = new Wine
            {
                Name = nameWine.Text?.ToString(),
                Type = type.SelectedItem?.ToString(),
                Sugar = sugar.SelectedItem?.ToString(),
                Homeland = country.SelectedItem?.ToString()
            };
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
