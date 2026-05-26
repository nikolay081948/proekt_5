namespace Forms
{
    partial class Seller
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
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(72, 190);
            button1.Name = "button1";
            button1.Size = new Size(132, 58);
            button1.TabIndex = 0;
            button1.Text = "Добави магазин";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(248, 190);
            button2.Name = "button2";
            button2.Size = new Size(132, 58);
            button2.TabIndex = 0;
            button2.Text = "Добави продукт";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(422, 190);
            button3.Name = "button3";
            button3.Size = new Size(132, 58);
            button3.TabIndex = 0;
            button3.Text = "Покажи магазини";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(595, 190);
            button4.Name = "button4";
            button4.Size = new Size(132, 58);
            button4.TabIndex = 0;
            button4.Text = "Покажи продукти";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(694, 409);
            button5.Name = "button5";
            button5.Size = new Size(94, 29);
            button5.TabIndex = 9;
            button5.Text = "Затвори";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // Seller
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Seller";
            Text = "Seller";
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
    }
}