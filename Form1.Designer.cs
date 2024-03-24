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
            button2 = new Button();
            checkBox1 = new CheckBox();
            checkBox2 = new CheckBox();
            label5 = new Label();
            labelStatus = new Label();
            FrontnumericUpDown1 = new NumericUpDown();
            RearnumericUpDown1 = new NumericUpDown();
            label6 = new Label();
            label7 = new Label();
            FrontBlinkcheckbox = new CheckBox();
            FrontBlinkUpDown = new NumericUpDown();
            RearBlinkUpDown = new NumericUpDown();
            RearBlinkcheckbox = new CheckBox();
            LEDFrontgroupBox = new GroupBox();
            groupBox1 = new GroupBox();
            AudiogroupBox = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)FrontnumericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)RearnumericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)FrontBlinkUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)RearBlinkUpDown).BeginInit();
            LEDFrontgroupBox.SuspendLayout();
            groupBox1.SuspendLayout();
            AudiogroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(28, 35);
            button1.Name = "button1";
            button1.Size = new Size(118, 45);
            button1.TabIndex = 0;
            button1.Text = "Color";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(29, 35);
            button2.Name = "button2";
            button2.Size = new Size(118, 45);
            button2.TabIndex = 3;
            button2.Text = "Color";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Font = new Font("Segoe UI", 14F);
            checkBox1.Location = new Point(28, 24);
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
            checkBox2.Location = new Point(160, 24);
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
            label5.Location = new Point(37, 346);
            label5.Name = "label5";
            label5.Size = new Size(75, 30);
            label5.TabIndex = 8;
            label5.Text = "Status:";
            // 
            // labelStatus
            // 
            labelStatus.AutoSize = true;
            labelStatus.Enabled = false;
            labelStatus.Location = new Point(118, 358);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(29, 15);
            labelStatus.TabIndex = 12;
            labelStatus.Text = "N/A";
            // 
            // FrontnumericUpDown1
            // 
            FrontnumericUpDown1.Font = new Font("Segoe UI", 18F);
            FrontnumericUpDown1.Location = new Point(28, 115);
            FrontnumericUpDown1.Maximum = new decimal(new int[] { 15, 0, 0, 0 });
            FrontnumericUpDown1.Name = "FrontnumericUpDown1";
            FrontnumericUpDown1.Size = new Size(118, 39);
            FrontnumericUpDown1.TabIndex = 13;
            FrontnumericUpDown1.Tag = "Front Brightness";
            FrontnumericUpDown1.ValueChanged += FrontnumericUpDown1_ValueChanged;
            // 
            // RearnumericUpDown1
            // 
            RearnumericUpDown1.Font = new Font("Segoe UI", 18F);
            RearnumericUpDown1.Location = new Point(29, 112);
            RearnumericUpDown1.Maximum = new decimal(new int[] { 15, 0, 0, 0 });
            RearnumericUpDown1.Name = "RearnumericUpDown1";
            RearnumericUpDown1.Size = new Size(118, 39);
            RearnumericUpDown1.TabIndex = 14;
            RearnumericUpDown1.Tag = "Front Brightness";
            RearnumericUpDown1.ValueChanged += RearnumericUpDown1_ValueChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(17, 88);
            label6.Name = "label6";
            label6.Size = new Size(163, 21);
            label6.TabIndex = 15;
            label6.Text = "Brightness/Duty Cycle";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(6, 88);
            label7.Name = "label7";
            label7.Size = new Size(163, 21);
            label7.TabIndex = 16;
            label7.Text = "Brightness/Duty Cycle";
            // 
            // FrontBlinkcheckbox
            // 
            FrontBlinkcheckbox.AutoSize = true;
            FrontBlinkcheckbox.Font = new Font("Segoe UI", 14F);
            FrontBlinkcheckbox.Location = new Point(65, 183);
            FrontBlinkcheckbox.Name = "FrontBlinkcheckbox";
            FrontBlinkcheckbox.Size = new Size(99, 29);
            FrontBlinkcheckbox.TabIndex = 18;
            FrontBlinkcheckbox.Text = "Blinking";
            FrontBlinkcheckbox.UseVisualStyleBackColor = true;
            FrontBlinkcheckbox.CheckedChanged += FrontBlinkcheckbox_CheckedChanged;
            // 
            // FrontBlinkUpDown
            // 
            FrontBlinkUpDown.Font = new Font("Segoe UI", 16F);
            FrontBlinkUpDown.Location = new Point(28, 188);
            FrontBlinkUpDown.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            FrontBlinkUpDown.Name = "FrontBlinkUpDown";
            FrontBlinkUpDown.Size = new Size(118, 36);
            FrontBlinkUpDown.TabIndex = 19;
            FrontBlinkUpDown.Tag = "Front Brightness";
            FrontBlinkUpDown.ValueChanged += FrontBlinkUpDown_ValueChanged;
            // 
            // RearBlinkUpDown
            // 
            RearBlinkUpDown.Font = new Font("Segoe UI", 16F);
            RearBlinkUpDown.Location = new Point(29, 188);
            RearBlinkUpDown.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            RearBlinkUpDown.Name = "RearBlinkUpDown";
            RearBlinkUpDown.Size = new Size(118, 36);
            RearBlinkUpDown.TabIndex = 21;
            RearBlinkUpDown.Tag = "Front Brightness";
            RearBlinkUpDown.ValueChanged += RearBlinkUpDown_ValueChanged;
            // 
            // RearBlinkcheckbox
            // 
            RearBlinkcheckbox.AutoSize = true;
            RearBlinkcheckbox.Font = new Font("Segoe UI", 14F);
            RearBlinkcheckbox.Location = new Point(29, 157);
            RearBlinkcheckbox.Name = "RearBlinkcheckbox";
            RearBlinkcheckbox.Size = new Size(99, 29);
            RearBlinkcheckbox.TabIndex = 20;
            RearBlinkcheckbox.Text = "Blinking";
            RearBlinkcheckbox.UseVisualStyleBackColor = true;
            RearBlinkcheckbox.CheckedChanged += RearBlinkcheckbox_CheckedChanged;
            // 
            // LEDFrontgroupBox
            // 
            LEDFrontgroupBox.Controls.Add(label6);
            LEDFrontgroupBox.Controls.Add(FrontBlinkUpDown);
            LEDFrontgroupBox.Controls.Add(button1);
            LEDFrontgroupBox.Controls.Add(FrontnumericUpDown1);
            LEDFrontgroupBox.Font = new Font("Segoe UI", 16F);
            LEDFrontgroupBox.Location = new Point(37, 23);
            LEDFrontgroupBox.Name = "LEDFrontgroupBox";
            LEDFrontgroupBox.Size = new Size(200, 237);
            LEDFrontgroupBox.TabIndex = 22;
            LEDFrontgroupBox.TabStop = false;
            LEDFrontgroupBox.Text = "Front LED Strip";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(RearBlinkcheckbox);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(RearBlinkUpDown);
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(RearnumericUpDown1);
            groupBox1.Font = new Font("Segoe UI", 16F);
            groupBox1.Location = new Point(266, 23);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(183, 237);
            groupBox1.TabIndex = 23;
            groupBox1.TabStop = false;
            groupBox1.Text = "Rear LED Strip";
            // 
            // AudiogroupBox
            // 
            AudiogroupBox.Controls.Add(checkBox2);
            AudiogroupBox.Controls.Add(checkBox1);
            AudiogroupBox.Font = new Font("Segoe UI", 14F);
            AudiogroupBox.Location = new Point(37, 272);
            AudiogroupBox.Name = "AudiogroupBox";
            AudiogroupBox.Size = new Size(264, 59);
            AudiogroupBox.TabIndex = 24;
            AudiogroupBox.TabStop = false;
            AudiogroupBox.Text = "Audio";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(624, 405);
            Controls.Add(AudiogroupBox);
            Controls.Add(FrontBlinkcheckbox);
            Controls.Add(labelStatus);
            Controls.Add(label5);
            Controls.Add(LEDFrontgroupBox);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)FrontnumericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)RearnumericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)FrontBlinkUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)RearBlinkUpDown).EndInit();
            LEDFrontgroupBox.ResumeLayout(false);
            LEDFrontgroupBox.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            AudiogroupBox.ResumeLayout(false);
            AudiogroupBox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private Label label5;
        private Label labelStatus;
        private NumericUpDown FrontnumericUpDown1;
        private NumericUpDown RearnumericUpDown1;
        private Label label6;
        private Label label7;
        private CheckBox FrontBlinkcheckbox;
        private NumericUpDown FrontBlinkUpDown;
        private NumericUpDown RearBlinkUpDown;
        private CheckBox RearBlinkcheckbox;
        private GroupBox LEDFrontgroupBox;
        private GroupBox groupBox1;
        private GroupBox AudiogroupBox;
    }

}
