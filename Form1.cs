using CustomPhotoConverter.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomPhotoConverter
{
    public partial class Form1 : Form
    {
        CancellationTokenSource _cancellationTokenSource;

        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "Select the source..";
            textBox2.Text = "Select the destination..";
        }


        private async void button1_ClickAsync(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || !Directory.Exists(textBox1.Text))
            {
                MessageBox.Show("Invalid Source", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(textBox2.Text) || !Directory.Exists(textBox2.Text))
            {
                MessageBox.Show("Invalid Destination", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }

            var dialogResult = MessageBox.Show($"Conversion is about to start on folder {textBox1.Text.Split('\\').Last()}\nAre you sure you want to continue?", "Confirmation", MessageBoxButtons.YesNo);
            if(dialogResult == DialogResult.Yes)
            {
                _cancellationTokenSource?.Dispose();
                _cancellationTokenSource = new CancellationTokenSource();
                var token = _cancellationTokenSource.Token;

                lblProgress.Text = "Converting.. please wait..";
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                button4.Text = "Stop";

                var conversion = new ConversionHelper(textBox1.Text, textBox2.Text, progressBar1, lblProgress);

                await conversion.ConvertPhotos(token);

                if (!token.IsCancellationRequested)
                {
                    button1.Enabled = true;
                    button2.Enabled = true;
                    button3.Enabled = true;
                    textBox1.Enabled = true;
                    textBox2.Enabled = true;
                    button4.Text = "Close";

                    MessageBox.Show("Done", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
                var fontSize = textBox2.Font.Size;
                textBox1.Font = new Font("Arial", fontSize, FontStyle.Regular);

                textBox1.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.Black;
                var fontSize = textBox2.Font.Size;
                textBox2.Font = new Font("Arial", fontSize, FontStyle.Regular);

                textBox2.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(button4.Text == "Stop")
            {
                var dialogResult = MessageBox.Show($"Conversion has started\nAre you sure you want to Stop?", "Confirmation", MessageBoxButtons.YesNo);
                if(dialogResult == DialogResult.Yes)
                {
                    _cancellationTokenSource?.Cancel();

                    lblProgress.Text = "Operation Cancelled";
                    button1.Enabled = true;
                    button2.Enabled = true;
                    button3.Enabled = true;
                    textBox1.Enabled = true;
                    textBox2.Enabled = true;
                    button4.Text = "Close";

                    _cancellationTokenSource?.Dispose();
                }
            }
            else
            {
                Application.Exit();
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if(textBox1.Text == "Select the source..")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;

                var fontSize = textBox1.Font.Size;
                textBox1.Font = new Font("Arial", fontSize, FontStyle.Regular);
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Select the source..";
                textBox1.ForeColor = Color.LightGray;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Select the destination..";
                textBox2.ForeColor = Color.LightGray;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Select the destination..")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.Black;
                var fontSize = textBox2.Font.Size; 
                textBox2.Font = new Font("Arial", fontSize, FontStyle.Regular);
            }
        }
    }
}
