using System.Collections.Generic;

namespace OverWeightControl.Core.FileTransfer.WorkFlow
{
    /// <summary>
    /// Интерфейс обработки файлов.
    /// </summary>

    public interface IWorkFlowProducerConsumer
    {
        /// <summary>
        ///   Пытается добавить объект в коллекцию <see cref="T:System.Collections.Concurrent.IProducerConsumerCollection`1" />.
        /// </summary>
        /// <param name="item">
        ///   Объект, добавляемый в коллекцию <see cref="T:System.Collections.Concurrent.IProducerConsumerCollection`1" />.
        /// </param>
        /// <returns>
        ///   Значение true, если объект был успешно добавлен; в противном случае — значение false.
        /// </returns>
        /// <exception cref="T:System.ArgumentException">
        ///   <paramref name="item" /> Недопустим для данной коллекции.
        /// </exception>
        bool TryAdd(FileTransferInfo item);

        /// <summary>
        ///   Пытается удалить и вернуть объект из коллекции <see cref="T:System.Collections.Concurrent.IProducerConsumerCollection`1" />.
        /// </summary>
        /// <param name="item">
        ///   При возвращении данного метода, если объект был успешно удален и возвращен, <paramref name="item" /> содержит удаленный объект.
        ///    Если объект, доступный для удаления, не найден, значение не определено.
        /// </param>
        /// <returns>
        ///   значение true, если объект был успешно удален и возвращен; в противном случае — значение false.
        /// </returns>
        bool TryTake(out FileTransferInfo item);

        /// <summary>
        /// Рабочий процесс по передаче(обработке). файлов.
        /// </summary>
        void WorkFlow();

        /// <summary>
        /// Производит поиск и копирование новых файлов
        /// в дирректории сканирования.
        /// </summary>
        /// <returns>Список информации о файлах.</returns>
        IEnumerable<FileTransferInfo> LoadFiles();
        
        /// <summary>
        /// Токен отмены.
        /// </summary>
        WorkFlowCancelationToken CancelationToken { get; set; }

        /// <summary>
        /// Колличество файлов на обработке
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Получение статистики.
        /// </summary>
        /// <returns></returns>
        IDictionary<string, int> GetStatistic();
    }
}