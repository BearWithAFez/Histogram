using System;
using System.Collections.Generic;
using System.Drawing;

namespace LogicaLayer
{
    public class ColorSystem
    {
        public static Func<Bitmap, Dictionary<string, int[]>> GetHistoDataMethod(ColorSystems cs)
        {
            switch (cs)
            {
                case ColorSystems.RGB:
                    return RGB_GetHistoData;
                case ColorSystems.HSL:
                default:
                    return HSL_GetHistoData;
            }
        }

        public static Func<Color, Dictionary<string, int[]>, Color> GetStretchPixelMethod(ColorSystems cs)
        {
            switch (cs)
            {
                case ColorSystems.RGB:
                    return RGB_StretchPixel;
                case ColorSystems.HSL:
                default:
                    return HSL_StretchPixel;
            }
        }

        private static Dictionary<string, int[]> HSL_GetHistoData(Bitmap img)
        {
            // Prep
            var histoData = new Dictionary<string, int[]> {
                { "Yellow", new int[256] }
            };

            // Fill
            for (int i = 0; i < img.Width; i++)
            {
                for (int j = 0; j < img.Height; j++)
                {
                    // http://csharphelper.com/blog/2016/08/convert-between-rgb-and-hls-color-models-in-c/
                    // Quick and dirty...Only meddle with lightness...
                    Color pixel = img.GetPixel(i, j);
                    histoData["Yellow"][(int)Math.Round(pixel.GetBrightness() * 255)]++;
                }
            }

            return histoData;
        }

        private static Dictionary<string, int[]> RGB_GetHistoData(Bitmap img)
        {
            // Prep
            var histoData = new Dictionary<string, int[]> {
                { "Red", new int[256] },
                { "Green", new int[256] },
                { "Blue", new int[256] }
            };

            // Fill
            for (int i = 0; i < img.Width; i++)
            {
                for (int j = 0; j < img.Height; j++)
                {
                    // Easy Peasy
                    Color pixel = img.GetPixel(i, j);
                    histoData["Red"][pixel.R]++;
                    histoData["Green"][pixel.G]++;
                    histoData["Blue"][pixel.B]++;
                }
            }

            return histoData;
        }

        private static Color HSL_StretchPixel(Color pixel, Dictionary<string, int[]> minMax)
        {
            return HSL.ColorFromHSL((pixel.GetHue() / 360f), pixel.GetSaturation(), (((int)Math.Round(((pixel.GetBrightness() * 255) - minMax["Yellow"][0]) * (255.0f / (minMax["Yellow"][1] - minMax["Yellow"][0])))) / 255f));
        }

        private static Color RGB_StretchPixel(Color pixel, Dictionary<string, int[]> minMax)
        {
            var r = (int)Math.Round((pixel.R - minMax["Red"][0]) * (255.0f / (minMax["Red"][1] - minMax["Red"][0])));
            var g = (int)Math.Round((pixel.G - minMax["Green"][0]) * (255.0f / (minMax["Green"][1] - minMax["Green"][0])));
            var b = (int)Math.Round((pixel.B - minMax["Blue"][0]) * (255.0f / (minMax["Blue"][1] - minMax["Blue"][0])));

            // Boundaries!!
            r = (r > 255) ? 255 : ((r < 0) ? 0 : r);
            g = (g > 255) ? 255 : ((g < 0) ? 0 : g);
            b = (b > 255) ? 255 : ((b < 0) ? 0 : b);

            return Color.FromArgb(r, g, b);
        }
    }

    public enum ColorSystems
    {
        RGB,
        HSL
    }

    public static class HSL
    {
        // IMPORTED FROM http://james-ramsden.com/convert-from-hsl-to-rgb-colour-codes-in-c/
        // USED TO CONVERT HSL => COLOR
        // EDITED BECAUSE THEY DIDNT CHECK BOUNDARIES... QUITE THE PROFESIONALS...


        public static Color ColorFromHSL(double h, double s, double l)
        {
            double r = 0, g = 0, b = 0;
            if (l != 0)
            {
                if (s == 0)
                    r = g = b = l;
                else
                {
                    double temp2;
                    if (l < 0.5)
                        temp2 = l * (1.0 + s);
                    else
                        temp2 = l + s - (l * s);

                    double temp1 = 2.0 * l - temp2;

                    r = GetColorComponent(temp1, temp2, h + 1.0 / 3.0);
                    g = GetColorComponent(temp1, temp2, h);
                    b = GetColorComponent(temp1, temp2, h - 1.0 / 3.0);

                    r *= 255;
                    g *= 255;
                    b *= 255;

                    if (r > 255) r = 255;
                    if (g > 255) g = 255;
                    if (b > 255) b = 255;

                    if (r < 0) r = 0;
                    if (g < 0) g = 0;
                    if (b < 0) b = 0;
                }
            }
            return Color.FromArgb((int)(r), (int)(g), (int)(b));
        }

        private static double GetColorComponent(double temp1, double temp2, double temp3)
        {
            if (temp3 < 0.0)
                temp3 += 1.0;
            else if (temp3 > 1.0)
                temp3 -= 1.0;

            if (temp3 < 1.0 / 6.0)
                return temp1 + (temp2 - temp1) * 6.0 * temp3;
            else if (temp3 < 0.5)
                return temp2;
            else if (temp3 < 2.0 / 3.0)
                return temp1 + ((temp2 - temp1) * ((2.0 / 3.0) - temp3) * 6.0);
            else
                return temp1;
        }
    }
}
