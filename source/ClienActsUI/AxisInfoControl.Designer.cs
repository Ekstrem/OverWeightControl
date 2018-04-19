namespace OverWeightControl.Clients.ActsUI
{
    partial class AxisInfoControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.AxisNumColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.axisStinginessColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.suspentionTypeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.distance2NextAxisColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.measuredAsisWeightColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.legalAxisWeightColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.specialAllowColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usedAxisAllowColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.weightRecordedExcessColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.percentRecordedExcessColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.overweightColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.axisCountTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.AxisNumColumn,
            this.axisStinginessColumn,
            this.suspentionTypeColumn,
            this.distance2NextAxisColumn,
            this.measuredAsisWeightColumn,
            this.legalAxisWeightColumn,
            this.specialAllowColumn,
            this.usedAxisAllowColumn,
            this.weightRecordedExcessColumn,
            this.percentRecordedExcessColumn,
            this.overweightColumn});
            this.dataGridView1.Location = new System.Drawing.Point(0, 26);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(600, 284);
            this.dataGridView1.TabIndex = 0;
            // 
            // AxisNumColumn
            // 
            this.AxisNumColumn.HeaderText = "№ оси";
            this.AxisNumColumn.Name = "AxisNumColumn";
            this.AxisNumColumn.ReadOnly = true;
            this.AxisNumColumn.Width = 32;
            // 
            // axisStinginessColumn
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.axisStinginessColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.axisStinginessColumn.HeaderText = "Скат ность";
            this.axisStinginessColumn.Name = "axisStinginessColumn";
            this.axisStinginessColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.axisStinginessColumn.Width = 45;
            // 
            // suspentionTypeColumn
            // 
            this.suspentionTypeColumn.HeaderText = "Тип подвески";
            this.suspentionTypeColumn.Name = "suspentionTypeColumn";
            this.suspentionTypeColumn.Width = 78;
            // 
            // distance2NextAxisColumn
            // 
            this.distance2NextAxisColumn.HeaderText = "Дист. до сл. оси";
            this.distance2NextAxisColumn.Name = "distance2NextAxisColumn";
            this.distance2NextAxisColumn.Width = 50;
            // 
            // measuredAsisWeightColumn
            // 
            this.measuredAsisWeightColumn.HeaderText = "Изме рено, т.";
            this.measuredAsisWeightColumn.Name = "measuredAsisWeightColumn";
            this.measuredAsisWeightColumn.Width = 50;
            // 
            // legalAxisWeightColumn
            // 
            this.legalAxisWeightColumn.HeaderText = "Норм атив, т.";
            this.legalAxisWeightColumn.Name = "legalAxisWeightColumn";
            this.legalAxisWeightColumn.Width = 50;
            // 
            // specialAllowColumn
            // 
            this.specialAllowColumn.HeaderText = "Спец. разр. т.";
            this.specialAllowColumn.Name = "specialAllowColumn";
            this.specialAllowColumn.Width = 50;
            // 
            // usedAxisAllowColumn
            // 
            this.usedAxisAllowColumn.HeaderText = "Приме няе мые,т.";
            this.usedAxisAllowColumn.Name = "usedAxisAllowColumn";
            this.usedAxisAllowColumn.Width = 50;
            // 
            // weightRecordedExcessColumn
            // 
            this.weightRecordedExcessColumn.HeaderText = "Учит. прев. , т.";
            this.weightRecordedExcessColumn.Name = "weightRecordedExcessColumn";
            this.weightRecordedExcessColumn.Width = 50;
            // 
            // percentRecordedExcessColumn
            // 
            this.percentRecordedExcessColumn.HeaderText = "Учит. прев. , %";
            this.percentRecordedExcessColumn.Name = "percentRecordedExcessColumn";
            this.percentRecordedExcessColumn.Width = 50;
            // 
            // overweightColumn
            // 
            this.overweightColumn.HeaderText = "Пере груз , т.";
            this.overweightColumn.Name = "overweightColumn";
            this.overweightColumn.Width = 50;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Осевые нагрузки";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.axisCountTextBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(600, 23);
            this.panel1.TabIndex = 2;
            // 
            // axisCountTextBox
            // 
            this.axisCountTextBox.Location = new System.Drawing.Point(559, 0);
            this.axisCountTextBox.Name = "axisCountTextBox";
            this.axisCountTextBox.Size = new System.Drawing.Size(41, 20);
            this.axisCountTextBox.TabIndex = 3;
            this.axisCountTextBox.Text = "12";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(441, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Колличество осей:";
            // 
            // AxisInfoControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "AxisInfoControl";
            this.Size = new System.Drawing.Size(600, 310);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox axisCountTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn AxisNumColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn axisStinginessColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn suspentionTypeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn distance2NextAxisColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn measuredAsisWeightColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn legalAxisWeightColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn specialAllowColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usedAxisAllowColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn weightRecordedExcessColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn percentRecordedExcessColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn overweightColumn;
    }
}
