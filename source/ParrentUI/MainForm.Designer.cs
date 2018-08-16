using Unity;

namespace OverWeightControl.Clients.ParrentUI
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.syncToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.syncProgressToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.storageCommitmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.syncProgressAtStComToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.verificationStationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actListVerificationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actVerificationWizardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsStationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportGeneratorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statisticToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adminingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nodeRolesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openHelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkForUpdatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.progressListControl1 = _container.Resolve<ProgressListControl>();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.syncToolStripMenuItem,
            this.storageCommitmentToolStripMenuItem,
            this.verificationStationToolStripMenuItem,
            this.reportsStationToolStripMenuItem,
            this.adminingToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1106, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // syncToolStripMenuItem
            // 
            this.syncToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.syncProgressToolStripMenuItem});
            this.syncToolStripMenuItem.Name = "syncToolStripMenuItem";
            this.syncToolStripMenuItem.Size = new System.Drawing.Size(98, 20);
            this.syncToolStripMenuItem.Text = "Синхронизаця";
            // 
            // syncProgressToolStripMenuItem
            // 
            this.syncProgressToolStripMenuItem.Name = "syncProgressToolStripMenuItem";
            this.syncProgressToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.syncProgressToolStripMenuItem.Text = "Ход синхронизации";
            // 
            // storageCommitmentToolStripMenuItem
            // 
            this.storageCommitmentToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.syncProgressAtStComToolStripMenuItem1});
            this.storageCommitmentToolStripMenuItem.Name = "storageCommitmentToolStripMenuItem";
            this.storageCommitmentToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.storageCommitmentToolStripMenuItem.Text = "Хранилище";
            // 
            // syncProgressAtStComToolStripMenuItem1
            // 
            this.syncProgressAtStComToolStripMenuItem1.Name = "syncProgressAtStComToolStripMenuItem1";
            this.syncProgressAtStComToolStripMenuItem1.Size = new System.Drawing.Size(182, 22);
            this.syncProgressAtStComToolStripMenuItem1.Text = "Ход синхронизации";
            // 
            // verificationStationToolStripMenuItem
            // 
            this.verificationStationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.actListVerificationToolStripMenuItem,
            this.actVerificationWizardToolStripMenuItem});
            this.verificationStationToolStripMenuItem.Name = "verificationStationToolStripMenuItem";
            this.verificationStationToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.verificationStationToolStripMenuItem.Text = "Верификация";
            // 
            // actListVerificationToolStripMenuItem
            // 
            this.actListVerificationToolStripMenuItem.Name = "actListVerificationToolStripMenuItem";
            this.actListVerificationToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.actListVerificationToolStripMenuItem.Text = "Верификация акта | Лист";
            // 
            // actVerificationWizardToolStripMenuItem
            // 
            this.actVerificationWizardToolStripMenuItem.Name = "actVerificationWizardToolStripMenuItem";
            this.actVerificationWizardToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.actVerificationWizardToolStripMenuItem.Text = "Мастер верификации акта";
            // 
            // reportsStationToolStripMenuItem
            // 
            this.reportsStationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reportGeneratorToolStripMenuItem,
            this.statisticToolStripMenuItem});
            this.reportsStationToolStripMenuItem.Name = "reportsStationToolStripMenuItem";
            this.reportsStationToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.reportsStationToolStripMenuItem.Text = "Отчёты";
            // 
            // reportGeneratorToolStripMenuItem
            // 
            this.reportGeneratorToolStripMenuItem.Name = "reportGeneratorToolStripMenuItem";
            this.reportGeneratorToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.reportGeneratorToolStripMenuItem.Text = "Генерация отчётов";
            // 
            // statisticToolStripMenuItem
            // 
            this.statisticToolStripMenuItem.Name = "statisticToolStripMenuItem";
            this.statisticToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.statisticToolStripMenuItem.Text = "Сводная статистика";
            // 
            // adminingToolStripMenuItem
            // 
            this.adminingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.nodeRolesToolStripMenuItem});
            this.adminingToolStripMenuItem.Name = "adminingToolStripMenuItem";
            this.adminingToolStripMenuItem.Size = new System.Drawing.Size(134, 20);
            this.adminingToolStripMenuItem.Text = "Администрирование";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.settingsToolStripMenuItem.Text = "Настройки";
            // 
            // nodeRolesToolStripMenuItem
            // 
            this.nodeRolesToolStripMenuItem.Name = "nodeRolesToolStripMenuItem";
            this.nodeRolesToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.nodeRolesToolStripMenuItem.Text = "Роли узла ИС";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openHelpToolStripMenuItem,
            this.checkForUpdatesToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.helpToolStripMenuItem.Text = "Справка";
            // 
            // openHelpToolStripMenuItem
            // 
            this.openHelpToolStripMenuItem.Enabled = true;
            this.openHelpToolStripMenuItem.Name = "openHelpToolStripMenuItem";
            this.openHelpToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.openHelpToolStripMenuItem.Text = "Помощь";
            // 
            // checkForUpdatesToolStripMenuItem
            // 
            this.checkForUpdatesToolStripMenuItem.Enabled = false;
            this.checkForUpdatesToolStripMenuItem.Name = "checkForUpdatesToolStripMenuItem";
            this.checkForUpdatesToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.checkForUpdatesToolStripMenuItem.Text = "Проверить обновления";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Enabled = false;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.aboutToolStripMenuItem.Text = "О программе";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(128, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(291, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Прогресс очереди синхронизации:";
            //
            // progressListControl1
            // 
            this.progressListControl1.Location = new System.Drawing.Point(31, 93);
            this.progressListControl1.Name = "progressListControl1";
            this.progressListControl1.Size = new System.Drawing.Size(520, 274);
            this.progressListControl1.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1106, 774);
            this.Controls.Add(this.progressListControl1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Text = "Информационная система оцифровки данных о перевесе на станциях ППВК";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem syncToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem syncProgressToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem storageCommitmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem syncProgressAtStComToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem verificationStationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem actListVerificationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem actVerificationWizardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsStationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportGeneratorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem statisticToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adminingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nodeRolesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openHelpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkForUpdatesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private ProgressListControl progressListControl1;
    }
}