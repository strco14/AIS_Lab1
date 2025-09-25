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

            
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            // Создание колонок
            dataGridView1.Columns.Add("Name", "Название");
            dataGridView1.Columns.Add("Type", "Тип");
            dataGridView1.Columns.Add("Sugar", "Сахар");
            dataGridView1.Columns.Add("Homeland", "Страна");
            dataGridView1.Columns.Add("Mark", "Оценка");
            this.BackColor = Color.FromArgb(128, 0, 0);
            dataGridView1.BackgroundColor = Color.FromArgb(128, 0, 0);
            dataGridView1.BorderStyle = BorderStyle.None;
            UpdateDataGrid(logic.GetWines());
            groupBox1.BackColor = Color.FromArgb(128, 0, 0);
            groupBox2.BackColor = Color.FromArgb(128, 0, 0);
        }
        /// <summary>
        /// обновление таблицы вин
        /// </summary>
        /// <param name="wines"></param>
        private void UpdateDataGrid(List<Wine> wines)
        {
            dataGridView1.Rows.Clear();
            foreach (var wine in wines)
            {
                dataGridView1.Rows.Add(
                    wine.Name,
                    wine.Type,
                    wine.Sugar,
                    wine.Homeland,
                    wine.Rating
                );
            }
        }

        private void AddWineBtn_Click(object sender, EventArgs e)
        {
            var formAdd = new AddWineForm();
            if (formAdd.ShowDialog() == DialogResult.OK)
            {
                if(logic.CheckWineInList(formAdd.wine))
                {
                    logic.AddWine(formAdd.wine);
                    UpdateDataGrid(logic.GetWines());
                }
                else MessageBox.Show("Такое вино уже есть");
            }
            else
            {
                MessageBox.Show("Проверьте заполненные поля");
            }
        }

        private void ChangeWineBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Получаем выбранное вино из исходного списка
                int selectedIndex = dataGridView1.SelectedRows[0].Index;
                Wine selectedWine = logic.GetWines()[selectedIndex];

                var formChange = new EditWineForm(selectedWine);
                if (formChange.ShowDialog() == DialogResult.OK)
                {
                    if (logic.CheckWineInList(formChange.wine))
                    {
                        logic.ChangeWine(formChange.wine, selectedIndex);
                        UpdateDataGrid(logic.GetWines());
                    }
                    else MessageBox.Show("Такое вино уже есть");
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
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedIndex = dataGridView1.SelectedRows[0].Index;
                Wine selectedWine = logic.GetWines()[selectedIndex];

                logic.RemoveWine(selectedWine);
                UpdateDataGrid(logic.GetWines());
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

                UpdateDataGrid(logic.SearchWines(
                    elemWine.Name,
                    elemWine.Type,
                    elemWine.Sugar,
                    elemWine.Homeland
                ));
            }
        }

        private void AllWine_Click(object sender, EventArgs e)
        {
            UpdateDataGrid(logic.GetWines());
        }

        private void GettingMarkBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedIndex = dataGridView1.SelectedRows[0].Index;
                Wine selectedWine = logic.GetWines()[selectedIndex];

                var gettingMarkForm = new GettingMarkForm();
                if (DialogResult.OK == gettingMarkForm.ShowDialog())
                {
                    logic.GetMark(gettingMarkForm.Mark, selectedWine);
                    UpdateDataGrid(logic.GetWines());
                }
            }
            else
            {
                MessageBox.Show("Нужно выбрать вино");
            }
        }

        private void BestWinesBtn_Click(object sender, EventArgs e)
        {
            UpdateDataGrid(logic.BestWines());
        }

       
    }
}