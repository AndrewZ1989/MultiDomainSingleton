
using System;

namespace SingletonAndDomains
{
    /// <summary>
    /// Very simple singleton implementation. It's not shared between application domains
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class SingletonWrapper<T> where T : new()
    {
        #region .ctor

        private SingletonWrapper() { }

        #endregion

        #region Fields

        private static object syncRoot = new Object();
        private static T _instance;

        #endregion

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (syncRoot)
                    {
                        if (_instance == null) _instance = new T();
                    }
                }
                return _instance;
            }
        }
    }
}
