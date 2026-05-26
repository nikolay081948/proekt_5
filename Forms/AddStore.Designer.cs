namespace Forms
{
    partial class AddStore
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
            textBox1 = new TextBox();
            richTextBox1 = new RichTextBox();
            label2 = new Label();
            textBox2 = new TextBox();
            label3 = new Label();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(100, 75);
            label1.Name = "label1";
            label1.Size = new Size(133, 20);
            label1.TabIndex = 0;
            label1.Text = "Име на магазина:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(275, 75);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(156, 27);
            textBox1.TabIndex = 1;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(100, 219);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(331, 181);
            richTextBox1.TabIndex = 2;
            richTextBox1.Text = "";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(100, 125);
            label2.Name = "label2";
            label2.Size = new Size(153, 20);
            label2.TabIndex = 0;
            label2.Text = "Сфера на продажби:";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(275, 125);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(156, 27);
            textBox2.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(100, 173);
            label3.Name = "label3";
            label3.Size = new Size(154, 20);
            label3.TabIndex = 0;
            label3.Text = "Мотиви за отваряне:";
            // 
            // button1
            // 
            button1.Location = new Point(643, 12);
            button1.Name = "button1";
            button1.Size = new Size(145, 66);
            button1.TabIndex = 3;
            button1.Text = "Добави";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(680, 402);
            button2.Name = "button2";
            button2.Size = new Size(108, 36);
            button2.TabIndex = 6;
            button2.Text = "Затвори";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // AddStore
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(richTextBox1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "AddStore";
            Text = "AddStore";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private RichTextBox richTextBox1;
        private Label label2;
        private TextBox textBox2;
        private Label label3;
        private Button button1;
        private Button button2;
    }
}