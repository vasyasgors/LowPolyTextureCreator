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
        public static MainForm Instance;


     
        private Texture texture;

        public MainForm()
        {
            if (Instance != null) return;

            Instance = this;

            InitializeComponent();


            foreach (ToolStripMenuItem menuItem in menuStrip1.Items)
                ((ToolStripDropDownMenu)menuItem.DropDown).ShowImageMargin = false;

            menuStrip1.Renderer = new CustomMenuRenderer();
            создатьToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.N;

            this.StartPosition = FormStartPosition.CenterScreen;




        }

        // Menu
        private void загрузитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();

            if (result != DialogResult.OK) return;

            texture = new Texture(sourcePictureBox, openFileDialog1.FileName);
            //texture.FillPictureBox(sourcePictureBox);
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

        public void CreateTexture(int colorAmount)
        {
            texture = new Texture(colorAmount);
            texture.FillPictureBox(sourcePictureBox);
        }


        private void sourcePictureBox_Click(object sender, EventArgs e)
        {
            MouseEventArgs mouseEventArgs = (e as MouseEventArgs);

            if (texture == null) return;

            if (mouseEventArgs.Button == MouseButtons.Left)
            {
                COLORColor color = texture.GetColorByPixelPosition(sourcePictureBox.Width, mouseEventArgs.X);

                colorDialog1.Color = System.Drawing.Color.FromArgb(color.R, color.G, color.B);

                if (colorDialog1.ShowDialog() == DialogResult.OK)
                {
                    int colorIndex = texture.GetColorIndexByPixelPosition(sourcePictureBox.Width, mouseEventArgs.X);
                    texture.SetColorByIndex(colorIndex, new COLORColor(colorDialog1.Color.R, colorDialog1.Color.G, colorDialog1.Color.B));
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


        }

        private void AddColorRight_Click(object sender, EventArgs e)
        {
            if (texture == null) return;

            texture.AddColorToRight(COLORColor.RandomColor());
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

            texture.AddColorToLeft(COLORColor.RandomColor());
            texture.FillPictureBox(sourcePictureBox);
        }

        private void RemoveColorLeft_Click(object sender, EventArgs e)
        {
            if (texture == null) return;

            texture.RemoveColorFromLeft();
            texture.FillPictureBox(sourcePictureBox);

        }

        private void создатьToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

            CreateTextureForm createTextureForm = new CreateTextureForm();
            createTextureForm.ShowDialog();
        }
    }

}
