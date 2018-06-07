namespace OverWeightControl.Clients.ActsUI.Database
{
    partial class FiltersDockControl
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.filtersPanel = new System.Windows.Forms.Panel();
            this.addButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.filterControl3 = new OverWeightControl.Clients.ActsUI.Database.FilterControl();
            this.filterControl2 = new OverWeightControl.Clients.ActsUI.Database.FilterControl();
            this.filterControl1 = new OverWeightControl.Clients.ActsUI.Database.FilterControl();
            this.filtersPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // filtersPanel
            // 
            this.filtersPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filtersPanel.Controls.Add(this.filterControl3);
            this.filtersPanel.Controls.Add(this.filterControl2);
            this.filtersPanel.Controls.Add(this.filterControl1);
            this.filtersPanel.Location = new System.Drawing.Point(0, 0);
            this.filtersPanel.Name = "filtersPanel";
            this.filtersPanel.Size = new System.Drawing.Size(509, 107);
            this.filtersPanel.TabIndex = 0;
            // 
            // addButton
            // 
            this.addButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addButton.Enabled = false;
            this.addButton.Location = new System.Drawing.Point(515, 3);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(32, 32);
            this.addButton.TabIndex = 1;
            this.addButton.Text = "+";
            this.addButton.UseVisualStyleBackColor = true;
            // 
            // removeButton
            // 
            this.removeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.removeButton.Enabled = false;
            this.removeButton.Location = new System.Drawing.Point(515, 41);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(32, 32);
            this.removeButton.TabIndex = 2;
            this.removeButton.Text = "-";
            this.removeButton.UseVisualStyleBackColor = true;
            // 
            // filterControl3
            // 
            this.filterControl3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filterControl3.Location = new System.Drawing.Point(0, 70);
            this.filterControl3.Name = "filterControl3";
            this.filterControl3.Size = new System.Drawing.Size(503, 29);
            this.filterControl3.TabIndex = 2;
            // 
            // filterControl2
            // 
            this.filterControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filterControl2.Location = new System.Drawing.Point(0, 35);
            this.filterControl2.Name = "filterControl2";
            this.filterControl2.Size = new System.Drawing.Size(503, 29);
            this.filterControl2.TabIndex = 1;
            // 
            // filterControl1
            // 
            this.filterControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filterControl1.Location = new System.Drawing.Point(0, 0);
            this.filterControl1.Name = "filterControl1";
            this.filterControl1.Size = new System.Drawing.Size(503, 29);
            this.filterControl1.TabIndex = 0;
            // 
            // FiltersDockControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.filtersPanel);
            this.Name = "FiltersDockControl";
            this.Size = new System.Drawing.Size(550, 107);
            this.filtersPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel filtersPanel;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button removeButton;
        private FilterControl filterControl1;
        private FilterControl filterControl3;
        private FilterControl filterControl2;
    }
}
