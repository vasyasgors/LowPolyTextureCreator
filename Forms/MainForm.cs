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


        private int selectedIndexColor = -1;
        private Texture texture;

        private COLORColor copiedColor;
        private bool isCopied = false;

        public MainForm()
        {
            if (Instance != null) return;

            Instance = this;

            InitializeComponent();

            menuStrip1.Renderer = new CustomMenuRenderer();
            contextMenuStrip1.Renderer = new CustomMenuRenderer();

            foreach (ToolStripMenuItem menuItem in menuStrip1.Items)
                ((ToolStripDropDownMenu)menuItem.DropDown).ShowImageMargin = false;


            contextMenuStrip1.ShowImageMargin = false;




            создатьToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.N;

            this.StartPosition = FormStartPosition.CenterScreen;


            CreateTexture(4);



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


            if (mouseEventArgs.Button == MouseButtons.Right)
            {

                selectedIndexColor = texture.GetColorIndexByPixelPosition(sourcePictureBox.Width, mouseEventArgs.X);


                вставитьToolStripMenuItem.Enabled = isCopied;
                удалитьToolStripMenuItem.Enabled = texture.Colors.Count != 1;
                contextMenuStrip1.Show(Cursor.Position);
            }

          

           



            if (mouseEventArgs.Button == MouseButtons.Left)
            {
                COLORColor color = texture.GetColorByPixelPosition(sourcePictureBox.Width, mouseEventArgs.X);

                colorDialog1.Color = System.Drawing.Color.FromArgb(color.R, color.G, color.B);



                ColorPicker.ColorDialog colorDialog = new ColorPicker.ColorDialog();

                colorDialog.Color = System.Drawing.Color.FromArgb(color.R, color.G, color.B);



                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    int colorIndex = texture.GetColorIndexByPixelPosition(sourcePictureBox.Width, mouseEventArgs.X);

                    texture.SetColorByIndex(colorIndex, new COLORColor(
                        colorDialog.Color.R, 
                        colorDialog.Color.G, 
                        colorDialog.Color.B));

                    texture.FillPictureBox(sourcePictureBox);

                   
                }


                /*

                if (colorDialog1.ShowDialog() == DialogResult.OK)
                {
                    int colorIndex = texture.GetColorIndexByPixelPosition(sourcePictureBox.Width, mouseEventArgs.X);
                    texture.SetColorByIndex(colorIndex, new COLORColor(colorDialog1.Color.R, colorDialog1.Color.G, colorDialog1.Color.B));
                    texture.FillPictureBox(sourcePictureBox);
                }*/
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

        }

        private void RemoveColorRight_Click(object sender, EventArgs e)
        {
      
        }

        private void AddColorLeft_Click(object sender, EventArgs e)
        {
          
        }

        private void RemoveColorLeft_Click(object sender, EventArgs e)
        {


        }

        private void создатьToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

            CreateTextureForm createTextureForm = new CreateTextureForm();
            createTextureForm.ShowDialog();
        }

        private void добавитьСлеваToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (texture == null) return;

            texture.InsterColor(selectedIndexColor, COLORColor.RandomColor());
            texture.FillPictureBox(sourcePictureBox);
        }

        private void добавитьСправаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (texture == null) return;

            texture.InsterColor(selectedIndexColor + 1, COLORColor.RandomColor());
            texture.FillPictureBox(sourcePictureBox);

        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (texture == null) return;

            texture.RemoveColorAt(selectedIndexColor);
            texture.FillPictureBox(sourcePictureBox);
        }

        private void копироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            copiedColor = texture.GetColorByIndex(selectedIndexColor);
            isCopied = true;
        }

        private void вставитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            texture.SetColorByIndex(selectedIndexColor, copiedColor);
            texture.FillPictureBox(sourcePictureBox);
        }
    }

}
