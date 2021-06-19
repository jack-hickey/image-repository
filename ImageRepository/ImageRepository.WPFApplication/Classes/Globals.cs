using System;
using System.Collections.Generic;
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
    }
}
