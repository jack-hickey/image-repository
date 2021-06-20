using ImageRepository.WPFApplication.Classes.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ImageRepository.WPFApplication.Classes
{
    public static class Repository
    {
        public static void PostImage(ImageData data)
        {
            try
            {
                List<ImageData> lstData = new List<ImageData>()
                {
                    data
                };

                FileInfo dataFile = GetDataFile();

                File.WriteAllText(dataFile.FullName, JsonSerializer.Serialize(lstData));
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred posting image: {ex}");
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
                    _ = File.Create(fullPath);

                return new FileInfo(fullPath);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred getting data file: {ex}");
            }
        }
    }
}
