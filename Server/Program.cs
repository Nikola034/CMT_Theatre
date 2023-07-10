using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Common;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost serviceHost = new ServiceHost(typeof(Pozoriste)))
            {
                serviceHost.AddServiceEndpoint(
                    typeof(IPozoriste),
                    new BasicHttpBinding(),
                    new Uri("http://localhost:8000"));

                serviceHost.Open();

                Console.WriteLine("Server je pokrenut!");

                Console.ReadKey();
            }
        }
    }
}
