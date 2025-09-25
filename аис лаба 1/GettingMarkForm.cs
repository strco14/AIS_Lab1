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
    public partial class GettingMarkForm : Form
    {
        public int Mark;
        public GettingMarkForm()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(128, 0, 0);
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
