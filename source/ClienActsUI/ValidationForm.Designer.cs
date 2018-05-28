using Unity;

namespace OverWeightControl.Clients.ActsUI
{
    partial class ValidationForm
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
            this.validatioinControl1 = // new OverWeightControl.Clients.ParrentUI.ValidatioinControl();
                _container.Resolve<ValidatioinControl>();
            this.actBtn = new System.Windows.Forms.Button();
            this.validateBtn = new System.Windows.Forms.Button();
            this.updateBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // validatioinControl1
            // 
            this.validatioinControl1.Location = new System.Drawing.Point(12, 12);
            this.validatioinControl1.Name = "validatioinControl1";
            this.validatioinControl1.Size = new System.Drawing.Size(479, 505);
            this.validatioinControl1.TabIndex = 0;
            // 
            // actBtn
            // 
            this.actBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.actBtn.Location = new System.Drawing.Point(398, 517);
            this.actBtn.Name = "actBtn";
            this.actBtn.Size = new System.Drawing.Size(75, 23);
            this.actBtn.TabIndex = 1;
            this.actBtn.Text = "Закрыть";
            this.actBtn.UseVisualStyleBackColor = true;
            // 
            // validateBtn
            // 
            this.validateBtn.Location = new System.Drawing.Point(279, 517);
            this.validateBtn.Name = "validateBtn";
            this.validateBtn.Size = new System.Drawing.Size(113, 23);
            this.validateBtn.TabIndex = 2;
            this.validateBtn.Text = "Начать проверку";
            this.validateBtn.UseVisualStyleBackColor = true;
            this.validateBtn.Click += new System.EventHandler(this.validateBtn_Click);
            // 
            // updateBtn
            // 
            this.updateBtn.Location = new System.Drawing.Point(162, 517);
            this.updateBtn.Name = "updateBtn";
            this.updateBtn.Size = new System.Drawing.Size(111, 23);
            this.updateBtn.TabIndex = 3;
            this.updateBtn.Text = "Обновить список";
            this.updateBtn.UseVisualStyleBackColor = true;
            this.updateBtn.Click += new System.EventHandler(this.updateBtn_Click);
            // 
            // ValidationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 552);
            this.Controls.Add(this.updateBtn);
            this.Controls.Add(this.validateBtn);
            this.Controls.Add(this.actBtn);
            this.Controls.Add(this.validatioinControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ValidationForm";
            this.Text = "Проверка распознанных документов";
            this.ResumeLayout(false);

        }

        #endregion

        private ValidatioinControl validatioinControl1;
        private System.Windows.Forms.Button actBtn;
        private System.Windows.Forms.Button validateBtn;
        private System.Windows.Forms.Button updateBtn;
    }
}