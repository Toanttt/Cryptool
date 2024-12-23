﻿namespace Cryptool
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
            panel_manual = new Panel();
            textBox_D = new TextBox();
            label16 = new Label();
            textBox_phiN = new TextBox();
            label17 = new Label();
            textBox_E = new TextBox();
            label15 = new Label();
            textBox_N = new TextBox();
            label2 = new Label();
            textBox_Q = new TextBox();
            label4 = new Label();
            textBox_P = new TextBox();
            label5 = new Label();
            label6 = new Label();
            resultPanel = new Panel();
            label_message = new Label();
            button_decrypt = new Button();
            button_encrypt = new Button();
            cipher_textbox = new RichTextBox();
            label3 = new Label();
            panel_auto = new Panel();
            radioButton3 = new RadioButton();
            radioButton4 = new RadioButton();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            privatekeyTextbox = new RichTextBox();
            label18 = new Label();
            publickeyTextbox = new RichTextBox();
            label19 = new Label();
            label20 = new Label();
            plain_textbox = new RichTextBox();
            label21 = new Label();
            checkBox_auto = new CheckBox();
            panel1.SuspendLayout();
            tctrlMain.SuspendLayout();
            tabPlayfair.SuspendLayout();
            gbOption.SuspendLayout();
            panel3.SuspendLayout();
            tabRSA.SuspendLayout();
            panel_manual.SuspendLayout();
            resultPanel.SuspendLayout();
            panel_auto.SuspendLayout();
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
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(799, 37);
            panel1.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F);
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(170, 37);
            label1.TabIndex = 6;
            label1.Text = "PlayRSA Tool";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(731, 2);
            btnSave.Margin = new Padding(3, 2, 3, 2);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(56, 32);
            btnSave.TabIndex = 6;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnOpen
            // 
            btnOpen.Location = new Point(669, 2);
            btnOpen.Margin = new Padding(3, 2, 3, 2);
            btnOpen.Name = "btnOpen";
            btnOpen.Size = new Size(56, 32);
            btnOpen.TabIndex = 6;
            btnOpen.Text = "Open";
            btnOpen.UseVisualStyleBackColor = true;
            btnOpen.Click += btnOpen_Click;
            // 
            // btnNew
            // 
            btnNew.Location = new Point(608, 2);
            btnNew.Margin = new Padding(3, 2, 3, 2);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(56, 32);
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
            tctrlMain.Location = new Point(0, 41);
            tctrlMain.Margin = new Padding(3, 2, 3, 2);
            tctrlMain.Name = "tctrlMain";
            tctrlMain.SelectedIndex = 0;
            tctrlMain.Size = new Size(799, 595);
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
            tabPlayfair.Location = new Point(4, 26);
            tabPlayfair.Margin = new Padding(3, 2, 3, 2);
            tabPlayfair.Name = "tabPlayfair";
            tabPlayfair.Padding = new Padding(3, 2, 3, 2);
            tabPlayfair.Size = new Size(791, 565);
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
            gbOption.Location = new Point(27, 181);
            gbOption.Name = "gbOption";
            gbOption.Size = new Size(323, 183);
            gbOption.TabIndex = 29;
            gbOption.TabStop = false;
            gbOption.Text = "Option";
            // 
            // cb5x5
            // 
            cb5x5.DropDownStyle = ComboBoxStyle.DropDownList;
            cb5x5.FormattingEnabled = true;
            cb5x5.Items.AddRange(new object[] { "J -> I", "Q -> Z", "V -> U", "W -> V", "Z -> Y", "K -> C" });
            cb5x5.Location = new Point(173, 136);
            cb5x5.Name = "cb5x5";
            cb5x5.Size = new Size(121, 25);
            cb5x5.TabIndex = 30;
            cb5x5.SelectedIndexChanged += cb5x5_SelectedIndexChanged;
            // 
            // cbChar
            // 
            cbChar.AutoSize = true;
            cbChar.BackgroundImageLayout = ImageLayout.None;
            cbChar.Location = new Point(17, 24);
            cbChar.Name = "cbChar";
            cbChar.Size = new Size(284, 23);
            cbChar.TabIndex = 29;
            cbChar.Text = "Chọn ký tự tách trùng lặp (mặc định: X, Y)";
            cbChar.UseVisualStyleBackColor = true;
            // 
            // tbFirstSep
            // 
            tbFirstSep.BorderStyle = BorderStyle.FixedSingle;
            tbFirstSep.Location = new Point(192, 58);
            tbFirstSep.Name = "tbFirstSep";
            tbFirstSep.Size = new Size(28, 25);
            tbFirstSep.TabIndex = 28;
            tbFirstSep.Text = "X";
            tbFirstSep.TextAlign = HorizontalAlignment.Center;
            tbFirstSep.TextChanged += tbFirstSep_TextChanged;
            tbFirstSep.KeyPress += tbFirstSep_KeyPress;
            // 
            // tbSecondSep
            // 
            tbSecondSep.BorderStyle = BorderStyle.FixedSingle;
            tbSecondSep.Location = new Point(192, 94);
            tbSecondSep.Name = "tbSecondSep";
            tbSecondSep.Size = new Size(28, 25);
            tbSecondSep.TabIndex = 28;
            tbSecondSep.Text = "Y";
            tbSecondSep.TextAlign = HorizontalAlignment.Center;
            tbSecondSep.TextChanged += tbSecondSep_TextChanged;
            tbSecondSep.KeyPress += tbSecondSep_KeyPress;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(11, 59);
            label13.Name = "label13";
            label13.Size = new Size(160, 19);
            label13.TabIndex = 24;
            label13.Text = "Kí tự phân cách đầu tiên:";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(11, 139);
            label14.Name = "label14";
            label14.Size = new Size(144, 19);
            label14.TabIndex = 24;
            label14.Text = "Loại bỏ ký tự cho 5x5:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(11, 96);
            label9.Name = "label9";
            label9.Size = new Size(150, 19);
            label9.TabIndex = 24;
            label9.Text = "Dấu phân cách thứ hai:";
            // 
            // cbVersion
            // 
            cbVersion.FormattingEnabled = true;
            cbVersion.Items.AddRange(new object[] { "5x5", "6x6" });
            cbVersion.Location = new Point(547, 10);
            cbVersion.Margin = new Padding(3, 2, 3, 2);
            cbVersion.Name = "cbVersion";
            cbVersion.Size = new Size(133, 25);
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
            tlpKeyMatrix.Location = new Point(460, 38);
            tlpKeyMatrix.Margin = new Padding(3, 2, 3, 2);
            tlpKeyMatrix.Name = "tlpKeyMatrix";
            tlpKeyMatrix.RowCount = 5;
            tlpKeyMatrix.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tlpKeyMatrix.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tlpKeyMatrix.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tlpKeyMatrix.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tlpKeyMatrix.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tlpKeyMatrix.Size = new Size(219, 188);
            tlpKeyMatrix.TabIndex = 26;
            // 
            // rtbInputPlayfair
            // 
            rtbInputPlayfair.BorderStyle = BorderStyle.None;
            rtbInputPlayfair.Location = new Point(27, 80);
            rtbInputPlayfair.Margin = new Padding(3, 2, 3, 2);
            rtbInputPlayfair.Name = "rtbInputPlayfair";
            rtbInputPlayfair.Size = new Size(323, 96);
            rtbInputPlayfair.TabIndex = 25;
            rtbInputPlayfair.Text = "KhanhQuoc";
            rtbInputPlayfair.KeyPress += rtbInputPlayfair_KeyPress;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(350, 40);
            label8.Name = "label8";
            label8.Size = new Size(0, 19);
            label8.TabIndex = 24;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(27, 60);
            label12.Name = "label12";
            label12.Size = new Size(63, 19);
            label12.TabIndex = 24;
            label12.Text = "Message";
            // 
            // btnDecryptPlayfair
            // 
            btnDecryptPlayfair.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnDecryptPlayfair.Location = new Point(113, 525);
            btnDecryptPlayfair.Margin = new Padding(3, 2, 3, 2);
            btnDecryptPlayfair.Name = "btnDecryptPlayfair";
            btnDecryptPlayfair.Size = new Size(82, 33);
            btnDecryptPlayfair.TabIndex = 23;
            btnDecryptPlayfair.Text = "Decrypt";
            btnDecryptPlayfair.UseVisualStyleBackColor = true;
            btnDecryptPlayfair.Click += btnDecrypt_Click;
            // 
            // btnEncryptPlayfair
            // 
            btnEncryptPlayfair.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnEncryptPlayfair.Location = new Point(25, 525);
            btnEncryptPlayfair.Margin = new Padding(3, 2, 3, 2);
            btnEncryptPlayfair.Name = "btnEncryptPlayfair";
            btnEncryptPlayfair.Size = new Size(82, 33);
            btnEncryptPlayfair.TabIndex = 22;
            btnEncryptPlayfair.Text = "Encrypt";
            btnEncryptPlayfair.UseVisualStyleBackColor = true;
            btnEncryptPlayfair.Click += btnEncrypt_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(460, 12);
            label7.Name = "label7";
            label7.Size = new Size(48, 19);
            label7.TabIndex = 20;
            label7.Text = "Matrix";
            // 
            // panel3
            // 
            panel3.Controls.Add(rtbResultPlayfair);
            panel3.Controls.Add(label10);
            panel3.Location = new Point(27, 380);
            panel3.Margin = new Padding(3, 2, 3, 2);
            panel3.Name = "panel3";
            panel3.Size = new Size(760, 141);
            panel3.TabIndex = 19;
            // 
            // rtbResultPlayfair
            // 
            rtbResultPlayfair.BorderStyle = BorderStyle.None;
            rtbResultPlayfair.Location = new Point(0, 17);
            rtbResultPlayfair.Margin = new Padding(3, 2, 3, 2);
            rtbResultPlayfair.Name = "rtbResultPlayfair";
            rtbResultPlayfair.ReadOnly = true;
            rtbResultPlayfair.Size = new Size(757, 104);
            rtbResultPlayfair.TabIndex = 22;
            rtbResultPlayfair.Text = "";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(17, 0);
            label10.Name = "label10";
            label10.Size = new Size(49, 15);
            label10.TabIndex = 8;
            label10.Text = "RESULT";
            // 
            // rtbKeyPlayfair
            // 
            rtbKeyPlayfair.BorderStyle = BorderStyle.None;
            rtbKeyPlayfair.Location = new Point(27, 29);
            rtbKeyPlayfair.Margin = new Padding(3, 2, 3, 2);
            rtbKeyPlayfair.Name = "rtbKeyPlayfair";
            rtbKeyPlayfair.Size = new Size(323, 24);
            rtbKeyPlayfair.TabIndex = 18;
            rtbKeyPlayfair.Text = "Hello";
            rtbKeyPlayfair.ContentsResized += rtbKey_ContentsResized;
            rtbKeyPlayfair.KeyPress += rtbKeyPlayfair_KeyPress;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(27, 10);
            label11.Name = "label11";
            label11.Size = new Size(75, 19);
            label11.TabIndex = 17;
            label11.Text = "Cipher Key";
            // 
            // tabRSA
            // 
            tabRSA.Controls.Add(panel_manual);
            tabRSA.Controls.Add(resultPanel);
            tabRSA.Controls.Add(button_decrypt);
            tabRSA.Controls.Add(button_encrypt);
            tabRSA.Controls.Add(cipher_textbox);
            tabRSA.Controls.Add(label3);
            tabRSA.Controls.Add(panel_auto);
            tabRSA.Controls.Add(plain_textbox);
            tabRSA.Controls.Add(label21);
            tabRSA.Controls.Add(checkBox_auto);
            tabRSA.Location = new Point(4, 26);
            tabRSA.Margin = new Padding(3, 2, 3, 2);
            tabRSA.Name = "tabRSA";
            tabRSA.Padding = new Padding(3, 2, 3, 2);
            tabRSA.Size = new Size(791, 565);
            tabRSA.TabIndex = 1;
            tabRSA.Text = "RSA";
            tabRSA.UseVisualStyleBackColor = true;
            tabRSA.Click += tabPage2_Click;
            // 
            // panel_manual
            // 
            panel_manual.BackColor = Color.White;
            panel_manual.Controls.Add(textBox_D);
            panel_manual.Controls.Add(label16);
            panel_manual.Controls.Add(textBox_phiN);
            panel_manual.Controls.Add(label17);
            panel_manual.Controls.Add(textBox_E);
            panel_manual.Controls.Add(label15);
            panel_manual.Controls.Add(textBox_N);
            panel_manual.Controls.Add(label2);
            panel_manual.Controls.Add(textBox_Q);
            panel_manual.Controls.Add(label4);
            panel_manual.Controls.Add(textBox_P);
            panel_manual.Controls.Add(label5);
            panel_manual.Controls.Add(label6);
            panel_manual.Location = new Point(18, 209);
            panel_manual.Margin = new Padding(3, 2, 3, 2);
            panel_manual.Name = "panel_manual";
            panel_manual.Size = new Size(718, 264);
            panel_manual.TabIndex = 18;
            // 
            // textBox_D
            // 
            textBox_D.BorderStyle = BorderStyle.FixedSingle;
            textBox_D.Location = new Point(372, 206);
            textBox_D.Margin = new Padding(3, 2, 3, 2);
            textBox_D.Name = "textBox_D";
            textBox_D.Size = new Size(213, 25);
            textBox_D.TabIndex = 34;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(372, 177);
            label16.Name = "label16";
            label16.Size = new Size(91, 19);
            label16.TabIndex = 33;
            label16.Text = "Private Key D";
            // 
            // textBox_phiN
            // 
            textBox_phiN.BorderStyle = BorderStyle.FixedSingle;
            textBox_phiN.Location = new Point(372, 143);
            textBox_phiN.Margin = new Padding(3, 2, 3, 2);
            textBox_phiN.Name = "textBox_phiN";
            textBox_phiN.ReadOnly = true;
            textBox_phiN.Size = new Size(216, 25);
            textBox_phiN.TabIndex = 32;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(372, 114);
            label17.Name = "label17";
            label17.Size = new Size(126, 19);
            label17.TabIndex = 31;
            label17.Text = "Euler's Totient φ(N)";
            // 
            // textBox_E
            // 
            textBox_E.BorderStyle = BorderStyle.FixedSingle;
            textBox_E.Location = new Point(19, 143);
            textBox_E.Margin = new Padding(3, 2, 3, 2);
            textBox_E.Name = "textBox_E";
            textBox_E.Size = new Size(216, 25);
            textBox_E.TabIndex = 28;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(19, 114);
            label15.Name = "label15";
            label15.Size = new Size(16, 19);
            label15.TabIndex = 27;
            label15.Text = "E";
            // 
            // textBox_N
            // 
            textBox_N.BorderStyle = BorderStyle.FixedSingle;
            textBox_N.Location = new Point(19, 206);
            textBox_N.Margin = new Padding(3, 2, 3, 2);
            textBox_N.Name = "textBox_N";
            textBox_N.ReadOnly = true;
            textBox_N.Size = new Size(216, 25);
            textBox_N.TabIndex = 26;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(19, 177);
            label2.Name = "label2";
            label2.Size = new Size(19, 19);
            label2.TabIndex = 25;
            label2.Text = "N";
            // 
            // textBox_Q
            // 
            textBox_Q.BorderStyle = BorderStyle.FixedSingle;
            textBox_Q.Location = new Point(372, 74);
            textBox_Q.Margin = new Padding(3, 2, 3, 2);
            textBox_Q.Name = "textBox_Q";
            textBox_Q.Size = new Size(216, 25);
            textBox_Q.TabIndex = 24;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(372, 46);
            label4.Name = "label4";
            label4.Size = new Size(79, 19);
            label4.TabIndex = 23;
            label4.Text = "Prime 2 (Q)";
            // 
            // textBox_P
            // 
            textBox_P.BorderStyle = BorderStyle.FixedSingle;
            textBox_P.Location = new Point(19, 74);
            textBox_P.Margin = new Padding(3, 2, 3, 2);
            textBox_P.Name = "textBox_P";
            textBox_P.Size = new Size(216, 25);
            textBox_P.TabIndex = 22;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(19, 44);
            label5.Name = "label5";
            label5.Size = new Size(76, 19);
            label5.TabIndex = 18;
            label5.Text = "Prime 1 (P)";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(15, 8);
            label6.Name = "label6";
            label6.Size = new Size(117, 19);
            label6.TabIndex = 8;
            label6.Text = "Key Management";
            // 
            // resultPanel
            // 
            resultPanel.BackColor = Color.WhiteSmoke;
            resultPanel.Controls.Add(label_message);
            resultPanel.Location = new Point(18, 487);
            resultPanel.Margin = new Padding(3, 2, 3, 2);
            resultPanel.Name = "resultPanel";
            resultPanel.Size = new Size(718, 32);
            resultPanel.TabIndex = 29;
            // 
            // label_message
            // 
            label_message.AutoSize = true;
            label_message.Location = new Point(4, 5);
            label_message.Name = "label_message";
            label_message.Size = new Size(171, 19);
            label_message.TabIndex = 0;
            label_message.Text = "Đã chọn tự động tạo khoá";
            // 
            // button_decrypt
            // 
            button_decrypt.Location = new Point(106, 523);
            button_decrypt.Margin = new Padding(3, 2, 3, 2);
            button_decrypt.Name = "button_decrypt";
            button_decrypt.Size = new Size(82, 35);
            button_decrypt.TabIndex = 28;
            button_decrypt.Text = "Decrypt";
            button_decrypt.UseVisualStyleBackColor = true;
            // 
            // button_encrypt
            // 
            button_encrypt.Location = new Point(18, 523);
            button_encrypt.Margin = new Padding(3, 2, 3, 2);
            button_encrypt.Name = "button_encrypt";
            button_encrypt.Size = new Size(82, 35);
            button_encrypt.TabIndex = 27;
            button_encrypt.Text = "Encrypt";
            button_encrypt.UseVisualStyleBackColor = true;
            // 
            // cipher_textbox
            // 
            cipher_textbox.BorderStyle = BorderStyle.None;
            cipher_textbox.Location = new Point(412, 32);
            cipher_textbox.Margin = new Padding(3, 2, 3, 2);
            cipher_textbox.Name = "cipher_textbox";
            cipher_textbox.Size = new Size(347, 173);
            cipher_textbox.TabIndex = 26;
            cipher_textbox.Text = "";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(412, 4);
            label3.Name = "label3";
            label3.Size = new Size(77, 19);
            label3.TabIndex = 25;
            label3.Text = "Cipher Text";
            // 
            // panel_auto
            // 
            panel_auto.BackColor = Color.White;
            panel_auto.Controls.Add(radioButton3);
            panel_auto.Controls.Add(radioButton4);
            panel_auto.Controls.Add(radioButton2);
            panel_auto.Controls.Add(radioButton1);
            panel_auto.Controls.Add(privatekeyTextbox);
            panel_auto.Controls.Add(label18);
            panel_auto.Controls.Add(publickeyTextbox);
            panel_auto.Controls.Add(label19);
            panel_auto.Controls.Add(label20);
            panel_auto.Location = new Point(18, 209);
            panel_auto.Margin = new Padding(3, 2, 3, 2);
            panel_auto.Name = "panel_auto";
            panel_auto.Size = new Size(718, 264);
            panel_auto.TabIndex = 24;
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Location = new Point(168, 229);
            radioButton3.Margin = new Padding(3, 2, 3, 2);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(79, 23);
            radioButton3.TabIndex = 20;
            radioButton3.TabStop = true;
            radioButton3.Text = "2048 bit";
            radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            radioButton4.AutoSize = true;
            radioButton4.Location = new Point(254, 229);
            radioButton4.Margin = new Padding(3, 2, 3, 2);
            radioButton4.Name = "radioButton4";
            radioButton4.Size = new Size(79, 23);
            radioButton4.TabIndex = 19;
            radioButton4.TabStop = true;
            radioButton4.Text = "4096 bit";
            radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(89, 229);
            radioButton2.Margin = new Padding(3, 2, 3, 2);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(79, 23);
            radioButton2.TabIndex = 18;
            radioButton2.TabStop = true;
            radioButton2.Text = "1024 bit";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(17, 229);
            radioButton1.Margin = new Padding(3, 2, 3, 2);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(71, 23);
            radioButton1.TabIndex = 17;
            radioButton1.Text = "512 bit";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // privatekeyTextbox
            // 
            privatekeyTextbox.BorderStyle = BorderStyle.None;
            privatekeyTextbox.Location = new Point(372, 44);
            privatekeyTextbox.Margin = new Padding(3, 2, 3, 2);
            privatekeyTextbox.Name = "privatekeyTextbox";
            privatekeyTextbox.ReadOnly = true;
            privatekeyTextbox.Size = new Size(322, 181);
            privatekeyTextbox.TabIndex = 16;
            privatekeyTextbox.Text = "";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(372, 27);
            label18.Name = "label18";
            label18.Size = new Size(77, 19);
            label18.TabIndex = 15;
            label18.Text = "Private Key";
            // 
            // publickeyTextbox
            // 
            publickeyTextbox.AcceptsTab = true;
            publickeyTextbox.BorderStyle = BorderStyle.None;
            publickeyTextbox.Location = new Point(24, 44);
            publickeyTextbox.Margin = new Padding(3, 2, 3, 2);
            publickeyTextbox.Name = "publickeyTextbox";
            publickeyTextbox.ReadOnly = true;
            publickeyTextbox.Size = new Size(322, 181);
            publickeyTextbox.TabIndex = 14;
            publickeyTextbox.Text = "";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(24, 27);
            label19.Name = "label19";
            label19.Size = new Size(71, 19);
            label19.TabIndex = 9;
            label19.Text = "Public Key";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(15, 0);
            label20.Name = "label20";
            label20.Size = new Size(117, 19);
            label20.TabIndex = 8;
            label20.Text = "Key Management";
            // 
            // plain_textbox
            // 
            plain_textbox.BorderStyle = BorderStyle.None;
            plain_textbox.Location = new Point(18, 32);
            plain_textbox.Margin = new Padding(3, 2, 3, 2);
            plain_textbox.Name = "plain_textbox";
            plain_textbox.Size = new Size(347, 173);
            plain_textbox.TabIndex = 23;
            plain_textbox.Text = "";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(18, 6);
            label21.Name = "label21";
            label21.Size = new Size(71, 19);
            label21.TabIndex = 22;
            label21.Text = "Plaint Text";
            // 
            // checkBox_auto
            // 
            checkBox_auto.AutoSize = true;
            checkBox_auto.Location = new Point(648, 2);
            checkBox_auto.Margin = new Padding(3, 2, 3, 2);
            checkBox_auto.Name = "checkBox_auto";
            checkBox_auto.Size = new Size(118, 23);
            checkBox_auto.TabIndex = 30;
            checkBox_auto.Text = "Auto Generate";
            checkBox_auto.UseVisualStyleBackColor = true;
            // 
            // Cryptool
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gainsboro;
            ClientSize = new Size(799, 636);
            Controls.Add(tctrlMain);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 2, 3, 2);
            Name = "Cryptool";
            Text = "PlayRSA Tool";
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
            panel_manual.ResumeLayout(false);
            panel_manual.PerformLayout();
            resultPanel.ResumeLayout(false);
            resultPanel.PerformLayout();
            panel_auto.ResumeLayout(false);
            panel_auto.PerformLayout();
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
        private Panel resultPanel;
        private Label label_message;
        private Button button_decrypt;
        private Button button_encrypt;
        private RichTextBox cipher_textbox;
        private Label label3;
        private Panel panel_auto;
        private Panel panel_manual;
        private TextBox textBox_D;
        private Label label16;
        private TextBox textBox_phiN;
        private Label label17;
        private TextBox textBox_E;
        private Label label15;
        private TextBox textBox_N;
        private Label label2;
        private TextBox textBox_Q;
        private Label label4;
        private TextBox textBox_P;
        private Label label5;
        private Label label6;
        private RadioButton radioButton3;
        private RadioButton radioButton4;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private RichTextBox privatekeyTextbox;
        private Label label18;
        private RichTextBox publickeyTextbox;
        private Label label19;
        private Label label20;
        private RichTextBox plain_textbox;
        private Label label21;
        private CheckBox checkBox_auto;
    }
}
