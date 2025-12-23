using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using Ninject;
using Shared;
using static Shared.WineDTO;

namespace аис_лаба_1
{
    public partial class Form1 : Form, IWineView
    {
        private BindingList<WineDTO> _wines;
        private BindingSource _bindingSource;

        //РЕАЛИЗАЦИЯ IWineView
        public event EventHandler LoadWinesRequested;
        public event EventHandler<WineEventArgs> AddWineRequested;
        public event EventHandler<WineEventArgs> EditWineRequested;
        public event EventHandler<DeleteWineEventArgs> DeleteWineRequested;
        public event EventHandler<SearchWineEventArgs> SearchWinesRequested;
        public event EventHandler<RateWineEventArgs> RateWineRequested;
        public event EventHandler ShowBestWinesRequested;

        public WineDTO SelectedWine =>
            dataGridView1.SelectedRows.Count > 0
                ? dataGridView1.SelectedRows[0].DataBoundItem as WineDTO
                : null;

        public WineDTO WineToAdd { get; private set; }
        public WineDTO WineToEdit { get; private set; }
        public SearchCriteriaDto SearchCriteria { get; private set; }
        public RatingInfo RatingInfo { get; private set; }
        public Form1()
        {
            
            InitializeComponent();
            SetupDataGridView();
            SetupFormDesign();
            this.BackColor = Color.FromArgb(128, 0, 0);

            //IKernel ninKer = new StandardKernel(new SimpleConfigModule());
            //logic = ninKer.Get<IWineService>();

            //winesList = new BindingList<WineDto>();


            //UpdateDataGrid();
        }
        /// <summary>
        /// Дизайн
        /// </summary>
        private void SetupFormDesign()
        {
            this.BackColor = Color.FromArgb(240, 240, 240);
            this.Text = "Винный каталог - MVP Архитектура";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MinimumSize = new Size(800, 600);

            // Настройка стиля кнопок
            foreach (Control control in this.Controls)
            {
                if (control is Button button)
                {
                    button.BackColor = Color.FromArgb(70, 130, 180);
                    button.ForeColor = Color.White;
                    button.FlatStyle = FlatStyle.Flat;
                    button.FlatAppearance.BorderSize = 0;
                    button.Font = new Font("Segoe UI", 10, FontStyle.Regular);
                    button.Padding = new Padding(10, 5, 10, 5);
                }
            }
        }

        public void DisplayWines(IEnumerable<WineDTO> wines)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => DisplayWines(wines)));
                return;
            }

            _wines.Clear();
            foreach (var wine in wines)
            {
                _wines.Add(wine);
            }
        }

        public void DisplayMessage(string message, MessageType type)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => DisplayMessage(message, type)));
                return;
            }


            if (type == MessageType.Error)
            {
                MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (type == MessageType.Warning)
            {
                MessageBox.Show(message, "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (type == MessageType.Success)
            {

                this.Text = $"Винный каталог - {message}";


                var timer = new Timer { Interval = 3000 };
                timer.Tick += (s, e) =>
                {
                    this.Text = "Винный каталог";
                    timer.Stop();
                    timer.Dispose();
                };
                timer.Start();
            }
        }

        public void ClearWinesDisplay()
        {
            _wines.Clear();
        }

        public void RefreshView()
        {
            dataGridView1.Refresh();
        }
        private void SetupDataGridView()
        {
            _wines = new BindingList<WineDto>();
            _bindingSource = new BindingSource(_wines, null);
            dataGridView1.DataSource = _bindingSource;

            // Настройка столбцов
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id",
                HeaderText = "ID",
                Width = 50,
                ReadOnly = true
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Name",
                HeaderText = "Название",
                Width = 150,
                ReadOnly = true
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Type",
                HeaderText = "Тип",
                Width = 80,
                ReadOnly = true
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Sugar",
                HeaderText = "Сладость",
                Width = 100,
                ReadOnly = true
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Homeland",
                HeaderText = "Страна",
                Width = 100,
                ReadOnly = true
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Rating",
                HeaderText = "Оценка",
                Width = 60,
                ReadOnly = true
            });

            // Настройка внешнего вида
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.Fixed3D;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void AddWineBtn_Click(object sender, EventArgs e)
        {
            using (var addForm = new AddWineForm())
            {
                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    WineToAdd = addForm.WineDto;
                    AddWineRequested?.Invoke(this, new WineEventArgs(WineToAdd));
                }
            }

        }

        private void ChangeWineBtn_Click(object sender, EventArgs e)
        {
            if (SelectedWine == null)
            {
                DisplayMessage("Выберите вино для редактирования", MessageType.Warning);
                return;
            }

            using (var editForm = new EditWineForm(SelectedWine))
            {
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    WineToEdit = editForm.WineDto;
                    EditWineRequested?.Invoke(this, new WineEventArgs(WineToEdit));
                }
            }
        }

        private void DeleteWineBtn_Click(object sender, EventArgs e)
        {
            if (SelectedWine == null)
            {
                DisplayMessage("Выберите вино для удаления", MessageType.Warning);
                return;
            }

            var result = MessageBox.Show(
                $"Удалить вино '{SelectedWine.Name}'?",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                DeleteWineRequested?.Invoke(this, new DeleteWineEventArgs(SelectedWine.Id));
            }
        }

        private void Search_Click(object sender, EventArgs e)
        {
            using (var searchForm = new SearchWineForm())
            {
                if (searchForm.ShowDialog() == DialogResult.OK)
                {
                    SearchCriteria = searchForm.Criteria;
                    SearchWinesRequested?.Invoke(this, new SearchWineEventArgs(SearchCriteria));
                }
            }
        }

        private void AllWine_Click(object sender, EventArgs e)
        {
            LoadWinesRequested?.Invoke(this, EventArgs.Empty);
        }

        private void GettingMarkBtn_Click(object sender, EventArgs e)
        {
            if (SelectedWine == null)
            {
                DisplayMessage("Выберите вино для оценки", MessageType.Warning);
                return;
            }

            using (var rateForm = new GettingMarkForm(SelectedWine.Id))
            {
                if (rateForm.ShowDialog() == DialogResult.OK)
                {
                    RatingInfo = new RatingInfo
                    {
                        WineId = SelectedWine.Id,
                        Rating = rateForm.Mark
                    };
                    RateWineRequested?.Invoke(this, new RateWineEventArgs(RatingInfo.WineId, RatingInfo.Rating));
                }
            }
        }

        private void BestWinesBtn_Click(object sender, EventArgs e)
        {
            ShowBestWinesRequested?.Invoke(this, EventArgs.Empty);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadWinesRequested?.Invoke(this, EventArgs.Empty);

        }
    }
}