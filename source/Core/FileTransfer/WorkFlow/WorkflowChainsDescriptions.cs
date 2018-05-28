using System;
using System.Collections.Generic;
using OverWeightControl.Core.FileTransfer.Client;
using OverWeightControl.Core.FileTransfer.RecognitionServer;
using OverWeightControl.Core.FileTransfer.Server;

namespace OverWeightControl.Core.FileTransfer.WorkFlow
{
    internal static class WorkflowChainsDescriptions
    {
        private static IDictionary<Type, string> dict;
        private static IDictionary<Type, string> GetDictinary()
        {
            return dict ?? (dict = new Dictionary<Type, string>
            {
                {typeof(FinderFiles), "Копирование отсканированных файлов"},
                {typeof(BufferedFiles), "Загрузка файлов в память"},
                {typeof(Md5HashComputerFiles), "Подсчёт хэша файлов"},
                {typeof(CompresserFiles), "Сжатие файлов"},
                {typeof(UnCompresserFiles), "Разжатие файлов"},
                {typeof(SenderFiles), "Отправка файлов на сервер" },
                {typeof(RecivingFiles), "Получено файлов" },
                {typeof(SaveForAfcFiles), "Сохраненние файлов для AFC" },
                {typeof(DeleteFiles), "Удаление файлов" },
                {typeof(BackUpFiles), "Копирование в BackUp" },
                {typeof(FinalizeFiles), "Очистка очереди" },
                {typeof(JsonReadFiles), "Загружено файлов для верификации" }
            });
        }

        public static string GetDescription<T>() => dict[typeof(T)];
        public static string GetDescription(Type type) => dict[type];
    }
}