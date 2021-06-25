using System;
using System.Management;
using System.Threading;
using System.Windows.Forms;

namespace CV_creator
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Properties.Settings.Default.Language.ToLower());
            Helper.CreateLanguageDll();
            try
            {
                if (true)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new fHome()); 
                }
                else
                {
                    MessageBox.Show(Words.KeyNotFound, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static bool isCorrectUsb()
        {
            string val = "";
            ManagementObjectSearcher searcher = new ManagementObjectSearcher
            ("SELECT * FROM Win32_DiskDrive WHERE  SerialNumber='2E366D52'");
            bool isCorrect = false;
            try
            {
                foreach (ManagementObject mo in searcher.Get())
                {
                    val = mo["SerialNumber"].ToString();
                    isCorrect = true;
                }
            }
            catch (ManagementException ex)
            {
            }
            return isCorrect;
        }
    }
}
