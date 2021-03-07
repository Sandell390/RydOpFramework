using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace RydOpFramework
{
    public static class QueryManager
    {

        public static ManagementObjectCollection GetDiskInfo() 
        {
            ManagementScope managementScope = new ManagementScope();

            ObjectQuery objectQuery = new ObjectQuery("select FreeSpace,Size,Name from Win32_LogicalDisk where DriveType=3");

            ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);

            return managementObjectSearcher.Get();
        }

        public static ManagementObjectCollection GetCPUInfo() 
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from Win32_PerfFormattedData_PerfOS_Processor");

            return searcher.Get();
        }

        public static ManagementObjectCollection GetMemoryInfo() 
        {
            ObjectQuery wql = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(wql);
            return searcher.Get();
        }

        public static ManagementObjectCollection GetComputerInfo() 
        {
            ObjectQuery wql = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(wql);
            return searcher.Get();
        }

        public static ManagementObjectCollection GetBootDevice() 
        {
            ManagementScope scope = new ManagementScope("\\\\.\\ROOT\\cimv2");

            //create object query
            ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");

            //create object searcher
            ManagementObjectSearcher searcher =
                                    new ManagementObjectSearcher(scope, query);

            //get a collection of WMI objects
            return searcher.Get();
        }

        public static ManagementObject GetHardDiskSerialNumber(string drive = "C") 
        {
            ManagementObject managementObject = new ManagementObject("Win32_LogicalDisk.DeviceID=\"" + drive + "\"");
            managementObject.Get();

            return managementObject;

        }

        public static ManagementObjectCollection GetAllServices() 
        {
            ManagementObjectSearcher windowsServicesSearcher = new ManagementObjectSearcher("root\\cimv2", "select * from Win32_Service");
            return windowsServicesSearcher.Get();
        }

    }
}
