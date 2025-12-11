using System;
using System.Drawing;
using System.Windows.Forms;

namespace аис_лаба_1
{
    public partial class GettingMarkForm : Form
    {
        public int Mark { get; private set; }
        public GettingMarkForm(string wineId)
        {
            InitializeComponent();

            this.BackColor = Color.FromArgb(128, 0, 0);
            Mark = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Mark = 1;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Mark = 2;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Mark = 3;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Mark = 4;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Mark = 5;

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
