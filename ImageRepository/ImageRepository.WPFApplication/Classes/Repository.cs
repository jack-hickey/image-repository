using ImageRepository.WPFApplication.Classes.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace ImageRepository.WPFApplication.Classes
{
    public static class Repository
    {
        public static void PostImage(ImageData data)
        {
            try
            {
                List<ImageData> lstData = GetAllImages();

                if (!lstData.Any(x => x.Data == data.Data))
                {
                    lstData.Add(data);
                    FileInfo dataFile = GetDataFile();

                    File.WriteAllText(dataFile.FullName, JsonSerializer.Serialize(lstData));
                }
                else
                {
                    MessageBox.Show("This image is already stored in your repository!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred posting image: {ex}");
            }
        }

        public static List<ImageData> GetAllImages()
        {
            try
            {
                FileInfo dataFile = GetDataFile();

                return (List<ImageData>)JsonSerializer.Deserialize(File.ReadAllText(dataFile.FullName), typeof(List<ImageData>));
            }
            catch (Exception)
            {
                return new List<ImageData>();
            }
        }

        public static FileInfo GetDataFile()
        {
            try
            {
                string fullPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"Image Repository\data.json");
                string directory = Path.GetDirectoryName(fullPath);

                if (!Directory.Exists(directory))
                    Directory.CreateDirectory(directory);

                if (!File.Exists(fullPath))
                {
                    using (FileStream stream = File.Create(fullPath))
                        return new FileInfo(fullPath);
                }
                else
                {
                    return new FileInfo(fullPath);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred getting data file: {ex}");
            }
        }
    }
}
