using System;
using System.Collections.Generic;
using OverWeightControl.Core.FileTransfer;
using OverWeightControl.Core.FileTransfer.Client;
using OverWeightControl.Core.FileTransfer.RecognitionServer;
using OverWeightControl.Core.FileTransfer.Server;

namespace OverWeightControl.Core.Settings
{
    public static class ArgsKeyList
    {
        public static string ScanPath = nameof(ScanPath);
        public static string StorePath = nameof(StorePath);
        public static string BackUpPath = nameof(BackUpPath);
        public static string ArgsFileLocation = nameof(ArgsFileLocation);
        public static string IsDebugMode = nameof(IsDebugMode);
        public static string WFProcWaitingFor = nameof(WFProcWaitingFor);
        public static string ServerName = nameof(ServerName);
        public static string Port = nameof(Port);
        public static string ScanExt = nameof(ScanExt);
        public static string AfcPath = nameof(AfcPath);
        public static string ConnectionString = nameof(ConnectionString);
        public static string Mode = nameof(Mode);
        public static string Binding = nameof(Binding);
        public static string Version = nameof(Version);
        public static string HandValidation = nameof(HandValidation);
        public static string QueuesSize = nameof(QueuesSize);
        public static string PpvkName = nameof(PpvkName);
    }

    public static class ConfigurationKeyDescription
    {
        private static IDictionary<string, string> _dict;
        private static IDictionary<string, string> GetDictinary()
        {
            return _dict ?? (_dict = new Dictionary<string, string>
            {
                {ArgsKeyList.ScanPath, "Папка поиска файлов."},
                {ArgsKeyList.StorePath, "Папка временного размещения файлов."},
                {ArgsKeyList.BackUpPath, "Папка резерного копирования."},
                {ArgsKeyList.AfcPath, "Папка из которой AFC ведёт распознавание."},
                {ArgsKeyList.ArgsFileLocation, "Путь к файлу настройки."},
                {ArgsKeyList.IsDebugMode, "Режим отладки."},
                {ArgsKeyList.WFProcWaitingFor, "Частота обновления процессов, в сек."},
                {ArgsKeyList.ServerName, "Адрес сервера."},
                {ArgsKeyList.Port, "Порт сервера."},
                {ArgsKeyList.ScanExt, "Искомые расширения файлов"},
                {ArgsKeyList.ConnectionString, "Строка подключения к БД"},
                {ArgsKeyList.Mode, "Модель десериализации."},
                {ArgsKeyList.Binding, "Биндинг привязки."},
                {ArgsKeyList.Version, "Текущая версия пакета обновлений."},
                {ArgsKeyList.HandValidation, "Ручная потоковая верификация."},
                {ArgsKeyList.QueuesSize, "Максимальный размер очереди в обработчике."},
                {ArgsKeyList.PpvkName, "Имя текущего ПВК."}
            });
        }

        public static string GetDescription(string key)
        {
            return GetDictinary().ContainsKey(key) ? GetDictinary()[key] : String.Empty;
        }
    }
}
