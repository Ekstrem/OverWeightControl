using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using OverWeightControl.Common.Model;
using Unity;
using Unity.Attributes;

namespace OverWeightControl.Clients.ActsUI
{
    public partial class ActEditForm : Form
    {
        private readonly IUnityContainer _container;

        public ActEditForm()
        {
            InitializeComponent();
        }

        [InjectionConstructor]
        public ActEditForm(IUnityContainer container)
        {
            _container = container;
            InitializeComponent();
        }

        public static void ShowModal(
            IUnityContainer container,
            Act act = null)
        {
            var aef = container.Resolve<ActEditForm>();
            aef.AutoSize = true;
            var bufAct = act ?? ActTest();
            aef.actControl1.LoadData(bufAct);
            aef.Text = $@"Акт №{bufAct.ActNumber}";
            aef.ShowDialog();
        }

        private static Act ActTest()
        {
            return new Act
            {
                ActNumber = 11623,
                ActDateTime = DateTime.Now.ToString(CultureInfo.CurrentCulture),
                PpvkNumber = 17,
                WeightPoint = "testWeightPointAddress",

                #region Вес

                Weighter = new WeighterInfo
                {
                    WeigherNumber = "983454",
                    CertificateNumber = "234234",
                    VerificationDate = "30.03.2018",
                    ViolationNature = "some",
                    ViolationKoap = null
                },

                #endregion

                #region Груз

                Cargo = new CargoInfo
                {
                    #region Axises collection
                    Axises = new List<AxisInfo>
                    {
                        new AxisInfo
                        {
                            AxisNum = "1",
                            AxisStinginess = 1,
                            Distance2NextAxis = 2,
                            LegalAxisWeight = 4,
                            MeasuredAsisWeight = 4,
                            Overweight = "0",
                            PercentRecordedExcess = 0,
                            SpecialAllow = 0,
                            SuspentionType = "Пневма",
                            UsedAxisAllow = 0
                        },
                        new AxisInfo
                        {
                            AxisNum = "2",
                            AxisStinginess = 2,
                            Distance2NextAxis = 2,
                            LegalAxisWeight = 4,
                            MeasuredAsisWeight = 4,
                            Overweight = "0",
                            PercentRecordedExcess = 0,
                            SpecialAllow = 0,
                            SuspentionType = "Пневма",
                            UsedAxisAllow = 0
                        },
                        new AxisInfo
                        {
                            AxisNum = "3",
                            AxisStinginess = 2,
                            Distance2NextAxis = 0,
                            LegalAxisWeight = 6,
                            MeasuredAsisWeight = 8,
                            Overweight = "0",
                            PercentRecordedExcess = 0,
                            SpecialAllow = 0,
                            SuspentionType = "Механика",
                            UsedAxisAllow = 0
                        }
                    },
                    #endregion
                    CargoCharacter = "Делимый",
                    CargoType = "Грунт",
                    LegalWeight = 32,
                    ValetWeight = 32,
                    FactWeight = float.Parse("32,12"),
                    CargoSpecialAllow = 0,
                    PercentWeightOverflow = 0,
                    LegLength = 0,
                    OtherViolation = "",
                    Pass = "",
                    DriverExplanation = ""
                },

                #endregion

                #region Водитель

                Driver = new DriverInfo
                {
                    DriversLicenseNumber = "50 50 357498",
                    FnMnSname = "Иванов Иван Иванович",
                    GetingMark = "Получено",
                    GibddName = "Сергеев Сергей Сергеевич",
                    OperatorName = "Юров Юрий Юрьевич"
                },

                #endregion

                #region ТС

                Vehicle = new VehicleInfo
                {
                    #region Общая информация

                    Detail = new List<VehicleDetail>
                    {
                        new VehicleDetail
                        {
                            VehicleType = "Тягач",
                            VehicleBrand = "Камаз",
                            VehicleModel = "3145",
                            StateNumber = "Т2315Т50"
                        },
                        new VehicleDetail
                        {
                            VehicleType = "Прицеп",
                            VehicleBrand = "ФАВ",
                            VehicleModel = "П-12",
                            StateNumber = "ТА231450"
                        }
                    },

                    #endregion

                    FederalHighwaysDistance = "600",
                    VehicleCompanyAddress = "Мск.",
                    VehicleCountry = "Россия",
                    VehicleOwner = "Рога и копыта",
                    VehicleRoute = "Москва - Питер",
                    VehicleShipper = "Ромашка",
                    VehicleSubjectCode = 50
                }

                #endregion
            };
        }
    }
}
