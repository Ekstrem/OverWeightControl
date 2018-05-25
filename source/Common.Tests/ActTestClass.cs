using OverWeightControl.Common.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Globalization;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using OverWeightControl.Common.BelModel;
using OverWeightControl.Common.RawData;
using OverWeightControl.Common.Serialization;

namespace OverWeightControl.Common.Tests
{
    public class ActTestClass
    {
        public static void Main()
        {
            Console.WriteLine("Test started");
            Console.WriteLine();
            //
            /*var actJson = ActTest();
            Console.WriteLine(actJson);
            Console.WriteLine();
            var act = new Act().LoadFromJson(actJson);
            TestBd(act);
            Console.WriteLine(act.Id);
            Console.WriteLine();
            //
            var rawActJson = RawActTest();
            Console.WriteLine(rawActJson);
            var rawact = new RawAct().LoadFromJson(rawActJson);
            Console.WriteLine(act.Id);*/
            //
            TestBel();
            Console.ReadKey();
        }

        private static void TestBel()
        {
            var json = File.ReadAllText("C:\\Users\\Евгений\\Downloads\\Telegram Desktop\\response.json");
            var res = JsonConvert.DeserializeObject<BlankList>(json).blankValues;
            var a = res.weightOfCargo.value[0].value[0].recognizedValue;
            var b = res.distanceBetween.value
                .Select(m => new KeyValuePair<int?, string>(m.index, m.recognizedValue));
        }

        private static void TestBd(Act act)
        {
            try
            {
                var context = new ModelContext(null, null);
                context.Acts.Add(act);
                context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                {
                    Console.Write("Object: " + validationError.Entry.Entity.ToString());
                    Console.Write("");
                    foreach (DbValidationError err in validationError.ValidationErrors)
                    {
                        Console.Write(err.ErrorMessage + "");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private static string ActTest()
        {
            var id = Guid.NewGuid();
            var act = new Act
            {
                Id = id,
                ActNumber = 11623,
                ActDateTime = DateTime.Now.ToString(CultureInfo.CurrentCulture),
                PpvkNumber = 17,
                WeightPoint = "testWeightPointAddress",

                #region Вес

                Weighter = new WeighterInfo(id)
                {
                    CertificateNumber = "234234",
                    VerificationDate = "30.03.2018",
                    ViolationNature = "some",
                    ViolationKoap = null
                },

                #endregion

                #region Груз

                Cargo = new CargoInfo(id)
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

                Driver = new DriverInfo(id)
                {
                    DriversLicenseNumber = "50 50 357498",
                    FnMnSname = "Иванов Иван Иванович",
                    GetingMark = "Получено",
                    GibddName = "Сергеев Сергей Сергеевич",
                    OperatorName = "Юров Юрий Юрьевич"
                },

                #endregion

                #region ТС

                Vehicle = new VehicleInfo(id)
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

            return act.ToJson();
        }

        private static string RawActTest()
        {
            var act = new RawAct
            {
                ActNumber = RecognizedValue.Factory("11623"),
                ActDate = RecognizedValue.Factory(DateTime.Now.ToShortDateString()),
                ActTime = RecognizedValue.Factory(DateTime.Now.ToLongTimeString()),
                PpvkNumber = RecognizedValue.Factory("17"),
                WeightPoint = RecognizedValue.Factory("testWeightPointAddress"),

                #region Вес

                Weighter = new RawWeighterInfo
                {
                    CertificateNumber = RecognizedValue.Factory("234234"),
                    VerificationDate = RecognizedValue.Factory("30.03.2018"),
                    ViolationNature = RecognizedValue.Factory("some"),
                    ViolationKoap = RecognizedValue.Factory("")
                },

                #endregion

                #region Груз

                Cargo = new RawCargoInfo
                {
                    #region Axises collection
                    Axises = new List<RawAxisInfo>
                    {
                        new RawAxisInfo
                        {
                            AxisNum = RecognizedValue.Factory("1"),
                            AxisStinginess = RecognizedValue.Factory("1"),
                            Distance2NextAxis = RecognizedValue.Factory("2"),
                            LegalAxisWeight = RecognizedValue.Factory("4"),
                            MeasuredAsisWeight = RecognizedValue.Factory("4"),
                            Overweight = RecognizedValue.Factory("0"),
                            PercentRecordedExcess = RecognizedValue.Factory("0"),
                            SpecialAllow = RecognizedValue.Factory("0"),
                            SuspentionType = RecognizedValue.Factory("Пневма"),
                            UsedAxisAllow = RecognizedValue.Factory("0")
                        },
                        new RawAxisInfo
                        {
                            AxisNum = RecognizedValue.Factory("2"),
                            AxisStinginess = RecognizedValue.Factory("2"),
                            Distance2NextAxis = RecognizedValue.Factory("2"),
                            LegalAxisWeight = RecognizedValue.Factory("4"),
                            MeasuredAsisWeight = RecognizedValue.Factory("4"),
                            Overweight = RecognizedValue.Factory("0"),
                            PercentRecordedExcess = RecognizedValue.Factory("0"),
                            SpecialAllow = RecognizedValue.Factory("0"),
                            SuspentionType = RecognizedValue.Factory("Пневма"),
                            UsedAxisAllow = RecognizedValue.Factory("0")
                        },
                        new RawAxisInfo
                        {
                            AxisNum = RecognizedValue.Factory("3"),
                            AxisStinginess = RecognizedValue.Factory("2"),
                            Distance2NextAxis = RecognizedValue.Factory("0"),
                            LegalAxisWeight = RecognizedValue.Factory("6"),
                            MeasuredAsisWeight = RecognizedValue.Factory("8"),
                            Overweight = RecognizedValue.Factory("0"),
                            PercentRecordedExcess = RecognizedValue.Factory("0"),
                            SpecialAllow = RecognizedValue.Factory("0"),
                            SuspentionType = RecognizedValue.Factory("Механика"),
                            UsedAxisAllow = RecognizedValue.Factory("0")
                        }
                    },
                    #endregion
                    CargoCharacter = RecognizedValue.Factory("Делимый"),
                    CargoType = RecognizedValue.Factory("Грунт"),
                    LegalWeight = RecognizedValue.Factory("32"),
                    ValetWeight = RecognizedValue.Factory("32"),
                    FactWeight = RecognizedValue.Factory("32,12"),
                    CargoSpecialAllow = RecognizedValue.Factory("0"),
                    PercentWeightOverflow = RecognizedValue.Factory("0"),
                    LegLength = RecognizedValue.Factory("0"),
                    OtherViolation = RecognizedValue.Factory(""),
                    Pass = RecognizedValue.Factory(""),
                    DriverExplanation = RecognizedValue.Factory("")
                },

                #endregion

                #region Водитель

                Driver = new RawDriverInfo
                {
                    DriversLicenseNumber = RecognizedValue.Factory("50 50 357498"),
                    FnMnSname = RecognizedValue.Factory("Иванов Иван Иванович"),
                    GetingMark = RecognizedValue.Factory("Получено"),
                    GibddName = RecognizedValue.Factory("Сергеев Сергей Сергеевич"),
                    OperatorName = RecognizedValue.Factory("Юров Юрий Юрьевич")
                },

                #endregion

                #region ТС

                Vehicle = new RawVehicleInfo
                {
                    #region Общая информация

                    Detail = new List<RawVehicleDetail>
                    {
                        new RawVehicleDetail
                        {
                            VehicleType = RecognizedValue.Factory("Тягач"),
                            VehicleBrand = RecognizedValue.Factory("Камаз"),
                            VehicleModel = RecognizedValue.Factory("3145"),
                            StateNumber = RecognizedValue.Factory("Т2315Т50")
                        },
                        new RawVehicleDetail
                        {
                            VehicleType = RecognizedValue.Factory("Прицеп"),
                            VehicleBrand = RecognizedValue.Factory("ФАВ"),
                            VehicleModel = RecognizedValue.Factory("П-12"),
                            StateNumber = RecognizedValue.Factory("ТА231450")
                        }
                    },

                    #endregion

                    FederalHighwaysDistance = RecognizedValue.Factory("600"),
                    VehicleCompanyAddress = RecognizedValue.Factory("Мск."),
                    VehicleCountry = RecognizedValue.Factory("Россия"),
                    VehicleOwner = RecognizedValue.Factory("Рога и копыта"),
                    VehicleRoute = RecognizedValue.Factory("Москва - Питер"),
                    VehicleShipper = RecognizedValue.Factory("Ромашка"),
                    VehicleSubjectCode = RecognizedValue.Factory("50")
                }

                #endregion
            };

            return act.ToJson();
        }
    }
}
