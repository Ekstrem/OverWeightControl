namespace OverWeightControl.Clients.ActsUI.PpvkMonitor
{
    partial class MonitorGridControl
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
            this.actGridView = new System.Windows.Forms.DataGridView();
            this.infoLabel = new System.Windows.Forms.Label();
            this.firstButton = new System.Windows.Forms.Button();
            this.previousButton = new System.Windows.Forms.Button();
            this.pageTextBox = new System.Windows.Forms.TextBox();
            this.nextButton = new System.Windows.Forms.Button();
            this.lastButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.actGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // actGridView
            // 
            this.actGridView.AllowUserToAddRows = false;
            this.actGridView.AllowUserToDeleteRows = false;
            this.actGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.actGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.actGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.actGridView.Location = new System.Drawing.Point(3, 3);
            this.actGridView.MultiSelect = false;
            this.actGridView.Name = "actGridView";
            this.actGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.actGridView.Size = new System.Drawing.Size(507, 561);
            this.actGridView.TabIndex = 0;
            // 
            // infoLabel
            // 
            this.infoLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.infoLabel.AutoSize = true;
            this.infoLabel.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.infoLabel.Location = new System.Drawing.Point(18, 570);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(262, 18);
            this.infoLabel.TabIndex = 1;
            this.infoLabel.Text = "Инициируется доступ к базе данных";
            // 
            // firstButton
            // 
            this.firstButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.firstButton.Location = new System.Drawing.Point(343, 568);
            this.firstButton.Name = "firstButton";
            this.firstButton.Size = new System.Drawing.Size(29, 22);
            this.firstButton.TabIndex = 4;
            this.firstButton.Text = "<<";
            this.firstButton.UseVisualStyleBackColor = true;
            // 
            // previousButton
            // 
            this.previousButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.previousButton.Location = new System.Drawing.Point(378, 568);
            this.previousButton.Name = "previousButton";
            this.previousButton.Size = new System.Drawing.Size(29, 22);
            this.previousButton.TabIndex = 5;
            this.previousButton.Text = "<";
            this.previousButton.UseVisualStyleBackColor = true;
            // 
            // pageTextBox
            // 
            this.pageTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pageTextBox.Location = new System.Drawing.Point(413, 570);
            this.pageTextBox.Name = "pageTextBox";
            this.pageTextBox.ReadOnly = true;
            this.pageTextBox.Size = new System.Drawing.Size(25, 20);
            this.pageTextBox.TabIndex = 6;
            // 
            // nextButton
            // 
            this.nextButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.nextButton.Location = new System.Drawing.Point(444, 568);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(29, 22);
            this.nextButton.TabIndex = 7;
            this.nextButton.Text = ">";
            this.nextButton.UseVisualStyleBackColor = true;
            // 
            // lastButton
            // 
            this.lastButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lastButton.Location = new System.Drawing.Point(479, 568);
            this.lastButton.Name = "lastButton";
            this.lastButton.Size = new System.Drawing.Size(29, 22);
            this.lastButton.TabIndex = 8;
            this.lastButton.Text = ">>";
            this.lastButton.UseVisualStyleBackColor = true;
            // 
            // ActGridControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lastButton);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.pageTextBox);
            this.Controls.Add(this.previousButton);
            this.Controls.Add(this.firstButton);
            this.Controls.Add(this.infoLabel);
            this.Controls.Add(this.actGridView);
            this.Name = "ActGridControl";
            this.Size = new System.Drawing.Size(513, 592);
            ((System.ComponentModel.ISupportInitialize)(this.actGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView actGridView;
        private System.Windows.Forms.Label infoLabel;
        private System.Windows.Forms.Button firstButton;
        private System.Windows.Forms.Button previousButton;
        private System.Windows.Forms.TextBox pageTextBox;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.Button lastButton;
    }
}
