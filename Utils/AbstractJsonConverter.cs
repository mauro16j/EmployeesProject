using Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace Utils
{
    public abstract class AbstractJsonConverter<T> : JsonConverter
    {
        protected abstract T Create(Type objectType, JObject jObject);

        /// <summary>
        /// Metodo que puede determina si el objeto se puede convertir al tipo determinado
        /// </summary>
        /// <param name="objectType"></param>
        /// <returns></returns>
        public override bool CanConvert(Type objectType)
        {
            return typeof(T).IsAssignableFrom(objectType);
        }

        /// <summary>
        /// Metodo para leer Json
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="objectType"></param>
        /// <param name="existingValue"></param>
        /// <param name="serializer"></param>
        /// <returns></returns>
        public override object ReadJson(
            JsonReader reader,
            Type objectType,
            object existingValue,
            JsonSerializer serializer)
        {
            var jObject = JObject.Load(reader);

            T target = Create(objectType, jObject);
            serializer.Populate(jObject.CreateReader(), target);

            return target;
        }

        public override void WriteJson(
            JsonWriter writer,
            object value,
            JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Metodo que valida si existe un campo en JSON y devuelve su valor si existe
        /// </summary>
        /// <param name="jObject"></param>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <returns>elemento Diccionario con objeto JSON y campo</returns>
        protected static Dictionary<JObject, string> ValueFieldExists(
            JObject jObject,
            string name,
            JTokenType type)
        {
            JToken token;
            var keyValue = new Dictionary<JObject, string>();
            if (jObject.TryGetValue(name, out token) && token.Type == type)
            {
                string empType = token.Value<string>();
                keyValue.Add(jObject, empType);
                return keyValue;
            }                

            return null;
        }
    }

    
}
