using System;
using System.IO;
using System.Windows.Forms;

namespace PressKeySearch
{
    internal static class Program
    {
        static string hiddenFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Roaming\\PKS";
        public static string configPath =  hiddenFolder + "\\config.cfg";
        public static string logPath; //файл логов
        public static int textLength; // число строк в EPMAgent0.log
        // Главная точка входа для приложения.
        [STAThread]
        static void Main()
        {
             StreamWriter writer;
            // проверка наличия config.cfg
            if (!File.Exists(configPath))
            {
                MessageBox.Show("Файл " + configPath + " не существует. Будет создан новый пустой файл");
                if (!Directory.Exists(hiddenFolder))
                    Directory.CreateDirectory(hiddenFolder);
                writer = new StreamWriter(configPath, false);
                writer.WriteLine("logpath = \"\"");
                writer.Close();
            }
            StreamReader reader = new StreamReader(configPath);
            string line = reader.ReadLine();
            reader.Close();
            logPath = line.Substring(line.IndexOf("= ") + 2);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
