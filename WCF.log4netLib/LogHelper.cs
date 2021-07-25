namespace WCF.log4netLib
{
    /// <summary>
    /// 日志帮助类
    /// </summary>
    public class LogHelper
    {
        /// <summary>
        /// 日志记录
        /// </summary>
        public static log4net.ILog InfoLog = log4net.LogManager.GetLogger("InfoLogger");
        /// <summary>
        /// 错误日志
        /// </summary>
        public static log4net.ILog ErrorLog = log4net.LogManager.GetLogger("ErrorLogger");
    }
}