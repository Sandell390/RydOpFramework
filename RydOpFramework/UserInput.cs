using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RydOpFramework
{
    public static class UserInput
    {
        public static bool MenuSelect()
        {
            //Vælger noget for menu'en
            int input = ParseInt();

            switch (input)
            {
                case -1:
                    return false;
                case 0:
                    UI.DiskMetaDataView();
                    return true;
                case 1:
                    UI.CPUView();
                    return true;
                case 2:
                    UI.MemoryView();
                    return true;
                case 3:
                    UI.ComputerInfoView();
                    return true;
                case 4:
                    UI.BootDeviceView();
                    return true;
                case 5:
                    UI.AllServiceView();
                    return true;
                default:
                    UI.ErrorMessage();
                    return true;
            }

        }

        public static int ParseInt()
        {
            int input;
            while (!int.TryParse(Console.ReadLine(), out input))
            {
                UI.ErrorMessage();
            }
            return input;

        }
    }
}
