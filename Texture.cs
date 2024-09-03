using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LowPolyTextureCreater
{

    class Texture
    {
        //private const string NewFileImagePath = "source_TEMP.png";
        private const int Width = 256;


        public List<Color> Colors;

        private int pixelForColor;

        public Texture(int colorAmount)
        {
            Colors = new List<Color>();
            Random rnd = new Random();

            for (int i = 0; i < colorAmount; i++)
            {
                Colors.Add(Color.FromArgb(rnd.Next(0, 255), rnd.Next(0, 255),rnd.Next(0, 255)) );
            }

            pixelForColor = (int) (Width / Colors.Count);
        }

        public Texture(PictureBox pictureBox, string fileName)
        {
            Colors = new List<Color>();

            //Image bitmap = Bitmap.FromFile(fileName);
            Bitmap bitmap = new Bitmap(fileName);
        
            ImageProcessor img = new ImageProcessor(bitmap);

            for (int y = 0; y < Width; y++)
            {
                int index = 0;

                for (int x = 0; x < Width; x++)
                {
                    index = y * Width * img.BytePerPixel + x * img.BytePerPixel;

                    Color pixelColor = Color.FromArgb(
                        img.Pixels[index + 2], 
                        img.Pixels[index + 1], 
                        img.Pixels[index + 0]);

                    if (Colors.Contains(pixelColor) == false)
                        Colors.Add(pixelColor);
                }
            }


            img.Unlock();
            pictureBox.Image = img.Bitmap;

            bitmap.Dispose();

            pixelForColor = (int)(Width / Colors.Count);
            

        }



        // Оптимизировать алгоритм и работу
        public void FillPictureBox(PictureBox pictureBox)
        {
            pictureBox.Image = new Bitmap(Width, Width, System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            ImageProcessor img = new ImageProcessor(pictureBox.Image);

            int pixelIndex = 0;

            for (int y = 0; y < Width; y++)
            {
                int index = 0;

                for (int x = 0; x < Width; x++)
                {
                    pixelIndex = y * Width * img.BytePerPixel + x * img.BytePerPixel;

                    if ((x != 0) && (index < Colors.Count - 1) && (x % pixelForColor == 0))
                    {
                        index++;
                    }

                    img.Pixels[pixelIndex + 0] = Colors[index].B;
                    img.Pixels[pixelIndex + 1] = Colors[index].G;
                    img.Pixels[pixelIndex + 2] = Colors[index].R;
                }
            }

            img.Unlock();

            pictureBox.Image = img.Bitmap;
        }

        public Color GetColorByIndex(int index)
        {
            return Colors[index];
        }

        public void SetColorByIndex(int index, Color color)
        {
            Colors[index] = color;
        }
        public int GetColorIndexByPixelPosition(int pictureBoxSize, int x)
        {
            int pixelForColor2 = pictureBoxSize / Colors.Count;
            return x / pixelForColor2;
        }


        public void InsterRandomColor(int index)
        {
            Colors.Insert(index, GetRandomColor());
         
            pixelForColor = (int)(Width / Colors.Count);
        }

        public void AddRandomColor()
        {
            Colors.Add(GetRandomColor());
            pixelForColor = (int)(Width / Colors.Count);
        }

        public void RemoveColorAt(int index)
        {
            if (Colors.Count == 1) return;

            Colors.RemoveAt(index);
            pixelForColor = (int)(Width / Colors.Count);
        }

        private Color GetRandomColor()
        {
            Random rnd = new Random();
            return Color.FromArgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));
        }
    }
}
