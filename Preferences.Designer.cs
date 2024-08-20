namespace CustomPhotoConverter
{
    partial class Preferences
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
            this.rdBtnCm = new System.Windows.Forms.RadioButton();
            this.rdBtnPixel = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grpBoxcm = new System.Windows.Forms.GroupBox();
            this.txtSizeTwoQty = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtSizeOneQty = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtOneHeightcm = new System.Windows.Forms.TextBox();
            this.txtResolution = new System.Windows.Forms.TextBox();
            this.txtOneWidthcm = new System.Windows.Forms.TextBox();
            this.txtTwoHeightcm = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTwoWidthcm = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTwoHeight = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTwoWidth = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtOneHeight = new System.Windows.Forms.TextBox();
            this.txtOneWidth = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPreview = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.grpBoxcm.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // rdBtnCm
            // 
            this.rdBtnCm.AutoSize = true;
            this.rdBtnCm.Checked = true;
            this.rdBtnCm.Location = new System.Drawing.Point(5, 25);
            this.rdBtnCm.Name = "rdBtnCm";
            this.rdBtnCm.Size = new System.Drawing.Size(39, 17);
            this.rdBtnCm.TabIndex = 12;
            this.rdBtnCm.TabStop = true;
            this.rdBtnCm.Text = "cm";
            this.rdBtnCm.UseVisualStyleBackColor = true;
            this.rdBtnCm.CheckedChanged += new System.EventHandler(this.rdBtnCm_CheckedChanged);
            // 
            // rdBtnPixel
            // 
            this.rdBtnPixel.AutoSize = true;
            this.rdBtnPixel.Location = new System.Drawing.Point(6, 48);
            this.rdBtnPixel.Name = "rdBtnPixel";
            this.rdBtnPixel.Size = new System.Drawing.Size(46, 17);
            this.rdBtnPixel.TabIndex = 13;
            this.rdBtnPixel.Text = "pixel";
            this.rdBtnPixel.UseVisualStyleBackColor = true;
            this.rdBtnPixel.CheckedChanged += new System.EventHandler(this.rdBtnPixel_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdBtnPixel);
            this.groupBox1.Controls.Add(this.rdBtnCm);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(100, 74);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Measurement";
            // 
            // grpBoxcm
            // 
            this.grpBoxcm.Controls.Add(this.txtSizeTwoQty);
            this.grpBoxcm.Controls.Add(this.label11);
            this.grpBoxcm.Controls.Add(this.txtSizeOneQty);
            this.grpBoxcm.Controls.Add(this.label10);
            this.grpBoxcm.Controls.Add(this.label9);
            this.grpBoxcm.Controls.Add(this.txtOneHeightcm);
            this.grpBoxcm.Controls.Add(this.txtResolution);
            this.grpBoxcm.Controls.Add(this.txtOneWidthcm);
            this.grpBoxcm.Controls.Add(this.txtTwoHeightcm);
            this.grpBoxcm.Controls.Add(this.label2);
            this.grpBoxcm.Controls.Add(this.label8);
            this.grpBoxcm.Controls.Add(this.label6);
            this.grpBoxcm.Controls.Add(this.txtTwoWidthcm);
            this.grpBoxcm.Controls.Add(this.label7);
            this.grpBoxcm.Location = new System.Drawing.Point(146, 12);
            this.grpBoxcm.Name = "grpBoxcm";
            this.grpBoxcm.Size = new System.Drawing.Size(400, 126);
            this.grpBoxcm.TabIndex = 15;
            this.grpBoxcm.TabStop = false;
            this.grpBoxcm.Text = "Measurement in cm";
            // 
            // txtSizeTwoQty
            // 
            this.txtSizeTwoQty.Location = new System.Drawing.Point(351, 66);
            this.txtSizeTwoQty.Name = "txtSizeTwoQty";
            this.txtSizeTwoQty.Size = new System.Drawing.Size(43, 20);
            this.txtSizeTwoQty.TabIndex = 30;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(299, 70);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(46, 13);
            this.label11.TabIndex = 29;
            this.label11.Text = "Quantity";
            // 
            // txtSizeOneQty
            // 
            this.txtSizeOneQty.Location = new System.Drawing.Point(351, 28);
            this.txtSizeOneQty.Name = "txtSizeOneQty";
            this.txtSizeOneQty.Size = new System.Drawing.Size(43, 20);
            this.txtSizeOneQty.TabIndex = 28;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(299, 32);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 13);
            this.label10.TabIndex = 27;
            this.label10.Text = "Quantity";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(130, 101);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Resolution";
            // 
            // txtOneHeightcm
            // 
            this.txtOneHeightcm.Location = new System.Drawing.Point(244, 28);
            this.txtOneHeightcm.Name = "txtOneHeightcm";
            this.txtOneHeightcm.Size = new System.Drawing.Size(43, 20);
            this.txtOneHeightcm.TabIndex = 26;
            this.txtOneHeightcm.TextChanged += new System.EventHandler(this.txtOneHeightcm_TextChanged);
            // 
            // txtResolution
            // 
            this.txtResolution.Location = new System.Drawing.Point(193, 98);
            this.txtResolution.Name = "txtResolution";
            this.txtResolution.Size = new System.Drawing.Size(49, 20);
            this.txtResolution.TabIndex = 16;
            this.txtResolution.TextChanged += new System.EventHandler(this.txtResolution_TextChanged);
            // 
            // txtOneWidthcm
            // 
            this.txtOneWidthcm.Location = new System.Drawing.Point(100, 27);
            this.txtOneWidthcm.Name = "txtOneWidthcm";
            this.txtOneWidthcm.Size = new System.Drawing.Size(43, 20);
            this.txtOneWidthcm.TabIndex = 25;
            this.txtOneWidthcm.TextChanged += new System.EventHandler(this.txtOneWidthcm_TextChanged);
            // 
            // txtTwoHeightcm
            // 
            this.txtTwoHeightcm.Location = new System.Drawing.Point(244, 66);
            this.txtTwoHeightcm.Name = "txtTwoHeightcm";
            this.txtTwoHeightcm.Size = new System.Drawing.Size(43, 20);
            this.txtTwoHeightcm.TabIndex = 24;
            this.txtTwoHeightcm.TextChanged += new System.EventHandler(this.txtTwoHeightcm_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(152, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Size1 Height (cm)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 28);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Size1 Width (cm)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(152, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Size2 Height (cm)";
            // 
            // txtTwoWidthcm
            // 
            this.txtTwoWidthcm.Location = new System.Drawing.Point(100, 66);
            this.txtTwoWidthcm.Name = "txtTwoWidthcm";
            this.txtTwoWidthcm.Size = new System.Drawing.Size(43, 20);
            this.txtTwoWidthcm.TabIndex = 20;
            this.txtTwoWidthcm.TextChanged += new System.EventHandler(this.txtTwoWidthcm_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 69);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Size2 Width (cm)";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtTwoHeight);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtTwoWidth);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtOneHeight);
            this.groupBox2.Controls.Add(this.txtOneWidth);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(562, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(312, 126);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Measurement in pixels";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(159, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Size1 Height (px)";
            // 
            // txtTwoHeight
            // 
            this.txtTwoHeight.Location = new System.Drawing.Point(252, 67);
            this.txtTwoHeight.Name = "txtTwoHeight";
            this.txtTwoHeight.Size = new System.Drawing.Size(49, 20);
            this.txtTwoHeight.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(159, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Size2 Height (px)";
            // 
            // txtTwoWidth
            // 
            this.txtTwoWidth.Location = new System.Drawing.Point(104, 66);
            this.txtTwoWidth.Name = "txtTwoWidth";
            this.txtTwoWidth.Size = new System.Drawing.Size(49, 20);
            this.txtTwoWidth.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Size2 Width (px)";
            // 
            // txtOneHeight
            // 
            this.txtOneHeight.Location = new System.Drawing.Point(252, 27);
            this.txtOneHeight.Name = "txtOneHeight";
            this.txtOneHeight.Size = new System.Drawing.Size(49, 20);
            this.txtOneHeight.TabIndex = 14;
            // 
            // txtOneWidth
            // 
            this.txtOneWidth.Location = new System.Drawing.Point(104, 26);
            this.txtOneWidth.Name = "txtOneWidth";
            this.txtOneWidth.Size = new System.Drawing.Size(49, 20);
            this.txtOneWidth.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Size1 Width (px)";
            // 
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(471, 151);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(75, 23);
            this.btnPreview.TabIndex = 20;
            this.btnPreview.Text = "Preview";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(387, 151);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 19;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(141, 194);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            // 
            // Preferences
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1098, 647);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grpBoxcm);
            this.Controls.Add(this.groupBox1);
            this.Name = "Preferences";
            this.Text = "Preferences";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpBoxcm.ResumeLayout(false);
            this.grpBoxcm.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RadioButton rdBtnCm;
        private System.Windows.Forms.RadioButton rdBtnPixel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox grpBoxcm;
        private System.Windows.Forms.TextBox txtOneWidthcm;
        private System.Windows.Forms.TextBox txtTwoHeightcm;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTwoWidthcm;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtOneHeightcm;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtResolution;
        private System.Windows.Forms.TextBox txtSizeTwoQty;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtSizeOneQty;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTwoHeight;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTwoWidth;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtOneHeight;
        private System.Windows.Forms.TextBox txtOneWidth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}