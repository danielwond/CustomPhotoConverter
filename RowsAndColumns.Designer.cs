using System.Windows.Forms;

namespace CustomPhotoConverter
{
    partial class RowsAndColumns : Form
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtSizeOneRowsQty = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSizeOneColumnsQty = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSizeOneHeight = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSizeOneWidth = new System.Windows.Forms.TextBox();
            this.lable1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtSizeTwoRowsQty = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSizeTwoColumnsQty = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSizeTwoHeight = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSizeTwoWidth = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtResolution = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtBorder = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtSizeOneRowsQty);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtSizeOneColumnsQty);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtSizeOneHeight);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtSizeOneWidth);
            this.groupBox1.Controls.Add(this.lable1);
            this.groupBox1.Location = new System.Drawing.Point(198, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(230, 95);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Size One";
            // 
            // txtSizeOneRowsQty
            // 
            this.txtSizeOneRowsQty.Location = new System.Drawing.Point(164, 51);
            this.txtSizeOneRowsQty.Name = "txtSizeOneRowsQty";
            this.txtSizeOneRowsQty.Size = new System.Drawing.Size(50, 20);
            this.txtSizeOneRowsQty.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(129, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Row";
            // 
            // txtSizeOneColumnsQty
            // 
            this.txtSizeOneColumnsQty.Location = new System.Drawing.Point(164, 25);
            this.txtSizeOneColumnsQty.Name = "txtSizeOneColumnsQty";
            this.txtSizeOneColumnsQty.Size = new System.Drawing.Size(50, 20);
            this.txtSizeOneColumnsQty.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(123, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Column";
            // 
            // txtSizeOneHeight
            // 
            this.txtSizeOneHeight.Location = new System.Drawing.Point(66, 51);
            this.txtSizeOneHeight.Name = "txtSizeOneHeight";
            this.txtSizeOneHeight.Size = new System.Drawing.Size(50, 20);
            this.txtSizeOneHeight.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Height";
            // 
            // txtSizeOneWidth
            // 
            this.txtSizeOneWidth.Location = new System.Drawing.Point(66, 25);
            this.txtSizeOneWidth.Name = "txtSizeOneWidth";
            this.txtSizeOneWidth.Size = new System.Drawing.Size(50, 20);
            this.txtSizeOneWidth.TabIndex = 1;
            // 
            // lable1
            // 
            this.lable1.AutoSize = true;
            this.lable1.Location = new System.Drawing.Point(28, 28);
            this.lable1.Name = "lable1";
            this.lable1.Size = new System.Drawing.Size(35, 13);
            this.lable1.TabIndex = 0;
            this.lable1.Text = "Width";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtSizeTwoRowsQty);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtSizeTwoColumnsQty);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtSizeTwoHeight);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtSizeTwoWidth);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(459, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(230, 95);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Size Two";
            // 
            // txtSizeTwoRowsQty
            // 
            this.txtSizeTwoRowsQty.Location = new System.Drawing.Point(160, 50);
            this.txtSizeTwoRowsQty.Name = "txtSizeTwoRowsQty";
            this.txtSizeTwoRowsQty.Size = new System.Drawing.Size(50, 20);
            this.txtSizeTwoRowsQty.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(125, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Row";
            // 
            // txtSizeTwoColumnsQty
            // 
            this.txtSizeTwoColumnsQty.Location = new System.Drawing.Point(160, 24);
            this.txtSizeTwoColumnsQty.Name = "txtSizeTwoColumnsQty";
            this.txtSizeTwoColumnsQty.Size = new System.Drawing.Size(50, 20);
            this.txtSizeTwoColumnsQty.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(119, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Column";
            // 
            // txtSizeTwoHeight
            // 
            this.txtSizeTwoHeight.Location = new System.Drawing.Point(62, 50);
            this.txtSizeTwoHeight.Name = "txtSizeTwoHeight";
            this.txtSizeTwoHeight.Size = new System.Drawing.Size(50, 20);
            this.txtSizeTwoHeight.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Height";
            // 
            // txtSizeTwoWidth
            // 
            this.txtSizeTwoWidth.Location = new System.Drawing.Point(62, 24);
            this.txtSizeTwoWidth.Name = "txtSizeTwoWidth";
            this.txtSizeTwoWidth.Size = new System.Drawing.Size(50, 20);
            this.txtSizeTwoWidth.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Width";
            // 
            // txtResolution
            // 
            this.txtResolution.Location = new System.Drawing.Point(366, 124);
            this.txtResolution.Name = "txtResolution";
            this.txtResolution.Size = new System.Drawing.Size(50, 20);
            this.txtResolution.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(303, 127);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Resolution";
            // 
            // txtBorder
            // 
            this.txtBorder.Location = new System.Drawing.Point(511, 124);
            this.txtBorder.Name = "txtBorder";
            this.txtBorder.Size = new System.Drawing.Size(50, 20);
            this.txtBorder.TabIndex = 11;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(444, 127);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "Border Size";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(119, 171);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::CustomPhotoConverter.Properties.Resources.Untitled_1;
            this.pictureBox2.Location = new System.Drawing.Point(729, 127);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(413, 407);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 13;
            this.pictureBox2.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(729, 29);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "Preview";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(729, 55);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // RowsAndColumns
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1159, 569);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtBorder);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtResolution);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "RowsAndColumns";
            this.Text = "RowsAndColumns";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RowsAndColumns_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtSizeOneRowsQty;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSizeOneColumnsQty;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSizeOneHeight;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSizeOneWidth;
        private System.Windows.Forms.Label lable1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtSizeTwoRowsQty;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSizeTwoColumnsQty;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSizeTwoHeight;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSizeTwoWidth;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtResolution;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtBorder;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private Button button1;
        private Button btnSave;
    }
}