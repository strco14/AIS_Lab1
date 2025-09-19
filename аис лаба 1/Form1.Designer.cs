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
            this.listWines = new System.Windows.Forms.ListBox();
            this.AddWineBtn = new System.Windows.Forms.Button();
            this.ChangeWineBtn = new System.Windows.Forms.Button();
            this.DeleteWineBtn = new System.Windows.Forms.Button();
            this.Search = new System.Windows.Forms.Button();
            this.AllWine = new System.Windows.Forms.Button();
            this.GettingMarkBtn = new System.Windows.Forms.Button();
            this.BestWinesBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listWines
            // 
            this.listWines.FormattingEnabled = true;
            this.listWines.Location = new System.Drawing.Point(4, 6);
            this.listWines.Name = "listWines";
            this.listWines.Size = new System.Drawing.Size(630, 433);
            this.listWines.TabIndex = 6;
            // 
            // AddWineBtn
            // 
            this.AddWineBtn.Location = new System.Drawing.Point(640, 6);
            this.AddWineBtn.Name = "AddWineBtn";
            this.AddWineBtn.Size = new System.Drawing.Size(120, 30);
            this.AddWineBtn.TabIndex = 7;
            this.AddWineBtn.Text = "Добавить";
            this.AddWineBtn.UseVisualStyleBackColor = true;
            this.AddWineBtn.Click += new System.EventHandler(this.AddWineBtn_Click);
            // 
            // ChangeWineBtn
            // 
            this.ChangeWineBtn.Location = new System.Drawing.Point(640, 51);
            this.ChangeWineBtn.Name = "ChangeWineBtn";
            this.ChangeWineBtn.Size = new System.Drawing.Size(120, 30);
            this.ChangeWineBtn.TabIndex = 8;
            this.ChangeWineBtn.Text = "Изменить";
            this.ChangeWineBtn.UseVisualStyleBackColor = true;
            this.ChangeWineBtn.Click += new System.EventHandler(this.ChangeWineBtn_Click);
            // 
            // DeleteWineBtn
            // 
            this.DeleteWineBtn.Location = new System.Drawing.Point(640, 97);
            this.DeleteWineBtn.Name = "DeleteWineBtn";
            this.DeleteWineBtn.Size = new System.Drawing.Size(120, 30);
            this.DeleteWineBtn.TabIndex = 9;
            this.DeleteWineBtn.Text = "Удалить";
            this.DeleteWineBtn.UseVisualStyleBackColor = true;
            this.DeleteWineBtn.Click += new System.EventHandler(this.DeleteWineBtn_Click);
            // 
            // Search
            // 
            this.Search.Location = new System.Drawing.Point(640, 147);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(119, 28);
            this.Search.TabIndex = 10;
            this.Search.Text = "Поиск";
            this.Search.UseVisualStyleBackColor = true;
            this.Search.Click += new System.EventHandler(this.Search_Click);
            // 
            // AllWine
            // 
            this.AllWine.Location = new System.Drawing.Point(640, 193);
            this.AllWine.Name = "AllWine";
            this.AllWine.Size = new System.Drawing.Size(118, 28);
            this.AllWine.TabIndex = 11;
            this.AllWine.Text = "Показать все";
            this.AllWine.UseVisualStyleBackColor = true;
            this.AllWine.Click += new System.EventHandler(this.AllWine_Click);
            // 
            // GettingMarkBtn
            // 
            this.GettingMarkBtn.Location = new System.Drawing.Point(640, 241);
            this.GettingMarkBtn.Name = "GettingMarkBtn";
            this.GettingMarkBtn.Size = new System.Drawing.Size(118, 28);
            this.GettingMarkBtn.TabIndex = 12;
            this.GettingMarkBtn.Text = "Выдать оценку";
            this.GettingMarkBtn.UseVisualStyleBackColor = true;
            this.GettingMarkBtn.Click += new System.EventHandler(this.GettingMarkBtn_Click);
            // 
            // BestWinesBtn
            // 
            this.BestWinesBtn.Location = new System.Drawing.Point(640, 289);
            this.BestWinesBtn.Name = "BestWinesBtn";
            this.BestWinesBtn.Size = new System.Drawing.Size(119, 28);
            this.BestWinesBtn.TabIndex = 13;
            this.BestWinesBtn.Text = "Лучшие вина";
            this.BestWinesBtn.UseVisualStyleBackColor = true;
            this.BestWinesBtn.Click += new System.EventHandler(this.BestWinesBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 450);
            this.Controls.Add(this.BestWinesBtn);
            this.Controls.Add(this.GettingMarkBtn);
            this.Controls.Add(this.AllWine);
            this.Controls.Add(this.Search);
            this.Controls.Add(this.DeleteWineBtn);
            this.Controls.Add(this.ChangeWineBtn);
            this.Controls.Add(this.AddWineBtn);
            this.Controls.Add(this.listWines);
            this.Name = "Form1";
            this.Text = "Винный погреб";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListBox listWines;
        private System.Windows.Forms.Button AddWineBtn;
        private System.Windows.Forms.Button ChangeWineBtn;
        private System.Windows.Forms.Button DeleteWineBtn;
        private System.Windows.Forms.Button Search;
        private System.Windows.Forms.Button AllWine;
        private System.Windows.Forms.Button GettingMarkBtn;
        private System.Windows.Forms.Button BestWinesBtn;
    }
}

