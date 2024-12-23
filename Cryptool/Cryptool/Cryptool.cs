using System.Drawing.Drawing2D;
using System;
using System.Reflection.Metadata;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

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
            if(version == 6)
            {
                cb5x5.Enabled = false;
            } else if (version == 5)
            {
                cb5x5.SelectedIndex = 0;
                cb5x5.Enabled = true;
            }
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
            if (tbFirstSep.Text == "" || tbSecondSep.Text == "")
            {
                tbFirstSep.Text = "X";
                tbSecondSep.Text = "Y";
            }
            bool isChecked = cbChar.Checked;
            char firstSep = 'X';
            char sencondSep = 'Y';
            if (isChecked)
            {
                firstSep = tbFirstSep.Text.ToUpper()[0];
                sencondSep = tbSecondSep.Text.ToUpper()[0];
                tbFirstSep.Text = tbFirstSep.Text.ToUpper();
                tbSecondSep.Text = tbSecondSep.Text.ToUpper();
            }

            string input = rtbInputPlayfair.Text;
            string result = cipher.Encode(input, firstSep, sencondSep);
            string[] resultString = result.Split(' ', 2);
            rtbResultPlayfair.Text = splitPair(resultString[0]) + 
                "\n" + splitPair(resultString[1]);
        }

        static string splitPair(string input)
        {
            if (string.IsNullOrEmpty(input)) return string.Empty;
            var result = new System.Text.StringBuilder();

            for (int i = 0; i < input.Length; i += 2)
            {
                if (i + 1 < input.Length)
                {
                    result.Append(input[i]).Append(input[i + 1]).Append(" ");
                }
                else
                {
                    result.Append(input[i]).Append(" ");
                }
            }

            // Xóa khoảng trắng cuối cùng
            return result.ToString().Trim();
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            if (tbFirstSep.Text == "" || tbSecondSep.Text == "")
            {
                tbFirstSep.Text = "X";
                tbSecondSep.Text = "Y";
            }
            string input = rtbInputPlayfair.Text;
            string result = cipher.Decode(input);
            if (result[0] != '-')
            {
                result = splitPair(result);
            }
            string mes = splitPair(rtbInputPlayfair.Text.ToUpper());
            rtbResultPlayfair.Text = mes + "\n" +result;
        }

        private void rtbKey_ContentsResized(object sender, ContentsResizedEventArgs e)
        {
            string change = rtbKeyPlayfair.Text;
            matrixLayout = cipher.createMatrix(change);
            DisplayMatrix(matrixLayout);
        }
        // Ô ký tự trùng thứ nhất 
        private void tbFirstSep_TextChanged(object sender, EventArgs e)
        {
            if (tbFirstSep.Text.Length > 1)
            {
                tbFirstSep.Text = tbFirstSep.Text[0].ToString();
                tbFirstSep.SelectionStart = tbFirstSep.Text.Length;
            }
            if (tbSecondSep.Text == tbFirstSep.Text)
            {
                tbSecondSep.Clear();
            }
        }

        private void tbFirstSep_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (version == 5)
            {
                if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            else if (version == 6)
            {
                if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            if (tbFirstSep.Text.Length == 1 && tbFirstSep.Text == tbSecondSep.Text)
            {
                e.Handled = true;
            }
        }
        // Ô ký tự trùng thứ hai
        private void tbSecondSep_TextChanged(object sender, EventArgs e)
        {
            if (tbSecondSep.Text.Length > 1)
            {
                tbSecondSep.Text = tbSecondSep.Text[0].ToString();
                tbSecondSep.SelectionStart = tbSecondSep.Text.Length;
            }
            if (tbSecondSep.Text == tbFirstSep.Text)
            {
                tbSecondSep.Clear();
            }
        }

        private void tbSecondSep_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (version == 5)
            {
                if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            else if (version == 6)
            {
                if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            if (tbFirstSep.Text.Length == 1 && tbFirstSep.Text == tbSecondSep.Text)
            {
                e.Handled = true;
            }
        }
        // Xử lý textbox khoá và thông điệp 
        private void rtbInputPlayfair_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (version == 5)
            {
                if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            else if (version == 6)
            {
                if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void rtbKeyPlayfair_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (version == 5)
            {
                if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            else if (version == 6)
            {
                if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
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
                    }
                    else if (currentIndex == 1) // Cần điền 
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
            int currentIndex = tctrlMain.SelectedIndex;
            if (currentIndex == 0)
            {
                rtbInputPlayfair.Clear();
                rtbKeyPlayfair.Clear();
                rtbResultPlayfair.Clear();
            }
            else if (currentIndex == 1) // Cần điền 
            {

            }
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
                            content += "{Key}" + rtbKeyPlayfair.Text;
                            content += "{Message}"+rtbInputPlayfair.Text;
                            content += "{Cipher}"+rtbResultPlayfair.Text;
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
