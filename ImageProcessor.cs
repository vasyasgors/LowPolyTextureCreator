using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LowPolyTextureCreater
{
    /*
            ImageProcessor img = new ImageProcessor(filteredImage);
            int r = 0, g = 0, b = 0;

            for (int i = 0; i < img.Pixels.Length; i += img.BytePerPixel)
            {
                b = img.Pixels[i + 0];
                g = img.Pixels[i + 1];
                r = img.Pixels[i + 2];

                PixelProcessor.ApplyDiscolor(ref r, ref g, ref b);

                r += 5;
                b -= 40;
                g -= 10;

                PixelProcessor.ClampColor(ref r, ref g, ref b);


                img.Pixels[i + 0] = (byte)b;
                img.Pixels[i + 1] = (byte)g;
                img.Pixels[i + 2] = (byte)r;
            }


            img.Unlock();

            filteredImage = img.Bitmap;*/

    class ImageProcessor
    {
        public Bitmap Bitmap;
        public byte[] Pixels;
        public int BytePerPixel;

        private BitmapData bitmapData;
        private IntPtr ptrFirstPixel;

        public ImageProcessor(Image image)
        {
            Bitmap = new Bitmap(image);

            BytePerPixel = Image.GetPixelFormatSize(Bitmap.PixelFormat); // кол-во бит
            BytePerPixel /= 8;
 
            bitmapData = Bitmap.LockBits(new Rectangle(0, 0, Bitmap.Width, Bitmap.Height),
                                         ImageLockMode.ReadWrite, 
                                         Bitmap.PixelFormat);

            Pixels = new byte[Bitmap.Width * Bitmap.Height * BytePerPixel];

            ptrFirstPixel = bitmapData.Scan0;

            Marshal.Copy(ptrFirstPixel, Pixels, 0, Pixels.Length);
        }

        public void Unlock()
        {
            Marshal.Copy(Pixels, 0, ptrFirstPixel, Pixels.Length);
            Bitmap.UnlockBits(bitmapData);
        }

    }
}
