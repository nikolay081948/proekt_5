namespace Forms
{
    partial class AddProduct
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
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            richTextBox1 = new RichTextBox();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(43, 63);
            label1.Name = "label1";
            label1.Size = new Size(72, 20);
            label1.TabIndex = 0;
            label1.Text = "Магазин:";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(192, 63);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 28);
            comboBox1.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(43, 119);
            label2.Name = "label2";
            label2.Size = new Size(130, 20);
            label2.TabIndex = 2;
            label2.Text = "Име на продукта:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(43, 171);
            label3.Name = "label3";
            label3.Size = new Size(93, 20);
            label3.TabIndex = 2;
            label3.Text = "Количество:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(43, 219);
            label4.Name = "label4";
            label4.Size = new Size(48, 20);
            label4.TabIndex = 2;
            label4.Text = "Цена:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(43, 274);
            label5.Name = "label5";
            label5.Size = new Size(82, 20);
            label5.TabIndex = 2;
            label5.Text = "Описание:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(192, 116);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(151, 27);
            textBox1.TabIndex = 3;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(192, 164);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(151, 27);
            textBox2.TabIndex = 3;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(192, 212);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(151, 27);
            textBox3.TabIndex = 3;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(43, 307);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(300, 120);
            richTextBox1.TabIndex = 4;
            richTextBox1.Text = "";
            // 
            // button1
            // 
            button1.Location = new Point(632, 12);
            button1.Name = "button1";
            button1.Size = new Size(156, 71);
            button1.TabIndex = 5;
            button1.Text = "Добави";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(680, 391);
            button2.Name = "button2";
            button2.Size = new Size(108, 36);
            button2.TabIndex = 5;
            button2.Text = "Затвори";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // AddProduct
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(richTextBox1);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(comboBox1);
            Controls.Add(label1);
            Name = "AddProduct";
            Text = "AddProduct";
            Load += AddProduct_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox comboBox1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private RichTextBox richTextBox1;
        private Button button1;
        private Button button2;
    }
}