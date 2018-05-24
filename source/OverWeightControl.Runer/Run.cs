using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace OverWeightControl.Runer
{
    public class Run
    {
        public static void Main(string[] args)
        {
            var defPath = GetDefault();

            FindOutLastVersion();

            if (String.IsNullOrEmpty(defPath))
                throw new ApplicationException($"Executable file OverWeightControl.exe not found at {defPath}");

            RunApplication(defPath);
        }

        private static void RunApplication(string path)
        {
            var iStartProcess = Activator.CreateInstance<Process>(); // новый процесс
            iStartProcess.StartInfo.FileName = path; // путь к запускаемому файлу

            // эта строка указывается, если программа запускается с параметрами
            // iStartProcess.StartInfo.Arguments =

            // эту строку указываем, если хотим запустить программу в скрытом виде
            // iStartProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

            iStartProcess.Start(); // запускаем программу

            // эту строку указываем, если нам надо будет ждать завершения программы определённое время, пример: 2 мин. (указано в миллисекундах - 2 мин. * 60 сек. * 1000 м.сек.)
            // iStartProcess.WaitForExit(120000); 
        }

        private static string GetDefault()
        {
            var path = AppDomain.CurrentDomain.BaseDirectory;
            var fileName = $"{path}OverWeightControl.exe";
            return File.Exists(fileName) ? fileName : String.Empty;
        }

        private static void FindOutLastVersion()
        {
            string path = $"{AppDomain.CurrentDomain.BaseDirectory}Updates//";
            int lastVersion = GetLastVersion(path);
            if (!Directory.Exists($"{path}{lastVersion}"))
                return;
            string fileMask = "*.exe | *.dll";
            var files = Directory.GetFiles(path, fileMask);
            foreach (var file in files)
            {
                if (File.Exists($"{AppDomain.CurrentDomain.BaseDirectory}{file}"))
                    File.Delete($"{AppDomain.CurrentDomain.BaseDirectory}{file}");
                File.Copy(
                    sourceFileName: $"{path}{file}",
                    destFileName: $"{AppDomain.CurrentDomain.BaseDirectory}{file}");
            }
        }
        
        private static int GetLastVersion(string path)
        {
            try
            {
                return Directory
                    .GetDirectories(path)
                    .Select(m => int.TryParse(m, out int buf) ? buf : -1)
                    .Max();
            }
            catch (Exception e)
            {
                return -1;
            }
        }
    }
}
