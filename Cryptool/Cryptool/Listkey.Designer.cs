namespace Cryptool
{
    partial class Listkey
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            listView1 = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            button_delete = new Button();
            button_sign = new Button();
            button_verify = new Button();
            SuspendLayout();
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2 });
            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            listView1.Location = new Point(2, 1);
            listView1.Name = "listView1";
            listView1.Size = new Size(796, 356);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Public key";
            columnHeader1.Width = 400;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Private Key";
            columnHeader2.Width = 400;
            // 
            // button_delete
            // 
            button_delete.Location = new Point(80, 397);
            button_delete.Name = "button_delete";
            button_delete.Size = new Size(94, 29);
            button_delete.TabIndex = 1;
            button_delete.Text = "Delete";
            button_delete.UseVisualStyleBackColor = true;
            button_delete.Click += button_delete_Click;
            // 
            // button_sign
            // 
            button_sign.Location = new Point(282, 397);
            button_sign.Name = "button_sign";
            button_sign.Size = new Size(94, 29);
            button_sign.TabIndex = 1;
            button_sign.Text = "Sign";
            button_sign.UseVisualStyleBackColor = true;
            button_sign.Click += button_sign_Click;
            // 
            // button_verify
            // 
            button_verify.Location = new Point(520, 397);
            button_verify.Name = "button_verify";
            button_verify.Size = new Size(94, 29);
            button_verify.TabIndex = 1;
            button_verify.Text = "Verify";
            button_verify.UseVisualStyleBackColor = true;
            button_verify.Click += button_verify_Click;
            // 
            // Listkey
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button_verify);
            Controls.Add(button_sign);
            Controls.Add(button_delete);
            Controls.Add(listView1);
            Name = "Listkey";
            Text = "Listkey";
            ResumeLayout(false);
        }

        #endregion

        private ListView listView1;
        private Button button_delete;
        private Button button_sign;
        private Button button_verify;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
    }
}