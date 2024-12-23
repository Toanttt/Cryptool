namespace Cryptool
{
    partial class Cryptool
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
            tctrlMain = new TabControl();
            tabPlayfair = new TabPage();
            gbOption = new GroupBox();
            cb5x5 = new ComboBox();
            cbChar = new CheckBox();
            tbFirstSep = new TextBox();
            tbSecondSep = new TextBox();
            label13 = new Label();
            label14 = new Label();
            label9 = new Label();
            cbVersion = new ComboBox();
            tlpKeyMatrix = new TableLayoutPanel();
            rtbInputPlayfair = new RichTextBox();
            label8 = new Label();
            label12 = new Label();
            btnDecryptPlayfair = new Button();
            btnEncryptPlayfair = new Button();
            label7 = new Label();
            panel3 = new Panel();
            rtbResultPlayfair = new RichTextBox();
            label10 = new Label();
            rtbKeyPlayfair = new RichTextBox();
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
            tctrlMain.SuspendLayout();
            tabPlayfair.SuspendLayout();
            gbOption.SuspendLayout();
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
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(913, 49);
            panel1.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F);
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(333, 46);
            label1.TabIndex = 6;
            label1.Text = "Cryptool Hand Made";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(699, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(64, 43);
            btnSave.TabIndex = 6;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnOpen
            // 
            btnOpen.Location = new Point(629, 3);
            btnOpen.Name = "btnOpen";
            btnOpen.Size = new Size(64, 43);
            btnOpen.TabIndex = 6;
            btnOpen.Text = "Open";
            btnOpen.UseVisualStyleBackColor = true;
            btnOpen.Click += btnOpen_Click;
            // 
            // btnNew
            // 
            btnNew.Location = new Point(559, 3);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(64, 43);
            btnNew.TabIndex = 0;
            btnNew.Text = "New";
            btnNew.UseVisualStyleBackColor = true;
            btnNew.Click += btnNew_Click;
            // 
            // tctrlMain
            // 
            tctrlMain.Controls.Add(tabPlayfair);
            tctrlMain.Controls.Add(tabRSA);
            tctrlMain.Dock = DockStyle.Bottom;
            tctrlMain.Font = new Font("Segoe UI", 10F);
            tctrlMain.Location = new Point(0, 55);
            tctrlMain.Name = "tctrlMain";
            tctrlMain.SelectedIndex = 0;
            tctrlMain.Size = new Size(913, 793);
            tctrlMain.TabIndex = 6;
            // 
            // tabPlayfair
            // 
            tabPlayfair.Controls.Add(gbOption);
            tabPlayfair.Controls.Add(cbVersion);
            tabPlayfair.Controls.Add(tlpKeyMatrix);
            tabPlayfair.Controls.Add(rtbInputPlayfair);
            tabPlayfair.Controls.Add(label8);
            tabPlayfair.Controls.Add(label12);
            tabPlayfair.Controls.Add(btnDecryptPlayfair);
            tabPlayfair.Controls.Add(btnEncryptPlayfair);
            tabPlayfair.Controls.Add(label7);
            tabPlayfair.Controls.Add(panel3);
            tabPlayfair.Controls.Add(rtbKeyPlayfair);
            tabPlayfair.Controls.Add(label11);
            tabPlayfair.Location = new Point(4, 32);
            tabPlayfair.Name = "tabPlayfair";
            tabPlayfair.Padding = new Padding(3, 3, 3, 3);
            tabPlayfair.Size = new Size(905, 757);
            tabPlayfair.TabIndex = 0;
            tabPlayfair.Text = "Playfair";
            tabPlayfair.UseVisualStyleBackColor = true;
            tabPlayfair.Click += tabPage1_Click;
            // 
            // gbOption
            // 
            gbOption.Controls.Add(cb5x5);
            gbOption.Controls.Add(cbChar);
            gbOption.Controls.Add(tbFirstSep);
            gbOption.Controls.Add(tbSecondSep);
            gbOption.Controls.Add(label13);
            gbOption.Controls.Add(label14);
            gbOption.Controls.Add(label9);
            gbOption.Location = new Point(31, 241);
            gbOption.Margin = new Padding(3, 4, 3, 4);
            gbOption.Name = "gbOption";
            gbOption.Padding = new Padding(3, 4, 3, 4);
            gbOption.Size = new Size(369, 244);
            gbOption.TabIndex = 29;
            gbOption.TabStop = false;
            gbOption.Text = "Option";
            // 
            // cb5x5
            // 
            cb5x5.DropDownStyle = ComboBoxStyle.DropDownList;
            cb5x5.FormattingEnabled = true;
            cb5x5.Items.AddRange(new object[] { "J -> I", "Q -> Z", "V -> U", "W -> V", "Z -> Y", "K -> C" });
            cb5x5.Location = new Point(198, 181);
            cb5x5.Margin = new Padding(3, 4, 3, 4);
            cb5x5.Name = "cb5x5";
            cb5x5.Size = new Size(138, 31);
            cb5x5.TabIndex = 30;
            cb5x5.SelectedIndexChanged += cb5x5_SelectedIndexChanged;
            // 
            // cbChar
            // 
            cbChar.AutoSize = true;
            cbChar.BackgroundImageLayout = ImageLayout.None;
            cbChar.Location = new Point(19, 32);
            cbChar.Margin = new Padding(3, 4, 3, 4);
            cbChar.Name = "cbChar";
            cbChar.Size = new Size(351, 27);
            cbChar.TabIndex = 29;
            cbChar.Text = "Chọn ký tự tách trùng lặp (mặc định: X, Y)";
            cbChar.UseVisualStyleBackColor = true;
            // 
            // tbFirstSep
            // 
            tbFirstSep.BorderStyle = BorderStyle.FixedSingle;
            tbFirstSep.Location = new Point(220, 77);
            tbFirstSep.Margin = new Padding(3, 4, 3, 4);
            tbFirstSep.Name = "tbFirstSep";
            tbFirstSep.Size = new Size(32, 30);
            tbFirstSep.TabIndex = 28;
            tbFirstSep.Text = "X";
            tbFirstSep.TextAlign = HorizontalAlignment.Center;
            tbFirstSep.TextChanged += tbFirstSep_TextChanged;
            tbFirstSep.KeyPress += tbFirstSep_KeyPress;
            // 
            // tbSecondSep
            // 
            tbSecondSep.BorderStyle = BorderStyle.FixedSingle;
            tbSecondSep.Location = new Point(220, 126);
            tbSecondSep.Margin = new Padding(3, 4, 3, 4);
            tbSecondSep.Name = "tbSecondSep";
            tbSecondSep.Size = new Size(32, 30);
            tbSecondSep.TabIndex = 28;
            tbSecondSep.Text = "Y";
            tbSecondSep.TextAlign = HorizontalAlignment.Center;
            tbSecondSep.TextChanged += tbSecondSep_TextChanged;
            tbSecondSep.KeyPress += tbSecondSep_KeyPress;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(13, 79);
            label13.Name = "label13";
            label13.Size = new Size(201, 23);
            label13.TabIndex = 24;
            label13.Text = "Kí tự phân cách đầu tiên:";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(13, 185);
            label14.Name = "label14";
            label14.Size = new Size(176, 23);
            label14.TabIndex = 24;
            label14.Text = "Loại bỏ ký tự cho 5x5:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(13, 128);
            label9.Name = "label9";
            label9.Size = new Size(188, 23);
            label9.TabIndex = 24;
            label9.Text = "Dấu phân cách thứ hai:";
            // 
            // cbVersion
            // 
            cbVersion.FormattingEnabled = true;
            cbVersion.Items.AddRange(new object[] { "5x5", "6x6" });
            cbVersion.Location = new Point(625, 13);
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
            tlpKeyMatrix.Location = new Point(526, 51);
            tlpKeyMatrix.Name = "tlpKeyMatrix";
            tlpKeyMatrix.RowCount = 5;
            tlpKeyMatrix.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tlpKeyMatrix.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tlpKeyMatrix.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tlpKeyMatrix.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tlpKeyMatrix.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tlpKeyMatrix.Size = new Size(250, 251);
            tlpKeyMatrix.TabIndex = 26;
            // 
            // rtbInputPlayfair
            // 
            rtbInputPlayfair.BorderStyle = BorderStyle.None;
            rtbInputPlayfair.Location = new Point(31, 107);
            rtbInputPlayfair.Name = "rtbInputPlayfair";
            rtbInputPlayfair.Size = new Size(369, 128);
            rtbInputPlayfair.TabIndex = 25;
            rtbInputPlayfair.Text = "KhanhQuoc";
            rtbInputPlayfair.KeyPress += rtbInputPlayfair_KeyPress;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(400, 53);
            label8.Name = "label8";
            label8.Size = new Size(0, 23);
            label8.TabIndex = 24;
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
            // btnDecryptPlayfair
            // 
            btnDecryptPlayfair.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnDecryptPlayfair.Location = new Point(129, 700);
            btnDecryptPlayfair.Name = "btnDecryptPlayfair";
            btnDecryptPlayfair.Size = new Size(94, 44);
            btnDecryptPlayfair.TabIndex = 23;
            btnDecryptPlayfair.Text = "Decrypt";
            btnDecryptPlayfair.UseVisualStyleBackColor = true;
            btnDecryptPlayfair.Click += btnDecrypt_Click;
            // 
            // btnEncryptPlayfair
            // 
            btnEncryptPlayfair.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnEncryptPlayfair.Location = new Point(29, 700);
            btnEncryptPlayfair.Name = "btnEncryptPlayfair";
            btnEncryptPlayfair.Size = new Size(94, 44);
            btnEncryptPlayfair.TabIndex = 22;
            btnEncryptPlayfair.Text = "Encrypt";
            btnEncryptPlayfair.UseVisualStyleBackColor = true;
            btnEncryptPlayfair.Click += btnEncrypt_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(526, 16);
            label7.Name = "label7";
            label7.Size = new Size(58, 23);
            label7.TabIndex = 20;
            label7.Text = "Matrix";
            // 
            // panel3
            // 
            panel3.Controls.Add(rtbResultPlayfair);
            panel3.Controls.Add(label10);
            panel3.Location = new Point(31, 507);
            panel3.Name = "panel3";
            panel3.Size = new Size(869, 188);
            panel3.TabIndex = 19;
            // 
            // rtbResultPlayfair
            // 
            rtbResultPlayfair.BorderStyle = BorderStyle.None;
            rtbResultPlayfair.Location = new Point(0, 23);
            rtbResultPlayfair.Name = "rtbResultPlayfair";
            rtbResultPlayfair.ReadOnly = true;
            rtbResultPlayfair.Size = new Size(865, 139);
            rtbResultPlayfair.TabIndex = 22;
            rtbResultPlayfair.Text = "";
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
            // rtbKeyPlayfair
            // 
            rtbKeyPlayfair.BorderStyle = BorderStyle.None;
            rtbKeyPlayfair.Location = new Point(31, 39);
            rtbKeyPlayfair.Name = "rtbKeyPlayfair";
            rtbKeyPlayfair.Size = new Size(369, 32);
            rtbKeyPlayfair.TabIndex = 18;
            rtbKeyPlayfair.Text = "Hello";
            rtbKeyPlayfair.ContentsResized += rtbKey_ContentsResized;
            rtbKeyPlayfair.KeyPress += rtbKeyPlayfair_KeyPress;
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
            tabRSA.Location = new Point(4, 32);
            tabRSA.Name = "tabRSA";
            tabRSA.Padding = new Padding(3, 3, 3, 3);
            tabRSA.Size = new Size(905, 757);
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
            richTextBox1.Size = new Size(396, 151);
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
            button2.Location = new Point(27, 129);
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
            richTextBox4.Size = new Size(367, 39);
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
            richTextBox3.Location = new Point(27, 72);
            richTextBox3.Name = "richTextBox3";
            richTextBox3.Size = new Size(367, 39);
            richTextBox3.TabIndex = 14;
            richTextBox3.Text = "";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(27, 36);
            label5.Name = "label5";
            label5.Size = new Size(75, 23);
            label5.TabIndex = 9;
            label5.Text = "Cryptool";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(27, 0);
            label4.Name = "label4";
            label4.Size = new Size(75, 23);
            label4.TabIndex = 8;
            label4.Text = "Cryptool";
            // 
            // richTextBox2
            // 
            richTextBox2.Location = new Point(63, 73);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.Size = new Size(396, 151);
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
            // Cryptool
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gainsboro;
            ClientSize = new Size(913, 848);
            Controls.Add(tctrlMain);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "Cryptool";
            Text = "EncryptTool";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tctrlMain.ResumeLayout(false);
            tabPlayfair.ResumeLayout(false);
            tabPlayfair.PerformLayout();
            gbOption.ResumeLayout(false);
            gbOption.PerformLayout();
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
        private TabControl tctrlMain;
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
        private Button btnDecryptPlayfair;
        private Button btnEncryptPlayfair;
        private Label label7;
        private Panel panel3;
        private Label label10;
        private RichTextBox rtbKeyPlayfair;
        private Label label11;
        private RichTextBox rtbInputPlayfair;
        private Label label12;
        private RichTextBox rtbResultPlayfair;
        private TableLayoutPanel tlpKeyMatrix;
        private ComboBox cbVersion;
        private TextBox tbSecondSep;
        private TextBox tbFirstSep;
        private Label label9;
        private Label label8;
        private GroupBox gbOption;
        private Label label13;
        private CheckBox cbChar;
        private ComboBox cb5x5;
        private Label label14;
    }
}
