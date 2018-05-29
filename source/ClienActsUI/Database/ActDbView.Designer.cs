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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.button1 = new System.Windows.Forms.Button();
            this.actGridControl1 = new OverWeightControl.Clients.ActsUI.Database.ActGridControl();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.actGridControl1);
            this.splitContainer1.Size = new System.Drawing.Size(794, 547);
            this.splitContainer1.SplitterDistance = 127;
            this.splitContainer1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(814, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(132, 50);
            this.button1.TabIndex = 1;
            this.button1.Text = "Просмотр и редактирование";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // actGridControl1
            // 
            this.actGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.actGridControl1.Location = new System.Drawing.Point(0, 0);
            this.actGridControl1.Name = "actGridControl1";
            this.actGridControl1.Size = new System.Drawing.Size(794, 416);
            this.actGridControl1.TabIndex = 0;
            // 
            // ActDbView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 547);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.splitContainer1);
            this.Name = "ActDbView";
            this.Text = "Просмотр сохранённых актов";
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private ActGridControl actGridControl1;
        private System.Windows.Forms.Button button1;
    }
}