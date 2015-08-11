using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperMap.Connector
{
    /// <summary>
    /// 缓存管理类。
    /// </summary>
    internal sealed class CacheManager
    {
        static readonly CacheManager _instance = new CacheManager();
        public static int CacheDuration = 60 * 15 * 1000; //缓存的过期时间，默认为15分钟。毫秒为单位。

        private Dictionary<string, CacheItem> _cacheContent = new Dictionary<string, CacheItem>(); //.net4中可以使用ConcurrentDictionary
        private static object _lockObject = new object();

        static CacheManager()
        {

        }

        private CacheManager()
        {
        }

        /// <summary>
        /// 存在唯一的缓存管理实例。
        /// </summary>
        public static CacheManager Instance
        {
            get
            {
                return _instance;
            }
        }

        /// <summary>
        /// 根据给定的Key和数据，加入到缓存中。
        /// </summary>
        /// <param name="key">缓存的key。</param>
        /// <param name="data">缓存的内容。</param>
        /// <returns>缓存是否成功。</returns>
        public bool AddCache(string key, object data)
        {
            lock (CacheManager._lockObject)
            {
                if (this._cacheContent.ContainsKey(key))
                {
                    CacheItem cacheItem = this._cacheContent[key];
                    if (cacheItem != null)
                    {
                        if (DateTime.Now.Subtract(cacheItem.CachedTime).Milliseconds >= CacheManager.CacheDuration)
                        {
                            this._cacheContent.Remove(key);
                            this._cacheContent.Add(key, new CacheItem(data, DateTime.Now));
                        }
                    }
                }
                else
                {
                    CacheItem cacheItem = new CacheItem(data, DateTime.Now);
                    this._cacheContent.Add(key, cacheItem);
                }
            }
            return true;
        }

        /// <summary>
        /// 根据给定的key获取到一个对应的缓存。
        /// </summary>
        /// <param name="key">缓存的key。</param>
        /// <returns>获取到缓存的内容，如果不存在，则返回null。</returns>
        public object GetCache(string key)
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentNullException();
            if (this._cacheContent.ContainsKey(key))
            {
                CacheItem cacheItem = this._cacheContent[key];
                if (cacheItem != null)
                {
                    if (DateTime.Now.Subtract(cacheItem.CachedTime).TotalMilliseconds >= CacheManager.CacheDuration)
                    {
                        return null;
                    }
                    else
                    {
                        return cacheItem.Data;
                    }
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 缓存项。
        /// </summary>
        internal class CacheItem
        {
            private object _data = null;
            private DateTime _cachedTime;
            /// <summary>
            /// 
            /// </summary>
            /// <param name="data">缓存的内容。</param>
            /// <param name="cachedTime">加入缓存的时间。</param>
            public CacheItem(object data, DateTime cachedTime)
            {
                this._data = data;
                this._cachedTime = cachedTime;
            }

            /// <summary>
            /// 缓存的数据。
            /// </summary>
            public object Data
            {
                get
                {
                    return this._data;
                }
            }

            /// <summary>
            /// 加入到缓存中的时间。
            /// </summary>
            public DateTime CachedTime
            {
                get
                {
                    return this._cachedTime;
                }
            }
        }
    }
}
