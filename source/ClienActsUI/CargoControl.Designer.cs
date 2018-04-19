namespace OverWeightControl.Clients.ActsUI
{
    partial class CargoControl
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
            this.cargoCharacterLabel = new System.Windows.Forms.Label();
            this.cargoCharacterTextBox = new System.Windows.Forms.TextBox();
            this.cargoTypeTextBox = new System.Windows.Forms.TextBox();
            this.cargoTypeLabel = new System.Windows.Forms.Label();
            this.legalWeightTextBox = new System.Windows.Forms.TextBox();
            this.legalWeightLabel = new System.Windows.Forms.Label();
            this.valetWeightTextBox = new System.Windows.Forms.TextBox();
            this.valetWeightLabel = new System.Windows.Forms.Label();
            this.factWeightTextBox = new System.Windows.Forms.TextBox();
            this.factWeightLabel = new System.Windows.Forms.Label();
            this.percentWeightOverflowLabel = new System.Windows.Forms.Label();
            this.percentWeightOverflowTextBox = new System.Windows.Forms.TextBox();
            this.cargoSpecialAllowTextBox = new System.Windows.Forms.TextBox();
            this.cargoSpecialAllowLabel = new System.Windows.Forms.Label();
            this.tariffsTextBox = new System.Windows.Forms.TextBox();
            this.tariffsLabel = new System.Windows.Forms.Label();
            this.legLengthLabel = new System.Windows.Forms.Label();
            this.legLengthTextBox = new System.Windows.Forms.TextBox();
            this.roadSectionLabel = new System.Windows.Forms.Label();
            this.roadSectionTextBox = new System.Windows.Forms.TextBox();
            this.passLabel = new System.Windows.Forms.Label();
            this.passTextBox = new System.Windows.Forms.TextBox();
            this.otherViolationLabel = new System.Windows.Forms.Label();
            this.otherViolationTextBox = new System.Windows.Forms.TextBox();
            this.driverExplanationLabel = new System.Windows.Forms.Label();
            this.driverExplanationTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cargoCharacterLabel
            // 
            this.cargoCharacterLabel.AutoSize = true;
            this.cargoCharacterLabel.Location = new System.Drawing.Point(-3, 6);
            this.cargoCharacterLabel.Name = "cargoCharacterLabel";
            this.cargoCharacterLabel.Size = new System.Drawing.Size(121, 13);
            this.cargoCharacterLabel.TabIndex = 0;
            this.cargoCharacterLabel.Text = "Характеристика груза";
            // 
            // cargoCharacterTextBox
            // 
            this.cargoCharacterTextBox.Location = new System.Drawing.Point(128, 3);
            this.cargoCharacterTextBox.Name = "cargoCharacterTextBox";
            this.cargoCharacterTextBox.Size = new System.Drawing.Size(147, 20);
            this.cargoCharacterTextBox.TabIndex = 1;
            // 
            // cargoTypeTextBox
            // 
            this.cargoTypeTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cargoTypeTextBox.Location = new System.Drawing.Point(414, 3);
            this.cargoTypeTextBox.Name = "cargoTypeTextBox";
            this.cargoTypeTextBox.Size = new System.Drawing.Size(186, 20);
            this.cargoTypeTextBox.TabIndex = 3;
            // 
            // cargoTypeLabel
            // 
            this.cargoTypeLabel.AutoSize = true;
            this.cargoTypeLabel.Location = new System.Drawing.Point(333, 6);
            this.cargoTypeLabel.Name = "cargoTypeLabel";
            this.cargoTypeLabel.Size = new System.Drawing.Size(57, 13);
            this.cargoTypeLabel.TabIndex = 2;
            this.cargoTypeLabel.Text = "Вид груза";
            // 
            // legalWeightTextBox
            // 
            this.legalWeightTextBox.Location = new System.Drawing.Point(128, 28);
            this.legalWeightTextBox.Name = "legalWeightTextBox";
            this.legalWeightTextBox.Size = new System.Drawing.Size(58, 20);
            this.legalWeightTextBox.TabIndex = 5;
            // 
            // legalWeightLabel
            // 
            this.legalWeightLabel.AutoSize = true;
            this.legalWeightLabel.Location = new System.Drawing.Point(-3, 31);
            this.legalWeightLabel.Name = "legalWeightLabel";
            this.legalWeightLabel.Size = new System.Drawing.Size(125, 13);
            this.legalWeightLabel.TabIndex = 4;
            this.legalWeightLabel.Text = "Нормативная масса, т.";
            // 
            // valetWeightTextBox
            // 
            this.valetWeightTextBox.Location = new System.Drawing.Point(332, 28);
            this.valetWeightTextBox.Name = "valetWeightTextBox";
            this.valetWeightTextBox.Size = new System.Drawing.Size(58, 20);
            this.valetWeightTextBox.TabIndex = 7;
            // 
            // valetWeightLabel
            // 
            this.valetWeightLabel.AutoSize = true;
            this.valetWeightLabel.Location = new System.Drawing.Point(207, 31);
            this.valetWeightLabel.Name = "valetWeightLabel";
            this.valetWeightLabel.Size = new System.Drawing.Size(119, 13);
            this.valetWeightLabel.TabIndex = 6;
            this.valetWeightLabel.Text = "Допустимая масса, т.";
            // 
            // factWeightTextBox
            // 
            this.factWeightTextBox.Location = new System.Drawing.Point(542, 28);
            this.factWeightTextBox.Name = "factWeightTextBox";
            this.factWeightTextBox.Size = new System.Drawing.Size(58, 20);
            this.factWeightTextBox.TabIndex = 9;
            // 
            // factWeightLabel
            // 
            this.factWeightLabel.AutoSize = true;
            this.factWeightLabel.Location = new System.Drawing.Point(411, 31);
            this.factWeightLabel.Name = "factWeightLabel";
            this.factWeightLabel.Size = new System.Drawing.Size(125, 13);
            this.factWeightLabel.TabIndex = 8;
            this.factWeightLabel.Text = "Фактическая масса, т.";
            // 
            // percentWeightOverflowLabel
            // 
            this.percentWeightOverflowLabel.AutoSize = true;
            this.percentWeightOverflowLabel.Location = new System.Drawing.Point(-3, 54);
            this.percentWeightOverflowLabel.Name = "percentWeightOverflowLabel";
            this.percentWeightOverflowLabel.Size = new System.Drawing.Size(101, 13);
            this.percentWeightOverflowLabel.TabIndex = 10;
            this.percentWeightOverflowLabel.Text = "Процент перевеса";
            // 
            // percentWeightOverflowTextBox
            // 
            this.percentWeightOverflowTextBox.Location = new System.Drawing.Point(104, 51);
            this.percentWeightOverflowTextBox.Name = "percentWeightOverflowTextBox";
            this.percentWeightOverflowTextBox.Size = new System.Drawing.Size(58, 20);
            this.percentWeightOverflowTextBox.TabIndex = 11;
            // 
            // cargoSpecialAllowTextBox
            // 
            this.cargoSpecialAllowTextBox.Location = new System.Drawing.Point(332, 51);
            this.cargoSpecialAllowTextBox.Name = "cargoSpecialAllowTextBox";
            this.cargoSpecialAllowTextBox.Size = new System.Drawing.Size(58, 20);
            this.cargoSpecialAllowTextBox.TabIndex = 13;
            // 
            // cargoSpecialAllowLabel
            // 
            this.cargoSpecialAllowLabel.AutoSize = true;
            this.cargoSpecialAllowLabel.Location = new System.Drawing.Point(187, 54);
            this.cargoSpecialAllowLabel.Name = "cargoSpecialAllowLabel";
            this.cargoSpecialAllowLabel.Size = new System.Drawing.Size(139, 13);
            this.cargoSpecialAllowLabel.TabIndex = 12;
            this.cargoSpecialAllowLabel.Text = "Специальное разрешение";
            // 
            // tariffsTextBox
            // 
            this.tariffsTextBox.Location = new System.Drawing.Point(542, 51);
            this.tariffsTextBox.Name = "tariffsTextBox";
            this.tariffsTextBox.Size = new System.Drawing.Size(58, 20);
            this.tariffsTextBox.TabIndex = 15;
            // 
            // tariffsLabel
            // 
            this.tariffsLabel.AutoSize = true;
            this.tariffsLabel.Location = new System.Drawing.Point(411, 54);
            this.tariffsLabel.Name = "tariffsLabel";
            this.tariffsLabel.Size = new System.Drawing.Size(96, 13);
            this.tariffsLabel.TabIndex = 14;
            this.tariffsLabel.Text = "Тариф на 100 км.";
            // 
            // legLengthLabel
            // 
            this.legLengthLabel.AutoSize = true;
            this.legLengthLabel.Location = new System.Drawing.Point(-3, 81);
            this.legLengthLabel.Name = "legLengthLabel";
            this.legLengthLabel.Size = new System.Drawing.Size(82, 13);
            this.legLengthLabel.TabIndex = 16;
            this.legLengthLabel.Text = "Длина участка";
            // 
            // legLengthTextBox
            // 
            this.legLengthTextBox.Location = new System.Drawing.Point(104, 78);
            this.legLengthTextBox.Name = "legLengthTextBox";
            this.legLengthTextBox.Size = new System.Drawing.Size(58, 20);
            this.legLengthTextBox.TabIndex = 17;
            // 
            // roadSectionLabel
            // 
            this.roadSectionLabel.AutoSize = true;
            this.roadSectionLabel.Location = new System.Drawing.Point(239, 81);
            this.roadSectionLabel.Name = "roadSectionLabel";
            this.roadSectionLabel.Size = new System.Drawing.Size(87, 13);
            this.roadSectionLabel.TabIndex = 18;
            this.roadSectionLabel.Text = "Участок дороги";
            // 
            // roadSectionTextBox
            // 
            this.roadSectionTextBox.Location = new System.Drawing.Point(332, 78);
            this.roadSectionTextBox.Name = "roadSectionTextBox";
            this.roadSectionTextBox.Size = new System.Drawing.Size(268, 20);
            this.roadSectionTextBox.TabIndex = 19;
            // 
            // passLabel
            // 
            this.passLabel.Location = new System.Drawing.Point(-3, 104);
            this.passLabel.Name = "passLabel";
            this.passLabel.Size = new System.Drawing.Size(419, 34);
            this.passLabel.TabIndex = 20;
            this.passLabel.Text = "Сведения о ГТС в реестре действующих пропусков, предоставляющих право она въезд и" +
    " передвижение в зонах ограничения движения по г. Москва.";
            // 
            // passTextBox
            // 
            this.passTextBox.Location = new System.Drawing.Point(412, 104);
            this.passTextBox.Name = "passTextBox";
            this.passTextBox.Size = new System.Drawing.Size(188, 20);
            this.passTextBox.TabIndex = 21;
            // 
            // otherViolationLabel
            // 
            this.otherViolationLabel.AutoSize = true;
            this.otherViolationLabel.Location = new System.Drawing.Point(-3, 138);
            this.otherViolationLabel.Name = "otherViolationLabel";
            this.otherViolationLabel.Size = new System.Drawing.Size(102, 13);
            this.otherViolationLabel.TabIndex = 22;
            this.otherViolationLabel.Text = "Другие нарушения";
            // 
            // otherViolationTextBox
            // 
            this.otherViolationTextBox.Location = new System.Drawing.Point(123, 135);
            this.otherViolationTextBox.Name = "otherViolationTextBox";
            this.otherViolationTextBox.Size = new System.Drawing.Size(477, 20);
            this.otherViolationTextBox.TabIndex = 23;
            // 
            // driverExplanationLabel
            // 
            this.driverExplanationLabel.AutoSize = true;
            this.driverExplanationLabel.Location = new System.Drawing.Point(-3, 164);
            this.driverExplanationLabel.Name = "driverExplanationLabel";
            this.driverExplanationLabel.Size = new System.Drawing.Size(120, 13);
            this.driverExplanationLabel.TabIndex = 24;
            this.driverExplanationLabel.Text = "Объяснение водителя";
            // 
            // driverExplanationTextBox
            // 
            this.driverExplanationTextBox.Location = new System.Drawing.Point(123, 161);
            this.driverExplanationTextBox.Name = "driverExplanationTextBox";
            this.driverExplanationTextBox.Size = new System.Drawing.Size(477, 20);
            this.driverExplanationTextBox.TabIndex = 25;
            // 
            // CargoControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.driverExplanationTextBox);
            this.Controls.Add(this.driverExplanationLabel);
            this.Controls.Add(this.otherViolationTextBox);
            this.Controls.Add(this.otherViolationLabel);
            this.Controls.Add(this.passTextBox);
            this.Controls.Add(this.passLabel);
            this.Controls.Add(this.roadSectionTextBox);
            this.Controls.Add(this.roadSectionLabel);
            this.Controls.Add(this.legLengthTextBox);
            this.Controls.Add(this.legLengthLabel);
            this.Controls.Add(this.tariffsTextBox);
            this.Controls.Add(this.tariffsLabel);
            this.Controls.Add(this.cargoSpecialAllowTextBox);
            this.Controls.Add(this.cargoSpecialAllowLabel);
            this.Controls.Add(this.percentWeightOverflowTextBox);
            this.Controls.Add(this.percentWeightOverflowLabel);
            this.Controls.Add(this.factWeightTextBox);
            this.Controls.Add(this.factWeightLabel);
            this.Controls.Add(this.valetWeightTextBox);
            this.Controls.Add(this.valetWeightLabel);
            this.Controls.Add(this.legalWeightTextBox);
            this.Controls.Add(this.legalWeightLabel);
            this.Controls.Add(this.cargoTypeTextBox);
            this.Controls.Add(this.cargoTypeLabel);
            this.Controls.Add(this.cargoCharacterTextBox);
            this.Controls.Add(this.cargoCharacterLabel);
            this.Name = "CargoControl";
            this.Size = new System.Drawing.Size(600, 186);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label cargoCharacterLabel;
        private System.Windows.Forms.TextBox cargoCharacterTextBox;
        private System.Windows.Forms.TextBox cargoTypeTextBox;
        private System.Windows.Forms.Label cargoTypeLabel;
        private System.Windows.Forms.TextBox legalWeightTextBox;
        private System.Windows.Forms.Label legalWeightLabel;
        private System.Windows.Forms.TextBox valetWeightTextBox;
        private System.Windows.Forms.Label valetWeightLabel;
        private System.Windows.Forms.TextBox factWeightTextBox;
        private System.Windows.Forms.Label factWeightLabel;
        private System.Windows.Forms.Label percentWeightOverflowLabel;
        private System.Windows.Forms.TextBox percentWeightOverflowTextBox;
        private System.Windows.Forms.TextBox cargoSpecialAllowTextBox;
        private System.Windows.Forms.Label cargoSpecialAllowLabel;
        private System.Windows.Forms.TextBox tariffsTextBox;
        private System.Windows.Forms.Label tariffsLabel;
        private System.Windows.Forms.Label legLengthLabel;
        private System.Windows.Forms.TextBox legLengthTextBox;
        private System.Windows.Forms.Label roadSectionLabel;
        private System.Windows.Forms.TextBox roadSectionTextBox;
        private System.Windows.Forms.Label passLabel;
        private System.Windows.Forms.TextBox passTextBox;
        private System.Windows.Forms.Label otherViolationLabel;
        private System.Windows.Forms.TextBox otherViolationTextBox;
        private System.Windows.Forms.Label driverExplanationLabel;
        private System.Windows.Forms.TextBox driverExplanationTextBox;
    }
}
