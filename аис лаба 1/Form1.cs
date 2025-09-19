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
    public partial class Form1 : Form
    {
        private Logic logic = new Logic();
        public Form1()
        {
            InitializeComponent();

            UpdateList(logic.GetWines());
        }
        private void UpdateList(List<Wine> wines)
        {
            listWines.Items.Clear();
            foreach (var wine in wines)
            {
                listWines.Items.Add(wine);
            }
        }
        private void AddWineBtn_Click(object sender, EventArgs e)
        {
            var formAdd = new AddWineForm();
            if(formAdd.ShowDialog() == DialogResult.OK)
            {
                logic.AddWine(formAdd.wine);
                UpdateList(logic.GetWines());
            }
            else
            {
                MessageBox.Show("Проверьте заполненные поля");
            }
        }

        private void ChangeWineBtn_Click(object sender, EventArgs e)
        {
            if(listWines.SelectedItem != null)
            {
                var formChange = new EditWineForm((Wine)listWines.SelectedItem);
                if (formChange.ShowDialog() == DialogResult.OK)
                {
                    logic.ChangeWine(formChange.wine, listWines.SelectedIndex);
                    UpdateList(logic.GetWines());
                }
                else
                {
                    MessageBox.Show("Проверьте заполненные поля");
                }
            }
            else
            {
                MessageBox.Show("Нужно выбрать вино");
            }

        }

        private void DeleteWineBtn_Click(object sender, EventArgs e)
        {
            if (listWines.SelectedItem != null)
            {
                logic.RemoveWine((Wine)listWines.SelectedItem);
                UpdateList(logic.GetWines());
            }
            else
            {
                MessageBox.Show("Нужно выбрать вино");
            }
        }

        private void Search_Click(object sender, EventArgs e)
        {
            var searchForm = new SearchWineForm();
            if (DialogResult.OK == searchForm.ShowDialog())
            {
                var elemWine = searchForm.wine;
                
               UpdateList(logic.SearchWines(elemWine.Name, elemWine.Type,
                   elemWine.Sugar, elemWine.Homeland));
            }
        }

        private void AllWine_Click(object sender, EventArgs e)
        {
            UpdateList(logic.GetWines());
        }

        private void GettingMarkBtn_Click(object sender, EventArgs e)
        {
            if (listWines.SelectedItem != null)
            { 
                var gettingMarkForm = new GettingMarkForm();
                if (DialogResult.OK == gettingMarkForm.ShowDialog())
                {
                    logic.GetMark(gettingMarkForm.Mark, (Wine)listWines.SelectedItem);
                    UpdateList(logic.GetWines());
                }
            }
            else
            {
                MessageBox.Show("Нужно выбрать вино");
            }
        }

        private void BestWinesBtn_Click(object sender, EventArgs e)
        {
            UpdateList(logic.BestWines());
        }
    }
}
