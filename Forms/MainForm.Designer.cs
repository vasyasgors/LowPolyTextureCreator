namespace LowPolyTextureCreater
{
    partial class MainForm
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
            this.sourcePictureBox = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.загрузитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.AddColorRight = new System.Windows.Forms.Button();
            this.RemoveColorRight = new System.Windows.Forms.Button();
            this.RemoveColorLeft = new System.Windows.Forms.Button();
            this.AddColorLeft = new System.Windows.Forms.Button();
            this.CreateTexture = new System.Windows.Forms.Button();
            this.colorAmountTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.sourcePictureBox)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // sourcePictureBox
            // 
            this.sourcePictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sourcePictureBox.Location = new System.Drawing.Point(82, 65);
            this.sourcePictureBox.Name = "sourcePictureBox";
            this.sourcePictureBox.Size = new System.Drawing.Size(512, 512);
            this.sourcePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.sourcePictureBox.TabIndex = 0;
            this.sourcePictureBox.TabStop = false;
            this.sourcePictureBox.Click += new System.EventHandler(this.sourcePictureBox_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(646, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.загрузитьToolStripMenuItem,
            this.сохранитьToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // загрузитьToolStripMenuItem
            // 
            this.загрузитьToolStripMenuItem.Name = "загрузитьToolStripMenuItem";
            this.загрузитьToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.загрузитьToolStripMenuItem.Text = "Открыть";
            this.загрузитьToolStripMenuItem.Click += new System.EventHandler(this.загрузитьToolStripMenuItem_Click);
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "PNG|*.png";
            // 
            // colorDialog1
            // 
            this.colorDialog1.FullOpen = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(183, 583);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(287, 27);
            this.button1.TabIndex = 10;
            this.button1.Text = "Открыть альтернатинвый выбиральщик цвета";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AddColorRight
            // 
            this.AddColorRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddColorRight.Location = new System.Drawing.Point(600, 249);
            this.AddColorRight.Name = "AddColorRight";
            this.AddColorRight.Size = new System.Drawing.Size(37, 35);
            this.AddColorRight.TabIndex = 11;
            this.AddColorRight.Text = "+";
            this.AddColorRight.UseVisualStyleBackColor = true;
            this.AddColorRight.Click += new System.EventHandler(this.AddColorRight_Click);
            // 
            // RemoveColorRight
            // 
            this.RemoveColorRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RemoveColorRight.Location = new System.Drawing.Point(600, 290);
            this.RemoveColorRight.Name = "RemoveColorRight";
            this.RemoveColorRight.Size = new System.Drawing.Size(37, 35);
            this.RemoveColorRight.TabIndex = 12;
            this.RemoveColorRight.Text = "-";
            this.RemoveColorRight.UseVisualStyleBackColor = true;
            this.RemoveColorRight.Click += new System.EventHandler(this.RemoveColorRight_Click);
            // 
            // RemoveColorLeft
            // 
            this.RemoveColorLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RemoveColorLeft.Location = new System.Drawing.Point(39, 290);
            this.RemoveColorLeft.Name = "RemoveColorLeft";
            this.RemoveColorLeft.Size = new System.Drawing.Size(37, 35);
            this.RemoveColorLeft.TabIndex = 14;
            this.RemoveColorLeft.Text = "-";
            this.RemoveColorLeft.UseVisualStyleBackColor = true;
            this.RemoveColorLeft.Click += new System.EventHandler(this.RemoveColorLeft_Click);
            // 
            // AddColorLeft
            // 
            this.AddColorLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddColorLeft.Location = new System.Drawing.Point(39, 249);
            this.AddColorLeft.Name = "AddColorLeft";
            this.AddColorLeft.Size = new System.Drawing.Size(37, 35);
            this.AddColorLeft.TabIndex = 13;
            this.AddColorLeft.Text = "+";
            this.AddColorLeft.UseVisualStyleBackColor = true;
            this.AddColorLeft.Click += new System.EventHandler(this.AddColorLeft_Click);
            // 
            // CreateTexture
            // 
            this.CreateTexture.Location = new System.Drawing.Point(361, 36);
            this.CreateTexture.Name = "CreateTexture";
            this.CreateTexture.Size = new System.Drawing.Size(75, 23);
            this.CreateTexture.TabIndex = 15;
            this.CreateTexture.Text = "Создать";
            this.CreateTexture.UseVisualStyleBackColor = true;
            this.CreateTexture.Click += new System.EventHandler(this.CreateTexture_Click);
            // 
            // colorAmountTextBox
            // 
            this.colorAmountTextBox.Location = new System.Drawing.Point(315, 38);
            this.colorAmountTextBox.Name = "colorAmountTextBox";
            this.colorAmountTextBox.Size = new System.Drawing.Size(30, 20);
            this.colorAmountTextBox.TabIndex = 16;
            this.colorAmountTextBox.Text = "4";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(230, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Кол-во цветов:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 624);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.colorAmountTextBox);
            this.Controls.Add(this.CreateTexture);
            this.Controls.Add(this.RemoveColorLeft);
            this.Controls.Add(this.AddColorLeft);
            this.Controls.Add(this.RemoveColorRight);
            this.Controls.Add(this.AddColorRight);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.sourcePictureBox);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Low Poly Texture Creator";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sourcePictureBox)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox sourcePictureBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem загрузитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button AddColorRight;
        private System.Windows.Forms.Button RemoveColorRight;
        private System.Windows.Forms.Button RemoveColorLeft;
        private System.Windows.Forms.Button AddColorLeft;
        private System.Windows.Forms.Button CreateTexture;
        private System.Windows.Forms.TextBox colorAmountTextBox;
        private System.Windows.Forms.Label label1;
    }
}

