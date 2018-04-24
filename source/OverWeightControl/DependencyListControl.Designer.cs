namespace OverWeightControl
{
    partial class DependencyListControl
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
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.upButton = new System.Windows.Forms.Button();
            this.downButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.orderColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.abstractionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.realizationColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.depNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.registerColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.cancelButton);
            this.groupBox.Controls.Add(this.okButton);
            this.groupBox.Controls.Add(this.downButton);
            this.groupBox.Controls.Add(this.upButton);
            this.groupBox.Controls.Add(this.dataGrid);
            this.groupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox.Location = new System.Drawing.Point(0, 0);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(589, 356);
            this.groupBox.TabIndex = 0;
            this.groupBox.TabStop = false;
            // 
            // dataGrid
            // 
            this.dataGrid.AllowUserToAddRows = false;
            this.dataGrid.AllowUserToDeleteRows = false;
            this.dataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.orderColumn,
            this.abstractionColumn,
            this.realizationColumn,
            this.depNameColumn,
            this.registerColumn});
            this.dataGrid.Location = new System.Drawing.Point(6, 19);
            this.dataGrid.MultiSelect = false;
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGrid.Size = new System.Drawing.Size(488, 326);
            this.dataGrid.TabIndex = 0;
            // 
            // upButton
            // 
            this.upButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.upButton.Location = new System.Drawing.Point(500, 19);
            this.upButton.Name = "upButton";
            this.upButton.Size = new System.Drawing.Size(83, 32);
            this.upButton.TabIndex = 1;
            this.upButton.Text = "Вверх";
            this.upButton.UseVisualStyleBackColor = true;
            // 
            // downButton
            // 
            this.downButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.downButton.Location = new System.Drawing.Point(500, 57);
            this.downButton.Name = "downButton";
            this.downButton.Size = new System.Drawing.Size(83, 32);
            this.downButton.TabIndex = 2;
            this.downButton.Text = "Вниз";
            this.downButton.UseVisualStyleBackColor = true;
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(500, 275);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(83, 32);
            this.okButton.TabIndex = 3;
            this.okButton.Text = "Принять";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(500, 313);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(83, 32);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Отменить";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // orderColumn
            // 
            this.orderColumn.HeaderText = "Order";
            this.orderColumn.Name = "orderColumn";
            this.orderColumn.ReadOnly = true;
            this.orderColumn.Width = 58;
            // 
            // abstractionColumn
            // 
            this.abstractionColumn.HeaderText = "Abstraction";
            this.abstractionColumn.Name = "abstractionColumn";
            this.abstractionColumn.ReadOnly = true;
            this.abstractionColumn.Width = 85;
            // 
            // realizationColumn
            // 
            this.realizationColumn.HeaderText = "Realization";
            this.realizationColumn.Name = "realizationColumn";
            this.realizationColumn.ReadOnly = true;
            this.realizationColumn.Width = 84;
            // 
            // depNameColumn
            // 
            this.depNameColumn.HeaderText = "Dependency Name";
            this.depNameColumn.Name = "depNameColumn";
            this.depNameColumn.ReadOnly = true;
            this.depNameColumn.Width = 114;
            // 
            // registerColumn
            // 
            this.registerColumn.HeaderText = "Register";
            this.registerColumn.Name = "registerColumn";
            this.registerColumn.Width = 52;
            // 
            // DependencyListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox);
            this.Name = "DependencyListControl";
            this.Size = new System.Drawing.Size(589, 356);
            this.groupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button downButton;
        private System.Windows.Forms.Button upButton;
        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn abstractionColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn realizationColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn depNameColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn registerColumn;
    }
}
