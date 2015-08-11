using System;
using System.Collections.Generic;
using System.Text;
using SuperMap.Connector.Utility;
using Newtonsoft.Json;

namespace SuperMap.Connector.Utility
{
#if !WINDOWS_PHONE
    internal class DatasetInfoConverter : JsonConverter
#else
    public class DatasetInfoConverter : JsonConverter
#endif
    {
        public override bool CanConvert(Type objectType)
        {
            if (typeof(DatasetInfo) == objectType ||
                typeof(DatasetImageInfo) == objectType ||
                typeof(DatasetGridInfo) == objectType ||
                typeof(DatasetVectorInfo) == objectType)
                return true;
            else return false;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            Dictionary<string, object> datasetInfoValues = serializer.Deserialize<Dictionary<string, object>>(reader);
            if (datasetInfoValues == null) return null;
            DatasetInfo datasetInfo = null;
            if (datasetInfoValues.ContainsKey("recordCount"))
            {
                datasetInfo = new DatasetVectorInfo();
                DatasetVectorInfo datasetVectorInfo = datasetInfo as DatasetVectorInfo;
                int recordCount = 0;
                if (datasetInfoValues.ContainsKey("recordCount") && datasetInfoValues["recordCount"] != null)
                {
                    recordCount = int.Parse(datasetInfoValues["recordCount"].ToString());
                }
                datasetVectorInfo.RecordCount = recordCount;
                bool isFileCache = false;
                if (datasetInfoValues.ContainsKey("isFileCache") && datasetInfoValues["isFileCache"] != null)
                {
                    isFileCache = bool.Parse(datasetInfoValues["isFileCache"].ToString());
                }
                datasetVectorInfo.IsFileCache = isFileCache;
                Charset charset = Charset.ANSI;
                if (datasetInfoValues.ContainsKey("charset") && datasetInfoValues["charset"] != null)
                {
                    charset = (Charset)Enum.Parse(typeof(Charset), datasetInfoValues["charset"].ToString(), false);
                }
                datasetVectorInfo.Charset = charset;
            }
            else if (datasetInfoValues.ContainsKey("isMultiBand"))
            {
                datasetInfo = new DatasetImageInfo();
                DatasetImageInfo datasetImageInfo = datasetInfo as DatasetImageInfo;
                int blockSize = 0;
                if (datasetInfoValues.ContainsKey("blockSize") && datasetInfoValues["blockSize"] != null)
                {
                    blockSize = int.Parse(datasetInfoValues["blockSize"].ToString());
                }
                datasetImageInfo.BlockSize = blockSize;
                int height = 0;
                if (datasetInfoValues.ContainsKey("height") && datasetInfoValues["height"] != null)
                {
                    height = int.Parse(datasetInfoValues["height"].ToString());
                }
                datasetImageInfo.Height = height;
                bool isMultiBand = false;
                if (datasetInfoValues.ContainsKey("isMultiBand") && datasetInfoValues["isMultiBand"] != null)
                {
                    isMultiBand = bool.Parse(datasetInfoValues["isMultiBand"].ToString());
                }
                datasetImageInfo.IsMultiBand = isMultiBand;

                datasetImageInfo.Palette = datasetInfoValues.ContainsKey("palette") && datasetInfoValues["palette"] != null ?
                    JsonConvert.DeserializeObject<Color[]>(datasetInfoValues["palette"].ToString()) : null;
                PixelFormat pixelFormat = PixelFormat.SINGLE;
                if (datasetInfoValues.ContainsKey("pixelFormat") && datasetInfoValues["pixelFormat"] != null)
                {
                    pixelFormat = (PixelFormat)Enum.Parse(typeof(PixelFormat), datasetInfoValues["pixelFormat"].ToString(), false);
                }
                datasetImageInfo.PixelFormat = pixelFormat;
                int width = 0;
                if (datasetInfoValues.ContainsKey("width") && datasetInfoValues["width"] != null)
                {
                    width = int.Parse(datasetInfoValues["width"].ToString());
                }
                datasetImageInfo.Width = width;
            }
            else if (datasetInfoValues.ContainsKey("noValue"))
            {
                datasetInfo = new DatasetGridInfo();
                DatasetGridInfo datasetGridInfo = datasetInfo as DatasetGridInfo;
                int blockSize = 0;
                if (datasetInfoValues.ContainsKey("blockSize") && datasetInfoValues["blockSize"] != null)
                {
                    blockSize = int.Parse(datasetInfoValues["blockSize"].ToString());
                }
                datasetGridInfo.BlockSize = blockSize;
                int height = 0;
                if (datasetInfoValues.ContainsKey("height") && datasetInfoValues["height"] != null)
                {
                    height = int.Parse(datasetInfoValues["height"].ToString());
                }
                datasetGridInfo.Height = height;
                double maxValue = 0.0;
                if (datasetInfoValues.ContainsKey("maxValue") && datasetInfoValues["maxValue"] != null)
                {
                    maxValue = double.Parse(datasetInfoValues["maxValue"].ToString());
                }
                datasetGridInfo.MaxValue = maxValue;
                double minValue = 0.0;
                if (datasetInfoValues.ContainsKey("minValue") && datasetInfoValues["minValue"] != null)
                {
                    maxValue = double.Parse(datasetInfoValues["minValue"].ToString());
                }
                datasetGridInfo.MinValue = minValue;
                double noValue = 0.0;
                if (datasetInfoValues.ContainsKey("noValue") && datasetInfoValues["noValue"] != null)
                {
                    noValue = double.Parse(datasetInfoValues["noValue"].ToString());
                }
                datasetGridInfo.NoValue = noValue;
                PixelFormat pixelFormat = PixelFormat.SINGLE;
                if (datasetInfoValues.ContainsKey("pixelFormat") && datasetInfoValues["pixelFormat"] != null)
                {
                    pixelFormat = (PixelFormat)Enum.Parse(typeof(PixelFormat), datasetInfoValues["pixelFormat"].ToString(), false);
                }
                datasetGridInfo.PixelFormat = pixelFormat;
                int width = 0;
                if (datasetInfoValues.ContainsKey("width") && datasetInfoValues["width"] != null)
                {
                    width = int.Parse(datasetInfoValues["width"].ToString());
                }
                datasetGridInfo.Width = width;
            }
            else
            {
                datasetInfo = new DatasetInfo();
            }
            datasetInfo.Bounds = datasetInfoValues.ContainsKey("bounds") && datasetInfoValues["bounds"] != null ?
                JsonConvert.DeserializeObject<Rectangle2D>(datasetInfoValues["bounds"].ToString()) : null;
            datasetInfo.DataSourceName = datasetInfoValues.ContainsKey("dataSourceName") && datasetInfoValues["dataSourceName"] != null ? datasetInfoValues["dataSourceName"].ToString() : "";
            datasetInfo.Description = datasetInfoValues.ContainsKey("description") && datasetInfoValues["description"] != null ? datasetInfoValues["description"].ToString() : "";
            EncodeType encodeType = EncodeType.NONE;
            if (datasetInfoValues.ContainsKey("encodeType") && datasetInfoValues["encodeType"] != null)
            {
                encodeType = (EncodeType)Enum.Parse(typeof(EncodeType), datasetInfoValues["encodeType"].ToString(), false);
            }
            datasetInfo.EncodeType = encodeType;
            bool isReadOnly = true;
            if (datasetInfoValues.ContainsKey("isReadOnly") && datasetInfoValues["isReadOnly"] != null)
            {
                isReadOnly = bool.Parse(datasetInfoValues["isReadOnly"].ToString());
            }
            datasetInfo.IsReadOnly = isReadOnly;
            datasetInfo.Name = datasetInfoValues.ContainsKey("name") && datasetInfoValues["name"] != null ? datasetInfoValues["name"].ToString() : "";
            datasetInfo.PrjCoordSys = datasetInfoValues.ContainsKey("prjCoordSys") && datasetInfoValues["prjCoordSys"] != null ?
                JsonConvert.DeserializeObject<PrjCoordSys>(datasetInfoValues["prjCoordSys"].ToString()) : null;
            datasetInfo.TableName = datasetInfoValues.ContainsKey("tableName") && datasetInfoValues["tableName"] != null ?
                datasetInfoValues["tableName"].ToString() : "";
            DatasetType type = DatasetType.UNDEFINED;
            if (datasetInfoValues.ContainsKey("type") && datasetInfoValues["type"] != null)
            {
                type = (DatasetType)Enum.Parse(typeof(DatasetType), datasetInfoValues["type"].ToString(), false);
            }
            datasetInfo.Type = type;

            return datasetInfo;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanWrite
        {
            get
            {
                return false;
            }
        }
    }
}
