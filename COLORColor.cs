using System;

namespace LowPolyTextureCreater
{
    public struct COLORColor
    {
        public byte R, G, B;

        public COLORColor(byte r, byte g, byte b)
        {
            R = r;
            G = g;
            B = b;
        }

        public static COLORColor RandomColor()
        {
            Random rnd = new Random();
            return new COLORColor((byte)rnd.Next(0, 255), (byte)rnd.Next(0, 255), (byte)rnd.Next(0, 255));
        }
    }
}
