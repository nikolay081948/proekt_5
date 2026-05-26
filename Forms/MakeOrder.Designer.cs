namespace Forms
{
    partial class MakeOrder
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
            comboBox1 = new ComboBox();
            label2 = new Label();
            textBox1 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            comboBox2 = new ComboBox();
            label3 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(227, 26);
            label1.Name = "label1";
            label1.Size = new Size(78, 20);
            label1.TabIndex = 0;
            label1.Text = "Продукти:";
            label1.Click += label1_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(227, 60);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(148, 28);
            comboBox1.TabIndex = 1;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(420, 26);
            label2.Name = "label2";
            label2.Size = new Size(93, 20);
            label2.TabIndex = 0;
            label2.Text = "Количество:";
            label2.Click += label1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(420, 60);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(148, 27);
            textBox1.TabIndex = 2;
            // 
            // button1
            // 
            button1.Location = new Point(30, 362);
            button1.Name = "button1";
            button1.Size = new Size(166, 76);
            button1.TabIndex = 3;
            button1.Text = "Добави в количка";
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
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(30, 59);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(148, 28);
            comboBox2.TabIndex = 11;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(30, 26);
            label3.Name = "label3";
            label3.Size = new Size(81, 20);
            label3.TabIndex = 10;
            label3.Text = "Магазини:";
            // 
            // MakeOrder
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(comboBox2);
            Controls.Add(label3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(comboBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "MakeOrder";
            Text = "MakeOrder";
            Load += MakeOrder_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox comboBox1;
        private Label label2;
        private TextBox textBox1;
        private Button button1;
        private Button button2;
        private ComboBox comboBox2;
        private Label label3;
    }
}