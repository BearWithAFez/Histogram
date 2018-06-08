using System.Drawing;

namespace DataLayer
{
    public interface IData
    {
        #region Properties
        Bitmap Image_Original { get;}
        string Path_Original { set; }
        #endregion

        #region Methods
        void SaveImage(Bitmap image, string path);
        #endregion
    }

    public class Data : IData
    {
        #region Fields
        private string path_original;   // Path to the orginial Image
        #endregion

        #region Properties
        public Bitmap Image_Original { get; private set; }

        public string Path_Original {
            set {
                path_original = value;
                ReadImage();
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Save the image under the given path
        /// </summary>
        /// <param name="image">The image to save</param>
        /// <param name="path">The path to save under</param>
        public void SaveImage(Bitmap image, string path) => image.Save(path);
        #endregion

        #region Helper Methods
        private void ReadImage() => Image_Original = new Bitmap(path_original);
        #endregion
    }
}
