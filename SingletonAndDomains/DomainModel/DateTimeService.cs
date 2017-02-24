using System;
using System.Threading;

namespace SingletonAndDomains
{

    [Serializable]
    public class DateTimeService
    {
        public DateTimeService()
        {
            Date = DateTime.Now;
        }

        public DateTime Date { get; }
    }
}
