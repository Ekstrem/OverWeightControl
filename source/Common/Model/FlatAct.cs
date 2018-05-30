using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace OverWeightControl.Common.Model
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
        public string ActDateTime { get; set; }

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
    }
}