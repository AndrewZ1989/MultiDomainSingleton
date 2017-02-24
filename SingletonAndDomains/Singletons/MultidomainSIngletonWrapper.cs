using System;

namespace SingletonAndDomains
{
    public sealed class MultidomainSIngletonWrapper<T> : MarshalByRefObject where T : new()
    {
        #region .ctor
        private MultidomainSIngletonWrapper() { }
        #endregion

        #region Fields

        private static T _instance;
        private static object syncRoot = new Object();

        #endregion

        public static T Instance
        {
            get
            {
                if (null == _instance)
                {
                    lock (syncRoot)
                    {
                        if (null == _instance)
                        {
                            _instance = CreateInstanceInDefaultDomain();
                        }
                    }
                }
                return _instance;
            }
        }

        private static T CreateInstanceInDefaultDomain()
        {
            var defaultDomain = AppDomainsStorage.DefaultAppDomain;
            T existingInstance = (T)defaultDomain.GetData(typeof(T).FullName);
            if (existingInstance == null)
            {
                existingInstance = (T)defaultDomain.CreateInstanceAndUnwrap(typeof(T).Assembly.FullName, typeof(T).FullName);
                defaultDomain.SetData(typeof(T).FullName, existingInstance);
            }
            return _instance = existingInstance;
        }
    }
}
