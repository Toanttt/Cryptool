namespace Cryptool
{
    public partial class Cryptool : Form
    {
        PlayfairCipher? cipher;
        char[,] matrixLayout;
        int version = 5; //playfair mặc định 5x5
        ToolTip toolTip = new ToolTip();

        public Cryptool()
        {
            InitializeComponent();
            cipher = new PlayfairCipher();
            matrixLayout = new char[version, version];
            InitMatrix(matrixLayout, '-');
            DisplayMatrix(matrixLayout);
            cbVersion.SelectedIndex = 0;
            cb5x5.SelectedIndex = 0;
            initToolTipPlayfair();
        }

        #region PlayFair

        private void initToolTipPlayfair()
        {
            toolTip.IsBalloon = true;
            toolTip.SetToolTip(rtbKeyPlayfair, "Nhập khoá.");
            toolTip.SetToolTip(rtbInputPlayfair, "Nhập thông điệp cần giải mã");
            toolTip.SetToolTip(cbChar,"Tích để tuỳ chỉnh ký tự");
            char c1 = 'X';
            char c2 = 'Y';

            if (tbFirstSep.Text.Length > 0 || tbSecondSep.Text.Length > 0)
            {
                c1 = tbFirstSep.Text[0];
                c2 = tbSecondSep.Text[0];
            }
            toolTip.SetToolTip(tbFirstSep, "Ví dụ: " + "UUF -> " + "U" + c1 + "UF");
            toolTip.SetToolTip(tbSecondSep, "Ví dụ: " + c1 + c1 + " -> " + c1 + c2 +c1);
        }
        private void cbVersion_SelectedIndexChanged(object sender, EventArgs e)
        {
            int version = cbVersion.SelectedItem.ToString() == "5x5" ? 5 : 6;
            string type = "5x5: chỉ có chữ.";
            if (version == 6)
            {
                cb5x5.Enabled = false;
                type = "6x6: gồm chữ và số.";
            }
            else if (version == 5)
            {
                cb5x5.Enabled = true;
                type = "5x5: chỉ có chữ.";
            }
            cipher.setVersion(version);
            this.version = version;
            matrixLayout = new char[version, version];
            InitMatrix(matrixLayout, '-');

            string change = rtbKeyPlayfair.Text;
            matrixLayout = cipher.createMatrix(change);
            DisplayMatrix(matrixLayout);

            toolTip.SetToolTip(cbVersion, "Đang chọn version " + type);
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
            string result = cipher.Encode(input, firstSep, sencondSep); // Hàm giải mã chính
            string[] resultString = result.Split(' ', 2);
            rtbResultPlayfair.Text = splitPair(resultString[0]) +
                "\n" + splitPair(resultString[1]);
        }

        string splitPair(string input)
        {
            if (string.IsNullOrEmpty(input)) return string.Empty;
            input = input.Replace(" ", "");


            char removeChar = 'J';
            char replaceChar = 'I';
            if (string.IsNullOrEmpty(cb5x5.SelectedItem.ToString()))
            {
            }
            else
            {
                removeChar = cb5x5.SelectedItem.ToString()[0];
                replaceChar = cb5x5.SelectedItem.ToString()[5];
            }

            if (version == 5)
            {
                input = new string(input.Where(char.IsLetterOrDigit).Select(char.ToUpper).ToArray()).Replace(removeChar, replaceChar);
            }
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
            rtbResultPlayfair.Text = mes + "\n" + result;
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
            char c1 = 'X';
            char c2 = 'Y';
            if (tbFirstSep.Text.Length > 1)
            {
                tbFirstSep.Text = tbFirstSep.Text[0].ToString();
                tbFirstSep.SelectionStart = tbFirstSep.Text.Length;
            }
            if (tbSecondSep.Text == tbFirstSep.Text)
            {
                tbSecondSep.Clear();
            }
            if (tbFirstSep.Text.Length > 0 && tbFirstSep.Text.Length > 0)
            {
                c1 = tbFirstSep.Text[0];
                c2 = tbSecondSep.Text[0];
            }

            toolTip.SetToolTip(tbFirstSep, "Ví dụ: " +  "UUF -> " + "U"+ c1 + "UF");
            toolTip.SetToolTip(tbSecondSep, "Ví dụ: " + c1 + c1 + " -> " + c1 + c2 + c1);

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
            char c1 = 'X';
            char c2 = 'Y';
            if (tbSecondSep.Text.Length > 1)
            {
                tbSecondSep.Text = tbSecondSep.Text[0].ToString();
                tbSecondSep.SelectionStart = tbSecondSep.Text.Length;
            }
            if (tbSecondSep.Text == tbFirstSep.Text)
            {
                tbSecondSep.Clear();
            }
            if (tbFirstSep.Text.Length > 0 && tbFirstSep.Text.Length > 0)
            {
                c1 = tbFirstSep.Text[0];
                c2 = tbSecondSep.Text[0];
            }
            toolTip.SetToolTip(tbFirstSep, "Ví dụ: " + "UUF -> " + "U" + c1 + "UF");
            toolTip.SetToolTip(tbSecondSep, "Ví dụ: " + c1 + c1 + " -> " + c1 + c2 + c1);
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

        private void cb5x5_SelectedIndexChanged(object sender, EventArgs e)
        {
            char removeChar = 'J';
            char replaceChar = 'I';
            removeChar = cb5x5.SelectedItem.ToString()[0];
            replaceChar = cb5x5.SelectedItem.ToString()[5];
            if (version == 5)
            {
                cipher.setAlphabet(removeChar, replaceChar);
                string change = rtbKeyPlayfair.Text;
                matrixLayout = cipher.createMatrix(change);
                DisplayMatrix(matrixLayout);
            }

            toolTip.SetToolTip(cb5x5, "Ma trận 5x5 loại kí tự " + removeChar + " thay bằng kí tự " + replaceChar);
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
            int currentIndex = tctrlMain.SelectedIndex;
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                saveFileDialog.Title = (currentIndex == 0)?"Playfair Save File":"";
                saveFileDialog.DefaultExt = "txt";
                saveFileDialog.AddExtension = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        
                        string content = "";
                        if (currentIndex == 0)
                        {
                            content += "{Key}" + rtbKeyPlayfair.Text;
                            content += "\n{Message}" + rtbInputPlayfair.Text;
                            content += "\n{Cipher}" + rtbResultPlayfair.Text;
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
