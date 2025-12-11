namespace аис_лаба_1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.AddWineBtn = new System.Windows.Forms.Button();
            this.ChangeWineBtn = new System.Windows.Forms.Button();
            this.DeleteWineBtn = new System.Windows.Forms.Button();
            this.Search = new System.Windows.Forms.Button();
            this.AllWine = new System.Windows.Forms.Button();
            this.GettingMarkBtn = new System.Windows.Forms.Button();
            this.BestWinesBtn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sugarDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.homelandDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ratingDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.winesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.databaseWinesDataSet = new аис_лаба_1.DatabaseWinesDataSet();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.winesTableAdapter = new аис_лаба_1.DatabaseWinesDataSetTableAdapters.WinesTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.winesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.databaseWinesDataSet)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // AddWineBtn
            // 
            this.AddWineBtn.BackColor = System.Drawing.SystemColors.Control;
            this.AddWineBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.AddWineBtn.Location = new System.Drawing.Point(6, 19);
            this.AddWineBtn.Name = "AddWineBtn";
            this.AddWineBtn.Size = new System.Drawing.Size(120, 30);
            this.AddWineBtn.TabIndex = 7;
            this.AddWineBtn.Text = "Добавить";
            this.AddWineBtn.UseVisualStyleBackColor = false;
            this.AddWineBtn.Click += new System.EventHandler(this.AddWineBtn_Click);
            // 
            // ChangeWineBtn
            // 
            this.ChangeWineBtn.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ChangeWineBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ChangeWineBtn.Location = new System.Drawing.Point(6, 19);
            this.ChangeWineBtn.Name = "ChangeWineBtn";
            this.ChangeWineBtn.Size = new System.Drawing.Size(120, 30);
            this.ChangeWineBtn.TabIndex = 8;
            this.ChangeWineBtn.Text = "Изменить";
            this.ChangeWineBtn.UseVisualStyleBackColor = false;
            this.ChangeWineBtn.Click += new System.EventHandler(this.ChangeWineBtn_Click);
            // 
            // DeleteWineBtn
            // 
            this.DeleteWineBtn.BackColor = System.Drawing.SystemColors.Control;
            this.DeleteWineBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.DeleteWineBtn.Location = new System.Drawing.Point(6, 55);
            this.DeleteWineBtn.Name = "DeleteWineBtn";
            this.DeleteWineBtn.Size = new System.Drawing.Size(120, 30);
            this.DeleteWineBtn.TabIndex = 9;
            this.DeleteWineBtn.Text = "Удалить";
            this.DeleteWineBtn.UseVisualStyleBackColor = false;
            this.DeleteWineBtn.Click += new System.EventHandler(this.DeleteWineBtn_Click);
            // 
            // Search
            // 
            this.Search.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Search.Location = new System.Drawing.Point(6, 19);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(119, 28);
            this.Search.TabIndex = 10;
            this.Search.Text = "Поиск";
            this.Search.UseVisualStyleBackColor = true;
            this.Search.Click += new System.EventHandler(this.Search_Click);
            // 
            // AllWine
            // 
            this.AllWine.ForeColor = System.Drawing.SystemColors.ControlText;
            this.AllWine.Location = new System.Drawing.Point(7, 87);
            this.AllWine.Name = "AllWine";
            this.AllWine.Size = new System.Drawing.Size(118, 28);
            this.AllWine.TabIndex = 11;
            this.AllWine.Text = "Показать все";
            this.AllWine.UseVisualStyleBackColor = true;
            this.AllWine.Click += new System.EventHandler(this.AllWine_Click);
            // 
            // GettingMarkBtn
            // 
            this.GettingMarkBtn.BackColor = System.Drawing.SystemColors.Control;
            this.GettingMarkBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.GettingMarkBtn.Location = new System.Drawing.Point(6, 58);
            this.GettingMarkBtn.Name = "GettingMarkBtn";
            this.GettingMarkBtn.Size = new System.Drawing.Size(118, 28);
            this.GettingMarkBtn.TabIndex = 12;
            this.GettingMarkBtn.Text = "Выдать оценку";
            this.GettingMarkBtn.UseVisualStyleBackColor = false;
            this.GettingMarkBtn.Click += new System.EventHandler(this.GettingMarkBtn_Click);
            // 
            // BestWinesBtn
            // 
            this.BestWinesBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BestWinesBtn.Location = new System.Drawing.Point(6, 53);
            this.BestWinesBtn.Name = "BestWinesBtn";
            this.BestWinesBtn.Size = new System.Drawing.Size(119, 28);
            this.BestWinesBtn.TabIndex = 13;
            this.BestWinesBtn.Text = "Лучшие вина";
            this.BestWinesBtn.UseVisualStyleBackColor = true;
            this.BestWinesBtn.Click += new System.EventHandler(this.BestWinesBtn_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.typeDataGridViewTextBoxColumn,
            this.sugarDataGridViewTextBoxColumn,
            this.homelandDataGridViewTextBoxColumn,
            this.ratingDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.winesBindingSource;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle11;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dataGridView1.Size = new System.Drawing.Size(627, 450);
            this.dataGridView1.TabIndex = 14;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // typeDataGridViewTextBoxColumn
            // 
            this.typeDataGridViewTextBoxColumn.DataPropertyName = "Type";
            this.typeDataGridViewTextBoxColumn.HeaderText = "Type";
            this.typeDataGridViewTextBoxColumn.Name = "typeDataGridViewTextBoxColumn";
            // 
            // sugarDataGridViewTextBoxColumn
            // 
            this.sugarDataGridViewTextBoxColumn.DataPropertyName = "Sugar";
            this.sugarDataGridViewTextBoxColumn.HeaderText = "Sugar";
            this.sugarDataGridViewTextBoxColumn.Name = "sugarDataGridViewTextBoxColumn";
            // 
            // homelandDataGridViewTextBoxColumn
            // 
            this.homelandDataGridViewTextBoxColumn.DataPropertyName = "Homeland";
            this.homelandDataGridViewTextBoxColumn.HeaderText = "Homeland";
            this.homelandDataGridViewTextBoxColumn.Name = "homelandDataGridViewTextBoxColumn";
            // 
            // ratingDataGridViewTextBoxColumn
            // 
            this.ratingDataGridViewTextBoxColumn.DataPropertyName = "Rating";
            this.ratingDataGridViewTextBoxColumn.HeaderText = "Rating";
            this.ratingDataGridViewTextBoxColumn.Name = "ratingDataGridViewTextBoxColumn";
            // 
            // winesBindingSource
            // 
            this.winesBindingSource.DataMember = "Wines";
            this.winesBindingSource.DataSource = this.databaseWinesDataSet;
            // 
            // databaseWinesDataSet
            // 
            this.databaseWinesDataSet.DataSetName = "DatabaseWinesDataSet";
            this.databaseWinesDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Maroon;
            this.groupBox1.Controls.Add(this.DeleteWineBtn);
            this.groupBox1.Controls.Add(this.AddWineBtn);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Location = new System.Drawing.Point(640, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(134, 96);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Изменение таблицы";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Maroon;
            this.groupBox2.Controls.Add(this.GettingMarkBtn);
            this.groupBox2.Controls.Add(this.ChangeWineBtn);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Location = new System.Drawing.Point(640, 107);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(134, 95);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Для Сомелье";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.pictureBox1);
            this.groupBox3.Controls.Add(this.Search);
            this.groupBox3.Controls.Add(this.BestWinesBtn);
            this.groupBox3.Controls.Add(this.AllWine);
            this.groupBox3.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox3.Location = new System.Drawing.Point(640, 208);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(134, 242);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Поиск вин";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 118);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(112, 112);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // winesTableAdapter
            // 
            this.winesTableAdapter.ClearBeforeFill = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 450);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Винный погреб";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.winesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.databaseWinesDataSet)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button AddWineBtn;
        private System.Windows.Forms.Button ChangeWineBtn;
        private System.Windows.Forms.Button DeleteWineBtn;
        private System.Windows.Forms.Button Search;
        private System.Windows.Forms.Button AllWine;
        private System.Windows.Forms.Button GettingMarkBtn;
        private System.Windows.Forms.Button BestWinesBtn;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DatabaseWinesDataSet databaseWinesDataSet;
        private System.Windows.Forms.BindingSource winesBindingSource;
        private DatabaseWinesDataSetTableAdapters.WinesTableAdapter winesTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sugarDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn homelandDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ratingDataGridViewTextBoxColumn;
    }
}

