﻿using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.COMMON.Tools
{
    public static class SessionExtension
    {
        public static void SetObject(this ISession session, string key, object value)
        {
            string objectString = JsonConvert.SerializeObject(value);
            session.SetString(key, objectString);
        }

        public static T GetObject<T>(this ISession session, string key) where T : class //T(T bir referans tip olmak zorundadır)
        {
            string objectString = session.GetString(key);

            if (string.IsNullOrEmpty(objectString))
            {
                return null;
            }

            T deserializedObject = JsonConvert.DeserializeObject<T>(objectString);
            return deserializedObject;
        }
    }
}
