using System.Drawing;
using DataLayer;

namespace LogicaLayer
{
    public interface ILogic
    {
        Bitmap GetOriginalImage(string path_Original);
        Bitmap GetOriginalHistogram(ColorSystems cs, int margin, bool showMargin, bool showMinMax);
        Bitmap GetStretchImage(ColorSystems cs, int margin);
        Bitmap GetStretchHistogram(ColorSystems cs);
        void SaveOriginalHistogram(string path);
        void SaveStretchImage(string path);
        void SaveStretchHistogram(string path);
    }

    public class Logic : ILogic
    {
        private IData Data = new Data();

        private Bitmap OriginalHisto;
        private Bitmap StretchImage;
        private Bitmap StretchHisto;

        public Bitmap GetOriginalImage(string path_Original)
        {
            Data.Path_Original = path_Original;
            return Data.Image_Original;
        }

        public Bitmap GetOriginalHistogram(ColorSystems cs, int margin, bool showMargin, bool showMinMax)
        {
            OriginalHisto = Histogram.GetHistogram(Data.Image_Original, margin, showMargin, showMinMax, cs);
            OriginalHisto.RotateFlip(RotateFlipType.Rotate180FlipX);
            return OriginalHisto;
        }

        public Bitmap GetStretchImage(ColorSystems cs, int margin)
        {
            StretchImage = Histogram.GetStretch(Data.Image_Original, margin, cs);
            return StretchImage;
        }

        public Bitmap GetStretchHistogram(ColorSystems cs)
        {
            StretchHisto = Histogram.GetHistogram(StretchImage, 0, false, false, cs);
            StretchHisto.RotateFlip(RotateFlipType.Rotate180FlipX);
            return StretchHisto;
        }

        public void SaveOriginalHistogram(string path)
        {
            Data.SaveImage(OriginalHisto, path);
        }

        public void SaveStretchImage(string path)
        {
            Data.SaveImage(StretchImage, path);
        }

        public void SaveStretchHistogram(string path)
        {
            Data.SaveImage(StretchHisto, path);
        }
    }
}
