namespace аис_лаба_1
{
    partial class EditWineForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditWineForm));
            this.ChangeBtn = new System.Windows.Forms.Button();
            this.nameWine = new System.Windows.Forms.TextBox();
            this.sugar = new System.Windows.Forms.ComboBox();
            this.type = new System.Windows.Forms.ComboBox();
            this.country = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ChangeBtn
            // 
            this.ChangeBtn.Location = new System.Drawing.Point(472, 39);
            this.ChangeBtn.Name = "ChangeBtn";
            this.ChangeBtn.Size = new System.Drawing.Size(126, 34);
            this.ChangeBtn.TabIndex = 5;
            this.ChangeBtn.Text = "Обновить";
            this.ChangeBtn.UseVisualStyleBackColor = true;
            this.ChangeBtn.Click += new System.EventHandler(this.ChangeBtn_Click);
            // 
            // nameWine
            // 
            this.nameWine.Location = new System.Drawing.Point(12, 12);
            this.nameWine.Name = "nameWine";
            this.nameWine.Size = new System.Drawing.Size(187, 20);
            this.nameWine.TabIndex = 9;
            this.nameWine.Text = "Название";
            // 
            // sugar
            // 
            this.sugar.FormattingEnabled = true;
            this.sugar.Location = new System.Drawing.Point(441, 12);
            this.sugar.Name = "sugar";
            this.sugar.Size = new System.Drawing.Size(157, 21);
            this.sugar.TabIndex = 7;
            this.sugar.Text = "Сладость";
            // 
            // type
            // 
            this.type.FormattingEnabled = true;
            this.type.Location = new System.Drawing.Point(205, 12);
            this.type.Name = "type";
            this.type.Size = new System.Drawing.Size(103, 21);
            this.type.TabIndex = 8;
            this.type.Text = "Тип";
            // 
            // country
            // 
            this.country.FormattingEnabled = true;
            this.country.Location = new System.Drawing.Point(314, 12);
            this.country.Name = "country";
            this.country.Size = new System.Drawing.Size(121, 21);
            this.country.TabIndex = 6;
            this.country.Text = "Страна";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(26, 39);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(362, 164);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // EditWineForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 200);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.ChangeBtn);
            this.Controls.Add(this.nameWine);
            this.Controls.Add(this.sugar);
            this.Controls.Add(this.type);
            this.Controls.Add(this.country);
            this.Name = "EditWineForm";
            this.Text = "Изменить";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ChangeBtn;
        private System.Windows.Forms.TextBox nameWine;
        private System.Windows.Forms.ComboBox sugar;
        private System.Windows.Forms.ComboBox type;
        private System.Windows.Forms.ComboBox country;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}