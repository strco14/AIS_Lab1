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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.AddWineBtn = new System.Windows.Forms.Button();
            this.ChangeWineBtn = new System.Windows.Forms.Button();
            this.DeleteWineBtn = new System.Windows.Forms.Button();
            this.Search = new System.Windows.Forms.Button();
            this.AllWine = new System.Windows.Forms.Button();
            this.GettingMarkBtn = new System.Windows.Forms.Button();
            this.BestWinesBtn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // AddWineBtn
            // 
            this.AddWineBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.AddWineBtn.Location = new System.Drawing.Point(6, 19);
            this.AddWineBtn.Name = "AddWineBtn";
            this.AddWineBtn.Size = new System.Drawing.Size(120, 30);
            this.AddWineBtn.TabIndex = 7;
            this.AddWineBtn.Text = "Добавить";
            this.AddWineBtn.UseVisualStyleBackColor = true;
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
            this.DeleteWineBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.DeleteWineBtn.Location = new System.Drawing.Point(6, 55);
            this.DeleteWineBtn.Name = "DeleteWineBtn";
            this.DeleteWineBtn.Size = new System.Drawing.Size(120, 30);
            this.DeleteWineBtn.TabIndex = 9;
            this.DeleteWineBtn.Text = "Удалить";
            this.DeleteWineBtn.UseVisualStyleBackColor = true;
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
            this.GettingMarkBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.GettingMarkBtn.Location = new System.Drawing.Point(6, 58);
            this.GettingMarkBtn.Name = "GettingMarkBtn";
            this.GettingMarkBtn.Size = new System.Drawing.Size(118, 28);
            this.GettingMarkBtn.TabIndex = 12;
            this.GettingMarkBtn.Text = "Выдать оценку";
            this.GettingMarkBtn.UseVisualStyleBackColor = true;
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.Size = new System.Drawing.Size(627, 450);
            this.dataGridView1.TabIndex = 14;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.AddWineBtn);
            this.groupBox1.Controls.Add(this.DeleteWineBtn);
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
            this.groupBox2.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Controls.Add(this.ChangeWineBtn);
            this.groupBox2.Controls.Add(this.GettingMarkBtn);
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
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
    }
}

