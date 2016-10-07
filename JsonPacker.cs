using Newtonsoft.Json;

namespace RQEnchant
{
    public static class JsonPacker
    {
        /// <summary>
        /// Сериализовать объект в JSON
        /// </summary>
        /// <typeparam name="T">Тип сериализуемого объекта</typeparam>
        /// <param name="obj">Объект для сериализации</param>
        /// <returns>строка с JSON</returns>
        public static string ToJson<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj, GetSerializationSettings());
        }

        /// <summary>
        /// Десериализовать объект из JSON
        /// </summary>
        /// <typeparam name="T">Тип объекта</typeparam>
        /// <param name="stringData">Строка для десериализации</param>
        /// <returns>Объект, результат десериализации</returns>
        /// <remarks>ATTENTION: Для десериализации требуются дефолтный конструктор и публичные сеттеры</remarks>
        public static T FromJson<T>(string stringData)
        {
            return JsonConvert.DeserializeObject<T>(stringData, GetSerializationSettings());
        }

        private static JsonSerializerSettings GetSerializationSettings()
        {
            return new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                TypeNameHandling = TypeNameHandling.Auto,
            };
        }
    }
}