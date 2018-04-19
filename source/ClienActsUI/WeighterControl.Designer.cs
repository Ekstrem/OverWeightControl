namespace OverWeightControl.Clients.ActsUI
{
    partial class WeighterControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.weigherNumberLabel = new System.Windows.Forms.Label();
            this.weigherNumberTextBox = new System.Windows.Forms.TextBox();
            this.verificationDateLabel = new System.Windows.Forms.Label();
            this.verificationDatePicker = new System.Windows.Forms.DateTimePicker();
            this.certificateNumberLabel = new System.Windows.Forms.Label();
            this.certificateNumberTextBox = new System.Windows.Forms.TextBox();
            this.violatioNatureLabel = new System.Windows.Forms.Label();
            this.violationKoapLabel = new System.Windows.Forms.Label();
            this.violatioNatureTextBox = new System.Windows.Forms.TextBox();
            this.violationKoapComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // weigherNumberLabel
            // 
            this.weigherNumberLabel.AutoSize = true;
            this.weigherNumberLabel.Location = new System.Drawing.Point(-3, 3);
            this.weigherNumberLabel.Name = "weigherNumberLabel";
            this.weigherNumberLabel.Size = new System.Drawing.Size(48, 13);
            this.weigherNumberLabel.TabIndex = 0;
            this.weigherNumberLabel.Text = "Весы №";
            // 
            // weigherNumberTextBox
            // 
            this.weigherNumberTextBox.Location = new System.Drawing.Point(151, 0);
            this.weigherNumberTextBox.Name = "weigherNumberTextBox";
            this.weigherNumberTextBox.Size = new System.Drawing.Size(139, 20);
            this.weigherNumberTextBox.TabIndex = 1;
            // 
            // verificationDateLabel
            // 
            this.verificationDateLabel.Location = new System.Drawing.Point(-3, 32);
            this.verificationDateLabel.Name = "verificationDateLabel";
            this.verificationDateLabel.Size = new System.Drawing.Size(148, 31);
            this.verificationDateLabel.TabIndex = 2;
            this.verificationDateLabel.Text = "Весовое оборудование проверено";
            // 
            // verificationDatePicker
            // 
            this.verificationDatePicker.Location = new System.Drawing.Point(151, 32);
            this.verificationDatePicker.Name = "verificationDatePicker";
            this.verificationDatePicker.Size = new System.Drawing.Size(139, 20);
            this.verificationDatePicker.TabIndex = 3;
            // 
            // certificateNumberLabel
            // 
            this.certificateNumberLabel.AutoSize = true;
            this.certificateNumberLabel.Location = new System.Drawing.Point(-3, 63);
            this.certificateNumberLabel.Name = "certificateNumberLabel";
            this.certificateNumberLabel.Size = new System.Drawing.Size(144, 13);
            this.certificateNumberLabel.TabIndex = 4;
            this.certificateNumberLabel.Text = "№ свидетельства (клейма)";
            // 
            // certificateNumberTextBox
            // 
            this.certificateNumberTextBox.Location = new System.Drawing.Point(151, 60);
            this.certificateNumberTextBox.Name = "certificateNumberTextBox";
            this.certificateNumberTextBox.Size = new System.Drawing.Size(139, 20);
            this.certificateNumberTextBox.TabIndex = 5;
            // 
            // violatioNatureLabel
            // 
            this.violatioNatureLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.violatioNatureLabel.Location = new System.Drawing.Point(298, 6);
            this.violatioNatureLabel.Name = "violatioNatureLabel";
            this.violatioNatureLabel.Size = new System.Drawing.Size(65, 36);
            this.violatioNatureLabel.TabIndex = 6;
            this.violatioNatureLabel.Text = "Характер нарушения";
            // 
            // violationKoapLabel
            // 
            this.violationKoapLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.violationKoapLabel.AutoSize = true;
            this.violationKoapLabel.Location = new System.Drawing.Point(298, 63);
            this.violationKoapLabel.Name = "violationKoapLabel";
            this.violationKoapLabel.Size = new System.Drawing.Size(56, 13);
            this.violationKoapLabel.TabIndex = 7;
            this.violationKoapLabel.Text = "КоАП РФ";
            // 
            // violatioNatureTextBox
            // 
            this.violatioNatureTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.violatioNatureTextBox.Location = new System.Drawing.Point(369, 3);
            this.violatioNatureTextBox.Multiline = true;
            this.violatioNatureTextBox.Name = "violatioNatureTextBox";
            this.violatioNatureTextBox.Size = new System.Drawing.Size(231, 49);
            this.violatioNatureTextBox.TabIndex = 8;
            // 
            // violationKoapComboBox
            // 
            this.violationKoapComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.violationKoapComboBox.FormattingEnabled = true;
            this.violationKoapComboBox.Location = new System.Drawing.Point(369, 60);
            this.violationKoapComboBox.Name = "violationKoapComboBox";
            this.violationKoapComboBox.Size = new System.Drawing.Size(231, 21);
            this.violationKoapComboBox.TabIndex = 9;
            // 
            // WeighterControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.violationKoapComboBox);
            this.Controls.Add(this.violatioNatureTextBox);
            this.Controls.Add(this.violationKoapLabel);
            this.Controls.Add(this.violatioNatureLabel);
            this.Controls.Add(this.certificateNumberTextBox);
            this.Controls.Add(this.certificateNumberLabel);
            this.Controls.Add(this.verificationDatePicker);
            this.Controls.Add(this.verificationDateLabel);
            this.Controls.Add(this.weigherNumberTextBox);
            this.Controls.Add(this.weigherNumberLabel);
            this.Name = "WeighterControl";
            this.Size = new System.Drawing.Size(600, 87);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label weigherNumberLabel;
        private System.Windows.Forms.TextBox weigherNumberTextBox;
        private System.Windows.Forms.Label verificationDateLabel;
        private System.Windows.Forms.DateTimePicker verificationDatePicker;
        private System.Windows.Forms.Label certificateNumberLabel;
        private System.Windows.Forms.TextBox certificateNumberTextBox;
        private System.Windows.Forms.Label violatioNatureLabel;
        private System.Windows.Forms.Label violationKoapLabel;
        private System.Windows.Forms.TextBox violatioNatureTextBox;
        private System.Windows.Forms.ComboBox violationKoapComboBox;
    }
}
