using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;
using Shared;

namespace аис_лаба_1
{
    public partial class SearchWineForm : Form
    {
        public SearchCriteria Criteria { get; private set; }
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
            Criteria = new SearchCriteria
            {
                Name = string.IsNullOrWhiteSpace(nameWine.Text) ? null : nameWine.Text.Trim(),
                Type = type.SelectedIndex <= 0 ? null : type.SelectedItem.ToString(),
                Sugar = sugar.SelectedIndex <= 0 ? null : sugar.SelectedItem.ToString(),
                Homeland = country.SelectedIndex <= 0 ? null : country.SelectedItem.ToString()
            };

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
