﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageRepository.WPFApplication.Classes.Helpers
{
    [Serializable]
    public class ImageData
    {
        public string Data { get; set; } = "";

        public string[] Tags { get; set; } = new string[] { };

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
