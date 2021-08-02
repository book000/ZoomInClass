using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZoomInClass
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.ThreadException += new
                ThreadExceptionEventHandler(Application_ThreadException);

            // UnhandledExceptionイベント・ハンドラを登録する
            Thread.GetDomain().UnhandledException += new
                UnhandledExceptionEventHandler(Application_UnhandledException);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            new Form1();
            Application.Run();
        }
        public static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Error (ThreadException)",
                "An error has occurred and the operation has stopped.\n" +
                "It would be helpful if you could report this bug using GitHub issues!\n" +
                "https://github.com/book000/ZoomInClass/issues\n" +
                "\n" +
                "----- Error Details -----\n" +
                e.Exception.Message + "\n" +
                "\n" +
                "----- StackTrace -----\n" +
                e.Exception.StackTrace + "\n" +
                "\n" +
                "Click OK to open the Create GitHub issue page.\n" +
                "Click Cancel to close this application.",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Error);

            if(result == DialogResult.OK)
            {
                Process.Start("https://github.com/book000/ZoomInClass/issues/new");
            }
            Application.Exit();
        }

        public static void Application_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = e.ExceptionObject as Exception;
            if (ex != null)
            {
                DialogResult result = MessageBox.Show(
                    "Error (UnhandledException)",
                    "An error has occurred and the operation has stopped.\n" +
                    "It would be helpful if you could report this bug using GitHub issues!\n" +
                    "https://github.com/book000/ZoomInClass/issues\n" +
                    "\n" +
                    "----- Error Details -----\n" +
                    ex.Message + "\n" +
                    "\n" +
                    "----- StackTrace -----\n" +
                    ex.StackTrace + "\n" +
                    "\n" +
                    "Click OK to open the Create GitHub issue page.\n" +
                    "Click Cancel to close this application.",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Error);

                if (result == DialogResult.OK)
                {
                    Process.Start("https://github.com/book000/ZoomInClass/issues/new");
                }
                Application.Exit();
            }
        }
    }
}
