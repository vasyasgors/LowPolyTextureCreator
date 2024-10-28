namespace ColorPicker
{
    partial class ColorDialog
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
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.hueColorSlider = new ColorPicker.ColorSlider();
            this.valueColorSlider = new ColorPicker.ColorSlider();
            this.saturationColorSlider = new ColorPicker.ColorSlider();
            this.blueColorSlider = new ColorPicker.ColorSlider();
            this.greenColorSlider = new ColorPicker.ColorSlider();
            this.redColorSlider = new ColorPicker.ColorSlider();
            this.colorWheel1 = new ColorPicker.ColorWheel();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.Location = new System.Drawing.Point(291, 175);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 31;
            this.okButton.Text = "Ок";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Location = new System.Drawing.Point(372, 175);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 32;
            this.cancelButton.Text = "Отмена";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Visible = false;
            // 
            // hueColorSlider
            // 
            this.hueColorSlider.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.hueColorSlider.CustomGradient = null;
            this.hueColorSlider.Location = new System.Drawing.Point(227, 12);
            this.hueColorSlider.MaxColor = System.Drawing.Color.White;
            this.hueColorSlider.MinColor = System.Drawing.Color.Black;
            this.hueColorSlider.Mode = ColorPicker.ColorSlider.SliderMode.Degrees;
            this.hueColorSlider.Name = "hueColorSlider";
            this.hueColorSlider.Size = new System.Drawing.Size(220, 20);
            this.hueColorSlider.TabIndex = 28;
            this.hueColorSlider.Text = "H:";
            this.hueColorSlider.Value = 0;
            this.hueColorSlider.ValueChanged += new System.EventHandler(this.OnColorSliderValueChanged);
            // 
            // valueColorSlider
            // 
            this.valueColorSlider.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.valueColorSlider.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.valueColorSlider.CustomGradient = null;
            this.valueColorSlider.Location = new System.Drawing.Point(227, 64);
            this.valueColorSlider.MaxColor = System.Drawing.Color.White;
            this.valueColorSlider.MinColor = System.Drawing.Color.Black;
            this.valueColorSlider.Mode = ColorPicker.ColorSlider.SliderMode.Total;
            this.valueColorSlider.Name = "valueColorSlider";
            this.valueColorSlider.Size = new System.Drawing.Size(220, 20);
            this.valueColorSlider.TabIndex = 27;
            this.valueColorSlider.Text = "V:";
            this.valueColorSlider.Value = 0;
            this.valueColorSlider.ValueChanged += new System.EventHandler(this.OnColorSliderValueChanged);
            // 
            // saturationColorSlider
            // 
            this.saturationColorSlider.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.saturationColorSlider.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.saturationColorSlider.CustomGradient = null;
            this.saturationColorSlider.Location = new System.Drawing.Point(227, 38);
            this.saturationColorSlider.MaxColor = System.Drawing.Color.White;
            this.saturationColorSlider.MinColor = System.Drawing.Color.Black;
            this.saturationColorSlider.Mode = ColorPicker.ColorSlider.SliderMode.Total;
            this.saturationColorSlider.Name = "saturationColorSlider";
            this.saturationColorSlider.Size = new System.Drawing.Size(220, 20);
            this.saturationColorSlider.TabIndex = 26;
            this.saturationColorSlider.Text = "S:";
            this.saturationColorSlider.Value = 0;
            this.saturationColorSlider.ValueChanged += new System.EventHandler(this.OnColorSliderValueChanged);
            // 
            // blueColorSlider
            // 
            this.blueColorSlider.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.blueColorSlider.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.blueColorSlider.CustomGradient = null;
            this.blueColorSlider.Location = new System.Drawing.Point(227, 147);
            this.blueColorSlider.MaxColor = System.Drawing.Color.Blue;
            this.blueColorSlider.MinColor = System.Drawing.Color.Black;
            this.blueColorSlider.Mode = ColorPicker.ColorSlider.SliderMode.Channel;
            this.blueColorSlider.Name = "blueColorSlider";
            this.blueColorSlider.Size = new System.Drawing.Size(220, 20);
            this.blueColorSlider.TabIndex = 24;
            this.blueColorSlider.Text = "B:";
            this.blueColorSlider.Value = 0;
            this.blueColorSlider.ValueChanged += new System.EventHandler(this.OnColorSliderValueChanged);
            this.blueColorSlider.Load += new System.EventHandler(this.blueColorSlider_Load);
            // 
            // greenColorSlider
            // 
            this.greenColorSlider.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.greenColorSlider.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.greenColorSlider.CustomGradient = null;
            this.greenColorSlider.Location = new System.Drawing.Point(227, 121);
            this.greenColorSlider.MaxColor = System.Drawing.Color.Lime;
            this.greenColorSlider.MinColor = System.Drawing.Color.Black;
            this.greenColorSlider.Mode = ColorPicker.ColorSlider.SliderMode.Channel;
            this.greenColorSlider.Name = "greenColorSlider";
            this.greenColorSlider.Size = new System.Drawing.Size(220, 20);
            this.greenColorSlider.TabIndex = 23;
            this.greenColorSlider.Text = "G:";
            this.greenColorSlider.Value = 0;
            this.greenColorSlider.ValueChanged += new System.EventHandler(this.OnColorSliderValueChanged);
            // 
            // redColorSlider
            // 
            this.redColorSlider.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.redColorSlider.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.redColorSlider.CustomGradient = null;
            this.redColorSlider.Location = new System.Drawing.Point(227, 90);
            this.redColorSlider.MaxColor = System.Drawing.Color.Red;
            this.redColorSlider.MinColor = System.Drawing.Color.Black;
            this.redColorSlider.Mode = ColorPicker.ColorSlider.SliderMode.Channel;
            this.redColorSlider.Name = "redColorSlider";
            this.redColorSlider.Size = new System.Drawing.Size(220, 20);
            this.redColorSlider.TabIndex = 22;
            this.redColorSlider.Text = "R:";
            this.redColorSlider.Value = 0;
            this.redColorSlider.ValueChanged += new System.EventHandler(this.OnColorSliderValueChanged);
            // 
            // colorWheel1
            // 
            this.colorWheel1.Location = new System.Drawing.Point(12, 12);
            this.colorWheel1.Name = "colorWheel1";
            this.colorWheel1.Size = new System.Drawing.Size(186, 186);
            this.colorWheel1.TabIndex = 0;
            this.colorWheel1.ColorChanged += new System.EventHandler(this.OnWheelColorChanged);
            // 
            // ColorDialog
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(464, 207);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.hueColorSlider);
            this.Controls.Add(this.valueColorSlider);
            this.Controls.Add(this.saturationColorSlider);
            this.Controls.Add(this.blueColorSlider);
            this.Controls.Add(this.greenColorSlider);
            this.Controls.Add(this.redColorSlider);
            this.Controls.Add(this.colorWheel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ColorDialog";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Color";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ColorDialog_KeyPress);
            this.ResumeLayout(false);

        }

        #endregion

        private ColorWheel colorWheel1;
        private ColorSlider redColorSlider;
        private ColorSlider greenColorSlider;
        private ColorSlider blueColorSlider;
        private ColorSlider saturationColorSlider;
        private ColorSlider valueColorSlider;
        private ColorSlider hueColorSlider;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
    }
}