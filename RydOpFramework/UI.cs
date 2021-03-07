using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace RydOpFramework
{
    public class UI
    {
        public static void Menu()
        {
            Console.Clear();

            Console.WriteLine(":::::::Start menu::::::::");

            Console.WriteLine();

            Console.WriteLine("-1: Exit");
            Console.WriteLine("0: Get Disk Meta data");
            Console.WriteLine("1: See CPU Info");
            Console.WriteLine("2: See Memory Info");
            Console.WriteLine("3: See Computer Info");
            Console.WriteLine("4: See boot device");
            Console.WriteLine("5: See all servies");

        }


        public static void DiskMetaDataView() 
        {
            Console.Clear();

            ManagementObjectCollection managementObjectCollection = ProcessManager.GetDiskInfo();

            foreach (ManagementObject managementObject in managementObjectCollection)
            {

                Console.WriteLine("Disk Name : " + managementObject["Name"].ToString());

                Console.WriteLine("FreeSpace: " + managementObject["FreeSpace"].ToString());

                Console.WriteLine("Disk Size: " + managementObject["Size"].ToString());

                Console.WriteLine("Serial Number: " + ProcessManager.GetHardDiskSerialNumber(managementObject["Name"].ToString()));

                Console.WriteLine("---------------------------------------------------");

            }

            Console.ReadKey();
        }

        public static void CPUView() 
        {
            Console.Clear();

            ManagementObjectCollection managementObjectCollection = ProcessManager.GetCPUInfo();

            foreach (ManagementObject obj in managementObjectCollection)
            {
                var usage = obj["PercentProcessorTime"];
                var name = obj["Name"];
                Console.WriteLine(name + " : " + usage);
                Console.WriteLine("CPU");
            }

            Console.ReadKey();
        }

        public static void MemoryView() 
        {
            Console.Clear();

            ManagementObjectCollection managementObjectCollection = ProcessManager.GetMemoryInfo();

            foreach (ManagementObject result in managementObjectCollection)
            {
                Console.WriteLine("Total Visible Memory: {0}KB", result["TotalVisibleMemorySize"]);
                Console.WriteLine("Free Physical Memory: {0}KB", result["FreePhysicalMemory"]);
                Console.WriteLine("Total Virtual Memory: {0}KB", result["TotalVirtualMemorySize"]);
                Console.WriteLine("Free Virtual Memory: {0}KB", result["FreeVirtualMemory"]);
            }
            Console.ReadKey();
        }
        
        public static void ComputerInfoView() 
        {
            Console.Clear();

            ManagementObjectCollection results = ProcessManager.GetComputerInfo();

            foreach (ManagementObject result in results)
            {
                Console.WriteLine("User:\t{0}", result["RegisteredUser"]);
                Console.WriteLine("Org.:\t{0}", result["Organization"]);
                Console.WriteLine("O/S :\t{0}", result["Name"]);
            }

            Console.ReadKey();
        }

        public static void BootDeviceView()
        {
            Console.Clear();


            ManagementObjectCollection results = ProcessManager.GetComputerInfo();

            foreach (ManagementObject m in results)
            {
                // access properties of the WMI object
                Console.WriteLine("BootDevice : {0}", m["BootDevice"]);

            }

            Console.ReadKey();
        }

        public static void AllServiceView()
        {
            Console.Clear();

            ManagementObjectCollection objectCollection = ProcessManager.GetAllServices();

            Console.WriteLine("There are {0} Windows services: ", objectCollection.Count);

            foreach (ManagementObject windowsService in objectCollection)
            {
                PropertyDataCollection serviceProperties = windowsService.Properties;
                foreach (PropertyData serviceProperty in serviceProperties)
                {
                    if (serviceProperty.Value != null)
                    {
                        Console.WriteLine("Windows service property name: {0}", serviceProperty.Name);
                        Console.WriteLine("Windows service property value: {0}", serviceProperty.Value);
                    }
                }
                Console.WriteLine("---------------------------------------");
            }

            Console.ReadKey();

        }

        public static void ErrorMessage()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid number");
            Console.ResetColor();
            Console.ReadKey();
        }

    }
}
