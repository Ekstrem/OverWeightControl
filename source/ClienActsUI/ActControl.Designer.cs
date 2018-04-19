using Unity;

namespace OverWeightControl.Clients.ActsUI
{
    partial class ActControl
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
            this.actNumberLabel = new System.Windows.Forms.Label();
            this.actNumberTextBox = new System.Windows.Forms.TextBox();
            this.dateTimeLabel = new System.Windows.Forms.Label();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.ppvkNumberTextBox = new System.Windows.Forms.TextBox();
            this.ppvkNumberLabel = new System.Windows.Forms.Label();
            this.weightPointLabel = new System.Windows.Forms.Label();
            this.weightPointTextBox = new System.Windows.Forms.TextBox();
            /* this.driverControl1 = new OverWeightControl.Clients.ActsUI.DriverControl();
            this.axisInfoControl1 = new OverWeightControl.Clients.ActsUI.AxisInfoControl();
            this.cargoControl1 = new OverWeightControl.Clients.ActsUI.CargoControl();
            this.vehicleControl1 = new OverWeightControl.Clients.ActsUI.VehicleControl();
            this.vehicleDetailControl1 = new OverWeightControl.Clients.ActsUI.VehicleDetailControl();
            this.weighterControl1 = new OverWeightControl.Clients.ActsUI.WeighterControl(); */
            this.driverControl1 = _container.Resolve<DriverControl>();
            this.axisInfoControl1 = _container.Resolve<AxisInfoControl>();
            this.cargoControl1 = _container.Resolve<CargoControl>();
            this.vehicleControl1 = _container.Resolve<VehicleControl>();
            this.vehicleDetailControl1 = _container.Resolve<VehicleDetailControl>();
            this.weighterControl1 = _container.Resolve<WeighterControl>();
            this.SuspendLayout();
            // 
            // actNumberLabel
            // 
            this.actNumberLabel.AutoSize = true;
            this.actNumberLabel.Location = new System.Drawing.Point(15, 15);
            this.actNumberLabel.Name = "actNumberLabel";
            this.actNumberLabel.Size = new System.Drawing.Size(39, 13);
            this.actNumberLabel.TabIndex = 0;
            this.actNumberLabel.Text = "Акт №";
            // 
            // actNumberTextBox
            // 
            this.actNumberTextBox.Location = new System.Drawing.Point(60, 12);
            this.actNumberTextBox.Name = "actNumberTextBox";
            this.actNumberTextBox.Size = new System.Drawing.Size(79, 20);
            this.actNumberTextBox.TabIndex = 1;
            // 
            // dateTimeLabel
            // 
            this.dateTimeLabel.AutoSize = true;
            this.dateTimeLabel.Location = new System.Drawing.Point(214, 15);
            this.dateTimeLabel.Name = "dateTimeLabel";
            this.dateTimeLabel.Size = new System.Drawing.Size(77, 13);
            this.dateTimeLabel.TabIndex = 2;
            this.dateTimeLabel.Text = "Дата / Время";
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.CustomFormat = "dd.mm.yyyy / hh:mm";
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker.Location = new System.Drawing.Point(297, 12);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(130, 20);
            this.dateTimePicker.TabIndex = 3;
            // 
            // ppvkNumberTextBox
            // 
            this.ppvkNumberTextBox.Location = new System.Drawing.Point(539, 12);
            this.ppvkNumberTextBox.Name = "ppvkNumberTextBox";
            this.ppvkNumberTextBox.Size = new System.Drawing.Size(79, 20);
            this.ppvkNumberTextBox.TabIndex = 5;
            // 
            // ppvkNumberLabel
            // 
            this.ppvkNumberLabel.AutoSize = true;
            this.ppvkNumberLabel.Location = new System.Drawing.Point(482, 15);
            this.ppvkNumberLabel.Name = "ppvkNumberLabel";
            this.ppvkNumberLabel.Size = new System.Drawing.Size(51, 13);
            this.ppvkNumberLabel.TabIndex = 4;
            this.ppvkNumberLabel.Text = "ППВК №";
            // 
            // weightPointLabel
            // 
            this.weightPointLabel.AutoSize = true;
            this.weightPointLabel.Location = new System.Drawing.Point(15, 35);
            this.weightPointLabel.Name = "weightPointLabel";
            this.weightPointLabel.Size = new System.Drawing.Size(232, 13);
            this.weightPointLabel.TabIndex = 6;
            this.weightPointLabel.Text = "Место проведения контроля (взвешивания):";
            // 
            // weightPointTextBox
            // 
            this.weightPointTextBox.Location = new System.Drawing.Point(18, 51);
            this.weightPointTextBox.Name = "weightPointTextBox";
            this.weightPointTextBox.Size = new System.Drawing.Size(600, 20);
            this.weightPointTextBox.TabIndex = 7;
            // 
            // driverControl1
            // 
            this.driverControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.driverControl1.BackColor = System.Drawing.Color.Azure;
            this.driverControl1.Location = new System.Drawing.Point(18, 751);
            this.driverControl1.Name = "driverControl1";
            this.driverControl1.Size = new System.Drawing.Size(600, 89);
            this.driverControl1.TabIndex = 13;
            // 
            // axisInfoControl1
            // 
            this.axisInfoControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.axisInfoControl1.Location = new System.Drawing.Point(18, 553);
            this.axisInfoControl1.Name = "axisInfoControl1";
            this.axisInfoControl1.Size = new System.Drawing.Size(600, 189);
            this.axisInfoControl1.TabIndex = 12;
            // 
            // cargoControl1
            // 
            this.cargoControl1.BackColor = System.Drawing.Color.Azure;
            this.cargoControl1.Location = new System.Drawing.Point(18, 368);
            this.cargoControl1.Name = "cargoControl1";
            this.cargoControl1.Size = new System.Drawing.Size(600, 186);
            this.cargoControl1.TabIndex = 11;
            // 
            // vehicleControl1
            // 
            this.vehicleControl1.BackColor = System.Drawing.Color.Azure;
            this.vehicleControl1.Location = new System.Drawing.Point(18, 237);
            this.vehicleControl1.Name = "vehicleControl1";
            this.vehicleControl1.Size = new System.Drawing.Size(600, 125);
            this.vehicleControl1.TabIndex = 10;
            // 
            // vehicleDetailControl1
            // 
            this.vehicleDetailControl1.BackColor = System.Drawing.Color.Azure;
            this.vehicleDetailControl1.Location = new System.Drawing.Point(18, 163);
            this.vehicleDetailControl1.Name = "vehicleDetailControl1";
            this.vehicleDetailControl1.Size = new System.Drawing.Size(600, 64);
            this.vehicleDetailControl1.TabIndex = 9;
            // 
            // weighterControl1
            // 
            this.weighterControl1.BackColor = System.Drawing.Color.Azure;
            this.weighterControl1.Location = new System.Drawing.Point(18, 77);
            this.weighterControl1.Name = "weighterControl1";
            this.weighterControl1.Size = new System.Drawing.Size(600, 94);
            this.weighterControl1.TabIndex = 8;
            // 
            // ActControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.driverControl1);
            this.Controls.Add(this.axisInfoControl1);
            this.Controls.Add(this.cargoControl1);
            this.Controls.Add(this.vehicleControl1);
            this.Controls.Add(this.vehicleDetailControl1);
            this.Controls.Add(this.weighterControl1);
            this.Controls.Add(this.weightPointTextBox);
            this.Controls.Add(this.weightPointLabel);
            this.Controls.Add(this.ppvkNumberTextBox);
            this.Controls.Add(this.ppvkNumberLabel);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.dateTimeLabel);
            this.Controls.Add(this.actNumberTextBox);
            this.Controls.Add(this.actNumberLabel);
            this.Name = "ActControl";
            this.Size = new System.Drawing.Size(636, 857);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label actNumberLabel;
        private System.Windows.Forms.TextBox actNumberTextBox;
        private System.Windows.Forms.Label dateTimeLabel;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.TextBox ppvkNumberTextBox;
        private System.Windows.Forms.Label ppvkNumberLabel;
        private System.Windows.Forms.Label weightPointLabel;
        private System.Windows.Forms.TextBox weightPointTextBox;
        private WeighterControl weighterControl1;
        private VehicleDetailControl vehicleDetailControl1;
        private VehicleControl vehicleControl1;
        private CargoControl cargoControl1;
        private AxisInfoControl axisInfoControl1;
        private DriverControl driverControl1;
    }
}
