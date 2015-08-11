using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;
#if !WINDOWS_PHONE
using System.Runtime.Serialization.Formatters.Binary;
#endif

namespace SuperMap.Connector.Utility
{
    internal class HashKeyHelper
    {
        private const string c_dictionary = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        public static string GetHashKey<T>(T obj)
        {
            if (obj == null)
            {
                return string.Empty;
            }
#if !WINDOWS_PHONE
            using (MD5 md5 = new MD5CryptoServiceProvider())
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(ms, obj);
                    ms.Position = 0;
                    byte[] hashedBytes = md5.ComputeHash(ms);
                    string hashedString = ConvertBytesToString(hashedBytes);
                    return hashedString;
                }
            }
#else
            //先转成json字符串再序列化
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
            System.Runtime.Serialization.DataContractSerializer serializer = new System.Runtime.Serialization.DataContractSerializer(typeof(string));
            using (MemoryStream ms = new MemoryStream())
            {
                serializer.WriteObject(ms, json);
                ms.Position = 0;
                byte[] hashBytes = ms.ToArray();
                return ConvertBytesToString(hashBytes);
            }
#endif
        }

        private static string ConvertBytesToString(byte[] bytes)
        {
            List<ulong> numbers = new List<ulong>();
            // byte为8位，ulong为64位。所以每8个byte转换为1个ulong。
            for (int i = 8; i <= bytes.Length; i += 8)
            {
                ulong value = 0;
                for (int j = 0; j < 8; j++)
                {
                    value += bytes[i - j - 1] * (ulong)Math.Pow(256, j);
                }
                numbers.Add(value);
            }
            if (bytes.Length % 8 != 0)
            {
                ulong lastValue = 0;
                for (int i = bytes.Length - bytes.Length % 8; i < bytes.Length; i++)
                {
                    lastValue += bytes[i] * (ulong)Math.Pow(256, (bytes.Length - i - 1));
                }
                numbers.Add(lastValue);
            }

            StringBuilder sb = new StringBuilder();
            foreach (ulong number in numbers)
            {
                string hex = ConvertNumberToCustomHex(number, 36);
                sb.Append(hex);
            }

            string text = sb.ToString();
            return text;
        }

        internal static string ConvertNumberToCustomHex(ulong input, uint customHex)
        {
            if (customHex < 2 || customHex > c_dictionary.Length)
            {
                throw new ArgumentOutOfRangeException("customHex");
            }

            //bool isNegative = (input < 0);
            //if (input < 0)
            //{
            //    input = -input;
            //}

            string output = string.Empty;
            while (input >= customHex)
            {
                int mod = (int)(input % customHex);
                char code = c_dictionary[mod];
                output = code + output;
                input = input / customHex;
            }
            char lastCode = c_dictionary[(int)input];
            output = lastCode + output;
            //if (isNegative)
            //{
            //    output = "-" + output;
            //}
            return output;
        }
    }
}
