using System;
using System.Collections.Generic;
using OverWeightControl.Core.FileTransfer.Client;
using OverWeightControl.Core.FileTransfer.RecognitionServer;
using OverWeightControl.Core.FileTransfer.Server;

namespace OverWeightControl.Core.FileTransfer.WorkFlow
{
    public static class WorkflowChainDescription
    {
        private static IDictionary<Type, string> _dict;
        private static IDictionary<Type, string> GetDictinary()
        {
            return _dict ?? (_dict = new Dictionary<Type, string>
            {
                {typeof(FinderFiles), "Поиск файлов в директории \"ScanPath\""},
                {typeof(BufferedFiles), "Загрузка файлов в память"},
                {typeof(Md5HashComputerFiles), "Подсчёт хэша файлов"},
                {typeof(CompresserFiles), "Сжатие файлов"},
                {typeof(UnCompresserFiles), "Разжатие файлов"},
                {typeof(SenderFiles), "Отправка файлов на сервер" },
                {typeof(RecivingFiles), "Получение файлов" },
                {typeof(SaveFileInfo), "Сохраненние информации о переданном файле" },
                {typeof(SaveForAfcFiles), "Сохраненние файлов для AFC в \"AcfPath\"" },
                {typeof(DeleteFiles), "Удаление файлов" },
                {typeof(BackUpFiles), "Копирование в \"BackUpPath\"" },
                {typeof(FinalizeFiles), "Очистка очереди" },
                {typeof(JsonReadFiles), "Загружено файлов для верификации" }
            });
        }

        public static string GetDescription(Type type)
        {
            return GetDictinary().ContainsKey(type) ? GetDictinary()[type] : String.Empty;
        }
    }
}