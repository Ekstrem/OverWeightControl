namespace OverWeightControl.Clients.ActsUI
{
    partial class VehicleDetailControl
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.VehicleTypeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VehicleBrandColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VehicleModelColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VehicleNumberColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.VehicleTypeColumn,
            this.VehicleBrandColumn,
            this.VehicleModelColumn,
            this.VehicleNumberColumn});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(738, 72);
            this.dataGridView1.TabIndex = 2;
            // 
            // VehicleTypeColumn
            // 
            this.VehicleTypeColumn.HeaderText = "Тип";
            this.VehicleTypeColumn.Name = "VehicleTypeColumn";
            // 
            // VehicleBrandColumn
            // 
            this.VehicleBrandColumn.HeaderText = "Марка";
            this.VehicleBrandColumn.Name = "VehicleBrandColumn";
            // 
            // VehicleModelColumn
            // 
            this.VehicleModelColumn.HeaderText = "Модель";
            this.VehicleModelColumn.Name = "VehicleModelColumn";
            // 
            // VehicleNumberColumn
            // 
            this.VehicleNumberColumn.HeaderText = "Регистрационый №";
            this.VehicleNumberColumn.Name = "VehicleNumberColumn";
            // 
            // VehicleDetailControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView1);
            this.Name = "VehicleDetailControl";
            this.Size = new System.Drawing.Size(738, 72);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn VehicleTypeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn VehicleBrandColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn VehicleModelColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn VehicleNumberColumn;
    }
}
