using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;



namespace LowPolyTextureCreater
{
    public partial class MainForm : Form
    {


        private Texture texture;

        public MainForm()
        {
            InitializeComponent();



        }

        // Menu
        private void загрузитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();

            if (result != DialogResult.OK) return;

            texture = new Texture(openFileDialog1.FileName);
            texture.FillPictureBox(sourcePictureBox);
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sourcePictureBox.Image == null) return;

            DialogResult result = saveFileDialog1.ShowDialog();

            if (result != DialogResult.OK) return;

            sourcePictureBox.Image.Save(saveFileDialog1.FileName);

        }

 

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
        
        }

        private void sourcePictureBox_Click(object sender, EventArgs e)
        {
            MouseEventArgs mouseEventArgs = (e as MouseEventArgs);

            if (mouseEventArgs.Button == MouseButtons.Left)
            {
                if (colorDialog1.ShowDialog() == DialogResult.OK)
                {
                    int colorIndex = texture.GetColorIndexByPixelColor(sourcePictureBox.Width, mouseEventArgs.X);
                    texture.SetColorByIndex(colorIndex, new Color(colorDialog1.Color.R, colorDialog1.Color.G, colorDialog1.Color.B));
                    texture.FillPictureBox(sourcePictureBox);
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ColorPicker.ColorDialog colorDialog = new ColorPicker.ColorDialog();
            colorDialog.ShowDialog();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        private void CreateTexture_Click(object sender, EventArgs e)
        {
            texture = new Texture( int.Parse(colorAmountTextBox.Text));
            texture.FillPictureBox(sourcePictureBox);
        }

        private void AddColorRight_Click(object sender, EventArgs e)
        {
            if (texture == null) return;

            texture.AddColorToRight(Color.RandomColor());
            texture.FillPictureBox(sourcePictureBox);
        }

        private void RemoveColorRight_Click(object sender, EventArgs e)
        {
            if (texture == null) return;

            texture.RemoveColorFormRight();
            texture.FillPictureBox(sourcePictureBox);
        }

        private void AddColorLeft_Click(object sender, EventArgs e)
        {
            if (texture == null) return;

            texture.AddColorToLeft(Color.RandomColor());
            texture.FillPictureBox(sourcePictureBox);
        }

        private void RemoveColorLeft_Click(object sender, EventArgs e)
        {
            if (texture == null) return;

            texture.RemoveColorFromLeft();
            texture.FillPictureBox(sourcePictureBox);

        }
    }

}
