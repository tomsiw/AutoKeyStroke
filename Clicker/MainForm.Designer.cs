namespace Clicker
{
    partial class MainForm
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
            this.keyStrokeListBox = new System.Windows.Forms.ListBox();
            this.addButton = new System.Windows.Forms.Button();
            this.keyTextBox = new System.Windows.Forms.TextBox();
            this.startButton = new System.Windows.Forms.Button();
            this.delayTextBox = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.countDownLabel = new System.Windows.Forms.Label();
            this.repeatTextBox = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.loadButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // keyStrokeListBox
            // 
            this.keyStrokeListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.keyStrokeListBox.FormattingEnabled = true;
            this.keyStrokeListBox.IntegralHeight = false;
            this.keyStrokeListBox.Location = new System.Drawing.Point(12, 12);
            this.keyStrokeListBox.Name = "keyStrokeListBox";
            this.keyStrokeListBox.Size = new System.Drawing.Size(243, 207);
            this.keyStrokeListBox.TabIndex = 0;
            this.keyStrokeListBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyStrokeListBox_KeyDown);
            // 
            // addButton
            // 
            this.addButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addButton.Location = new System.Drawing.Point(267, 43);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(105, 23);
            this.addButton.TabIndex = 1;
            this.addButton.Text = "Add Key Stroke";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // keyTextBox
            // 
            this.keyTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.keyTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.keyTextBox.ForeColor = System.Drawing.Color.DimGray;
            this.keyTextBox.Location = new System.Drawing.Point(267, 12);
            this.keyTextBox.Name = "keyTextBox";
            this.keyTextBox.ReadOnly = true;
            this.keyTextBox.Size = new System.Drawing.Size(105, 20);
            this.keyTextBox.TabIndex = 2;
            this.keyTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.keyTextBox_KeyPress);
            this.keyTextBox.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.keyTextBox_PreviewKeyDown);
            // 
            // startButton
            // 
            this.startButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.startButton.Location = new System.Drawing.Point(267, 196);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(105, 23);
            this.startButton.TabIndex = 3;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // delayTextBox
            // 
            this.delayTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.delayTextBox.Location = new System.Drawing.Point(316, 170);
            this.delayTextBox.Mask = "00000";
            this.delayTextBox.Name = "delayTextBox";
            this.delayTextBox.RejectInputOnFirstFailure = true;
            this.delayTextBox.ResetOnPrompt = false;
            this.delayTextBox.ResetOnSpace = false;
            this.delayTextBox.Size = new System.Drawing.Size(38, 20);
            this.delayTextBox.TabIndex = 4;
            this.delayTextBox.Text = "5";
            this.delayTextBox.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.delayTextBox.ValidatingType = typeof(int);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(358, 173);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "[s]";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(264, 173);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Delay:";
            // 
            // countDownLabel
            // 
            this.countDownLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.countDownLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.countDownLabel.ForeColor = System.Drawing.Color.Green;
            this.countDownLabel.Location = new System.Drawing.Point(264, 69);
            this.countDownLabel.Name = "countDownLabel";
            this.countDownLabel.Size = new System.Drawing.Size(114, 39);
            this.countDownLabel.TabIndex = 6;
            this.countDownLabel.Text = "5";
            this.countDownLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.countDownLabel.Visible = false;
            // 
            // repeatTextBox
            // 
            this.repeatTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.repeatTextBox.Culture = new System.Globalization.CultureInfo("");
            this.repeatTextBox.Location = new System.Drawing.Point(316, 148);
            this.repeatTextBox.Mask = "00000";
            this.repeatTextBox.Name = "repeatTextBox";
            this.repeatTextBox.RejectInputOnFirstFailure = true;
            this.repeatTextBox.ResetOnPrompt = false;
            this.repeatTextBox.ResetOnSpace = false;
            this.repeatTextBox.Size = new System.Drawing.Size(56, 20);
            this.repeatTextBox.TabIndex = 4;
            this.repeatTextBox.Text = "1";
            this.repeatTextBox.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.repeatTextBox.ValidatingType = typeof(int);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(264, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Cycles:";
            // 
            // loadButton
            // 
            this.loadButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.loadButton.Location = new System.Drawing.Point(267, 117);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(50, 23);
            this.loadButton.TabIndex = 7;
            this.loadButton.Text = "Load";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.Location = new System.Drawing.Point(323, 117);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(49, 23);
            this.saveButton.TabIndex = 7;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 236);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.countDownLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.repeatTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.delayTextBox);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.keyTextBox);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.keyStrokeListBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 275);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Auto KeyStroke";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox keyStrokeListBox;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.TextBox keyTextBox;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.MaskedTextBox delayTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label countDownLabel;
        private System.Windows.Forms.MaskedTextBox repeatTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Button saveButton;
    }
}

