using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_ATMoop
{
    class Program
    {
        static void Main(string[] args)
        {
            EATMMainStructure customer = new EATMMainStructure();
            customer.InitDefaultValues();
            customer.cardNumber();

            Console.ReadKey();

        }
    }
}
