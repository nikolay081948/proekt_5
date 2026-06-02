namespace Forms
{
    partial class Leave_review
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
            comboBox1 = new ComboBox();
            label1 = new Label();
            comboBox2 = new ComboBox();
            label2 = new Label();
            label3 = new Label();
            richTextBox1 = new RichTextBox();
            button1 = new Button();
            label4 = new Label();
            comboBox3 = new ComboBox();
            button2 = new Button();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(54, 81);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(166, 28);
            comboBox1.TabIndex = 3;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(54, 48);
            label1.Name = "label1";
            label1.Size = new Size(83, 20);
            label1.TabIndex = 2;
            label1.Text = "Магазини:";
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(519, 81);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(166, 28);
            comboBox2.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(519, 48);
            label2.Name = "label2";
            label2.Size = new Size(63, 20);
            label2.TabIndex = 4;
            label2.Text = "Звезди:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(54, 144);
            label3.Name = "label3";
            label3.Size = new Size(52, 20);
            label3.TabIndex = 6;
            label3.Text = "Ревю:";
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(54, 186);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(417, 235);
            richTextBox1.TabIndex = 7;
            richTextBox1.Text = "";
            // 
            // button1
            // 
            button1.Location = new Point(781, 409);
            button1.Name = "button1";
            button1.Size = new Size(106, 29);
            button1.TabIndex = 8;
            button1.Text = "Затвори";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(271, 48);
            label4.Name = "label4";
            label4.Size = new Size(83, 20);
            label4.TabIndex = 2;
            label4.Text = "Продукти:";
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(271, 81);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(166, 28);
            comboBox3.TabIndex = 3;
            // 
            // button2
            // 
            button2.Location = new Point(742, 14);
            button2.Name = "button2";
            button2.Size = new Size(144, 54);
            button2.TabIndex = 9;
            button2.Text = "Качи ревю";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Leave_review
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.bg_06_arctic_aurora;
            ClientSize = new Size(900, 450);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(richTextBox1);
            Controls.Add(label3);
            Controls.Add(comboBox2);
            Controls.Add(label2);
            Controls.Add(comboBox3);
            Controls.Add(label4);
            Controls.Add(comboBox1);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Name = "Leave_review";
            Text = "Leave_review";
            Load += Leave_review_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBox1;
        private Label label1;
        private ComboBox comboBox2;
        private Label label2;
        private Label label3;
        private RichTextBox richTextBox1;
        private Button button1;
        private Label label4;
        private ComboBox comboBox3;
        private Button button2;
    }
}