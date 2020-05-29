using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using KalkulatorBiegowyService;

namespace KalkulatorBiegoweSelfHost
{
    class Program
    {
        static void Main(string[] args)
        {
            RunHost();
        }
        private static void RunHost()
        {
            using (ServiceHost host = new ServiceHost(typeof(KalkulatorBiegowyService.KalkulatorBiegowyService)))
            {
                Console.WriteLine("Personal Information Service host starting");
                host.Open();
                Console.WriteLine("Press Enter to stop service...");
                Console.ReadKey();
            }
        }

    }
}
