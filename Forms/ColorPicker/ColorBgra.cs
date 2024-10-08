﻿/* Permission is hereby granted, free of charge, to any person obtaining a copy of 
 * this software and associated documentation files (the "Software"), to deal in 
 * the Software without restriction, including without limitation the rights to 
 * use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of 
 * the Software, and to permit persons to whom the Software is furnished to do so, 
 * subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all 
 * copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR 
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS 
 * FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR 
 * COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER 
 * IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN 
 * CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 */

using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace ColorPicker
{
    [Serializable]
    public struct ColorBgra
    {
        public byte B { get { return (byte)((this.Bgra & 0x000000FFu) >> 0); } }
        public byte G { get { return (byte)((this.Bgra & 0x0000FF00u) >> 8); } }
        public byte R { get { return (byte)((this.Bgra & 0x00FF0000u) >> 16); } }
        public byte A { get { return (byte)((this.Bgra & 0xFF000000u) >> 24); } }

        [NonSerialized]
        public readonly uint Bgra;

        public ColorBgra(uint bgra)
        {
            this.Bgra = bgra;
        }

        public const int BlueChannel = 0;
        public const int GreenChannel = 1;
        public const int RedChannel = 2;
        public const int AlphaChannel = 3;

        public const int SizeOf = 4;

        public static ColorBgra ParseHexString(string hexString)
        {
            uint value = Convert.ToUInt32(hexString, 16);
            return FromUInt32(value);
        }

        public string ToHexString()
        {
            int rgbNumber = (this.R << 16) | (this.G << 8) | this.B;
            string colorString = Convert.ToString(rgbNumber, 16);

            while (colorString.Length < 6)
            {
                colorString = "0" + colorString;
            }

            string alphaString = Convert.ToString(this.A, 16);

            while (alphaString.Length < 2)
            {
                alphaString = "0" + alphaString;
            }

            colorString = alphaString + colorString;

            return colorString.ToUpper();
        }

        /// <summary>
        /// Gets the luminance intensity of the pixel based on the values of the red, green, and blue components. Alpha is ignored.
        /// </summary>
        /// <returns>A value in the range 0 to 1 inclusive.</returns>
        public double GetIntensity()
        {
            return ((0.114 * this.B) + (0.587 * this.G) + (0.299 * this.R)) / 255.0;
        }

        /// <summary>
        /// Gets the luminance intensity of the pixel based on the values of the red, green, and blue components. Alpha is ignored.
        /// </summary>
        /// <returns>A value in the range 0 to 255 inclusive.</returns>
        public byte GetIntensityByte()
        {
            return (byte)((7471 * B + 38470 * G + 19595 * R) >> 16);
        }

        /// <summary>
        /// Returns the maximum value out of the B, G, and R values. Alpha is ignored.
        /// </summary>
        /// <returns></returns>
        public byte GetMaxColorChannelValue()
        {
            return Math.Max(this.B, Math.Max(this.G, this.R));
        }

        /// <summary>
        /// Returns the average of the B, G, and R values. Alpha is ignored.
        /// </summary>
        /// <returns></returns>
        public byte GetAverageColorChannelValue()
        {
            return (byte)((this.B + this.G + this.R) / 3);
        }

        /// <summary>
        /// Compares two ColorBgra instance to determine if they are equal.
        /// </summary>
        public static bool operator ==(ColorBgra lhs, ColorBgra rhs)
        {
            return lhs.Bgra == rhs.Bgra;
        }

        /// <summary>
        /// Compares two ColorBgra instance to determine if they are not equal.
        /// </summary>
        public static bool operator !=(ColorBgra lhs, ColorBgra rhs)
        {
            return lhs.Bgra != rhs.Bgra;
        }

        /// <summary>
        /// Compares two ColorBgra instance to determine if they are equal.
        /// </summary>
        public override bool Equals(object obj)
        {
            if (obj != null && obj is ColorBgra && ((ColorBgra)obj).Bgra == this.Bgra)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Returns a hash code for this color value.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            unchecked
            {
                return (int)Bgra;
            }
        }

        /// <summary>
        /// Gets the equivalent GDI+ PixelFormat.
        /// </summary>
        /// <remarks>
        /// This property always returns PixelFormat.Format32bppArgb.
        /// </remarks>
        public static PixelFormat PixelFormat
        {
            get { return PixelFormat.Format32bppArgb; }
        }

        /// <summary>
        /// Returns a new ColorBgra with the same color values but with a new alpha component value.
        /// </summary>
        public ColorBgra NewAlpha(byte newA)
        {
            return FromBgra(B, G, R, newA);
        }

        /// <summary>
        /// Creates a new ColorBgra instance with the given color and alpha values.
        /// </summary>
        public static ColorBgra FromBgra(byte b, byte g, byte r, byte a)
        {
            return new ColorBgra(BgraToUInt32(b, g, r, a));
        }

        /// <summary>
        /// Creates a new ColorBgra instance with the given color and alpha values.
        /// </summary>
        public static ColorBgra FromBgraClamped(int b, int g, int r, int a)
        {
            return FromBgra(
                b.ClampToByte(),
                g.ClampToByte(),
                r.ClampToByte(),
                a.ClampToByte());
        }

        /// <summary>
        /// Creates a new ColorBgra instance with the given color and alpha values.
        /// </summary>
        public static ColorBgra FromBgraClamped(float b, float g, float r, float a)
        {
            return FromBgra(
                b.ClampToByte(),
                g.ClampToByte(),
                r.ClampToByte(),
                a.ClampToByte());
        }

        /// <summary>
        /// Creates a new ColorBgra instance with the given color and alpha values.
        /// </summary>
        public static ColorBgra FromBgraClamped(double b, double g, double r, double a)
        {
            return FromBgra(
                b.ClampToByte(),
                g.ClampToByte(),
                r.ClampToByte(),
                a.ClampToByte());
        }

        /// <summary>
        /// Packs color and alpha values into a 32-bit integer.
        /// </summary>
        public static UInt32 BgraToUInt32(byte b, byte g, byte r, byte a)
        {
            return b + ((uint)g << 8) + ((uint)r << 16) + ((uint)a << 24);
        }

        /// <summary>
        /// Packs color and alpha values into a 32-bit integer.
        /// </summary>
        public static UInt32 BgraToUInt32(int b, int g, int r, int a)
        {
            return (uint)b + ((uint)g << 8) + ((uint)r << 16) + ((uint)a << 24);
        }

        /// <summary>
        /// Creates a new ColorBgra instance with the given color values, and 255 for alpha.
        /// </summary>
        public static ColorBgra FromBgr(byte b, byte g, byte r)
        {
            return FromBgra(b, g, r, 255);
        }

        /// <summary>
        /// Constructs a new ColorBgra instance with the given 32-bit value.
        /// </summary>
        public static ColorBgra FromUInt32(UInt32 bgra)
        {
            return new ColorBgra(bgra);
        }

        /// <summary>
        /// Constructs a new ColorBgra instance from the values in the given Color instance.
        /// </summary>
        public static ColorBgra FromColor(Color c)
        {
            return FromBgra(c.B, c.G, c.R, c.A);
        }

        /// <summary>
        /// Converts this ColorBgra instance to a Color instance.
        /// </summary>
        public Color ToColor()
        {
            return Color.FromArgb(A, R, G, B);
        }

        private static byte FastScaleByteByByte(byte a, byte b)
        {
            int r1 = a * b + 0x80;
            int r2 = ((r1 >> 8) + r1) >> 8;
            return (byte)r2;
        }

        /// <summary>
        /// Smoothly blends between two colors.
        /// </summary>
        public static ColorBgra Blend(ColorBgra ca, ColorBgra cb, byte cbAlpha)
        {
            uint caA = FastScaleByteByByte((byte)(255 - cbAlpha), ca.A);
            uint cbA = FastScaleByteByByte(cbAlpha, cb.A);
            uint cbAt = caA + cbA;

            uint r;
            uint g;
            uint b;

            if (cbAt == 0)
            {
                r = 0;
                g = 0;
                b = 0;
            }
            else
            {
                r = ((ca.R * caA) + (cb.R * cbA)) / cbAt;
                g = ((ca.G * caA) + (cb.G * cbA)) / cbAt;
                b = ((ca.B * caA) + (cb.B * cbA)) / cbAt;
            }

            return FromBgra((byte)b, (byte)g, (byte)r, (byte)cbAt);
        }

        /// <summary>
        /// Linearly interpolates between two color values.
        /// </summary>
        /// <param name="from">The color value that represents 0 on the lerp number line.</param>
        /// <param name="to">The color value that represents 1 on the lerp number line.</param>
        /// <param name="frac">A value in the range [0, 1].</param>
        /// <remarks>
        /// This method does a simple lerp on each color value and on the alpha channel. It does
        /// not properly take into account the alpha channel's effect on color blending.
        /// </remarks>
        public static ColorBgra Lerp(ColorBgra from, ColorBgra to, float frac)
        {
            return FromBgraClamped(
                (((float)@from.B).Lerp(to.B, frac)),
                (((float)@from.G).Lerp(to.G, frac)),
                (((float)@from.R).Lerp(to.R, frac)),
                (((float)@from.A).Lerp(to.A, frac)));
        }

        /// <summary>
        /// Linearly interpolates between two color values.
        /// </summary>
        /// <param name="from">The color value that represents 0 on the lerp number line.</param>
        /// <param name="to">The color value that represents 1 on the lerp number line.</param>
        /// <param name="frac">A value in the range [0, 1].</param>
        /// <remarks>
        /// This method does a simple lerp on each color value and on the alpha channel. It does
        /// not properly take into account the alpha channel's effect on color blending.
        /// </remarks>
        public static ColorBgra Lerp(ColorBgra from, ColorBgra to, double frac)
        {
            return FromBgraClamped(
                (((double)@from.B).Lerp(to.B, frac)),
                (((double)@from.G).Lerp(to.G, frac)),
                (((double)@from.R).Lerp(to.R, frac)),
                (((double)@from.A).Lerp(to.A, frac)));
        }

        /// <summary>
        /// Blends four colors together based on the given weight values.
        /// </summary>
        /// <returns>The blended color.</returns>
        /// <remarks>
        /// The weights should be 16-bit fixed point numbers that add up to 65536 ("1.0").
        /// 4W16IP means "4 colors, weights, 16-bit integer precision"
        /// </remarks>
        public static ColorBgra BlendColors(ColorBgra c1,
                                                  uint w1,
                                                  ColorBgra c2,
                                                  uint w2,
                                                  ColorBgra c3,
                                                  uint w3,
                                                  ColorBgra c4,
                                                  uint w4)
        {
            const uint ww = 32768;
            uint af = (c1.A * w1) + (c2.A * w2) + (c3.A * w3) + (c4.A * w4);
            uint a = (af + ww) >> 16;

            uint b;
            uint g;
            uint r;

            if (a == 0)
            {
                b = 0;
                g = 0;
                r = 0;
            }
            else
            {
                b =
                    (uint)
                    ((((long)c1.A * c1.B * w1) + ((long)c2.A * c2.B * w2) + ((long)c3.A * c3.B * w3) +
                      ((long)c4.A * c4.B * w4)) / af);
                g =
                    (uint)
                    ((((long)c1.A * c1.G * w1) + ((long)c2.A * c2.G * w2) + ((long)c3.A * c3.G * w3) +
                      ((long)c4.A * c4.G * w4)) / af);
                r =
                    (uint)
                    ((((long)c1.A * c1.R * w1) + ((long)c2.A * c2.R * w2) + ((long)c3.A * c3.R * w3) +
                      ((long)c4.A * c4.R * w4)) / af);
            }

            return FromBgra((byte)b, (byte)g, (byte)r, (byte)a);
        }

        /// <summary>
        /// Blends the colors based on the given weight values.
        /// </summary>
        /// <param name="c">The array of color values.</param>
        /// <param name="w">The array of weight values.</param>
        /// <returns>
        /// The weights should be fixed point numbers. 
        /// The total summation of the weight values will be treated as "1.0".
        /// Each color will be blended in proportionally to its weight value respective to 
        /// the total summation of the weight values.
        /// </returns>
        /// <remarks>
        /// "WAIP" stands for "weights, arbitrary integer precision"</remarks>
        public static ColorBgra BlendColors(ColorBgra[] c, uint[] w)
        {
            if (c.Length != w.Length)
            {
                throw new ArgumentException("c.Length != w.Length");
            }

            if (c.Length == 0)
            {
                return FromUInt32(0);
            }

            long wsum = 0;
            long asum = 0;

            for (int i = 0; i < w.Length; ++i)
            {
                wsum += w[i];
                asum += c[i].A * w[i];
            }

            var a = (uint)((asum + (wsum >> 1)) / wsum);

            long b;
            long g;
            long r;

            if (a == 0)
            {
                b = 0;
                g = 0;
                r = 0;
            }
            else
            {
                b = 0;
                g = 0;
                r = 0;

                for (int i = 0; i < c.Length; ++i)
                {
                    b += (long)c[i].A * c[i].B * w[i];
                    g += (long)c[i].A * c[i].G * w[i];
                    r += (long)c[i].A * c[i].R * w[i];
                }

                b /= asum;
                g /= asum;
                r /= asum;
            }

            return FromUInt32((uint)b + ((uint)g << 8) + ((uint)r << 16) + (a << 24));
        }

        /// <summary>
        /// Blends the colors based on the given weight values.
        /// </summary>
        /// <param name="c">The array of color values.</param>
        /// <param name="w">The array of weight values.</param>
        /// <returns>
        /// Each color will be blended in proportionally to its weight value respective to 
        /// the total summation of the weight values.
        /// </returns>
        /// <remarks>
        /// "WAIP" stands for "weights, floating-point"</remarks>
        public static ColorBgra BlendColors(ColorBgra[] c, double[] w)
        {
            if (c.Length != w.Length)
            {
                throw new ArgumentException("c.Length != w.Length");
            }

            if (c.Length == 0)
            {
                return Transparent;
            }

            double wsum = 0;
            double asum = 0;

            for (int i = 0; i < w.Length; ++i)
            {
                wsum += w[i];
                asum += c[i].A * w[i];
            }

            double a = asum / wsum;
            double aMultWsum = a * wsum;

            double b;
            double g;
            double r;

            if (Equals(asum, 0.0) == true)
            {
                b = 0;
                g = 0;
                r = 0;
            }
            else
            {
                b = 0;
                g = 0;
                r = 0;

                for (int i = 0; i < c.Length; ++i)
                {
                    b += (double)c[i].A * c[i].B * w[i];
                    g += (double)c[i].A * c[i].G * w[i];
                    r += (double)c[i].A * c[i].R * w[i];
                }

                b /= aMultWsum;
                g /= aMultWsum;
                r /= aMultWsum;
            }

            return FromBgra((byte)b, (byte)g, (byte)r, (byte)a);
        }

        /*
        public static ColorBGRA Blend(ColorBGRA[] colors)
        {
            unsafe
            {
                fixed (ColorBGRA* pColors = colors)
                {
                    return Blend(pColors, colors.Length);
                }
            }
        }
        */

        /*
        /// <summary>
        /// Smoothly blends the given colors together, assuming equal weighting for each one.
        /// </summary>
        /// <param name="colors"></param>
        /// <param name="colorCount"></param>
        /// <returns></returns>
        public unsafe static ColorBGRA Blend(ColorBGRA* colors, int count)
        {
            if (count < 0)
            {
                throw new ArgumentOutOfRangeException("count must be 0 or greater");
            }

            if (count == 0)
            {
                return ColorBGRA.Transparent;
            }

            ulong aSum = 0;

            for (int i = 0; i < count; ++i)
            {
                aSum += (ulong)colors[i].A;
            }

            byte b = 0;
            byte g = 0;
            byte r = 0;
            byte a = (byte)(aSum / (ulong)count);

            if (aSum != 0)
            {
                ulong bSum = 0;
                ulong gSum = 0;
                ulong rSum = 0;

                for (int i = 0; i < count; ++i)
                {
                    bSum += (ulong)(colors[i].A * colors[i].B);
                    gSum += (ulong)(colors[i].A * colors[i].G);
                    rSum += (ulong)(colors[i].A * colors[i].R);
                }

                b = (byte)(bSum / aSum);
                g = (byte)(gSum / aSum);
                r = (byte)(rSum / aSum);
            }

            return FromBgra(b, g, r, a);
        }
        */

        public override string ToString()
        {
            return "B: " + B + ", G: " + G + ", R: " + R + ", A: " + A;
        }

        /// <summary>
        /// Casts a ColorBgra to a UInt32.
        /// </summary>
        public static explicit operator UInt32(ColorBgra color)
        {
            return color.Bgra;
        }

        /// <summary>
        /// Casts a UInt32 to a ColorBgra.
        /// </summary>
        public static explicit operator ColorBgra(UInt32 uint32)
        {
            return FromUInt32(uint32);
        }

        public static ColorBgra Transparent
        {
            get
            {
                return FromBgra(255, 255, 255, 0);
            }
        }

        public static ColorBgra AliceBlue
        {
            get
            {
                return FromBgra(255, 248, 240, 255);
            }
        }

        public static ColorBgra AntiqueWhite
        {
            get
            {
                return FromBgra(215, 235, 250, 255);
            }
        }

        public static ColorBgra Aqua
        {
            get
            {
                return FromBgra(255, 255, 0, 255);
            }
        }

        public static ColorBgra Aquamarine
        {
            get
            {
                return FromBgra(212, 255, 127, 255);
            }
        }

        public static ColorBgra Azure
        {
            get
            {
                return FromBgra(255, 255, 240, 255);
            }
        }

        public static ColorBgra Beige
        {
            get
            {
                return FromBgra(220, 245, 245, 255);
            }
        }

        public static ColorBgra Bisque
        {
            get
            {
                return FromBgra(196, 228, 255, 255);
            }
        }

        public static ColorBgra Black
        {
            get
            {
                return FromBgra(0, 0, 0, 255);
            }
        }

        public static ColorBgra BlanchedAlmond
        {
            get
            {
                return FromBgra(205, 235, 255, 255);
            }
        }

        public static ColorBgra Blue
        {
            get
            {
                return FromBgra(255, 0, 0, 255);
            }
        }

        public static ColorBgra BlueViolet
        {
            get
            {
                return FromBgra(226, 43, 138, 255);
            }
        }

        public static ColorBgra Brown
        {
            get
            {
                return FromBgra(42, 42, 165, 255);
            }
        }

        public static ColorBgra BurlyWood
        {
            get
            {
                return FromBgra(135, 184, 222, 255);
            }
        }

        public static ColorBgra CadetBlue
        {
            get
            {
                return FromBgra(160, 158, 95, 255);
            }
        }

        public static ColorBgra Chartreuse
        {
            get
            {
                return FromBgra(0, 255, 127, 255);
            }
        }

        public static ColorBgra Chocolate
        {
            get
            {
                return FromBgra(30, 105, 210, 255);
            }
        }

        public static ColorBgra Coral
        {
            get
            {
                return FromBgra(80, 127, 255, 255);
            }
        }

        public static ColorBgra CornflowerBlue
        {
            get
            {
                return FromBgra(237, 149, 100, 255);
            }
        }

        public static ColorBgra Cornsilk
        {
            get
            {
                return FromBgra(220, 248, 255, 255);
            }
        }

        public static ColorBgra Crimson
        {
            get
            {
                return FromBgra(60, 20, 220, 255);
            }
        }

        public static ColorBgra Cyan
        {
            get
            {
                return FromBgra(255, 255, 0, 255);
            }
        }

        public static ColorBgra DarkBlue
        {
            get
            {
                return FromBgra(139, 0, 0, 255);
            }
        }

        public static ColorBgra DarkCyan
        {
            get
            {
                return FromBgra(139, 139, 0, 255);
            }
        }

        public static ColorBgra DarkGoldenrod
        {
            get
            {
                return FromBgra(11, 134, 184, 255);
            }
        }

        public static ColorBgra DarkGray
        {
            get
            {
                return FromBgra(169, 169, 169, 255);
            }
        }

        public static ColorBgra DarkGreen
        {
            get
            {
                return FromBgra(0, 100, 0, 255);
            }
        }

        public static ColorBgra DarkKhaki
        {
            get
            {
                return FromBgra(107, 183, 189, 255);
            }
        }

        public static ColorBgra DarkMagenta
        {
            get
            {
                return FromBgra(139, 0, 139, 255);
            }
        }

        public static ColorBgra DarkOliveGreen
        {
            get
            {
                return FromBgra(47, 107, 85, 255);
            }
        }

        public static ColorBgra DarkOrange
        {
            get
            {
                return FromBgra(0, 140, 255, 255);
            }
        }

        public static ColorBgra DarkOrchid
        {
            get
            {
                return FromBgra(204, 50, 153, 255);
            }
        }

        public static ColorBgra DarkRed
        {
            get
            {
                return FromBgra(0, 0, 139, 255);
            }
        }

        public static ColorBgra DarkSalmon
        {
            get
            {
                return FromBgra(122, 150, 233, 255);
            }
        }

        public static ColorBgra DarkSeaGreen
        {
            get
            {
                return FromBgra(139, 188, 143, 255);
            }
        }

        public static ColorBgra DarkSlateBlue
        {
            get
            {
                return FromBgra(139, 61, 72, 255);
            }
        }

        public static ColorBgra DarkSlateGray
        {
            get
            {
                return FromBgra(79, 79, 47, 255);
            }
        }

        public static ColorBgra DarkTurquoise
        {
            get
            {
                return FromBgra(209, 206, 0, 255);
            }
        }

        public static ColorBgra DarkViolet
        {
            get
            {
                return FromBgra(211, 0, 148, 255);
            }
        }

        public static ColorBgra DeepPink
        {
            get
            {
                return FromBgra(147, 20, 255, 255);
            }
        }

        public static ColorBgra DeepSkyBlue
        {
            get
            {
                return FromBgra(255, 191, 0, 255);
            }
        }

        public static ColorBgra DimGray
        {
            get
            {
                return FromBgra(105, 105, 105, 255);
            }
        }

        public static ColorBgra DodgerBlue
        {
            get
            {
                return FromBgra(255, 144, 30, 255);
            }
        }

        public static ColorBgra Firebrick
        {
            get
            {
                return FromBgra(34, 34, 178, 255);
            }
        }

        public static ColorBgra FloralWhite
        {
            get
            {
                return FromBgra(240, 250, 255, 255);
            }
        }

        public static ColorBgra ForestGreen
        {
            get
            {
                return FromBgra(34, 139, 34, 255);
            }
        }

        public static ColorBgra Fuchsia
        {
            get
            {
                return FromBgra(255, 0, 255, 255);
            }
        }

        public static ColorBgra Gainsboro
        {
            get
            {
                return FromBgra(220, 220, 220, 255);
            }
        }

        public static ColorBgra GhostWhite
        {
            get
            {
                return FromBgra(255, 248, 248, 255);
            }
        }

        public static ColorBgra Gold
        {
            get
            {
                return FromBgra(0, 215, 255, 255);
            }
        }

        public static ColorBgra Goldenrod
        {
            get
            {
                return FromBgra(32, 165, 218, 255);
            }
        }

        public static ColorBgra Gray
        {
            get
            {
                return FromBgra(128, 128, 128, 255);
            }
        }

        public static ColorBgra Green
        {
            get
            {
                return FromBgra(0, 128, 0, 255);
            }
        }

        public static ColorBgra GreenYellow
        {
            get
            {
                return FromBgra(47, 255, 173, 255);
            }
        }

        public static ColorBgra Honeydew
        {
            get
            {
                return FromBgra(240, 255, 240, 255);
            }
        }

        public static ColorBgra HotPink
        {
            get
            {
                return FromBgra(180, 105, 255, 255);
            }
        }

        public static ColorBgra IndianRed
        {
            get
            {
                return FromBgra(92, 92, 205, 255);
            }
        }

        public static ColorBgra Indigo
        {
            get
            {
                return FromBgra(130, 0, 75, 255);
            }
        }

        public static ColorBgra Ivory
        {
            get
            {
                return FromBgra(240, 255, 255, 255);
            }
        }

        public static ColorBgra Khaki
        {
            get
            {
                return FromBgra(140, 230, 240, 255);
            }
        }

        public static ColorBgra Lavender
        {
            get
            {
                return FromBgra(250, 230, 230, 255);
            }
        }

        public static ColorBgra LavenderBlush
        {
            get
            {
                return FromBgra(245, 240, 255, 255);
            }
        }

        public static ColorBgra LawnGreen
        {
            get
            {
                return FromBgra(0, 252, 124, 255);
            }
        }

        public static ColorBgra LemonChiffon
        {
            get
            {
                return FromBgra(205, 250, 255, 255);
            }
        }

        public static ColorBgra LightBlue
        {
            get
            {
                return FromBgra(230, 216, 173, 255);
            }
        }

        public static ColorBgra LightCoral
        {
            get
            {
                return FromBgra(128, 128, 240, 255);
            }
        }

        public static ColorBgra LightCyan
        {
            get
            {
                return FromBgra(255, 255, 224, 255);
            }
        }

        public static ColorBgra LightGoldenrodYellow
        {
            get
            {
                return FromBgra(210, 250, 250, 255);
            }
        }

        public static ColorBgra LightGreen
        {
            get
            {
                return FromBgra(144, 238, 144, 255);
            }
        }

        public static ColorBgra LightGray
        {
            get
            {
                return FromBgra(211, 211, 211, 255);
            }
        }

        public static ColorBgra LightPink
        {
            get
            {
                return FromBgra(193, 182, 255, 255);
            }
        }

        public static ColorBgra LightSalmon
        {
            get
            {
                return FromBgra(122, 160, 255, 255);
            }
        }

        public static ColorBgra LightSeaGreen
        {
            get
            {
                return FromBgra(170, 178, 32, 255);
            }
        }

        public static ColorBgra LightSkyBlue
        {
            get
            {
                return FromBgra(250, 206, 135, 255);
            }
        }

        public static ColorBgra LightSlateGray
        {
            get
            {
                return FromBgra(153, 136, 119, 255);
            }
        }

        public static ColorBgra LightSteelBlue
        {
            get
            {
                return FromBgra(222, 196, 176, 255);
            }
        }

        public static ColorBgra LightYellow
        {
            get
            {
                return FromBgra(224, 255, 255, 255);
            }
        }

        public static ColorBgra Lime
        {
            get
            {
                return FromBgra(0, 255, 0, 255);
            }
        }

        public static ColorBgra LimeGreen
        {
            get
            {
                return FromBgra(50, 205, 50, 255);
            }
        }

        public static ColorBgra Linen
        {
            get
            {
                return FromBgra(230, 240, 250, 255);
            }
        }

        public static ColorBgra Magenta
        {
            get
            {
                return FromBgra(255, 0, 255, 255);
            }
        }

        public static ColorBgra Maroon
        {
            get
            {
                return FromBgra(0, 0, 128, 255);
            }
        }

        public static ColorBgra MediumAquamarine
        {
            get
            {
                return FromBgra(170, 205, 102, 255);
            }
        }

        public static ColorBgra MediumBlue
        {
            get
            {
                return FromBgra(205, 0, 0, 255);
            }
        }

        public static ColorBgra MediumOrchid
        {
            get
            {
                return FromBgra(211, 85, 186, 255);
            }
        }

        public static ColorBgra MediumPurple
        {
            get
            {
                return FromBgra(219, 112, 147, 255);
            }
        }

        public static ColorBgra MediumSeaGreen
        {
            get
            {
                return FromBgra(113, 179, 60, 255);
            }
        }

        public static ColorBgra MediumSlateBlue
        {
            get
            {
                return FromBgra(238, 104, 123, 255);
            }
        }

        public static ColorBgra MediumSpringGreen
        {
            get
            {
                return FromBgra(154, 250, 0, 255);
            }
        }

        public static ColorBgra MediumTurquoise
        {
            get
            {
                return FromBgra(204, 209, 72, 255);
            }
        }

        public static ColorBgra MediumVioletRed
        {
            get
            {
                return FromBgra(133, 21, 199, 255);
            }
        }

        public static ColorBgra MidnightBlue
        {
            get
            {
                return FromBgra(112, 25, 25, 255);
            }
        }

        public static ColorBgra MintCream
        {
            get
            {
                return FromBgra(250, 255, 245, 255);
            }
        }

        public static ColorBgra MistyRose
        {
            get
            {
                return FromBgra(225, 228, 255, 255);
            }
        }

        public static ColorBgra Moccasin
        {
            get
            {
                return FromBgra(181, 228, 255, 255);
            }
        }

        public static ColorBgra NavajoWhite
        {
            get
            {
                return FromBgra(173, 222, 255, 255);
            }
        }

        public static ColorBgra Navy
        {
            get
            {
                return FromBgra(128, 0, 0, 255);
            }
        }

        public static ColorBgra OldLace
        {
            get
            {
                return FromBgra(230, 245, 253, 255);
            }
        }

        public static ColorBgra Olive
        {
            get
            {
                return FromBgra(0, 128, 128, 255);
            }
        }

        public static ColorBgra OliveDrab
        {
            get
            {
                return FromBgra(35, 142, 107, 255);
            }
        }

        public static ColorBgra Orange
        {
            get
            {
                return FromBgra(0, 165, 255, 255);
            }
        }

        public static ColorBgra OrangeRed
        {
            get
            {
                return FromBgra(0, 69, 255, 255);
            }
        }

        public static ColorBgra Orchid
        {
            get
            {
                return FromBgra(214, 112, 218, 255);
            }
        }

        public static ColorBgra PaleGoldenrod
        {
            get
            {
                return FromBgra(170, 232, 238, 255);
            }
        }

        public static ColorBgra PaleGreen
        {
            get
            {
                return FromBgra(152, 251, 152, 255);
            }
        }

        public static ColorBgra PaleTurquoise
        {
            get
            {
                return FromBgra(238, 238, 175, 255);
            }
        }

        public static ColorBgra PaleVioletRed
        {
            get
            {
                return FromBgra(147, 112, 219, 255);
            }
        }

        public static ColorBgra PapayaWhip
        {
            get
            {
                return FromBgra(213, 239, 255, 255);
            }
        }

        public static ColorBgra PeachPuff
        {
            get
            {
                return FromBgra(185, 218, 255, 255);
            }
        }

        public static ColorBgra Peru
        {
            get
            {
                return FromBgra(63, 133, 205, 255);
            }
        }

        public static ColorBgra Pink
        {
            get
            {
                return FromBgra(203, 192, 255, 255);
            }
        }

        public static ColorBgra Plum
        {
            get
            {
                return FromBgra(221, 160, 221, 255);
            }
        }

        public static ColorBgra PowderBlue
        {
            get
            {
                return FromBgra(230, 224, 176, 255);
            }
        }

        public static ColorBgra Purple
        {
            get
            {
                return FromBgra(128, 0, 128, 255);
            }
        }

        public static ColorBgra Red
        {
            get
            {
                return FromBgra(0, 0, 255, 255);
            }
        }

        public static ColorBgra RosyBrown
        {
            get
            {
                return FromBgra(143, 143, 188, 255);
            }
        }

        public static ColorBgra RoyalBlue
        {
            get
            {
                return FromBgra(225, 105, 65, 255);
            }
        }

        public static ColorBgra SaddleBrown
        {
            get
            {
                return FromBgra(19, 69, 139, 255);
            }
        }

        public static ColorBgra Salmon
        {
            get
            {
                return FromBgra(114, 128, 250, 255);
            }
        }

        public static ColorBgra SandyBrown
        {
            get
            {
                return FromBgra(96, 164, 244, 255);
            }
        }

        public static ColorBgra SeaGreen
        {
            get
            {
                return FromBgra(87, 139, 46, 255);
            }
        }

        public static ColorBgra SeaShell
        {
            get
            {
                return FromBgra(238, 245, 255, 255);
            }
        }

        public static ColorBgra Sienna
        {
            get
            {
                return FromBgra(45, 82, 160, 255);
            }
        }

        public static ColorBgra Silver
        {
            get
            {
                return FromBgra(192, 192, 192, 255);
            }
        }

        public static ColorBgra SkyBlue
        {
            get
            {
                return FromBgra(235, 206, 135, 255);
            }
        }

        public static ColorBgra SlateBlue
        {
            get
            {
                return FromBgra(205, 90, 106, 255);
            }
        }

        public static ColorBgra SlateGray
        {
            get
            {
                return FromBgra(144, 128, 112, 255);
            }
        }

        public static ColorBgra Snow
        {
            get
            {
                return FromBgra(250, 250, 255, 255);
            }
        }

        public static ColorBgra SpringGreen
        {
            get
            {
                return FromBgra(127, 255, 0, 255);
            }
        }

        public static ColorBgra SteelBlue
        {
            get
            {
                return FromBgra(180, 130, 70, 255);
            }
        }

        public static ColorBgra Tan
        {
            get
            {
                return FromBgra(140, 180, 210, 255);
            }
        }

        public static ColorBgra Teal
        {
            get
            {
                return FromBgra(128, 128, 0, 255);
            }
        }

        public static ColorBgra Thistle
        {
            get
            {
                return FromBgra(216, 191, 216, 255);
            }
        }

        public static ColorBgra Tomato
        {
            get
            {
                return FromBgra(71, 99, 255, 255);
            }
        }

        public static ColorBgra Turquoise
        {
            get
            {
                return FromBgra(208, 224, 64, 255);
            }
        }

        public static ColorBgra Violet
        {
            get
            {
                return FromBgra(238, 130, 238, 255);
            }
        }

        public static ColorBgra Wheat
        {
            get
            {
                return FromBgra(179, 222, 245, 255);
            }
        }

        public static ColorBgra White
        {
            get
            {
                return FromBgra(255, 255, 255, 255);
            }
        }

        public static ColorBgra WhiteSmoke
        {
            get
            {
                return FromBgra(245, 245, 245, 255);
            }
        }

        public static ColorBgra Yellow
        {
            get
            {
                return FromBgra(0, 255, 255, 255);
            }
        }

        public static ColorBgra YellowGreen
        {
            get
            {
                return FromBgra(50, 205, 154, 255);
            }
        }

        public static ColorBgra Zero
        {
            get
            {
                return (ColorBgra)0;
            }
        }
    }
}
