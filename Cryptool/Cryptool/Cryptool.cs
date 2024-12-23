﻿using System.Numerics;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace Cryptool
{
    public partial class Cryptool : Form
    {
        PlayfairCipher? cipher;
        char[,] matrixLayout;
        int version = 5; //playfair mặc định 5x5
        ToolTip toolTip = new ToolTip();
        private bool isAutoMode = false;
        private Listkey listKeyForm;

        public Cryptool()
        {
            InitializeComponent();
            initPlayfair();
            initRSA();
        }

        #region PlayFair
        private void initPlayfair()
        {
            cipher = new PlayfairCipher();
            matrixLayout = new char[version, version];
            InitMatrix(matrixLayout, '-');
            DisplayMatrix(matrixLayout);
            cbVersion.SelectedIndex = 0;
            cb5x5.SelectedIndex = 0;
            initToolTipPlayfair();
        }
        // Khởi tạo các toolTip cho các controls
        private void initToolTipPlayfair()
        {
            toolTip.IsBalloon = true;
            toolTip.SetToolTip(rtbKeyPlayfair, "Nhập khoá.");
            toolTip.SetToolTip(rtbInputPlayfair, "Nhập thông điệp cần giải mã");
            toolTip.SetToolTip(cbChar, "Tích để tuỳ chỉnh ký tự");
            char c1 = 'X';
            char c2 = 'Y';

            if (tbFirstSep.Text.Length > 0 || tbSecondSep.Text.Length > 0)
            {
                c1 = tbFirstSep.Text[0];
                c2 = tbSecondSep.Text[0];
            }
            toolTip.SetToolTip(tbFirstSep, "Ví dụ: " + "UUF -> " + "U" + c1 + "UF");
            toolTip.SetToolTip(tbSecondSep, "Ví dụ: " + c1 + c1 + " -> " + c1 + c2 + c1);
        }
        // Khởi tạo giá trị cho ma trận khoá 
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

        // Hiện ma trận khoá thông qua table layout panel
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
        // Button mã hoá 
        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(rtbKeyPlayfair.Text))
            {
                btnRand.PerformClick();
            }
            if (string.IsNullOrEmpty(rtbInputPlayfair.Text))
            {
                MessageBox.Show("Chưa nhập thông điệp");
                return;
            }
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
            rtbResultPlayfair.Text = "{Message} " + splitPair(resultString[0]) +
                "\n" + "{Cipher} " + splitPair(resultString[1]);
        }
        // Chia string theo cặp 2 kí tự để hiển thị
        string splitPair(string input)
        {
            if (string.IsNullOrEmpty(input)) return string.Empty;
            input = input.Replace(" ", "");
            char removeChar = cb5x5.SelectedItem?.ToString()[0] ?? 'J';
            char replaceChar = cb5x5.SelectedItem?.ToString()[5] ?? 'I';

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
        // Button giải mã 
        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(rtbKeyPlayfair.Text))
            {
                btnRand.PerformClick();
            }
            if (string.IsNullOrEmpty(rtbInputPlayfair.Text))
            {
                MessageBox.Show("Chưa nhập thông điệp");
                return;
            }
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
            rtbResultPlayfair.Text = "{Cipher} " + mes +
                "\n" + "{Message} " + result;
        }

        // Ô ký tự trùng thứ nhất 
        private void tbFirstSep_TextChanged(object sender, EventArgs e)
        {
            char c1 = 'X';
            char c2 = 'Y';
            if (string.IsNullOrEmpty(tbFirstSep.Text))
            {
                tbFirstSep.Text = "X";
                return;
            }
            if (tbFirstSep.Text.Length > 1)
            {
                tbFirstSep.Text = tbFirstSep.Text[0].ToString();
                tbFirstSep.SelectionStart = tbFirstSep.Text.Length;
            }
            if (tbSecondSep.Text == tbFirstSep.Text)
            {
                tbSecondSep.Clear();
            }
            else if (tbFirstSep.Text.Length > 0 && tbFirstSep.Text.Length > 0)
            {
                c1 = tbFirstSep.Text[0];
                c2 = tbSecondSep.Text[0];
            }

            toolTip.SetToolTip(tbFirstSep, "Ví dụ: " + "UUF -> " + "U" + c1 + "UF");
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
            if (string.IsNullOrEmpty(tbSecondSep.Text))
            {
                tbSecondSep.Text = "Y";
                return;
            }
            if (tbSecondSep.Text.Length > 1)
            {
                tbSecondSep.Text = tbSecondSep.Text[0].ToString();
                tbSecondSep.SelectionStart = tbSecondSep.Text.Length;
            }
            if (tbSecondSep.Text == tbFirstSep.Text)
            {
                tbSecondSep.Clear();
            }
            else if (tbFirstSep.Text.Length > 0 && tbFirstSep.Text.Length > 0)
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
                if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
                {
                    e.Handled = true;
                }
            }
            else if (version == 6)
            {
                if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
                {
                    e.Handled = true;
                }
            }
        }
        // Xử lý khoá 
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

        private void rtbKey_ContentsResized(object sender, ContentsResizedEventArgs e)
        {
            string change = rtbKeyPlayfair.Text;
            matrixLayout = cipher.createMatrix(change);
            DisplayMatrix(matrixLayout);
        }
        // Combobox loại ký tự và thay thế
        private void cb5x5_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedText = cb5x5.SelectedItem.ToString();
            char removeChar = selectedText[0];
            char replaceChar = selectedText[5];
            if (version == 5)
            {
                cipher.setAlphabet(removeChar, replaceChar);
                string change = rtbKeyPlayfair.Text;
                matrixLayout = cipher.createMatrix(change);
                DisplayMatrix(matrixLayout);
            }

            toolTip.SetToolTip(cb5x5, "Ma trận 5x5 loại kí tự " + removeChar + " thay bằng kí tự " + replaceChar);
        }
        // Combobox chọn version 5x5 hoăc 6x6
        private void cbVersion_SelectedIndexChanged(object sender, EventArgs e)
        {
            version = cbVersion.SelectedItem.ToString() == "5x5" ? 5 : 6;
            bool is5x5 = version == 5;
            cb5x5.Enabled = is5x5;

            cipher.setVersion(version);
            matrixLayout = new char[version, version];
            InitMatrix(matrixLayout, '-');
            matrixLayout = cipher.createMatrix(rtbKeyPlayfair.Text);
            DisplayMatrix(matrixLayout);

            string type = is5x5 ? "5x5: chỉ có chữ." : "6x6: gồm chữ và số.";
            toolTip.SetToolTip(cbVersion, $"Đang chọn version {type}");
        }

        private void btnRand_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            string chars = version == 5 ? "ABCDEFGHIJKLMNOPQRSTUVWXYZ" : "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            int length = version == 5 ? 5 : 6;

            rtbKeyPlayfair.Text = new string(Enumerable.Range(0, length)
                .Select(_ => chars[random.Next(chars.Length)])
                .ToArray());
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
            int currentIndex = tctrlMain.SelectedIndex;
            btnNew.PerformClick();

            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*",
                Title = "Chọn file văn bản"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string content = File.ReadAllText(openFileDialog.FileName);
                    if (currentIndex == 0)
                    {
                        var keyMatch = Regex.Match(content, @"\{Key\}(.*?)(\n|$)", RegexOptions.Singleline);
                        var messageMatch = Regex.Match(content, @"\{Message\}(.*?)(\n|$)", RegexOptions.Singleline);
                        var cipherMatch = Regex.Match(content, @"\{Cipher\}(.*?)(\n|$)", RegexOptions.Singleline);
                        var resultMatch = Regex.Match(content, @"\n(.*)$", RegexOptions.Singleline);

                        if (keyMatch.Success) content = content.Replace(keyMatch.Value, "").Trim();
                        if (messageMatch.Success) content = content.Replace(messageMatch.Value, "").Trim();
                        if (resultMatch.Success) content = content.Replace(resultMatch.Value, "").Trim();

                        if (keyMatch.Success) rtbKeyPlayfair.Text = keyMatch.Groups[1].Value.Trim();
                        if (messageMatch.Success) rtbInputPlayfair.Text = messageMatch.Groups[1].Value.Trim();
                        if (resultMatch.Success) rtbResultPlayfair.Text = resultMatch.Groups[1].Value.Trim();

                        if (!string.IsNullOrWhiteSpace(content)) rtbInputPlayfair.Text += content;
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
                saveFileDialog.Title = (currentIndex == 0) ? "Playfair Save File" : "RSA Save File";
                saveFileDialog.DefaultExt = "txt";
                saveFileDialog.AddExtension = true;
                saveFileDialog.FileName = (currentIndex == 0) ? "Playfair_Save.txt" : "RSA_Save.txt";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string content = "";
                        if (currentIndex == 0)
                        {
                            content += "{Key}" + rtbKeyPlayfair.Text;
                            content += "\n" + rtbResultPlayfair.Text;
                        }
                        else if (currentIndex == 1)
                        {

                            if (currentIndex == 0)
                            {
                                // Lưu dữ liệu Playfair
                                content += "{Key}" + rtbKeyPlayfair.Text;
                                content += "\n{Message}" + rtbInputPlayfair.Text;
                                content += "\n{Cipher}" + rtbResultPlayfair.Text;
                            }
                            else if (currentIndex == 1)
                            {
                                // Lưu dữ liệu RSA
                                if (isAutoMode)
                                {
                                    // Dữ liệu cho chế độ tự động
                                    content =
                                        $"Plain text:\n{plain_textbox.Text}\n\n" +
                                        $"Cipher text:\n{cipher_textbox.Text}\n\n" +
                                        $"Private Key:\n{privatekeyTextbox.Text}\n\n" +
                                        $"Public Key:\n{publickeyTextbox.Text}";
                                }
                                else
                                {
                                    // Dữ liệu cho chế độ thủ công
                                    content =
                                        $"Plain text:\n{plain_textbox.Text}\n\n" +
                                        $"Cipher text:\n{cipher_textbox.Text}\n\n" +
                                        $"P: {textBox_P.Text}\n" +
                                        $"Q: {textBox_Q.Text}\n" +
                                        $"E: {textBox_E.Text}\n" +
                                        $"phi(N): {textBox_phiN.Text}\n" +
                                        $"N: {textBox_N.Text}\n" +
                                        $"D: {textBox_D.Text}";
                                }
                            }
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
        private void initRSA()
        {
            // Gắn sự kiện cho RadioButton
            radioButton1.CheckedChanged += RadioButton_CheckedChanged;
            radioButton2.CheckedChanged += RadioButton_CheckedChanged;
            radioButton3.CheckedChanged += RadioButton_CheckedChanged;
            radioButton4.CheckedChanged += RadioButton_CheckedChanged;
            textBox_P.TextChanged += TextBox_PQ_TextChanged;
            textBox_Q.TextChanged += TextBox_PQ_TextChanged;
            textBox_E.TextChanged += TextBox_E_TextChanged;
            textBox_D.TextChanged += TextBox_D_TextChanged;

            // Gắn sự kiện cho nút mã hóa và giải mã
            button_encrypt.Click += button_encrypt_Click;
            button_decrypt.Click += button_decrypt_Click;
            checkBox_auto.CheckedChanged += checkbox_auto_CheckedChanged;
            showmessage("Nhập P và Q để tạo khoá thủ công");
            inittooltip();
            sug_1.Text = string.Empty;
            sug_2.Text = string.Empty;
            sug_3.Text = string.Empty;

            sug_1.Click += LabelD_Click;
            sug_2.Click += LabelD_Click;
            sug_3.Click += LabelD_Click;
        }
        private void inittooltip()
        {
            ToolTip tooltip = new ToolTip() { };

            tooltip.IsBalloon = true;
            tooltip.SetToolTip(plain_textbox, "Thông điệp gốc");
            tooltip.SetToolTip(cipher_textbox, "Thông điệp mã hoá");
            tooltip.SetToolTip(privatekeyTextbox, "Khoá bí mật");
            tooltip.SetToolTip(publickeyTextbox, "Khoá công khai");
            tooltip.SetToolTip(textBox_P, "Nhập số nguyên tố P (P > 1).");
            tooltip.SetToolTip(textBox_Q, "Nhập số nguyên tố Q (Q > 1).");
            tooltip.SetToolTip(textBox_E, "Nhập số nguyên E (1 < E < φ(N), và E phải nguyên tố cùng nhau với φ(N)).");
            tooltip.SetToolTip(textBox_D, "Nhập số nguyên D (D là nghịch đảo của E mod φ(N)).");
            tooltip.SetToolTip(textBox_N, "Giá trị N được tính tự động: N = P * Q.");
            tooltip.SetToolTip(textBox_phiN, "Giá trị φ(N) được tính tự động: φ(N) = (P-1) * (Q-1).");
        }

        private void checkbox_auto_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_auto.Checked)
            {
                // Nếu checkbox được check, hiển thị panel_auto
                panel_manual.Visible = false;
                showmessage("Chế độ tạo khoá tự động đã được chọn.");
                isAutoMode = true;

                radioButton1.Checked = true;
                RadioButton_CheckedChanged(radioButton1, EventArgs.Empty);
            }
            else
            {
                // Nếu checkbox không được check, hiển thị panel_manual
                panel_manual.Visible = true;
                showmessage("Chế độ tạo khoá thủ công được chọn.");
                isAutoMode = false;
            }
        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                generate_key();
            }
        }

        private void showmessage(string message)
        {
            label_message.Text = message;
            label_message.Visible = true;
        }

        private void generate_key()
        {
            int length = radioButton1.Checked ? 512 :
                         radioButton2.Checked ? 1024 :
                         radioButton3.Checked ? 2048 :
                         radioButton4.Checked ? 4096 : 0;

            if (length == 0)
            {
                showmessage("Vui lòng chọn độ dài khóa!");
                return;
            }

            try
            {
                using (var rsa = RSA.Create(length))
                {
                    // Lấy khóa công khai ở định dạng X.509
                    string publicKey = Convert.ToBase64String(rsa.ExportSubjectPublicKeyInfo());

                    // Lấy khóa riêng tư ở định dạng PKCS#8
                    string privateKey = Convert.ToBase64String(rsa.ExportPkcs8PrivateKey());

                    // Hiển thị kết quả trong TextBox
                    publickeyTextbox.Text = $"-----BEGIN PUBLIC KEY-----\n{InsertLineBreaks(publicKey)}\n-----END PUBLIC KEY-----";
                    privatekeyTextbox.Text = $"-----BEGIN PRIVATE KEY-----\n{InsertLineBreaks(privateKey)}\n-----END PRIVATE KEY-----";

                    showmessage($"Khóa RSA {length} bits đã được tạo thành công!");
                }
            }
            catch (Exception ex)
            {
                showmessage($"Lỗi khi tạo khóa: {ex.Message}");
            }
        }

        private string Encrypt(string data, string publicKeyPem)
        {
            try
            {
                byte[] publicKeyBytes = Convert.FromBase64String(RemovePemHeaders(publicKeyPem, "PUBLIC KEY"));

                using (var rsa = RSA.Create())
                {
                    rsa.ImportSubjectPublicKeyInfo(publicKeyBytes, out _);
                    byte[] dataBytes = System.Text.Encoding.UTF8.GetBytes(data);
                    byte[] encryptedBytes = rsa.Encrypt(dataBytes, RSAEncryptionPadding.Pkcs1);
                    return Convert.ToBase64String(encryptedBytes);
                }
            }
            catch (Exception ex)
            {
                showmessage($"Lỗi khi mã hóa: {ex.Message}");
                return null;
            }
        }

        private string Decrypt(string encryptedData, string privateKeyPem)
        {
            try
            {
                byte[] privateKeyBytes = Convert.FromBase64String(RemovePemHeaders(privateKeyPem, "PRIVATE KEY"));

                using (var rsa = RSA.Create())
                {
                    rsa.ImportPkcs8PrivateKey(privateKeyBytes, out _);
                    byte[] encryptedBytes = Convert.FromBase64String(encryptedData);
                    byte[] decryptedBytes = rsa.Decrypt(encryptedBytes, RSAEncryptionPadding.Pkcs1);
                    return System.Text.Encoding.UTF8.GetString(decryptedBytes);
                }
            }
            catch (Exception ex)
            {
                showmessage($"Lỗi khi giải mã: {ex.Message}");
                return null;
            }
        }
        private string EncryptManual(string data, BigInteger e, BigInteger n)
        {
            try
            {
                // Chuyển dữ liệu đầu vào (string) thành BigInteger
                BigInteger dataInt;
                if (!BigInteger.TryParse(data, out dataInt))
                {
                    showmessage("Dữ liệu phải là một số nguyên hợp lệ.");
                    return null;
                }

                // Kiểm tra nếu dữ liệu quá lớn để mã hóa
                if (dataInt >= n)
                {
                    showmessage("Dữ liệu quá lớn để mã hóa với giá trị N đã chọn. Vui lòng chọn M [0; phi(N))");
                    return null;
                }

                // Mã hóa dữ liệu bằng cách sử dụng phương thức ModPow
                BigInteger encryptedData = BigInteger.ModPow(dataInt, e, n);

                // Chuyển dữ liệu mã hóa thành chuỗi Base64
                return encryptedData.ToString();  // Trả về dưới dạng chuỗi số nguyên
            }
            catch (Exception ex)
            {
                // Bắt lỗi và hiển thị thông báo
                showmessage($"Lỗi khi mã hóa: {ex.Message}");
                return null;
            }
        }

        private string DecryptManual(string encryptedData, BigInteger d, BigInteger n)
        {
            try
            {
                // Convert the encrypted data from Base64 to a BigInteger
                BigInteger encryptedInt = BigInteger.Parse(encryptedData);

                // Decrypt the data using ModPow with the private key exponent (d) and modulus (n)
                BigInteger decryptedData = BigInteger.ModPow(encryptedInt, d, n);

                // Return the decrypted data as a number (string format)
                return decryptedData.ToString();  // Return the decrypted BigInteger as a string of the number
            }
            catch (Exception ex)
            {
                // Display error message if decryption fails
                showmessage($"Lỗi khi giải mã: {ex.Message}");
                return null;
            }
        }

        private void button_encrypt_Click(object sender, EventArgs e)
        {
            string dataToEncrypt = plain_textbox.Text;

            if (isAutoMode)
            {
                string publicKey = publickeyTextbox.Text;
                if (string.IsNullOrEmpty(dataToEncrypt) || string.IsNullOrEmpty(publicKey))
                {
                    showmessage("Vui lòng nhập dữ liệu và chọn khóa công khai!");
                    return;
                }

                string encryptedData = Encrypt(dataToEncrypt, publicKey);
                if (encryptedData != null)
                {
                    cipher_textbox.Text = encryptedData;
                    plain_textbox.Text = "";
                    showmessage("Mã hóa thành công!");
                }
            }
            else
            {
                if (BigInteger.TryParse(textBox_E.Text, out BigInteger publicKeyExponent) &&
                    BigInteger.TryParse(textBox_N.Text, out BigInteger modulus))
                {
                    string encryptedData = EncryptManual(dataToEncrypt, publicKeyExponent, modulus);
                    if (encryptedData != null)
                    {
                        cipher_textbox.Text = encryptedData;
                        plain_textbox.Text = "";
                        showmessage("Mã hóa thành công!");
                    }
                }
                else
                {
                    showmessage("Mã hoá thất bại. Vui lòng kiểm tra giá trị E và N!");
                }
            }
        }

        private void button_decrypt_Click(object sender, EventArgs e)
        {
            string dataToDecrypt = cipher_textbox.Text;

            if (isAutoMode)
            {
                string privateKey = privatekeyTextbox.Text;
                if (string.IsNullOrEmpty(dataToDecrypt) || string.IsNullOrEmpty(privateKey))
                {
                    showmessage("Vui lòng nhập dữ liệu và chọn khóa riêng!");
                    return;
                }

                string decryptedData = Decrypt(dataToDecrypt, privateKey);
                if (decryptedData != null)
                {
                    plain_textbox.Text = decryptedData;
                    cipher_textbox.Text = "";
                    showmessage("Giải mã tự động thành công!");
                }
            }
            else
            {
                if (BigInteger.TryParse(textBox_D.Text, out BigInteger d) &&
                    BigInteger.TryParse(textBox_N.Text, out BigInteger n))
                {
                    string decryptedData = DecryptManual(dataToDecrypt, d, n);
                    if (decryptedData != null)
                    {
                        plain_textbox.Text = decryptedData;
                        cipher_textbox.Text = "";
                        showmessage("Giải mã thủ công thành công!");
                    }
                }
                else
                {
                    showmessage("Vui lòng kiểm tra giá trị D và N!");
                }
            }
        }

        // Helper: Chèn xuống dòng để định dạng PEM
        private string InsertLineBreaks(string input, int lineLength = 64)
        {
            return string.Join("\n", Enumerable.Range(0, (input.Length + lineLength - 1) / lineLength)
                                               .Select(i => input.Substring(i * lineLength, Math.Min(lineLength, input.Length - i * lineLength))));
        }

        // Helper: Loại bỏ header và footer PEM
        private string RemovePemHeaders(string pem, string keyType)
        {
            return pem.Replace($"-----BEGIN {keyType}-----", "")
                      .Replace($"-----END {keyType}-----", "")
                      .Replace("\n", "")
                      .Replace("\r", "");
        }

        private void TextBox_PQ_TextChanged(object sender, EventArgs e)
        {
            // Lấy giá trị từ P và Q
            if (BigInteger.TryParse(textBox_P.Text, out BigInteger P) && BigInteger.TryParse(textBox_Q.Text, out BigInteger Q))
            {
                // Kiểm tra nếu P và Q đều hợp lệ
                if (P > 1 && Q > 1)
                {
                    // Tính N = P * Q
                    BigInteger N = P * Q;

                    // Tính phiN = (P-1) * (Q-1)
                    BigInteger phiN = (P - 1) * (Q - 1);

                    // Cập nhật N và phiN vào các TextBox
                    textBox_N.Text = N.ToString();
                    textBox_phiN.Text = phiN.ToString();

                    // Hiển thị thông báo nếu tính toán thành công
                    showmessage("Đã tính toán N và phi(N) thành công!");
                }
                else
                {
                    // Hiển thị thông báo nếu P hoặc Q không hợp lệ
                    showmessage("P và Q phải là các số nguyên lớn hơn 1.");
                }
            }
            else
            {
                // Nếu P hoặc Q không phải là số nguyên hợp lệ
                showmessage("Vui lòng nhập P và Q hợp lệ.");
            }
        }

        private void TextBox_E_TextChanged(object sender, EventArgs e)
        {
            if (BigInteger.TryParse(textBox_E.Text, out BigInteger E) &&
                BigInteger.TryParse(textBox_N.Text, out BigInteger N) &&
                BigInteger.TryParse(textBox_phiN.Text, out BigInteger phiN))
            {
                if (E > 1 && E < phiN && BigInteger.GreatestCommonDivisor(E, phiN) == 1)
                {
                    // Hiển thị thông báo nếu E hợp lệ
                    showmessage("E hợp lệ!");
                    CalculateAndDisplayDValues((int)E, (int)phiN);
                }
                else
                {
                    // Hiển thị thông báo nếu E không hợp lệ
                    showmessage("1 < E < phi(N), và phải là số nguyên tố cùng nhau với phi(N)");
                }
            }
            else
            {
                // Hiển thị thông báo nếu giá trị E không hợp lệ (không phải số hợp lệ)
                showmessage("Vui lòng nhập một giá trị số hợp lệ cho E.");
            }
        }

        private void TextBox_D_TextChanged(object sender, EventArgs e)
        {
            // Kiểm tra xem D, N, và phi(N) có phải là các số hợp lệ không
            if (BigInteger.TryParse(textBox_D.Text, out BigInteger D) &&
                BigInteger.TryParse(textBox_N.Text, out BigInteger N) &&
                BigInteger.TryParse(textBox_phiN.Text, out BigInteger phiN))
            {
                // Lấy giá trị của E từ TextBox
                if (BigInteger.TryParse(textBox_E.Text, out BigInteger E))
                {
                    // Kiểm tra điều kiện E * D mod phi(N) == 1
                    if ((E * D) % phiN == 1)
                    {
                        showmessage("D hợp lệ!");
                    }
                    else
                    {
                        showmessage("D không hợp lệ. D phải là nghịch đảo modulo của E đối với phi(N).");
                    }
                }
            }
            else
            {
                // Thông báo lỗi nếu D, N, hoặc phi(N) không phải là số hợp lệ
                showmessage("Vui lòng nhập một giá trị số hợp lệ cho D, N, và phi(N).");
            }
        }

        private List<int> SuggestDValues(int E, int phiN)
        {
            List<int> suggestions = new List<int>();
            int x = 1;

            while (suggestions.Count < 3)
            {
                int candidate = (phiN * x + 1);
                if (candidate % E == 0)
                {
                    int D = candidate / E;
                    suggestions.Add(D);
                }

                x++;
            }

            return suggestions;
        }
        private void LabelD_Click(object sender, EventArgs e)
        {
            // Khi người dùng chọn một Label, giá trị hiển thị trong TextBox
            if (sender is Label label)
            {
                string value = label.Text.Split(':')[1].Trim(); // Lấy giá trị D từ Label
                textBox_D.Text = value;
            }
        }
        private void CalculateAndDisplayDValues(int E, int phiN)
        {
            // Gọi hàm gợi ý các giá trị D
            List<int> suggestedD = SuggestDValues(E, phiN);

            // Hiển thị các giá trị D lên Label
            sug_1.Text = $"D1: {suggestedD[0]}";
            sug_2.Text = $"D2: {suggestedD[1]}";
            sug_3.Text = $"D3: {suggestedD[2]}";
        }
        #endregion

        private void button_listkey_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu form chưa được tạo
            if (listKeyForm == null || listKeyForm.IsDisposed)
            {
                listKeyForm = new Listkey();
            }

            // Hiển thị form Listkey
            listKeyForm.Show();
        }


        private void button_savekey_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu form Listkey đã được tạo
            if (listKeyForm != null && !listKeyForm.IsDisposed)
            {
                // Lấy dữ liệu khóa (giả sử bạn đã có khóa publicKey và privateKey)
                string publicKey = publickeyTextbox.Text;
                string privateKey = privatekeyTextbox.Text;

                // Thêm dữ liệu vào form Listkey
                listKeyForm.AddKey(publicKey, privateKey);

                // Thông báo thành công
                MessageBox.Show("Khóa đã được lưu vào danh sách.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Danh sách khóa chưa được mở.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
