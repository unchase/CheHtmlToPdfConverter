using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace CheHtmlToPdfConverter.Helpers
{
    public class IniFileHelper
    {
        public class IniFile
        {
            private string Path { get; } // Имя файла

            [DllImport("kernel32")] // Подключаем kernel32.dll и описываем его функцию WritePrivateProfilesString
            public static extern long WritePrivateProfileString(string section, string key, string value, string filePath);

            [DllImport("kernel32")] // Еще раз подключаем kernel32.dll, а теперь описываем функцию GetPrivateProfileString
            public static extern int GetPrivateProfileString(string section, string key, string Default, StringBuilder retVal, int size, string filePath);

            // С помощью конструктора записываем путь до файла и его имя.
            public IniFile(string iniPath)
            {
                if (!File.Exists(iniPath))
                    File.Create(iniPath);
                Path = new FileInfo(iniPath).FullName;
                File.SetAttributes(iniPath, FileAttributes.System);
            }

            // Читаем ini-файл и возвращаем значение указного ключа из заданной секции.
            public string Read(string section, string key)
            {
                var retVal = new StringBuilder(255);
                GetPrivateProfileString(section, key, "", retVal, 255, Path);
                return retVal.ToString();
            }

            // Записываем в ini-файл. Запись происходит в выбранную секцию в выбранный ключ.
            public void Write(string section, string key, string value)
            {
                WritePrivateProfileString(section, key, value, Path);
            }

            // Удаляем ключ из выбранной секции.
            public void DeleteKey(string key, string section = null)
            {
                Write(section, key, null);
            }

            // Удаляем выбранную секцию
            public void DeleteSection(string section = null)
            {
                Write(section, null, null);
            }

            // Проверяем, есть ли такой ключ, в этой секции
            public bool KeyExists(string key, string section = null)
            {
                return Read(section, key).Length > 0;
            }
        }
    }
}
