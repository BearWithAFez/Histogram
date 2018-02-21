using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Microsoft;
using System.Text;
using System.Threading.Tasks;

namespace Histogram
{
    public class Logica
    {   
        // Enum for colorcodes
        public enum ColorCode { RGB, HSL };

        // Helper methode die de afbeelding afloopt en een Dictionary maakt met daarin per kleur en "waarde" (0 - 255) hoevaak deze voorkwam
        private Dictionary<string, int[]> GetHistogramData(Bitmap afbeelding,ColorCode code) {
            // Create a dict with 3 entries = R G B ;  ex: histoData["R"][0] = 5 => there are 5 pixells where red == 0
            Dictionary<string, int[]> histoData;
            switch (code) {
                case ColorCode.HSL:
                    histoData = new Dictionary<string, int[]> {
                        { "L", new int[256] }
                    };
                    break;
                case ColorCode.RGB:
                default:
                    histoData = new Dictionary<string, int[]> {
                        { "R", new int[256] },
                        { "G", new int[256] },
                        { "B", new int[256] }
                    };
                    break;
            }           

            // Fill it
            for (int i = 0; i < afbeelding.Width; i++) {
                for (int j = 0; j < afbeelding.Height; j++) {
                    Color pixel = afbeelding.GetPixel(i, j);
                    switch (code) {
                        case ColorCode.HSL:
                            // http://csharphelper.com/blog/2016/08/convert-between-rgb-and-hls-color-models-in-c/
                            // Quick and dirty...
                            // Only meddle with lightness...
                            histoData["L"][(int)Math.Round(pixel.GetBrightness() * 255)]++;
                            break;

                        case ColorCode.RGB:
                        default:
                            histoData["R"][pixel.R]++;
                            histoData["G"][pixel.G]++;
                            histoData["B"][pixel.B]++;
                            break;
                    }
                    
                }
            }

            // Return it like its hot
            return histoData;
        }

        // Helper methode die de minima en maximas per onderdeel van de waarde ophaalt.
        private Dictionary<string, int[]> getMinsAndMaxs(Dictionary<string, int[]> histoData, int margin,ColorCode code) {
            // Create returnable
            Dictionary<string, int[]> returnable;

            switch (code) {
                case ColorCode.HSL:
                    returnable = new Dictionary<string, int[]>{
                        { "L", new int[2]{0, 255} }
                    };

                    for (int i = 0; i < histoData["L"].Length; i++) {
                        // Lightness
                        if ((histoData["L"][i] >= margin) && (returnable["L"][0] == 0)) returnable["L"][0] = i;
                        if ((histoData["L"][histoData["L"].Length - i - 1] >= margin) && (returnable["L"][1] == 255)) returnable["L"][1] = histoData["L"].Length - i - 1;

                        // End of Search
                        if ((returnable["L"][0] != 0) && (returnable["L"][1] != 255)) break;
                    }
                    break;
                case ColorCode.RGB:
                default:
                    returnable = new Dictionary<string, int[]>{
                        { "R", new int[2]{0, 255} },
                        { "G", new int[2]{0, 255} },
                        { "B", new int[2]{0, 255} }
                    };

                    // Find all mins and maxs
                    for (int i = 0; i < histoData["R"].Length; i++) {
                        // Red
                        if ((histoData["R"][i] >= margin) && (returnable["R"][0] == 0)) returnable["R"][0] = i;
                        if ((histoData["R"][histoData["R"].Length - i - 1] >= margin) && (returnable["R"][1] == 255)) returnable["R"][1] = histoData["R"].Length - i - 1;

                        // Green
                        if ((histoData["G"][i] >= margin) && (returnable["G"][0] == 0)) returnable["G"][0] = i;
                        if ((histoData["G"][histoData["G"].Length - i - 1] >= margin) && (returnable["G"][1] == 255)) returnable["G"][1] = histoData["G"].Length - i - 1;

                        // Blue
                        if ((histoData["B"][i] >= margin) && (returnable["B"][0] == 0)) returnable["B"][0] = i;
                        if ((histoData["B"][histoData["B"].Length - i - 1] >= margin) && (returnable["B"][1] == 255)) returnable["B"][1] = histoData["B"].Length - i - 1;

                        // End of Search
                        if ((returnable["R"][0] != 0) && (returnable["R"][1] != 255) && (returnable["G"][0] != 0) && (returnable["G"][1] != 255) && (returnable["B"][0] != 0) && (returnable["B"][1] != 255)) break;
                    }
                    break;
            }           

            // Return it
            return returnable;
        }

        // Neemt een bitmap en return deze met gestretchde RGB waarden
        public Bitmap Stretch(Bitmap afbeelding, int margin, ColorCode code) {
            // get data
            Bitmap returnable = new Bitmap(afbeelding); // kopie
            Dictionary<string, int[]> histoData = GetHistogramData(afbeelding, code); // Zie helper methode
            Dictionary<string, int[]> minsAndMaxs = getMinsAndMaxs(histoData, margin, code); // Zie helper Methode

            // stretch!!
            for (int i = 0; i < afbeelding.Width; i++) {
                for (int j = 0; j < afbeelding.Height; j++) {
                    // Get original color
                    Color pixel = afbeelding.GetPixel(i, j);

                    // Set in new bitmap
                    switch (code) {
                        case ColorCode.HSL:
                            // Stretch
                            int l = (int) Math.Round(((pixel.GetBrightness() * 255) - minsAndMaxs["L"][0]) * (255.0f / (minsAndMaxs["L"][1] - minsAndMaxs["L"][0])));
                            
                            // set pixel
                            Color nPixel = ColorScale.ColorFromHSL((pixel.GetHue() / 360f), pixel.GetSaturation(), (l / 255f));
                            returnable.SetPixel(i, j, nPixel);
                            break;
                        case ColorCode.RGB:
                        default:
                            // Stretch that color
                            int r = (int) Math.Round((pixel.R - minsAndMaxs["R"][0]) * (255.0f / (minsAndMaxs["R"][1] - minsAndMaxs["R"][0])));
                            int g = (int) Math.Round((pixel.G - minsAndMaxs["G"][0]) * (255.0f / (minsAndMaxs["G"][1] - minsAndMaxs["G"][0])));
                            int b = (int) Math.Round((pixel.B - minsAndMaxs["B"][0]) * (255.0f / (minsAndMaxs["B"][1] - minsAndMaxs["B"][0])));

                            // Boundaries!!
                            r = (r > 255) ? 255 : ((r < 0) ? 0 : r);
                            g = (g > 255) ? 255 : ((g < 0) ? 0 : g);
                            b = (b > 255) ? 255 : ((b < 0) ? 0 : b);

                            // set pixel
                            returnable.SetPixel(i, j, Color.FromArgb(r, g, b));
                            break;
                    }
                }
            }

            // Return it
            return returnable;
        }

        // Neemt een bitmap en geeft het histogram van deze weer
        public Bitmap GetHistogram(Bitmap afbeelding, int margin, bool showMinMax, bool showMargin, ColorCode code) {
            // Get data
            Dictionary<string, int[]> histoData = GetHistogramData(afbeelding, code);
            Dictionary<string, int[]> minsAndMaxs = getMinsAndMaxs(histoData, margin, code);

            // Vars 
            Bitmap returnable = new Bitmap(256, 100);
            int totPix = afbeelding.Width * afbeelding.Height;
            int histoDataMax;
            if (code == ColorCode.RGB) {
                histoDataMax = histoData["R"].Max();
                if (histoDataMax < histoData["B"].Max()) histoDataMax = histoData["B"].Max();
                if (histoDataMax < histoData["G"].Max()) histoDataMax = histoData["G"].Max();
            } else histoDataMax = histoData["L"].Max();

            // Draw histogram
            using (Graphics g = Graphics.FromImage(returnable)) {
                // Clear it
                g.Clear(Color.White);
                switch (code) {
                    case ColorCode.HSL:
                        // Get the Polygon
                        PointF[] vals = new PointF[256];
                        for (int i = 0; i < 256; i++) {
                            vals[i] = new PointF(i, ((histoData["L"][i] * 100) / histoDataMax));
                        }

                        // Make sure there is a start/end point
                        var list = vals.ToList();
                        list.Insert(0, new PointF(0, 0));
                        list.Add(new PointF(255, 0));
                        vals = list.ToArray();

                        // Draw it
                        g.FillPolygon(new SolidBrush(Color.FromArgb(122, Color.Black)), vals);

                        // Show min max
                        if (showMinMax) {
                            // https://stackoverflow.com/questions/6100573/how-to-draw-a-dashed-line-over-an-object
                            Pen dashpen = new Pen(Color.Black, 1f);
                            dashpen.DashPattern = new float[] { 4, 2 };
                            g.DrawLine(dashpen, new Point(minsAndMaxs["L"][0], 0), new Point(minsAndMaxs["L"][0], 255));
                            dashpen.DashPattern = new float[] { 1, 1 };
                            g.DrawLine(dashpen, new Point(minsAndMaxs["L"][1], 0), new Point(minsAndMaxs["L"][1], 255));
                        }
                        break;
                    case ColorCode.RGB:
                    default:
                        // Get the Red Polygon
                        PointF[] redVals = new PointF[256];
                        for (int i = 0; i < 256; i++) {
                            redVals[i] = new PointF(i, ((histoData["R"][i] * 100) / histoDataMax));
                        }
                        // Make sure there is a start/end point
                        var x = redVals.ToList();
                        x.Insert(0, new PointF(0, 0));
                        x.Add(new PointF(255, 0));
                        redVals = x.ToArray();

                        // Get the Green Polygon
                        PointF[] greenVals = new PointF[256];
                        for (int i = 0; i < 256; i++) {
                            greenVals[i] = new PointF(i, ((histoData["G"][i] * 100) / histoDataMax));
                        }
                        // Make sure there is a start/end point
                        x = greenVals.ToList();
                        x.Insert(0, new PointF(0, 0));
                        x.Add(new PointF(255, 0));
                        greenVals = x.ToArray();

                        // Get the Blue Polygon
                        PointF[] blueVals = new PointF[256];
                        for (int i = 0; i < 256; i++) {
                            blueVals[i] = new PointF(i, ((histoData["B"][i] * 100) / histoDataMax));
                        }
                        // Make sure there is a start/end point
                        x = blueVals.ToList();
                        x.Insert(0, new PointF(0, 0));
                        x.Add(new PointF(255, 0));
                        blueVals = x.ToArray();

                        // Draw it!
                        g.FillPolygon(new SolidBrush(Color.FromArgb(122, Color.Red)), redVals);
                        g.FillPolygon(new SolidBrush(Color.FromArgb(122, Color.Blue)), blueVals);
                        g.FillPolygon(new SolidBrush(Color.FromArgb(122, Color.Green)), greenVals);

                        // Show min max
                        if (showMinMax) {
                            // https://stackoverflow.com/questions/6100573/how-to-draw-a-dashed-line-over-an-object
                            Pen dashpen = new Pen(Color.Red, 1f);
                            // MINS
                            dashpen.DashPattern = new float[] { 4, 2 };
                            g.DrawLine(dashpen, new Point(minsAndMaxs["R"][0], 0), new Point(minsAndMaxs["R"][0], 255));
                            dashpen.Color = Color.Blue;
                            g.DrawLine(dashpen, new Point(minsAndMaxs["B"][0], 0), new Point(minsAndMaxs["B"][0], 255));
                            dashpen.Color = Color.Green;
                            g.DrawLine(dashpen, new Point(minsAndMaxs["G"][0], 0), new Point(minsAndMaxs["G"][0], 255));

                            // MAXES
                            dashpen.Color = Color.Red;
                            dashpen.DashPattern = new float[] { 1, 1 };
                            g.DrawLine(dashpen, new Point(minsAndMaxs["R"][1], 0), new Point(minsAndMaxs["R"][1], 255));
                            dashpen.Color = Color.Blue;
                            g.DrawLine(dashpen, new Point(minsAndMaxs["B"][1], 0), new Point(minsAndMaxs["B"][1], 255));
                            dashpen.Color = Color.Green;
                            g.DrawLine(dashpen, new Point(minsAndMaxs["G"][1], 0), new Point(minsAndMaxs["G"][1], 255));
                        }
                        break;
                }      
                
                if (showMargin) {
                    g.DrawLine(new Pen(Color.Black,1f), new Point(0, ((margin * 100) / histoDataMax)), new Point(255, ((margin * 100) / histoDataMax)));
                }
            }

            // Don't forget to flip it since i drew it with reverse coordinates
            returnable.RotateFlip(RotateFlipType.RotateNoneFlipY);

            // return it
            return returnable;
        }
    }
}
