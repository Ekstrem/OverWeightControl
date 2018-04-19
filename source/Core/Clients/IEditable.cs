namespace OverWeightControl.Core.Clients
{
    /// <summary>
    /// Интерфейс манипуляции на формах и контролах.
    /// </summary>
    /// <typeparam name="TEditableEntity">Редактируемая сущность.</typeparam>
    public interface IEditable<TEditableEntity>
    {
        /// <summary>
        /// Загрузка данных в контрол.
        /// </summary>
        /// <param name="data">Обновляемые данные.</param>
        bool LoadData(TEditableEntity data);

        /// <summary>
        /// Получение данных из контрола после редактирования.
        /// </summary>
        /// <returns>Обновляемые данные.</returns>
        TEditableEntity UpdateData();
    }
}