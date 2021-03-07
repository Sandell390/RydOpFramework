using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace RydOpFramework
{
    class Program
    {
        static void Main(string[] args)
        {

            bool power = true;
            while (power)
            {
                UI.Menu();

                power = UserInput.MenuSelect();
            }

            Console.ReadKey();

        } //Slut main

    }
}
