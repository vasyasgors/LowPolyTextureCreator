using System;

namespace LowPolyTextureCreater
{
    public struct Color
    {
        public byte R, G, B;

        public Color(byte r, byte g, byte b)
        {
            R = r;
            G = g;
            B = b;
        }

        public static Color RandomColor()
        {
            Random rnd = new Random();
            return new Color((byte)rnd.Next(0, 255), (byte)rnd.Next(0, 255), (byte)rnd.Next(0, 255));
        }
    }
}
