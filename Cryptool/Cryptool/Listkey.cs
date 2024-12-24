using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Cryptool
{
    public partial class Listkey : Form
    {
        private Dictionary<string, string> signedDataMap = new Dictionary<string, string>(); // Lưu trữ chữ ký theo tên tệp

        public Listkey()
        {
            InitializeComponent();
        }

        public void AddKey(string publicKey, string privateKey)
        {
            var listViewItem = new ListViewItem(publicKey);
            listViewItem.SubItems.Add(privateKey);
            listView1.Items.Add(listViewItem);
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView1.SelectedItems)
            {
                listView1.Items.Remove(item);
            }
        }

        private void button_sign_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a key to sign.");
                return;
            }

            string privateKey = listView1.SelectedItems[0].SubItems[1].Text;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                string fileContent = File.ReadAllText(filePath);

                try
                {
                    string signedData = SignData(fileContent, privateKey);
                    signedDataMap[filePath] = signedData; // Lưu chữ ký theo tệp
                    MessageBox.Show($"File signed successfully.\nSignature:\n{signedData}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error signing the file: " + ex.Message);
                }
            }
        }

        private void button_verify_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a key to verify.");
                return;
            }

            string publicKey = listView1.SelectedItems[0].SubItems[0].Text;

            OpenFileDialog openFileDialogOriginal = new OpenFileDialog();
            if (openFileDialogOriginal.ShowDialog() == DialogResult.OK)
            {
                string originalFilePath = openFileDialogOriginal.FileName;
                string originalFileContent = File.ReadAllText(originalFilePath); // Dữ liệu gốc

                if (signedDataMap.TryGetValue(originalFilePath, out string signedData)) // Lấy chữ ký theo tệp
                {
                    try
                    {
                        bool isVerified = VerifyData(originalFileContent, signedData, publicKey);
                        MessageBox.Show(isVerified
                                                    ? "Signature verified successfully."
                                                    : "Signature verification failed.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error verifying the file: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("No signature found for the selected file.");
                }
            }
        }

        private string CleanBase64String(string base64)
        {
            string cleanedBase64 = base64.Replace("-----BEGIN PUBLIC KEY-----", "")
                                          .Replace("-----END PUBLIC KEY-----", "")
                                          .Replace("-----BEGIN PRIVATE KEY-----", "")
                                          .Replace("-----END PRIVATE KEY-----", "")
                                          .Replace("\n", "").Replace("\r", "").Replace(" ", "");

            int padding = cleanedBase64.Length % 4;
            if (padding > 0)
            {
                cleanedBase64 = cleanedBase64.PadRight(cleanedBase64.Length + (4 - padding), '=');
            }

            return cleanedBase64;
        }

        private bool IsBase64String(string base64)
        {
            base64 = base64.Trim();
            return (base64.Length % 4 == 0) && Regex.IsMatch(base64, @"^[a-zA-Z0-9\+/]*={0,2}$", RegexOptions.None);
        }

        private string SignData(string data, string privateKey)
        {
            using (RSA rsa = RSA.Create())
            {
                string cleanPrivateKey = CleanBase64String(privateKey);
                if (!IsBase64String(cleanPrivateKey))
                {
                    throw new FormatException("Invalid private key format.");
                }

                rsa.ImportPkcs8PrivateKey(Convert.FromBase64String(cleanPrivateKey), out _);

                byte[] dataBytes = Encoding.UTF8.GetBytes(data);
                byte[] signatureBytes = rsa.SignData(dataBytes, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);

                return Convert.ToBase64String(signatureBytes);
            }
        }

        private bool VerifyData(string originalData, string signedData, string publicKey)
        {
            using (RSA rsa = RSA.Create())
            {
                string cleanPublicKey = CleanBase64String(publicKey);
                if (!IsBase64String(cleanPublicKey))
                {
                    throw new FormatException("Invalid public key format.");
                }

                if (!IsBase64String(signedData))
                {
                    throw new FormatException("Invalid signed data format.");
                }

                rsa.ImportSubjectPublicKeyInfo(Convert.FromBase64String(cleanPublicKey), out _);

                byte[] dataBytes = Encoding.UTF8.GetBytes(originalData);
                byte[] signatureBytes = Convert.FromBase64String(signedData);

                return rsa.VerifyData(dataBytes, signatureBytes, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
            }
        }
    }
}