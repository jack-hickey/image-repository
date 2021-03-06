using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ImageRepository.WPFApplication.Classes.Helpers
{
    public static class Globals
    {
        public static void HandleError(Exception ex)
        {
            try
            {
                _ = MessageBox.Show(ex.ToString());
            }
            catch
            {
                //We're fucked anyway
            }
        }

        public static string GetFileRawData(string path)
        {
            try
            {
                byte[] buffer = null;

                using (FileStream fs = new(path, FileMode.Open, FileAccess.Read))
                {
                    buffer = new byte[fs.Length];
                    _ = fs.Read(buffer, 0, (int)fs.Length);
                }

                return Convert.ToBase64String(buffer);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred getting files raw data: {ex}");
            }
        }

        public static ImageSource GetImage(byte[] data)
        {
            try
            {
                BitmapImage biImg = new();
                MemoryStream ms = new(data);
                biImg.BeginInit();
                biImg.StreamSource = ms;
                biImg.EndInit();

                return biImg;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred getting image: {ex}");
            }
        }
    }
}
