namespace OverWeightControl.Clients.ActsUI
{
    partial class DriverControl
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
            this.fnMnSnameLabel = new System.Windows.Forms.Label();
            this.fnMnSnameTextBox = new System.Windows.Forms.TextBox();
            this.driversLicenseNumberTextBox = new System.Windows.Forms.TextBox();
            this.driversLicenseNumberLabel = new System.Windows.Forms.Label();
            this.operatorNameTextBox = new System.Windows.Forms.TextBox();
            this.operatorNameLabel = new System.Windows.Forms.Label();
            this.gibddNameTextBox = new System.Windows.Forms.TextBox();
            this.gibddNameLabel = new System.Windows.Forms.Label();
            this.getingMarkLabel = new System.Windows.Forms.Label();
            this.getingMarkTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // fnMnSnameLabel
            // 
            this.fnMnSnameLabel.AutoSize = true;
            this.fnMnSnameLabel.Location = new System.Drawing.Point(-3, 3);
            this.fnMnSnameLabel.Name = "fnMnSnameLabel";
            this.fnMnSnameLabel.Size = new System.Drawing.Size(101, 13);
            this.fnMnSnameLabel.TabIndex = 0;
            this.fnMnSnameLabel.Text = "ФИО водителя ТС";
            // 
            // fnMnSnameTextBox
            // 
            this.fnMnSnameTextBox.Location = new System.Drawing.Point(126, 0);
            this.fnMnSnameTextBox.Name = "fnMnSnameTextBox";
            this.fnMnSnameTextBox.Size = new System.Drawing.Size(257, 20);
            this.fnMnSnameTextBox.TabIndex = 1;
            // 
            // driversLicenseNumberTextBox
            // 
            this.driversLicenseNumberTextBox.Location = new System.Drawing.Point(481, 0);
            this.driversLicenseNumberTextBox.Name = "driversLicenseNumberTextBox";
            this.driversLicenseNumberTextBox.Size = new System.Drawing.Size(119, 20);
            this.driversLicenseNumberTextBox.TabIndex = 3;
            // 
            // driversLicenseNumberLabel
            // 
            this.driversLicenseNumberLabel.AutoSize = true;
            this.driversLicenseNumberLabel.Location = new System.Drawing.Point(416, 3);
            this.driversLicenseNumberLabel.Name = "driversLicenseNumberLabel";
            this.driversLicenseNumberLabel.Size = new System.Drawing.Size(59, 13);
            this.driversLicenseNumberLabel.TabIndex = 2;
            this.driversLicenseNumberLabel.Text = "№ вод. уд.";
            // 
            // operatorNameTextBox
            // 
            this.operatorNameTextBox.Location = new System.Drawing.Point(126, 26);
            this.operatorNameTextBox.Name = "operatorNameTextBox";
            this.operatorNameTextBox.Size = new System.Drawing.Size(257, 20);
            this.operatorNameTextBox.TabIndex = 5;
            // 
            // operatorNameLabel
            // 
            this.operatorNameLabel.AutoSize = true;
            this.operatorNameLabel.Location = new System.Drawing.Point(-3, 29);
            this.operatorNameLabel.Name = "operatorNameLabel";
            this.operatorNameLabel.Size = new System.Drawing.Size(123, 13);
            this.operatorNameLabel.TabIndex = 4;
            this.operatorNameLabel.Text = "ФИО оператора ППВК";
            // 
            // gibddNameTextBox
            // 
            this.gibddNameTextBox.Location = new System.Drawing.Point(126, 52);
            this.gibddNameTextBox.Name = "gibddNameTextBox";
            this.gibddNameTextBox.Size = new System.Drawing.Size(257, 20);
            this.gibddNameTextBox.TabIndex = 7;
            // 
            // gibddNameLabel
            // 
            this.gibddNameLabel.AutoSize = true;
            this.gibddNameLabel.Location = new System.Drawing.Point(-3, 55);
            this.gibddNameLabel.Name = "gibddNameLabel";
            this.gibddNameLabel.Size = new System.Drawing.Size(105, 13);
            this.gibddNameLabel.TabIndex = 6;
            this.gibddNameLabel.Text = "ФИО сотр. ГИБДД";
            // 
            // getingMarkLabel
            // 
            this.getingMarkLabel.Location = new System.Drawing.Point(416, 23);
            this.getingMarkLabel.Name = "getingMarkLabel";
            this.getingMarkLabel.Size = new System.Drawing.Size(184, 29);
            this.getingMarkLabel.TabIndex = 8;
            this.getingMarkLabel.Text = "Отметка о получении копии акта водителем.";
            // 
            // getingMarkTextBox
            // 
            this.getingMarkTextBox.Location = new System.Drawing.Point(419, 52);
            this.getingMarkTextBox.Name = "getingMarkTextBox";
            this.getingMarkTextBox.Size = new System.Drawing.Size(181, 20);
            this.getingMarkTextBox.TabIndex = 9;
            // 
            // DriverControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.getingMarkTextBox);
            this.Controls.Add(this.getingMarkLabel);
            this.Controls.Add(this.gibddNameTextBox);
            this.Controls.Add(this.gibddNameLabel);
            this.Controls.Add(this.operatorNameTextBox);
            this.Controls.Add(this.operatorNameLabel);
            this.Controls.Add(this.driversLicenseNumberTextBox);
            this.Controls.Add(this.driversLicenseNumberLabel);
            this.Controls.Add(this.fnMnSnameTextBox);
            this.Controls.Add(this.fnMnSnameLabel);
            this.Name = "DriverControl";
            this.Size = new System.Drawing.Size(600, 80);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label fnMnSnameLabel;
        private System.Windows.Forms.TextBox fnMnSnameTextBox;
        private System.Windows.Forms.TextBox driversLicenseNumberTextBox;
        private System.Windows.Forms.Label driversLicenseNumberLabel;
        private System.Windows.Forms.TextBox operatorNameTextBox;
        private System.Windows.Forms.Label operatorNameLabel;
        private System.Windows.Forms.TextBox gibddNameTextBox;
        private System.Windows.Forms.Label gibddNameLabel;
        private System.Windows.Forms.Label getingMarkLabel;
        private System.Windows.Forms.TextBox getingMarkTextBox;
    }
}
