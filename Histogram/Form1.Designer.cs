namespace GuiLayer
{
    partial class Gui
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.inlezen = new System.Windows.Forms.Button();
            this.imageOrigineel = new System.Windows.Forms.PictureBox();
            this.pathBox = new System.Windows.Forms.TextBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.imageHistoOrigineel = new System.Windows.Forms.PictureBox();
            this.statusLabel = new System.Windows.Forms.Label();
            this.buttonHistogram = new System.Windows.Forms.Button();
            this.imageStretch = new System.Windows.Forms.PictureBox();
            this.imageHistoStretch = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.numericUpDownMargin = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxColorCode = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBoxMargin = new System.Windows.Forms.CheckBox();
            this.checkBoxMinMax = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.imageOrigineel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageHistoOrigineel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageStretch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageHistoStretch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMargin)).BeginInit();
            this.SuspendLayout();
            // 
            // inlezen
            // 
            this.inlezen.Location = new System.Drawing.Point(527, 6);
            this.inlezen.Margin = new System.Windows.Forms.Padding(4);
            this.inlezen.Name = "inlezen";
            this.inlezen.Size = new System.Drawing.Size(143, 46);
            this.inlezen.TabIndex = 0;
            this.inlezen.Text = "Inlezen afbeelding";
            this.inlezen.UseVisualStyleBackColor = true;
            this.inlezen.Click += new System.EventHandler(this.Inlezen_Click);
            // 
            // imageOrigineel
            // 
            this.imageOrigineel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageOrigineel.Location = new System.Drawing.Point(13, 120);
            this.imageOrigineel.Margin = new System.Windows.Forms.Padding(4);
            this.imageOrigineel.Name = "imageOrigineel";
            this.imageOrigineel.Size = new System.Drawing.Size(300, 300);
            this.imageOrigineel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imageOrigineel.TabIndex = 1;
            this.imageOrigineel.TabStop = false;
            // 
            // pathBox
            // 
            this.pathBox.Location = new System.Drawing.Point(199, 18);
            this.pathBox.Margin = new System.Windows.Forms.Padding(4);
            this.pathBox.Name = "pathBox";
            this.pathBox.Size = new System.Drawing.Size(320, 22);
            this.pathBox.TabIndex = 2;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // imageHistoOrigineel
            // 
            this.imageHistoOrigineel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageHistoOrigineel.Location = new System.Drawing.Point(321, 160);
            this.imageHistoOrigineel.Margin = new System.Windows.Forms.Padding(4);
            this.imageHistoOrigineel.Name = "imageHistoOrigineel";
            this.imageHistoOrigineel.Size = new System.Drawing.Size(512, 200);
            this.imageHistoOrigineel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imageHistoOrigineel.TabIndex = 7;
            this.imageHistoOrigineel.TabStop = false;
            this.imageHistoOrigineel.DoubleClick += new System.EventHandler(this.ImageHistoOrigineel_DoubleClick);
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(16, 59);
            this.statusLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(168, 17);
            this.statusLabel.TabIndex = 8;
            this.statusLabel.Text = "Hier komt een statuslabel";
            // 
            // buttonHistogram
            // 
            this.buttonHistogram.Location = new System.Drawing.Point(690, 4);
            this.buttonHistogram.Margin = new System.Windows.Forms.Padding(4);
            this.buttonHistogram.Name = "buttonHistogram";
            this.buttonHistogram.Size = new System.Drawing.Size(143, 48);
            this.buttonHistogram.TabIndex = 9;
            this.buttonHistogram.Text = "Bereken Histogram";
            this.buttonHistogram.UseVisualStyleBackColor = true;
            this.buttonHistogram.Click += new System.EventHandler(this.ButtonHistogram_Click);
            // 
            // imageStretch
            // 
            this.imageStretch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageStretch.Location = new System.Drawing.Point(13, 428);
            this.imageStretch.Margin = new System.Windows.Forms.Padding(4);
            this.imageStretch.Name = "imageStretch";
            this.imageStretch.Size = new System.Drawing.Size(300, 300);
            this.imageStretch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imageStretch.TabIndex = 10;
            this.imageStretch.TabStop = false;
            this.imageStretch.DoubleClick += new System.EventHandler(this.imageStretch_DoubleClick);
            // 
            // imageHistoStretch
            // 
            this.imageHistoStretch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageHistoStretch.Location = new System.Drawing.Point(321, 462);
            this.imageHistoStretch.Margin = new System.Windows.Forms.Padding(4);
            this.imageHistoStretch.Name = "imageHistoStretch";
            this.imageHistoStretch.Size = new System.Drawing.Size(512, 200);
            this.imageHistoStretch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imageHistoStretch.TabIndex = 13;
            this.imageHistoStretch.TabStop = false;
            this.imageHistoStretch.DoubleClick += new System.EventHandler(this.ImageHistoStretch_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 32);
            this.label1.TabIndex = 14;
            this.label1.Text = "Current file:";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "Jpeg|*.JPEG";
            // 
            // numericUpDownMargin
            // 
            this.numericUpDownMargin.Location = new System.Drawing.Point(755, 61);
            this.numericUpDownMargin.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownMargin.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownMargin.Name = "numericUpDownMargin";
            this.numericUpDownMargin.Size = new System.Drawing.Size(78, 22);
            this.numericUpDownMargin.TabIndex = 15;
            this.numericUpDownMargin.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(677, 61);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 18);
            this.label2.TabIndex = 16;
            this.label2.Text = "Margin: ";
            // 
            // comboBoxColorCode
            // 
            this.comboBoxColorCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxColorCode.FormattingEnabled = true;
            this.comboBoxColorCode.Location = new System.Drawing.Point(527, 59);
            this.comboBoxColorCode.Name = "comboBoxColorCode";
            this.comboBoxColorCode.Size = new System.Drawing.Size(121, 24);
            this.comboBoxColorCode.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(423, 61);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 18);
            this.label3.TabIndex = 18;
            this.label3.Text = "ColorCoding:";
            // 
            // checkBoxMargin
            // 
            this.checkBoxMargin.AutoSize = true;
            this.checkBoxMargin.Location = new System.Drawing.Point(722, 132);
            this.checkBoxMargin.Name = "checkBoxMargin";
            this.checkBoxMargin.Size = new System.Drawing.Size(111, 21);
            this.checkBoxMargin.TabIndex = 19;
            this.checkBoxMargin.Text = "Show margin";
            this.checkBoxMargin.UseVisualStyleBackColor = true;
            // 
            // checkBoxMinMax
            // 
            this.checkBoxMinMax.AutoSize = true;
            this.checkBoxMinMax.Location = new System.Drawing.Point(601, 132);
            this.checkBoxMinMax.Name = "checkBoxMinMax";
            this.checkBoxMinMax.Size = new System.Drawing.Size(115, 21);
            this.checkBoxMinMax.TabIndex = 20;
            this.checkBoxMinMax.Text = "Show minmax";
            this.checkBoxMinMax.UseVisualStyleBackColor = true;
            // 
            // Histogram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 741);
            this.Controls.Add(this.checkBoxMinMax);
            this.Controls.Add(this.checkBoxMargin);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxColorCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericUpDownMargin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.imageHistoStretch);
            this.Controls.Add(this.imageStretch);
            this.Controls.Add(this.buttonHistogram);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.imageHistoOrigineel);
            this.Controls.Add(this.pathBox);
            this.Controls.Add(this.imageOrigineel);
            this.Controls.Add(this.inlezen);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Histogram";
            this.Text = "Histogram";
            ((System.ComponentModel.ISupportInitialize)(this.imageOrigineel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageHistoOrigineel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageStretch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageHistoStretch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMargin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button inlezen;
        private System.Windows.Forms.PictureBox imageOrigineel;
        private System.Windows.Forms.TextBox pathBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.PictureBox imageHistoOrigineel;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Button buttonHistogram;
        private System.Windows.Forms.PictureBox imageStretch;
        private System.Windows.Forms.PictureBox imageHistoStretch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.NumericUpDown numericUpDownMargin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxColorCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBoxMargin;
        private System.Windows.Forms.CheckBox checkBoxMinMax;
    }
}

