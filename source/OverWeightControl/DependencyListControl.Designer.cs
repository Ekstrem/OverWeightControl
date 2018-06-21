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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.downButton = new System.Windows.Forms.Button();
            this.upButton = new System.Windows.Forms.Button();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.orderColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.abstractionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.realizationColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.depNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.registerColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.aboutColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox
            // 
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
            // downButton
            // 
            this.downButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.downButton.Location = new System.Drawing.Point(551, 57);
            this.downButton.Name = "downButton";
            this.downButton.Size = new System.Drawing.Size(32, 32);
            this.downButton.TabIndex = 2;
            this.downButton.Text = "v";
            this.downButton.UseVisualStyleBackColor = true;
            // 
            // upButton
            // 
            this.upButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.upButton.Location = new System.Drawing.Point(551, 19);
            this.upButton.Name = "upButton";
            this.upButton.Size = new System.Drawing.Size(32, 32);
            this.upButton.TabIndex = 1;
            this.upButton.Text = "^";
            this.upButton.UseVisualStyleBackColor = true;
            // 
            // dataGrid
            // 
            this.dataGrid.AllowUserToAddRows = false;
            this.dataGrid.AllowUserToDeleteRows = false;
            this.dataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.orderColumn,
            this.abstractionColumn,
            this.realizationColumn,
            this.depNameColumn,
            this.registerColumn,
            this.aboutColumn});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGrid.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGrid.GridColor = System.Drawing.SystemColors.Control;
            this.dataGrid.Location = new System.Drawing.Point(18, 19);
            this.dataGrid.MultiSelect = false;
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGrid.RowHeadersVisible = false;
            this.dataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGrid.Size = new System.Drawing.Size(527, 326);
            this.dataGrid.TabIndex = 0;
            // 
            // orderColumn
            // 
            this.orderColumn.HeaderText = "Порядок";
            this.orderColumn.Name = "orderColumn";
            this.orderColumn.ReadOnly = true;
            this.orderColumn.Width = 76;
            // 
            // abstractionColumn
            // 
            this.abstractionColumn.HeaderText = "Абстракция";
            this.abstractionColumn.Name = "abstractionColumn";
            this.abstractionColumn.ReadOnly = true;
            this.abstractionColumn.Width = 92;
            // 
            // realizationColumn
            // 
            this.realizationColumn.HeaderText = "Реализация";
            this.realizationColumn.Name = "realizationColumn";
            this.realizationColumn.ReadOnly = true;
            this.realizationColumn.Width = 93;
            // 
            // depNameColumn
            // 
            this.depNameColumn.HeaderText = "Имя зависимости";
            this.depNameColumn.Name = "depNameColumn";
            this.depNameColumn.ReadOnly = true;
            this.depNameColumn.Width = 114;
            // 
            // registerColumn
            // 
            this.registerColumn.HeaderText = "Зарегистрировано";
            this.registerColumn.Name = "registerColumn";
            this.registerColumn.Width = 108;
            // 
            // aboutColumn
            // 
            this.aboutColumn.HeaderText = "Описание";
            this.aboutColumn.Name = "aboutColumn";
            this.aboutColumn.Width = 82;
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
        private System.Windows.Forms.Button downButton;
        private System.Windows.Forms.Button upButton;
        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn abstractionColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn realizationColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn depNameColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn registerColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aboutColumn;
    }
}
