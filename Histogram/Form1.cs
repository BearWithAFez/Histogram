using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using LogicaLayer;

namespace GuiLayer
{
    public partial class Gui : Form
    {
        ILogic logic = new Logic();

        public Gui()
        {
            InitializeComponent();
            pathBox.ReadOnly = true;
            statusLabel.Text = String.Empty;
            buttonHistogram.Enabled = false;
            comboBoxColorCode.DataSource = Enum.GetValues(typeof(ColorSystems));
        }

        private void Inlezen_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = openFileDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    var path = openFileDialog.FileName.ToString();
                    pathBox.Text = Path.GetFileName(path);
                    logic.GetOriginalImage(path);
                    imageOrigineel.Image = new Bitmap(path);
                    buttonHistogram.Enabled = true;
                    ResetGUI();
                }
            }
            catch
            {
                MessageBox.Show("Kan file niet openen");
            }
        }

        private void ButtonHistogram_Click(object sender, EventArgs e)
        {
            var cs = (ColorSystems)Enum.Parse(typeof(ColorSystems), comboBoxColorCode.SelectedValue.ToString());
            var margin = (int)numericUpDownMargin.Value;

            statusLabel.Text = ("Histogram ORIGINEEL aan het berekenen...");
            statusLabel.Refresh();
            imageHistoOrigineel.Image = logic.GetOriginalHistogram(cs, margin, checkBoxMargin.Checked, checkBoxMinMax.Checked);
            imageHistoOrigineel.Refresh();

            statusLabel.Text = ("Stretching...");
            statusLabel.Refresh();
            imageStretch.Image = logic.GetStretchImage(cs, margin);
            imageStretch.Refresh();

            statusLabel.Text = ("Histogram Stretch aan het berekenen...");
            statusLabel.Refresh();
            imageHistoStretch.Image = logic.GetStretchHistogram(cs);
            imageHistoStretch.Refresh();

            statusLabel.Text = ("Done!");
        }

        private void ResetGUI()
        {
            imageHistoOrigineel.Image = null;
            imageStretch.Image = null;
            imageHistoStretch.Image = null;
        }

        private void ImageHistoOrigineel_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = saveFileDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    logic.SaveOriginalHistogram(saveFileDialog.FileName);
                    ResetGUI();
                }
            }
            catch
            {
                MessageBox.Show("Kan de file niet oplsaan");
            }
        }

        private void ImageHistoStretch_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = saveFileDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    logic.SaveStretchHistogram(saveFileDialog.FileName);
                    ResetGUI();
                }
            }
            catch
            {
                MessageBox.Show("Kan de file niet oplsaan");
            }
        }

        private void imageStretch_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = saveFileDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    logic.SaveStretchImage(saveFileDialog.FileName);
                    ResetGUI();
                }
            }
            catch
            {
                MessageBox.Show("Kan de file niet oplsaan");
            }
        }
    }
}
