namespace OverWeightControl.Clients.ActsUI.Database
{
    partial class ActGridControl
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
            this.idColum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.actNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateTimeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ppvkNumColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.weightPointColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.actGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // actGridView
            // 
            this.actGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.actGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.actGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.actGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idColum,
            this.actNumber,
            this.DateTimeColumn,
            this.ppvkNumColumn,
            this.weightPointColumn});
            this.actGridView.Location = new System.Drawing.Point(3, 3);
            this.actGridView.MultiSelect = false;
            this.actGridView.Name = "actGridView";
            this.actGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.actGridView.Size = new System.Drawing.Size(507, 586);
            this.actGridView.TabIndex = 0;
            // 
            // idColum
            // 
            this.idColum.HeaderText = "ID";
            this.idColum.Name = "idColum";
            this.idColum.Visible = false;
            // 
            // actNumber
            // 
            this.actNumber.HeaderText = "№ акта";
            this.actNumber.Name = "actNumber";
            // 
            // DateTimeColumn
            // 
            this.DateTimeColumn.HeaderText = "Дата/время";
            this.DateTimeColumn.Name = "DateTimeColumn";
            // 
            // ppvkNumColumn
            // 
            this.ppvkNumColumn.HeaderText = "№ ППВК";
            this.ppvkNumColumn.Name = "ppvkNumColumn";
            // 
            // weightPointColumn
            // 
            this.weightPointColumn.HeaderText = "Место взвешивания";
            this.weightPointColumn.Name = "weightPointColumn";
            // 
            // ActGridControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.actGridView);
            this.Name = "ActGridControl";
            this.Size = new System.Drawing.Size(513, 592);
            ((System.ComponentModel.ISupportInitialize)(this.actGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView actGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn idColum;
        private System.Windows.Forms.DataGridViewTextBoxColumn actNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateTimeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ppvkNumColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn weightPointColumn;
    }
}
