using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Histogram
{
    public partial class Histogram : Form
    {
        Logica logica = new Logica();
        private Bitmap afbeelding;

        public Histogram()
        {
            InitializeComponent();
            pathBox.ReadOnly = true;
            statusLabel.Text = String.Empty;
            buttonHistogram.Enabled = false;
            comboBoxColorCode.DataSource = Enum.GetValues(typeof(Logica.ColorCode));
        }

        private void inlezen_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = openFileDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string filename = openFileDialog.FileName.ToString();
                    pathBox.Text = Path.GetFileName(filename);
                    afbeelding = new Bitmap(filename);
                    imageOrigineel.Image = afbeelding;
                    buttonHistogram.Enabled = true;
                    ResetGUI();
                }
            }
            catch
            {
                MessageBox.Show("Kan de file niet openen");
            }
        }

        private void buttonHistogram_Click(object sender, EventArgs e)
        {
            Logica.ColorCode code =(Logica.ColorCode) Enum.Parse(typeof(Logica.ColorCode), comboBoxColorCode.SelectedValue.ToString());

            statusLabel.Text = ("Histogram ORIGINEEL aan het berekenen...");
            statusLabel.Refresh();
            imageHistoOrigineel.Image = logica.GetHistogram(new Bitmap(imageOrigineel.Image), (int)numericUpDownMargin.Value, checkBoxMinMax.Checked, checkBoxMargin.Checked, code);
            imageHistoOrigineel.Refresh();

            statusLabel.Text = ("Stretching...");
            statusLabel.Refresh();
            imageStretch.Image = logica.Stretch(new Bitmap(imageOrigineel.Image), (int) numericUpDownMargin.Value, code);
            imageStretch.Refresh();

            statusLabel.Text = ("Histogram Stretch aan het berekenen...");
            statusLabel.Refresh();
            imageHistoStretch.Image = logica.GetHistogram(new Bitmap(imageStretch.Image), (int)numericUpDownMargin.Value, false, false, code);
            imageHistoStretch.Refresh();

            statusLabel.Text = ("Done!");
        }

        private void ResetGUI()
        {
            imageHistoOrigineel.Image = null;
            imageStretch.Image = null;
            imageHistoStretch.Image = null;
        }

        private void imageHistoOrigineel_DoubleClick(object sender, EventArgs e) {
            try {
                DialogResult result = saveFileDialog.ShowDialog();
                if (result == DialogResult.OK) {
                    imageHistoOrigineel.Image.Save(saveFileDialog.FileName);
                    ResetGUI();
                }
            } catch {
                MessageBox.Show("Kan de file niet oplsaan");
            }
        }

        private void imageHistoStretch_DoubleClick(object sender, EventArgs e) {
            try {
                DialogResult result = saveFileDialog.ShowDialog();
                if (result == DialogResult.OK) {
                    imageHistoStretch.Image.Save(saveFileDialog.FileName);
                    ResetGUI();
                }
            } catch {
                MessageBox.Show("Kan de file niet oplsaan");
            }
        }

        private void imageStretch_DoubleClick(object sender, EventArgs e) {
            try {
                DialogResult result = saveFileDialog.ShowDialog();
                if (result == DialogResult.OK) {
                    imageStretch.Image.Save(saveFileDialog.FileName);
                    ResetGUI();
                }
            } catch {
                MessageBox.Show("Kan de file niet oplsaan");
            }
        }
    }
}
