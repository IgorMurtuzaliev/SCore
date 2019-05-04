using log4net;

namespace SCore.WEB.Logger
{
    public static class Logger
    {
        private static ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static ILog Log
        {
            get { return log; }
        }

    }
}
