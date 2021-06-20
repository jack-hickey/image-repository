using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageRepository.WPFApplication.Classes.Helpers
{
    public static class Constants
    {
        public static OpenFileDialog ImagePrompt = new OpenFileDialog()
        {
            Multiselect = true,
            Filter = "Images (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png"
        };
    }
}
