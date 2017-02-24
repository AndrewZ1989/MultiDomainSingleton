using System;
using System.Reflection;

namespace SingletonAndDomains
{


    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //create the new domain
                AppDomain domain = AppDomain.CreateDomain("NewDomain");


                TestClass objectFromNewDomain = (TestClass)domain.CreateInstanceAndUnwrap(Assembly.GetExecutingAssembly().FullName, typeof(TestClass).FullName);

                Console.WriteLine($"New domain. Value ( non multi-domain singleton is used ):{Environment.NewLine}{objectFromNewDomain.Value}");
                Console.WriteLine($"New domain. ValueMultiDomain ( multi-domain singleton is used ):{Environment.NewLine}{objectFromNewDomain.ValueMultiDomain}");


                TestClass objectFromCurrentDomain = new TestClass();
                Console.WriteLine($"Current domain. Value ( non multi-domain singleton is used ):{Environment.NewLine}{objectFromCurrentDomain.Value}");
                Console.WriteLine($"Current domain. ValueMultiDomain ( multi-domain singleton is used ):{Environment.NewLine}{objectFromCurrentDomain.ValueMultiDomain}");

                Console.WriteLine();
                Console.WriteLine($"Value from new domain is equal to one from current domain: {objectFromNewDomain.Value == objectFromCurrentDomain.Value}");

                Console.WriteLine();
                Console.WriteLine($"ValueMultiDomain from new domain is equal to one from current domain: {objectFromNewDomain.ValueMultiDomain == objectFromCurrentDomain.ValueMultiDomain}");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }




            Console.ReadLine();
        }
    }
}
