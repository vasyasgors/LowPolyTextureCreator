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



        private int selectedIndexColor = -1;
        private Texture texture;

        private Color copiedColor;
        private bool isCopied = false;

        public MainForm()
        {

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

            selectedIndexColor = texture.GetColorIndexByPixelPosition(sourcePictureBox.Width, mouseEventArgs.X);

            if (mouseEventArgs.Button == MouseButtons.Right)
            {
                вставитьToolStripMenuItem.Enabled = isCopied;
                удалитьToolStripMenuItem.Enabled = texture.Colors.Count != 1;
                contextMenuStrip1.Show(Cursor.Position);
            }

            if (mouseEventArgs.Button == MouseButtons.Left)
            {
                Color color = texture.GetColorByIndex(selectedIndexColor);

                
                ColorPicker.ColorDialog colorDialog = new ColorPicker.ColorDialog();
                colorDialog.Color = color;

                colorDialog.ColorChanged += (s, ev) =>
                {
                    texture.SetColorByIndex(selectedIndexColor, colorDialog.Color);
                    texture.FillPictureBox(sourcePictureBox);

                };


                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    texture.SetColorByIndex(selectedIndexColor, colorDialog.Color);
                    texture.FillPictureBox(sourcePictureBox);
                }
                


            }
        }

    
        private void создатьToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

            CreateTextureForm createTextureForm = new CreateTextureForm();
            if (createTextureForm.ShowDialog() == DialogResult.OK)
            {
                texture = new Texture(createTextureForm.ColorAmount);
                texture.FillPictureBox(sourcePictureBox);
            }
        }

        private void добавитьСлеваToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (texture == null) return;

            texture.InsterRandomColor(selectedIndexColor);
            texture.FillPictureBox(sourcePictureBox);
        }

        private void добавитьСправаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (texture == null) return;

            texture.InsterRandomColor(selectedIndexColor + 1);
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
