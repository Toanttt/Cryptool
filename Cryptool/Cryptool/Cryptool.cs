﻿using System.Drawing.Drawing2D;
using System;
using System.Reflection.Metadata;
using System.Windows.Forms;

namespace Cryptool
{
    public partial class Cryptool : Form
    {
        PlayfairCipher? cipher;
        char[,] matrixLayout;
        int version = 5; //playfair mặc định 5x5

        public Cryptool()
        {
            InitializeComponent();

            cipher = new PlayfairCipher();
            matrixLayout = new char[version, version];
            InitMatrix(matrixLayout, '-');
            DisplayMatrix(matrixLayout);
            cbVersion.SelectedIndex = 0;
        }

        #region PlayFair

        private void cbVersion_SelectedIndexChanged(object sender, EventArgs e)
        {
            int version = cbVersion.SelectedItem.ToString() == "5x5" ? 5 : 6;
            cipher.setVersion(version);
            this.version = version;
            matrixLayout = new char[version, version];
            InitMatrix(matrixLayout, '-');
            string change = rtbKeyPlayfair.Text;
            matrixLayout = cipher.createMatrix(change);
            DisplayMatrix(matrixLayout);
        }

        private void InitMatrix(char[,] matrix, char defaultValue)
        {
            for (int i = 0; i < version; i++)
            {
                for (int j = 0; j < version; j++)
                {
                    matrix[i, j] = defaultValue;
                }
            }
        }

        private void DisplayMatrix(char[,] matrix)
        {
            tlpKeyMatrix.Controls.Clear();
            tlpKeyMatrix.RowCount = version;
            tlpKeyMatrix.ColumnCount = version;

            if (version == 5)
            {
                tlpKeyMatrix.Size = new Size(250, 250);
                foreach (Control control in tlpKeyMatrix.Controls)
                {
                    control.Size = new Size(50, 50);
                }
            }
            else if (version == 6)
            {
                tlpKeyMatrix.Size = new Size(300, 300);
                for (int i = 0; i < version; i++)
                {
                    tlpKeyMatrix.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50));
                }

                for (int i = 0; i < version; i++)
                {
                    tlpKeyMatrix.RowStyles.Add(new RowStyle(SizeType.Absolute, 50));
                }
            }

            for (int i = 0; i < version; i++)
            {
                for (int j = 0; j < version; j++)
                {
                    Label lbl = new Label
                    {
                        Text = matrix[i, j].ToString(),
                        TextAlign = ContentAlignment.MiddleCenter,
                        Dock = DockStyle.Fill,
                        BorderStyle = BorderStyle.FixedSingle,
                        Margin = new Padding(5)
                    };
                    tlpKeyMatrix.Controls.Add(lbl, j, i);
                }
            }
        }


        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            string key = rtbKeyPlayfair.Text;
            string input = rtbInputPlayfair.Text;
            string result = cipher.Encode(input);
            rtbResultPlayfair.Text = result;
            DisplayMatrix(cipher.getMatrix());
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            string key = rtbKeyPlayfair.Text;
            string input = rtbInputPlayfair.Text;
            string result = cipher.Decode(input);
            rtbResultPlayfair.Text = result;
            DisplayMatrix(cipher.getMatrix());
        }

        private void rtbKey_ContentsResized(object sender, ContentsResizedEventArgs e)
        {
            string change = rtbKeyPlayfair.Text;
            matrixLayout = cipher.createMatrix(change);
            DisplayMatrix(matrixLayout);
        }

        #endregion

        #region General

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*", 
                Title = "Chọn file văn bản"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string fileContent = File.ReadAllText(openFileDialog.FileName);
                    int currentIndex = tctrlMain.SelectedIndex;
                    if (currentIndex == 0)
                    {
                        rtbInputPlayfair.Text = fileContent;
                    } else if (currentIndex == 1) // Cần điền 
                    {

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi đọc file: " + ex.Message);
                }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            rtbInputPlayfair.Clear();
            rtbKeyPlayfair.Clear();
            rtbResultPlayfair.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*"; 
                saveFileDialog.Title = "Save Text File";
                saveFileDialog.DefaultExt = "txt";
                saveFileDialog.AddExtension = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        int currentIndex = tctrlMain.SelectedIndex;
                        string content = "";
                        if (currentIndex == 0)
                        {
                            content = rtbResultPlayfair.Text;
                        }
                        else if (currentIndex == 1) // Cần điền 
                        {

                        }
                        File.WriteAllText(saveFileDialog.FileName, content);
                        MessageBox.Show("File saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error saving file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        #endregion

        #region RSA
        #endregion
    }
}