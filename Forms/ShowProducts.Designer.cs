namespace Forms
{
    partial class ShowProducts
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
            dataGridView1 = new DataGridView();
            button1 = new Button();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(52, 35);
            label1.Name = "label1";
            label1.Size = new Size(127, 20);
            label1.TabIndex = 0;
            label1.Text = "Избери магазин:";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(215, 35);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 28);
            comboBox1.TabIndex = 1;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(52, 153);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(489, 285);
            dataGridView1.TabIndex = 3;
            // 
            // button1
            // 
            button1.Location = new Point(52, 95);
            button1.Name = "button1";
            button1.Size = new Size(144, 43);
            button1.TabIndex = 4;
            button1.Text = "Покажи продукти";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(679, 402);
            button2.Name = "button2";
            button2.Size = new Size(109, 36);
            button2.TabIndex = 4;
            button2.Text = "Затвори";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // ShowProducts
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Controls.Add(comboBox1);
            Controls.Add(label1);
            Name = "ShowProducts";
            Text = "ShowProducts";
            Load += ShowProducts_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox comboBox1;
        private DataGridView dataGridView1;
        private Button button1;
        private Button button2;
    }
}