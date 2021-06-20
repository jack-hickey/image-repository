using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageRepository.WPFApplication.Classes.Helpers
{
    public class ImageData
    {
        public string Data { get; set; } = "";

        public ImageData(string data)
        {
            try
            {
                this.Data = data;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred creating instance: {ex}");
            }
        }
    }
}
