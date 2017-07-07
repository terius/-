using Helpers;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LiHuo
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
           
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            #region 线程异常处理
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            #endregion
            Application.Run(new Login());
        }

        /// <summary>
        /// 线程异常处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            Loger.LogMessage(e.Exception.ToString());
            MessageBox.Show(e.Exception.Message);
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Loger.LogMessage(e.ExceptionObject.ToString());
            MessageBox.Show(e.ExceptionObject.ToString());
            
        }
    }
}
