namespace Cryptool
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            label1 = new Label();
            btnSave = new Button();
            btnOpen = new Button();
            btnNew = new Button();
            tabControl1 = new TabControl();
            tabPlayfair = new TabPage();
            cbVersion = new ComboBox();
            tlpKeyMatrix = new TableLayoutPanel();
            rtbInput = new RichTextBox();
            label12 = new Label();
            btnDecrypt = new Button();
            btnEncrypt = new Button();
            label7 = new Label();
            panel3 = new Panel();
            rtbResult = new RichTextBox();
            label10 = new Label();
            rtbKey = new RichTextBox();
            label11 = new Label();
            tabRSA = new TabPage();
            button7 = new Button();
            button3 = new Button();
            richTextBox1 = new RichTextBox();
            label3 = new Label();
            panel2 = new Panel();
            button2 = new Button();
            richTextBox4 = new RichTextBox();
            label6 = new Label();
            richTextBox3 = new RichTextBox();
            label5 = new Label();
            label4 = new Label();
            richTextBox2 = new RichTextBox();
            label2 = new Label();
            panel1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPlayfair.SuspendLayout();
            panel3.SuspendLayout();
            tabRSA.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btnSave);
            panel1.Controls.Add(btnOpen);
            panel1.Controls.Add(btnNew);
            panel1.Location = new Point(-1, -1);
            panel1.Name = "panel1";
            panel1.Size = new Size(1043, 45);
            panel1.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F);
            label1.Location = new Point(0, -6);
            label1.Name = "label1";
            label1.Size = new Size(333, 46);
            label1.TabIndex = 6;
            label1.Text = "Cryptool Hand Made";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(699, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(64, 42);
            btnSave.TabIndex = 6;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnOpen
            // 
            btnOpen.Location = new Point(629, 3);
            btnOpen.Name = "btnOpen";
            btnOpen.Size = new Size(64, 42);
            btnOpen.TabIndex = 6;
            btnOpen.Text = "Open";
            btnOpen.UseVisualStyleBackColor = true;
            btnOpen.Click += btnOpen_Click;
            // 
            // btnNew
            // 
            btnNew.Location = new Point(559, 3);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(64, 42);
            btnNew.TabIndex = 0;
            btnNew.Text = "New";
            btnNew.UseVisualStyleBackColor = true;
            btnNew.Click += btnNew_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPlayfair);
            tabControl1.Controls.Add(tabRSA);
            tabControl1.Font = new Font("Segoe UI", 10F);
            tabControl1.Location = new Point(12, 50);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1016, 655);
            tabControl1.TabIndex = 6;
            // 
            // tabPlayfair
            // 
            tabPlayfair.Controls.Add(cbVersion);
            tabPlayfair.Controls.Add(tlpKeyMatrix);
            tabPlayfair.Controls.Add(rtbInput);
            tabPlayfair.Controls.Add(label12);
            tabPlayfair.Controls.Add(btnDecrypt);
            tabPlayfair.Controls.Add(btnEncrypt);
            tabPlayfair.Controls.Add(label7);
            tabPlayfair.Controls.Add(panel3);
            tabPlayfair.Controls.Add(rtbKey);
            tabPlayfair.Controls.Add(label11);
            tabPlayfair.Location = new Point(4, 32);
            tabPlayfair.Name = "tabPlayfair";
            tabPlayfair.Padding = new Padding(3);
            tabPlayfair.Size = new Size(1008, 619);
            tabPlayfair.TabIndex = 0;
            tabPlayfair.Text = "Playfair";
            tabPlayfair.UseVisualStyleBackColor = true;
            tabPlayfair.Click += tabPage1_Click;
            // 
            // cbVersion
            // 
            cbVersion.FormattingEnabled = true;
            cbVersion.Items.AddRange(new object[] { "5x5", "6x6" });
            cbVersion.Location = new Point(545, 13);
            cbVersion.Name = "cbVersion";
            cbVersion.Size = new Size(151, 31);
            cbVersion.TabIndex = 27;
            cbVersion.SelectedIndexChanged += cbVersion_SelectedIndexChanged;
            // 
            // tlpKeyMatrix
            // 
            tlpKeyMatrix.ColumnCount = 5;
            tlpKeyMatrix.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tlpKeyMatrix.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tlpKeyMatrix.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tlpKeyMatrix.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tlpKeyMatrix.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tlpKeyMatrix.Location = new Point(496, 47);
            tlpKeyMatrix.Name = "tlpKeyMatrix";
            tlpKeyMatrix.RowCount = 5;
            tlpKeyMatrix.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tlpKeyMatrix.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tlpKeyMatrix.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tlpKeyMatrix.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tlpKeyMatrix.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tlpKeyMatrix.Size = new Size(250, 250);
            tlpKeyMatrix.TabIndex = 26;
            // 
            // rtbInput
            // 
            rtbInput.BorderStyle = BorderStyle.None;
            rtbInput.Location = new Point(31, 106);
            rtbInput.Name = "rtbInput";
            rtbInput.Size = new Size(369, 183);
            rtbInput.TabIndex = 25;
            rtbInput.Text = "KhanhQuoc";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(31, 80);
            label12.Name = "label12";
            label12.Size = new Size(86, 23);
            label12.TabIndex = 24;
            label12.Text = "Input Text";
            // 
            // btnDecrypt
            // 
            btnDecrypt.Location = new Point(129, 569);
            btnDecrypt.Name = "btnDecrypt";
            btnDecrypt.Size = new Size(94, 44);
            btnDecrypt.TabIndex = 23;
            btnDecrypt.Text = "Decrypt";
            btnDecrypt.UseVisualStyleBackColor = true;
            btnDecrypt.Click += btnDecrypt_Click;
            // 
            // btnEncrypt
            // 
            btnEncrypt.Location = new Point(29, 569);
            btnEncrypt.Name = "btnEncrypt";
            btnEncrypt.Size = new Size(94, 44);
            btnEncrypt.TabIndex = 22;
            btnEncrypt.Text = "Encrypt";
            btnEncrypt.UseVisualStyleBackColor = true;
            btnEncrypt.Click += btnEncrypt_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(488, 13);
            label7.Name = "label7";
            label7.Size = new Size(58, 23);
            label7.TabIndex = 20;
            label7.Text = "Matrix";
            // 
            // panel3
            // 
            panel3.Controls.Add(rtbResult);
            panel3.Controls.Add(label10);
            panel3.Location = new Point(31, 375);
            panel3.Name = "panel3";
            panel3.Size = new Size(821, 188);
            panel3.TabIndex = 19;
            // 
            // rtbResult
            // 
            rtbResult.BorderStyle = BorderStyle.None;
            rtbResult.Location = new Point(19, 35);
            rtbResult.Name = "rtbResult";
            rtbResult.Size = new Size(782, 138);
            rtbResult.TabIndex = 22;
            rtbResult.Text = "";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(19, 0);
            label10.Name = "label10";
            label10.Size = new Size(62, 20);
            label10.TabIndex = 8;
            label10.Text = "RESULT";
            // 
            // rtbKey
            // 
            rtbKey.BorderStyle = BorderStyle.None;
            rtbKey.Location = new Point(31, 39);
            rtbKey.Name = "rtbKey";
            rtbKey.Size = new Size(369, 32);
            rtbKey.TabIndex = 18;
            rtbKey.Text = "Hello";
            rtbKey.ContentsResized += rtbKey_ContentsResized;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(31, 13);
            label11.Name = "label11";
            label11.Size = new Size(92, 23);
            label11.TabIndex = 17;
            label11.Text = "Cipher Key";
            // 
            // tabRSA
            // 
            tabRSA.Controls.Add(button7);
            tabRSA.Controls.Add(button3);
            tabRSA.Controls.Add(richTextBox1);
            tabRSA.Controls.Add(label3);
            tabRSA.Controls.Add(panel2);
            tabRSA.Controls.Add(richTextBox2);
            tabRSA.Controls.Add(label2);
            tabRSA.Location = new Point(4, 29);
            tabRSA.Name = "tabRSA";
            tabRSA.Padding = new Padding(3);
            tabRSA.Size = new Size(1008, 622);
            tabRSA.TabIndex = 1;
            tabRSA.Text = "RSA";
            tabRSA.UseVisualStyleBackColor = true;
            tabRSA.Click += tabPage2_Click;
            // 
            // button7
            // 
            button7.Location = new Point(163, 456);
            button7.Name = "button7";
            button7.Size = new Size(94, 29);
            button7.TabIndex = 16;
            button7.Text = "button7";
            button7.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(63, 456);
            button3.Name = "button3";
            button3.Size = new Size(94, 29);
            button3.TabIndex = 15;
            button3.Text = "button3";
            button3.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(488, 73);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(396, 150);
            richTextBox1.TabIndex = 13;
            richTextBox1.Text = "";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(488, 28);
            label3.Name = "label3";
            label3.Size = new Size(75, 23);
            label3.TabIndex = 12;
            label3.Text = "Cryptool";
            // 
            // panel2
            // 
            panel2.Controls.Add(button2);
            panel2.Controls.Add(richTextBox4);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(richTextBox3);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label4);
            panel2.Location = new Point(63, 243);
            panel2.Name = "panel2";
            panel2.Size = new Size(821, 184);
            panel2.TabIndex = 11;
            // 
            // button2
            // 
            button2.Location = new Point(28, 129);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 14;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            // 
            // richTextBox4
            // 
            richTextBox4.Location = new Point(425, 72);
            richTextBox4.Name = "richTextBox4";
            richTextBox4.Size = new Size(368, 39);
            richTextBox4.TabIndex = 16;
            richTextBox4.Text = "";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(425, 36);
            label6.Name = "label6";
            label6.Size = new Size(75, 23);
            label6.TabIndex = 15;
            label6.Text = "Cryptool";
            // 
            // richTextBox3
            // 
            richTextBox3.Location = new Point(28, 72);
            richTextBox3.Name = "richTextBox3";
            richTextBox3.Size = new Size(368, 39);
            richTextBox3.TabIndex = 14;
            richTextBox3.Text = "";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(28, 36);
            label5.Name = "label5";
            label5.Size = new Size(75, 23);
            label5.TabIndex = 9;
            label5.Text = "Cryptool";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(28, 0);
            label4.Name = "label4";
            label4.Size = new Size(75, 23);
            label4.TabIndex = 8;
            label4.Text = "Cryptool";
            // 
            // richTextBox2
            // 
            richTextBox2.Location = new Point(63, 73);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.Size = new Size(396, 150);
            richTextBox2.TabIndex = 10;
            richTextBox2.Text = "";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(63, 28);
            label2.Name = "label2";
            label2.Size = new Size(75, 23);
            label2.TabIndex = 7;
            label2.Text = "Cryptool";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gainsboro;
            ClientSize = new Size(1040, 717);
            Controls.Add(tabControl1);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "EncryptTool";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPlayfair.ResumeLayout(false);
            tabPlayfair.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            tabRSA.ResumeLayout(false);
            tabRSA.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private Button btnNew;
        private Button btnSave;
        private Button btnOpen;
        private Label label1;
        private TabControl tabControl1;
        private TabPage tabPlayfair;
        private TabPage tabRSA;
        private RichTextBox richTextBox2;
        private Label label2;
        private RichTextBox richTextBox1;
        private Label label3;
        private Panel panel2;
        private Button button2;
        private RichTextBox richTextBox4;
        private Label label6;
        private RichTextBox richTextBox3;
        private Label label5;
        private Label label4;
        private Button button7;
        private Button button3;
        private Button btnDecrypt;
        private Button btnEncrypt;
        private Label label7;
        private Panel panel3;
        private Label label10;
        private RichTextBox rtbKey;
        private Label label11;
        private RichTextBox rtbInput;
        private Label label12;
        private RichTextBox rtbResult;
        private TableLayoutPanel tlpKeyMatrix;
        private ComboBox cbVersion;
    }
}
