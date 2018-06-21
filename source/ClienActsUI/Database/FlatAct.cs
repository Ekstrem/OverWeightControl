using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Windows.Forms;
using Newtonsoft.Json;
using OverWeightControl.Clients.ActsUI.Tools;
using OverWeightControl.Common.Model;
using OverWeightControl.Core.Console;

namespace OverWeightControl.Clients.ActsUI.Database
{
    /// <summary>
    /// Класс со всеми полями
    /// для удобного биндинга.
    /// </summary>
    [JsonObject]
    public class FlatAct
    {
        public static FlatAct Expand(Act act)
        {
            try
            {
                return new FlatAct
                {
                    Id = act.Id,
                    ActNumber = act.ActNumber,
                    ActDateTime = act.ActDateTime,
                    PpvkNumber = act.PpvkNumber,
                    WeightPoint = act.WeightPoint,

                    WeigherNumber = act?.Weighter?.WeigherNumber,
                    VerificationDate = act?.Weighter?.VerificationDate,
                    CertificateNumber = act?.Weighter?.CertificateNumber,
                    ViolationNature = act?.Weighter?.ViolationNature,
                    ViolationKoap = act?.Weighter?.ViolationKoap,

                    VehicleOwner = act?.Vehicle?.VehicleOwner,
                    VehicleCountry = act?.Vehicle?.VehicleCountry,
                    VehicleSubjectCode = act?.Vehicle?.VehicleSubjectCode,
                    VehicleCompanyAddress = act?.Vehicle?.VehicleCompanyAddress,
                    VehicleRoute = act?.Vehicle?.VehicleRoute,
                    VehicleShipper = act?.Vehicle?.VehicleShipper,
                    FederalHighwaysDistance = act?.Vehicle?.FederalHighwaysDistance,
                    CarriageType = act?.Vehicle?.CarriageType,

                    FnMnSname = act?.Driver?.FnMnSname,
                    DriversLicenseNumber = act?.Driver?.DriversLicenseNumber,
                    OperatorName = act?.Driver?.OperatorName,
                    GibddName = act?.Driver?.GibddName,
                    GetingMark = act?.Driver?.GetingMark,

                    CargoCharacter = act?.Cargo?.CargoCharacter,
                    CargoType = act?.Cargo?.CargoType,
                    LegalWeight = act?.Cargo?.LegalWeight,
                    ValetWeight = act?.Cargo?.ValetWeight,
                    FactWeight = act?.Cargo?.FactWeight,
                    PercentWeightOverflow = act?.Cargo?.PercentWeightOverflow,
                    CargoSpecialAllow = act?.Cargo?.CargoSpecialAllow,
                    RoadSection = act?.Cargo?.RoadSection,
                    Tariffs = act?.Cargo?.Tariffs,
                    LegLength = act?.Cargo?.LegLength,
                    Pass = act?.Cargo?.Pass,
                    OtherViolation = act?.Cargo?.OtherViolation,
                    DriverExplanation = act?.Cargo?.DriverExplanation
                };
            }
            catch(Exception)
            {
                return null;
            }
        }

        #region Act

        /// <summary>
        /// Id акта.
        /// </summary>
        [DisplayName("ID")]
        [JsonProperty(Order = 1)]
        public Guid Id { get; set; }

        /// <summary>
        /// Номер акта.
        /// </summary>
        [DisplayName("Номер акта.")]
        [JsonProperty(Order = 2)]
        public int? ActNumber { get; set; }

        /// <summary>
        /// Дата Акта.
        /// DD.MM.YYYY
        /// </summary>
        [DisplayName("Дата Акта.")]
        [JsonProperty(Order = 3)]
        [StringLength(20)]
        public DateTime ActDateTime { get; set; }

        /// <summary>
        /// Номер ППВК.
        /// value>0.
        /// </summary>
        [DisplayName("Номер ППВК.")]
        [JsonProperty(Order = 4)]
        public int PpvkNumber { get; set; }

        /// <summary>
        /// Место проведения контроля (взвешивания).
        /// </summary>
        [DisplayName("Место проведения контроля (взвешивания).")]
        [JsonProperty(Order = 5)]
        [StringLength(100)]
        public string WeightPoint { get; set; }

        #endregion

        #region Weighter

        /// <summary>
        /// Номер весов.
        /// </summary>
        [DisplayName("№ весов.")]
        [JsonProperty(Order = 6)]
        [StringLength(20)]
        public string WeigherNumber { get; set; }

        /// <summary>
        /// Дата поверки.
        /// DD.MM.YYYY
        /// </summary>
        [DisplayName("Дата поверки весов.")]
        [JsonProperty(Order = 7)]
        [StringLength(10)]
        public string VerificationDate { get; set; }

        /// <summary>
        /// Номер свидетельства (клейма).
        /// </summary>
        [DisplayName("№ свидетельства.")]
        [JsonProperty(Order = 8)]
        [StringLength(20)]
        public string CertificateNumber { get; set; }

        /// <summary>
        /// Характер нарушения.
        /// </summary>
        [DisplayName("Характер нарушения.")]
        [JsonProperty(Order = 9)]
        [StringLength(100)]
        public string ViolationNature { get; set; }

        /// <summary>
        /// КоАП РФ.
        /// Ст. 12.21.1 ч.1 - 11
        /// </summary>
        [DisplayName("КоАП РФ.")]
        [JsonProperty(Order = 10)]
        [StringLength(15)]
        public string ViolationKoap { get; set; }

        #endregion

        #region Vehicle

        /// <summary>
        /// Наименование владельца (собственника) ТС,
        /// осуществляющего перевозку тяжеловесного груза.
        /// </summary>
        [DisplayName("Наименование владельца (собственника) ТС")]
        [JsonProperty(Order = 11)]
        [StringLength(100)]
        public string VehicleOwner { get; set; }

        /// <summary>
        /// Страна регистрации.
        /// </summary>
        [DisplayName("Страна регистрации")]
        [JsonProperty(Order = 12)]
        [StringLength(25)]
        public string VehicleCountry { get; set; }

        /// <summary>
        /// Код субъекта.
        /// </summary>
        [DisplayName("Код субъекта")]
        [JsonProperty(Order = 13)]
        public int? VehicleSubjectCode { get; set; }

        /// <summary>
        /// Адрес организации.
        /// </summary>
        [DisplayName("Адрес организации")]
        [JsonProperty(Order = 14)]
        [StringLength(150)]
        public string VehicleCompanyAddress { get; set; }

        /// <summary>
        /// Маршрут движения.
        /// </summary>
        [DisplayName("Маршрут движения")]
        [JsonProperty(Order = 15)]
        [StringLength(25)]
        public string VehicleRoute { get; set; }

        /// <summary>
        /// Грузоотправитель
        /// </summary>
        [DisplayName("Грузоотправитель")]
        [JsonProperty(Order = 16)]
        [StringLength(25)]
        public string VehicleShipper { get; set; }

        /// <summary>
        /// Пройдено расстояние по федеральным трассам
        /// </summary>
        [DisplayName("Пройдено расстояние по федеральным трассам")]
        [JsonProperty(Order = 17)]
        [StringLength(25)]
        public string FederalHighwaysDistance { get; set; }

        /// <summary>
        /// Вид перевозки.
        /// </summary>
        [DisplayName("Вид перевозки")]
        [JsonProperty(Order = 19)]
        [StringLength(25)]
        public string CarriageType { get; set; }

        #endregion

        #region Driver

        /// <summary>
        /// Ф.И.О.
        /// </summary>
        [DisplayName("Ф.И.О.")]
        [JsonProperty(Order = 20)]
        [StringLength(150)]
        public string FnMnSname { get; set; }

        /// <summary>
        /// № водительского удостоверения.
        /// </summary>
        [DisplayName("№ ВУ")]
        [JsonProperty(Order = 21)]
        [StringLength(20)]
        public string DriversLicenseNumber { get; set; }

        /// <summary>
        /// Ф.И.О. оператора ППВК.
        /// </summary>
        [DisplayName("Ф.И.О. оператора ППВК")]
        [JsonProperty(Order = 22)]
        [StringLength(50)]
        public string OperatorName { get; set; }

        /// <summary>
        /// Ф.И.О сотрудника ГИБДД.
        /// </summary>
        [DisplayName("Ф.И.О сотрудника ГИБДД")]
        [JsonProperty(Order = 23)]
        [StringLength(50)]
        public string GibddName { get; set; }

        /// <summary>
        /// Отметка о получении копии акта водителем.
        /// </summary>
        [DisplayName("Отметка о получении копии акта водителем")]
        [JsonProperty(Order = 24)]
        [StringLength(10)]
        public string GetingMark { get; set; }

        #endregion

        #region Cargo

        /// <summary>
        /// Характеристика груза.
        /// </summary>
        [DisplayName("Характеристика груза")]
        [JsonProperty(Order = 25)]
        [StringLength(20)]
        public string CargoCharacter { get; set; }

        /// <summary>
        /// Вид груза.
        /// </summary>
        [DisplayName("Вид груза")]
        [JsonProperty(Order = 26)]
        [StringLength(30)]
        public string CargoType { get; set; }

        /// <summary>
        /// Нормативная масса.
        /// </summary>
        [DisplayName("Нормативная масса")]
        [JsonProperty(Order = 27)]
        public float? LegalWeight { get; set; }

        /// <summary>
        /// Допустимая масса.
        /// </summary>
        [DisplayName("Допустимая масса")]
        [JsonProperty(Order = 28)]
        public float? ValetWeight { get; set; }

        /// <summary>
        /// Фактическая масса.
        /// </summary>
        [DisplayName("Фактическая масса")]
        [JsonProperty(Order = 29)]
        public float? FactWeight { get; set; }

        /// <summary>
        /// Процент перевеса.
        /// </summary>
        [DisplayName("Процент перевеса")]
        [JsonProperty(Order = 30)]
        public float? PercentWeightOverflow { get; set; }

        /// <summary>
        /// Специальное разрешение.
        /// </summary>
        [DisplayName("Специальное разрешение")]
        [JsonProperty(Order = 31)]
        public float? CargoSpecialAllow { get; set; }

        /// <summary>
        /// Участок дороги.
        /// </summary>
        [DisplayName("Участок дороги")]
        [JsonProperty(Order = 32)]
        [StringLength(50)]
        public string RoadSection { get; set; }

        /// <summary>
        /// Тарифы. Указаны за 100км.
        /// </summary>
        [DisplayName("Тарифы")]
        [JsonProperty(Order = 33)]
        public int? Tariffs { get; set; }

        /// <summary>
        /// Длина участка.
        /// </summary>
        [DisplayName("Длина участка")]
        [JsonProperty(Order = 34)]
        public float? LegLength { get; set; }
        
        /// <summary>
        /// Сведения о ГТС в реестре действующих пропусков,
        /// предоставляющих право она въезд и передвижение
        /// в зонах ограничения движения по г. Москва.
        /// </summary>
        [DisplayName("Сведения о ГТС")]
        [JsonProperty(Order = 35)]
        [StringLength(15)]
        public string Pass { get; set; }

        /// <summary>
        /// Другие нарушения.
        /// </summary>
        [DisplayName("Другие нарушения")]
        [JsonProperty(Order = 36)]
        [StringLength(50)]
        public string OtherViolation { get; set; }

        /// <summary>
        /// Объяснение водителя.
        /// </summary>
        [DisplayName("Объяснение водителя")]
        [JsonProperty(Order = 37)]
        [StringLength(250)]
        public string DriverExplanation { get; set; }

        #endregion

        /// <summary>
        ///   Определяет, равен ли заданный объект текущему объекту.
        /// </summary>
        /// <param name="obj">
        ///   Объект, который требуется сравнить с текущим объектом.
        /// </param>
        /// <returns>
        ///   Значение <see langword="true" />, если указанный объект равен текущему объекту; в противном случае — значение <see langword="false" />.
        /// </returns>
        public override bool Equals(object obj)
        {
            try
            {
                return ((FlatAct) obj).Id == Id
                       && ((FlatAct) obj).ActNumber == ActNumber
                       && ((FlatAct) obj).ActDateTime == ActDateTime
                       && ((FlatAct) obj).PpvkNumber == PpvkNumber
                       && ((FlatAct) obj).WeightPoint == WeigherNumber
                       && ((FlatAct) obj).WeigherNumber == WeigherNumber
                       && ((FlatAct) obj).VerificationDate == VerificationDate
                       && ((FlatAct) obj).CertificateNumber == CertificateNumber
                       && ((FlatAct) obj).ViolationNature == ViolationNature
                       && ((FlatAct) obj).ViolationKoap == ViolationKoap
                       && ((FlatAct) obj).VehicleOwner == VehicleOwner
                       && ((FlatAct) obj).VehicleCountry == VehicleCountry
                       && ((FlatAct) obj).VehicleSubjectCode == VehicleSubjectCode
                       && ((FlatAct) obj).VehicleCompanyAddress == VehicleCompanyAddress
                       && ((FlatAct) obj).VehicleRoute == VehicleRoute
                       && ((FlatAct) obj).VehicleShipper == VehicleShipper
                       && ((FlatAct) obj).FederalHighwaysDistance == FederalHighwaysDistance
                       && ((FlatAct) obj).CarriageType == CarriageType
                       && ((FlatAct) obj).FnMnSname == FnMnSname
                       && ((FlatAct) obj).DriversLicenseNumber == DriversLicenseNumber
                       && ((FlatAct) obj).OperatorName == OperatorName
                       && ((FlatAct) obj).GibddName == GibddName
                       && ((FlatAct) obj).GetingMark == GetingMark
                       && ((FlatAct) obj).CargoCharacter == CargoCharacter
                       && ((FlatAct) obj).CarriageType == CarriageType
                       && ((FlatAct) obj).LegalWeight == LegalWeight
                       && ((FlatAct) obj).ValetWeight == ValetWeight
                       && ((FlatAct) obj).FactWeight == FactWeight
                       && ((FlatAct) obj).PercentWeightOverflow == PercentWeightOverflow
                       && ((FlatAct) obj).CargoSpecialAllow == CargoSpecialAllow
                       && ((FlatAct) obj).RoadSection == RoadSection
                       && ((FlatAct) obj).Tariffs == Tariffs
                       && ((FlatAct) obj).LegLength == LegLength
                       && ((FlatAct) obj).Pass == Pass
                       && ((FlatAct) obj).OtherViolation == OtherViolation
                       && ((FlatAct) obj).DriverExplanation == DriverExplanation;

            }
            catch (Exception e)
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            var hashCode = -845150336;
            hashCode = hashCode * -1521134295 + EqualityComparer<Guid>.Default.GetHashCode(Id);
            hashCode = hashCode * -1521134295 + EqualityComparer<int?>.Default.GetHashCode(ActNumber);
            hashCode = hashCode * -1521134295 + ActDateTime.GetHashCode();
            hashCode = hashCode * -1521134295 + PpvkNumber.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(WeightPoint);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(WeigherNumber);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(VerificationDate);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CertificateNumber);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ViolationNature);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ViolationKoap);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(VehicleOwner);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(VehicleCountry);
            hashCode = hashCode * -1521134295 + EqualityComparer<int?>.Default.GetHashCode(VehicleSubjectCode);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(VehicleCompanyAddress);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(VehicleRoute);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(VehicleShipper);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(FederalHighwaysDistance);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CarriageType);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(FnMnSname);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(DriversLicenseNumber);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(OperatorName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(GibddName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(GetingMark);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CargoCharacter);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CargoType);
            hashCode = hashCode * -1521134295 + EqualityComparer<float?>.Default.GetHashCode(LegalWeight);
            hashCode = hashCode * -1521134295 + EqualityComparer<float?>.Default.GetHashCode(ValetWeight);
            hashCode = hashCode * -1521134295 + EqualityComparer<float?>.Default.GetHashCode(FactWeight);
            hashCode = hashCode * -1521134295 + EqualityComparer<float?>.Default.GetHashCode(PercentWeightOverflow);
            hashCode = hashCode * -1521134295 + EqualityComparer<float?>.Default.GetHashCode(CargoSpecialAllow);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(RoadSection);
            hashCode = hashCode * -1521134295 + EqualityComparer<int?>.Default.GetHashCode(Tariffs);
            hashCode = hashCode * -1521134295 + EqualityComparer<float?>.Default.GetHashCode(LegLength);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Pass);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(OtherViolation);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(DriverExplanation);
            return hashCode;
        }

        internal static int LoadToGrid(
            ICollection<FlatAct> data,
            ICollection<ColumnInfo> columns,
            DataGridView actGridView,
            IConsoleService console = null)
        {
            try
            {
                actGridView.Rows.Clear();
                foreach (var flatAct in data)
                {
                    var index = actGridView.Rows.Add();
                    foreach (var e in columns)
                    {
                        actGridView.Rows[index].Cells[e.Name].Value =
                            flatAct.GetType().GetProperty(e.Name)?.GetValue(flatAct, null);
                    }
                }
                
                return data.Count;
            }
            catch (Exception e)
            {
                console?.AddException(e);
                return 0;
            }
        }
    }
}