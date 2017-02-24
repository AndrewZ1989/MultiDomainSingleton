using System;

namespace SingletonAndDomains
{
    [Serializable]
    public class TestClass
    {
        //this value will be new for each application domain (despite singleton usage)
        public string Value = SingletonWrapper<DateTimeService>.Instance.Date.Ticks.ToString();

        //this value will be the same for each application domain
        public string ValueMultiDomain = MultidomainSIngletonWrapper<DateTimeService>.Instance.Date.Ticks.ToString();
    }
}
