using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace RydOpFramework
{
    public class ProcessManager
    {
        public static ManagementObjectCollection GetDiskInfo()
        {
            return QueryManager.GetDiskInfo();
        }

        public static ManagementObjectCollection GetCPUInfo() 
        {
            return QueryManager.GetCPUInfo();
        }

        public static ManagementObjectCollection GetMemoryInfo() 
        {
            return QueryManager.GetMemoryInfo();
        }

        public static ManagementObjectCollection GetComputerInfo() 
        {
            return QueryManager.GetComputerInfo();
        }

        public static ManagementObjectCollection GetBootDevice() 
        {
            return QueryManager.GetBootDevice();
        }

        public static string GetHardDiskSerialNumber(string drive = "C")
        {

            ManagementObject managementObject = QueryManager.GetHardDiskSerialNumber(drive);

            return managementObject["VolumeSerialNumber"].ToString();

        }


        public static ManagementObjectCollection GetAllServices() 
        {
            return QueryManager.GetAllServices();
        }
    }
}
