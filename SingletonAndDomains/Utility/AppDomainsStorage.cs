using System;

namespace SingletonAndDomains
{

    public static class AppDomainsStorage
    {
        public static AppDomain DefaultAppDomain
        {
            get
            {
                var host = new mscoree.CorRuntimeHost();

                object ret;
                host.GetDefaultDomain(out ret);

                return (AppDomain)ret;
            }
        }
    }
}
