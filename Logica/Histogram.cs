using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace LogicaLayer
{
    static class Histogram
    {
        private static readonly int TRANSPARENCY = 122;

        public static Bitmap GetHistogram(Bitmap image, int margin, bool showMargin, bool showMinMax, ColorSystems cs)
        {
            // Get data
            var histoData = ColorSystem.GetHistoDataMethod(cs)(image);
            var minsAndMaxs = GetHistoMinMax(histoData, margin);
            var histo = new Bitmap(256, 100);
            int histoDataMax = 0;
            foreach (var kvp in histoData)
            {
                int max = kvp.Value.Max();
                if (histoDataMax < max) histoDataMax = max;
            }

            // Draw histogram
            using (Graphics g = Graphics.FromImage(histo))
            {
                // Clear it
                g.Clear(Color.White);

                // Draw the parts
                foreach (var kvp in histoData)
                {
                    // Data Conversion
                    var vals = new PointF[256];
                    for (int i = 0; i < 256; i++) vals[i] = new PointF(i, ((kvp.Value[i] * 100) / histoDataMax));

                    // Make sure there is a start/end point
                    var list = vals.ToList();
                    list.Insert(0, new PointF(0, 0));
                    list.Add(new PointF(255, 0));
                    vals = list.ToArray();

                    g.FillPolygon(new SolidBrush(Color.FromArgb(TRANSPARENCY, Color.FromName(kvp.Key))), vals);
                }

                // Draw MinMax
                if (showMinMax)
                {
                    foreach (var kvp in minsAndMaxs)
                    {
                        var dashpen = new Pen(Color.FromName(kvp.Key), 1f)
                        {
                            DashPattern = new float[] { 4, 2 }
                        };
                        g.DrawLine(dashpen, new Point(kvp.Value[0], 0), new Point(kvp.Value[0], 255));
                        dashpen.DashPattern = new float[] { 1, 1 };
                        g.DrawLine(dashpen, new Point(kvp.Value[1], 0), new Point(kvp.Value[1], 255));
                    }
                }

                // Draw Margin
                if (showMargin)
                {
                    var dashpen = new Pen(Color.Black, 1f)
                    {
                        DashPattern = new float[] { 4, 2, 2, 2 }
                    };
                    g.DrawLine(dashpen, new Point(0, ((margin * 100) / histoDataMax)), new Point(255, ((margin * 100) / histoDataMax)));
                }
            }

            return histo;
        }

        public static Bitmap GetStretch(Bitmap image_original, int margin, ColorSystems cs)
        {
            // Get data
            var stretch = new Bitmap(image_original);
            var histoData = ColorSystem.GetHistoDataMethod(cs)(image_original);
            var minsAndMaxs = GetHistoMinMax(histoData, margin);
            var stretchPix = ColorSystem.GetStretchPixelMethod(cs);

            // Stretch
            for (int i = 0; i < image_original.Width; i++) for (int j = 0; j < image_original.Height; j++) stretch.SetPixel(i, j, stretchPix(image_original.GetPixel(i, j), minsAndMaxs));

            // Return it
            return stretch;
        }

        private static Dictionary<string, int[]> GetHistoMinMax(Dictionary<string, int[]> histoData, int margin)
        {
            var minMax = new Dictionary<string, int[]>();

            foreach (var kvp in histoData)
            {
                var current = new int[] { 0, 255 };

                for (int i = 0; i < kvp.Value.Length; i++)
                {
                    if ((kvp.Value[i] >= margin) && (current[0] == 0)) current[0] = i;
                    if ((kvp.Value[kvp.Value.Length - i - 1] >= margin) && (current[1] == 255)) current[1] = kvp.Value.Length - i - 1;

                    if ((current[0] != 0) && (current[1] != 255)) break;
                }

                minMax.Add(kvp.Key, current);
            }
            return minMax;
        }
    }
}
