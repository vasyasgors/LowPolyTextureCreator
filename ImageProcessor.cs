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
