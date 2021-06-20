using ImageRepository.WPFApplication.Classes;
using ImageRepository.WPFApplication.Classes.Helpers;
using ImageRepository.WPFApplication.Controls;
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
                        Repository.PostImage(new ImageData(Globals.GetFileRawData(path)));
                    }
                }
            }
            catch (Exception ex)
            {
                Globals.HandleError(ex);
            }
        }

        private void UpdateTagList()
        {
            try
            {
                this.pnlTags.Children.Clear();

                List<ImageData> lstData = Repository.GetAllImages();

                if (lstData.Any())
                {
                    if (lstData.Any(x => x.Tags.Length < 1))
                        this.pnlTags.Children.Add(new TagControl("Untagged"));
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred updating tag list: {ex}");
            }
        }

        private void BaseWindow_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                this.UpdateTagList();
            }
            catch (Exception ex)
            {
                Globals.HandleError(ex);
            }
        }
    }
}
