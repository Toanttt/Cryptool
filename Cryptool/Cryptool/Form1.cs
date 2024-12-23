using System;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Numerics;
using System.IO;

namespace Cryptool
{
    public partial class Form1 : Form
    {
        private bool isAutoMode = false;
        public Form1()
        {
            InitializeComponent();


        }
        private void init()
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
            button5.Click += SaveData;

            // Gắn sự kiện cho nút mã hóa và giải mã
            button_encrypt.Click += button_encrypt_Click;
            button_decrypt.Click += button_decrypt_Click;
            showmessage("Nhập P và Q để tạo khoá thủ công");
            inittooltip();
        }
        private void inittooltip()
        {
            ToolTip tooltip = new ToolTip()
            {
                InitialDelay = 0,      // Hiển thị ngay lập tức
                AutoPopDelay = 5000,   // Tự động ẩn sau 5 giây
                ReshowDelay = 0        // Không có độ trễ khi hiển thị 

            };

            // Gắn thêm sự kiện MouseEnter và MouseLeave để hiển thị nhanh
            textBox_P.MouseEnter += (s, e) => tooltip.Show("Nhập số nguyên tố P (P > 1).", textBox_P);
            textBox_P.MouseLeave += (s, e) => tooltip.Hide(textBox_P);

            textBox_Q.MouseEnter += (s, e) => tooltip.Show("Nhập số nguyên tố Q (Q > 1).", textBox_Q);
            textBox_Q.MouseLeave += (s, e) => tooltip.Hide(textBox_Q);

            textBox_E.MouseEnter += (s, e) => tooltip.Show("Nhập số nguyên E (1 < E < φ(N), và E phải nguyên tố cùng nhau với φ(N)).", textBox_E);
            textBox_E.MouseLeave += (s, e) => tooltip.Hide(textBox_E);

            textBox_D.MouseEnter += (s, e) => tooltip.Show("Nhập số nguyên D (D là nghịch đảo của E mod φ(N)).", textBox_D);
            textBox_D.MouseLeave += (s, e) => tooltip.Hide(textBox_D);

            textBox_N.MouseEnter += (s, e) => tooltip.Show("Giá trị N được tính tự động: N = P * Q.", textBox_N);
            textBox_N.MouseLeave += (s, e) => tooltip.Hide(textBox_N);

            textBox_phiN.MouseEnter += (s, e) => tooltip.Show("Giá trị φ(N) được tính tự động: φ(N) = (P-1) * (Q-1).", textBox_phiN);
            textBox_phiN.MouseLeave += (s, e) => tooltip.Hide(textBox_phiN);

        }



        private void checkbox_auto_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_auto.Checked)
            {
                // Nếu checkbox được check, hiển thị panel_auto
                panel_manual.Visible = false;
                showmessage("Chế độ tạo khoá tự động đã được chọn.");
                isAutoMode = true;
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
        private void SaveData(object sender, EventArgs e)
        {
            try
            {
                // Create a SaveFileDialog to choose the location and file name
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                    saveFileDialog.Title = "Save Data";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = saveFileDialog.FileName;

                        // Check if we are in auto mode
                        if (isAutoMode)
                        {
                            // Collect the data to save for auto mode
                            string dataToSave =
                                $"Plain text:\n{plain_textbox.Text}\n\n" +
                                $"Cipher text:\n{cipher_textbox.Text}\n\n" +
                                $"Private Key:\n{privatekeyTextbox.Text}\n\n" +
                                $"Public Key:\n{publickeyTextbox.Text}";

                            // Save the data to the file
                            File.WriteAllText(filePath, dataToSave);
                            showmessage("Dữ liệu đã được lưu thành công (Auto Mode).");
                        }
                        else
                        {
                            // Collect the data to save for manual mode
                            string dataToSave =
                                $"Plain text:\n{plain_textbox.Text}\n\n" +
                                $"Cipher text:\n{cipher_textbox.Text}\n\n" +
                                $"P: {textBox_P.Text}\n" +
                                $"Q: {textBox_Q.Text}\n" +
                                $"E: {textBox_E.Text}\n" +
                                $"phi(N): {textBox_phiN.Text}\n" +
                                $"N: {textBox_N.Text}\n" +
                                $"D: {textBox_D.Text}";

                            // Save the data to the file
                            File.WriteAllText(filePath, dataToSave);
                            showmessage("Dữ liệu đã được lưu thành công (Manual Mode).");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                showmessage($"Lỗi khi lưu dữ liệu: {ex.Message}");
            }
        }

        private void panel_manual_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
