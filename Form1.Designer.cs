using System.Runtime.InteropServices;

namespace HID_LightingAudio
{
    public partial class Form1 : Form
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
            button1 = new Button();
            label1 = new Label();
            label2 = new Label();
            button2 = new Button();
            label3 = new Label();
            label4 = new Label();
            checkBox1 = new CheckBox();
            checkBox2 = new CheckBox();
            label5 = new Label();
            labelStatus = new Label();
            FrontnumericUpDown1 = new NumericUpDown();
            RearnumericUpDown1 = new NumericUpDown();
            label6 = new Label();
            label7 = new Label();
            ((System.ComponentModel.ISupportInitialize)FrontnumericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)RearnumericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(88, 87);
            button1.Name = "button1";
            button1.Size = new Size(118, 45);
            button1.TabIndex = 0;
            button1.Text = "Color";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(88, 54);
            label1.Name = "label1";
            label1.Size = new Size(56, 25);
            label1.TabIndex = 1;
            label1.Text = "Front";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F);
            label2.Location = new Point(267, 54);
            label2.Name = "label2";
            label2.Size = new Size(49, 25);
            label2.TabIndex = 2;
            label2.Text = "Rear";
            // 
            // button2
            // 
            button2.Location = new Point(267, 87);
            button2.Name = "button2";
            button2.Size = new Size(118, 45);
            button2.TabIndex = 3;
            button2.Text = "Color";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 16F);
            label3.Location = new Point(60, 24);
            label3.Name = "label3";
            label3.Size = new Size(132, 30);
            label3.TabIndex = 4;
            label3.Text = "LED Control:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 16F);
            label4.Location = new Point(60, 251);
            label4.Name = "label4";
            label4.Size = new Size(75, 30);
            label4.TabIndex = 5;
            label4.Text = "Audio:";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Font = new Font("Segoe UI", 14F);
            checkBox1.Location = new Point(88, 284);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(99, 29);
            checkBox1.TabIndex = 6;
            checkBox1.Text = "Enabled";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Font = new Font("Segoe UI", 14F);
            checkBox2.Location = new Point(221, 284);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(75, 29);
            checkBox2.TabIndex = 7;
            checkBox2.Text = "Mute";
            checkBox2.UseVisualStyleBackColor = true;
            checkBox2.CheckedChanged += checkBox2_CheckedChanged_1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 16F);
            label5.Location = new Point(60, 334);
            label5.Name = "label5";
            label5.Size = new Size(75, 30);
            label5.TabIndex = 8;
            label5.Text = "Status:";
            // 
            // labelStatus
            // 
            labelStatus.AutoSize = true;
            labelStatus.Enabled = false;
            labelStatus.Location = new Point(141, 346);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(29, 15);
            labelStatus.TabIndex = 12;
            labelStatus.Text = "N/A";
            // 
            // FrontnumericUpDown1
            // 
            FrontnumericUpDown1.Font = new Font("Segoe UI", 14F);
            FrontnumericUpDown1.Location = new Point(88, 196);
            FrontnumericUpDown1.Maximum = new decimal(new int[] { 15, 0, 0, 0 });
            FrontnumericUpDown1.Name = "FrontnumericUpDown1";
            FrontnumericUpDown1.Size = new Size(118, 32);
            FrontnumericUpDown1.TabIndex = 13;
            FrontnumericUpDown1.Tag = "Front Brightness";
            FrontnumericUpDown1.ValueChanged += FrontnumericUpDown1_ValueChanged;
            // 
            // RearnumericUpDown1
            // 
            RearnumericUpDown1.Font = new Font("Segoe UI", 14F);
            RearnumericUpDown1.Location = new Point(267, 196);
            RearnumericUpDown1.Maximum = new decimal(new int[] { 15, 0, 0, 0 });
            RearnumericUpDown1.Name = "RearnumericUpDown1";
            RearnumericUpDown1.Size = new Size(118, 32);
            RearnumericUpDown1.TabIndex = 14;
            RearnumericUpDown1.Tag = "Front Brightness";
            RearnumericUpDown1.ValueChanged += RearnumericUpDown1_ValueChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(88, 163);
            label6.Name = "label6";
            label6.Size = new Size(83, 21);
            label6.TabIndex = 15;
            label6.Text = "Brightness";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(267, 163);
            label7.Name = "label7";
            label7.Size = new Size(83, 21);
            label7.TabIndex = 16;
            label7.Text = "Brightness";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(624, 405);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(RearnumericUpDown1);
            Controls.Add(FrontnumericUpDown1);
            Controls.Add(labelStatus);
            Controls.Add(label5);
            Controls.Add(checkBox2);
            Controls.Add(checkBox1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(button2);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)FrontnumericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)RearnumericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label1;
        private Label label2;
        private Button button2;
        private Label label3;
        private Label label4;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private Label label5;
        private Label labelStatus;
        private NumericUpDown FrontnumericUpDown1;
        private NumericUpDown RearnumericUpDown1;
        private Label label6;
        private Label label7;
    }

}
