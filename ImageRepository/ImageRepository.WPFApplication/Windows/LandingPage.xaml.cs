using ImageRepository.WPFApplication.Classes;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ImageRepository.WPFApplication.Windows
{
    /// <summary>
    /// Interaction logic for LandingPage.xaml
    /// </summary>
    public partial class LandingPage : BaseWindow
    {
        public LandingPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Constants.ImagePrompt.ShowDialog() ?? false)
                {
                    foreach (string path in Constants.ImagePrompt.FileNames)
                    {
                        //Todo
                    }
                }
            }
            catch (Exception ex)
            {
                Globals.HandleError(ex);
            }
        }
    }
}
