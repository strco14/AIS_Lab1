namespace аис_лаба_1
{
    partial class SearchWineForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchWineForm));
            this.nameWine = new System.Windows.Forms.TextBox();
            this.sugar = new System.Windows.Forms.ComboBox();
            this.type = new System.Windows.Forms.ComboBox();
            this.country = new System.Windows.Forms.ComboBox();
            this.SearchBtn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // nameWine
            // 
            this.nameWine.Location = new System.Drawing.Point(12, 28);
            this.nameWine.Name = "nameWine";
            this.nameWine.Size = new System.Drawing.Size(187, 20);
            this.nameWine.TabIndex = 13;
            // 
            // sugar
            // 
            this.sugar.FormattingEnabled = true;
            this.sugar.Location = new System.Drawing.Point(441, 28);
            this.sugar.Name = "sugar";
            this.sugar.Size = new System.Drawing.Size(157, 21);
            this.sugar.TabIndex = 11;
            this.sugar.Text = "Сладость";
            // 
            // type
            // 
            this.type.FormattingEnabled = true;
            this.type.Location = new System.Drawing.Point(205, 28);
            this.type.Name = "type";
            this.type.Size = new System.Drawing.Size(103, 21);
            this.type.TabIndex = 12;
            this.type.Text = "Тип";
            // 
            // country
            // 
            this.country.FormattingEnabled = true;
            this.country.Location = new System.Drawing.Point(314, 28);
            this.country.Name = "country";
            this.country.Size = new System.Drawing.Size(121, 21);
            this.country.TabIndex = 10;
            this.country.Text = "Страна";
            // 
            // SearchBtn
            // 
            this.SearchBtn.Location = new System.Drawing.Point(441, 78);
            this.SearchBtn.Name = "SearchBtn";
            this.SearchBtn.Size = new System.Drawing.Size(126, 34);
            this.SearchBtn.TabIndex = 14;
            this.SearchBtn.Text = "Найти";
            this.SearchBtn.UseVisualStyleBackColor = true;
            this.SearchBtn.Click += new System.EventHandler(this.SearchBtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(24, 63);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(276, 189);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // SearchWineForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 246);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.SearchBtn);
            this.Controls.Add(this.nameWine);
            this.Controls.Add(this.sugar);
            this.Controls.Add(this.type);
            this.Controls.Add(this.country);
            this.Name = "SearchWineForm";
            this.Text = "SearchWineForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nameWine;
        private System.Windows.Forms.ComboBox sugar;
        private System.Windows.Forms.ComboBox type;
        private System.Windows.Forms.ComboBox country;
        private System.Windows.Forms.Button SearchBtn;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}