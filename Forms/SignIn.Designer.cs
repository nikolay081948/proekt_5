namespace Forms
{
    partial class SignIn
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            comboBox1 = new ComboBox();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(132, 79);
            label1.Name = "label1";
            label1.Size = new Size(78, 20);
            label1.TabIndex = 0;
            label1.Text = "Username:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(132, 176);
            label2.Name = "label2";
            label2.Size = new Size(73, 20);
            label2.TabIndex = 0;
            label2.Text = "Password:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(132, 127);
            label3.Name = "label3";
            label3.Size = new Size(49, 20);
            label3.TabIndex = 0;
            label3.Text = "Email:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(132, 238);
            label4.Name = "label4";
            label4.Size = new Size(42, 20);
            label4.TabIndex = 0;
            label4.Text = "Role:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(277, 79);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(151, 27);
            textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(277, 127);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(151, 27);
            textBox2.TabIndex = 1;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(277, 176);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(151, 27);
            textBox3.TabIndex = 1;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(277, 238);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 28);
            comboBox1.TabIndex = 2;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // button1
            // 
            button1.Location = new Point(626, 12);
            button1.Name = "button1";
            button1.Size = new Size(162, 77);
            button1.TabIndex = 3;
            button1.Text = "Register";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(694, 409);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 9;
            button2.Text = "Затвори";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // SignIn
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(comboBox1);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "SignIn";
            Text = "Sign In";
            Load += SignIn_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private ComboBox comboBox1;
        private Button button1;
        private Button button2;
    }
}