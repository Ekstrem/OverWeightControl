namespace OverWeightControl.Common.Serialization
{
    /// <summary>
    /// Интерфейс сериализации.
    /// </summary>
    /// <typeparam name="TEntity">Объект сериализации.</typeparam>
    public interface IJsonSerialization<TEntity>
    {
        /// <summary>
        /// Загрузка файла из json-строки
        /// </summary>
        /// <param name="json"></param>
        /// <returns>Десереализованный объект.</returns>
        TEntity LoadFromJson(string json);

        /// <summary>
        /// Загрузка тэга из json.
        /// </summary>
        /// <param name="json">json представление объекта.</param>
        /// <param name="tag">Тэг для чтения.</param>
        /// <returns>Свойство по тэгу.</returns>
        object LinqToJson(string json, string tag);

        /// <summary>
        /// Сохранение в json-формат.
        /// </summary>
        /// <param name="entity">Сохраняемый объект.</param>
        /// <returns>json строка.</returns>
        string ToJson();
    }
}