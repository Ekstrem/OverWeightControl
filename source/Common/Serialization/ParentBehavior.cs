using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace OverWeightControl.Common.Serialization
{
    /// <summary>
    /// Базовый класс.
    /// </summary>
    /// <typeparam name="TEntity">Дочерний класс.</typeparam>
    public class ParentBehavior<TEntity> : IJsonSerialization<TEntity>
    {
        protected ParentBehavior()
        {
            Id = Guid.NewGuid();
        }

        /// <summary>
        /// Unique identifier.
        /// </summary>
        [JsonProperty]
        public Guid Id { get; set; }

        /// <summary>
        /// Загрузка файла из json-строки
        /// </summary>
        /// <param name="json"></param>
        /// <returns>Десереализованный объект.</returns>
        public TEntity LoadFromJson(string json)
        {
            var jss = new JsonSerializerSettings { Formatting = Formatting.Indented };
            var obj = JsonConvert
                .DeserializeObject<TEntity>(json, jss);
            return obj;
        }

        /// <summary>
        /// Загрузка тэга из json.
        /// </summary>
        /// <param name="json">json представление объекта.</param>
        /// <param name="tag">Тэг для чтения.</param>
        /// <returns>Свойство по тэгу.</returns>
        public object LinqToJson(string json, string tag)
        {
            return JObject.Parse(json)[tag];
        }

        /// <summary>
        /// Сохранение в json-формат.
        /// </summary>
        /// <returns>json строка.</returns>
        public string ToJson()
        {
            var jss = new JsonSerializerSettings {Formatting = Formatting.Indented};
            return JsonConvert.SerializeObject(this, jss);
        }
    }
}
