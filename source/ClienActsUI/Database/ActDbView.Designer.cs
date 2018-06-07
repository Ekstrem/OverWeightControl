namespace OverWeightControl.Clients.ActsUI.Database
{
    partial class ActDbView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ActDbView));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.filtersDockControl1 = new OverWeightControl.Clients.ActsUI.Database.FiltersDockControl();
            this.label1 = new System.Windows.Forms.Label();
            this.actGridControl1 = new OverWeightControl.Clients.ActsUI.Database.ActGridControl();
            this.editActButton = new System.Windows.Forms.Button();
            this.columnsListEditButton = new System.Windows.Forms.Button();
            this.openOriginalFileButton = new System.Windows.Forms.Button();
            this.butonsPanel = new System.Windows.Forms.Panel();
            this.excelExportButton = new System.Windows.Forms.Button();
            this.updateDataButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.butonsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.filtersDockControl1);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.actGridControl1);
            this.splitContainer1.Size = new System.Drawing.Size(806, 584);
            this.splitContainer1.SplitterDistance = 95;
            this.splitContainer1.TabIndex = 0;
            // 
            // filtersDockControl1
            // 
            this.filtersDockControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filtersDockControl1.Location = new System.Drawing.Point(0, 0);
            this.filtersDockControl1.Name = "filtersDockControl1";
            this.filtersDockControl1.Size = new System.Drawing.Size(806, 95);
            this.filtersDockControl1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Фильтры";
            // 
            // actGridControl1
            // 
            this.actGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.actGridControl1.Location = new System.Drawing.Point(0, 0);
            this.actGridControl1.Name = "actGridControl1";
            this.actGridControl1.Size = new System.Drawing.Size(806, 485);
            this.actGridControl1.TabIndex = 0;
            // 
            // editActButton
            // 
            this.editActButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.editActButton.Location = new System.Drawing.Point(18, 12);
            this.editActButton.Name = "editActButton";
            this.editActButton.Size = new System.Drawing.Size(132, 50);
            this.editActButton.TabIndex = 1;
            this.editActButton.Text = "Просмотр и редактирование";
            this.editActButton.UseVisualStyleBackColor = true;
            // 
            // columnsListEditButton
            // 
            this.columnsListEditButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.columnsListEditButton.Location = new System.Drawing.Point(18, 68);
            this.columnsListEditButton.Name = "columnsListEditButton";
            this.columnsListEditButton.Size = new System.Drawing.Size(132, 50);
            this.columnsListEditButton.TabIndex = 2;
            this.columnsListEditButton.Text = "Выбор полей отображения";
            this.columnsListEditButton.UseVisualStyleBackColor = true;
            // 
            // openOriginalFileButton
            // 
            this.openOriginalFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.openOriginalFileButton.Location = new System.Drawing.Point(18, 124);
            this.openOriginalFileButton.Name = "openOriginalFileButton";
            this.openOriginalFileButton.Size = new System.Drawing.Size(132, 50);
            this.openOriginalFileButton.TabIndex = 3;
            this.openOriginalFileButton.Text = "Загрузить оригинальный документ";
            this.openOriginalFileButton.UseVisualStyleBackColor = true;
            // 
            // butonsPanel
            // 
            this.butonsPanel.Controls.Add(this.excelExportButton);
            this.butonsPanel.Controls.Add(this.updateDataButton);
            this.butonsPanel.Controls.Add(this.editActButton);
            this.butonsPanel.Controls.Add(this.openOriginalFileButton);
            this.butonsPanel.Controls.Add(this.columnsListEditButton);
            this.butonsPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.butonsPanel.Location = new System.Drawing.Point(812, 0);
            this.butonsPanel.Name = "butonsPanel";
            this.butonsPanel.Size = new System.Drawing.Size(162, 587);
            this.butonsPanel.TabIndex = 4;
            // 
            // excelExportButton
            // 
            this.excelExportButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.excelExportButton.Location = new System.Drawing.Point(18, 236);
            this.excelExportButton.Name = "excelExportButton";
            this.excelExportButton.Size = new System.Drawing.Size(132, 50);
            this.excelExportButton.TabIndex = 5;
            this.excelExportButton.Text = "Экспорт в Excel выбранных данных";
            this.excelExportButton.UseVisualStyleBackColor = true;
            // 
            // updateDataButton
            // 
            this.updateDataButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.updateDataButton.Location = new System.Drawing.Point(18, 180);
            this.updateDataButton.Name = "updateDataButton";
            this.updateDataButton.Size = new System.Drawing.Size(132, 50);
            this.updateDataButton.TabIndex = 4;
            this.updateDataButton.Text = "Обновить данные";
            this.updateDataButton.UseVisualStyleBackColor = true;
            // 
            // ActDbView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 587);
            this.Controls.Add(this.butonsPanel);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(990, 39);
            this.Name = "ActDbView";
            this.Text = "Просмотр сохранённых актов";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.butonsPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private ActGridControl actGridControl1;
        private System.Windows.Forms.Button editActButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button columnsListEditButton;
        private System.Windows.Forms.Button openOriginalFileButton;
        private System.Windows.Forms.Panel butonsPanel;
        private System.Windows.Forms.Button updateDataButton;
        private FiltersDockControl filtersDockControl1;
        private System.Windows.Forms.Button excelExportButton;
    }
}