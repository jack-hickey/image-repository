using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ImageRepository.WPFApplication.Classes
{
    public static class Globals
    {
        public static void HandleError(Exception ex)
        {
            try
            {
                MessageBox.Show(ex.ToString());
            }
            catch
            {
                //If this errors we're fucked anyway
            }
        }

        public static string GetFileRawData(string path)
        {
            try
            {
                byte[] buffer = null;

                using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    buffer = new byte[fs.Length];
                    fs.Read(buffer, 0, (int)fs.Length);
                }

                return Convert.ToBase64String(buffer);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred getting files raw data: {ex}");
            }
        }
    }
}
