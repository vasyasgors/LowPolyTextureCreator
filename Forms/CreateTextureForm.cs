using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LowPolyTextureCreater
{
    public partial class CreateTextureForm : Form
    {
        public CreateTextureForm()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;

            createButton.FlatAppearance.BorderColor = Color.FromArgb(51,51, 51);
            createButton.FlatAppearance.BorderSize = 1;
            createButton.ForeColor = Color.FromArgb(230, 230, 230);

            cancelButton.FlatAppearance.BorderColor = Color.FromArgb(51, 51, 51);
            cancelButton.FlatAppearance.BorderSize = 1;
            cancelButton.ForeColor = Color.FromArgb(230, 230, 230);

         
            colorAmountNumericUpDown.ForeColor = Color.FromArgb(230, 230, 230);
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            MainForm.Instance.CreateTexture((int) colorAmountNumericUpDown.Value);
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
