using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Histogram {
    // IMPORTED FROM http://james-ramsden.com/convert-from-hsl-to-rgb-colour-codes-in-c/
    // USED TO CONVERT HSL => COLOR
    // EDITED BECAUSE THEY DIDNT CHECK BOUNDARIES... QUITE THE PROFESIONALS...
    public class ColorScale {
        public static Color ColorFromHSL(double h, double s, double l) {
            double r = 0, g = 0, b = 0;
            if (l != 0) {
                if (s == 0)
                    r = g = b = l;
                else {
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

        private static double GetColorComponent(double temp1, double temp2, double temp3) {
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