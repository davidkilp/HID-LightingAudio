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
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(88, 109);
            button1.Name = "button1";
            button1.Size = new Size(118, 45);
            button1.TabIndex = 0;
            button1.Text = "Cycle";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F);
            label1.Location = new Point(88, 65);
            label1.Name = "label1";
            label1.Size = new Size(106, 30);
            label1.TabIndex = 1;
            label1.Text = "Front LED";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 16F);
            label2.Location = new Point(267, 65);
            label2.Name = "label2";
            label2.Size = new Size(98, 30);
            label2.TabIndex = 2;
            label2.Text = "Rear LED";
            // 
            // button2
            // 
            button2.Location = new Point(267, 109);
            button2.Name = "button2";
            button2.Size = new Size(118, 45);
            button2.TabIndex = 3;
            button2.Text = "Cycle";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 16F);
            label3.Location = new Point(88, 22);
            label3.Name = "label3";
            label3.Size = new Size(63, 30);
            label3.TabIndex = 4;
            label3.Text = "LEDs:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 16F);
            label4.Location = new Point(88, 211);
            label4.Name = "label4";
            label4.Size = new Size(75, 30);
            label4.TabIndex = 5;
            label4.Text = "Audio:";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(88, 271);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(68, 19);
            checkBox1.TabIndex = 6;
            checkBox1.Text = "Enabled";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(210, 271);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(54, 19);
            checkBox2.TabIndex = 7;
            checkBox2.Text = "Mute";
            checkBox2.UseVisualStyleBackColor = true;
            checkBox2.CheckedChanged += checkBox2_CheckedChanged_1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 16F);
            label5.Location = new Point(88, 340);
            label5.Name = "label5";
            label5.Size = new Size(75, 30);
            label5.TabIndex = 8;
            label5.Text = "Status:";
            // 
            // label6
            // 
            labelStatus.AutoSize = true;
            labelStatus.Enabled = false;
            labelStatus.Location = new Point(191, 352);
            labelStatus.Name = "label6";
            labelStatus.Size = new Size(29, 15);
            labelStatus.TabIndex = 12;
            labelStatus.Text = "N/A";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(624, 405);
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
    }

}
