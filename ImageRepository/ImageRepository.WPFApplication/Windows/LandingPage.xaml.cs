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

        public void PreviewImage(ImageSource image)
        {
            try
            {
                imgPreview.Source = image;
                dhMain.IsOpen = true;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred previewing image: {ex}");
            }
        }

        private void ChangeTag(string tagName)
        {
            try
            {
                ugImages.Children.Clear();

                List<ImageData> lstData = Repository.GetAllImages();

                if (!string.IsNullOrWhiteSpace(tagName))
                {
                    foreach (ImageData image in lstData.Where(x => x.Tags.Contains(tagName)))
                    {
                        _ = ugImages.Children.Add(new ImageInfo(image));
                    }
                }
                else
                {
                    foreach (ImageData image in lstData.Where(x => !x.Tags.Any()))
                    {
                        _ = ugImages.Children.Add(new ImageInfo(image));
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred changing tag name: {ex}");
            }
        }

        private void UpdateTagList()
        {
            try
            {
                pnlTags.Children.Clear();

                List<ImageData> lstData = Repository.GetAllImages();

                if (lstData.Any())
                {
                    if (lstData.Any(x => x.Tags.Length < 1))
                    {
                        TagControl control = new("Untagged");
                        control.Click += (_, __) => { ChangeTag(""); };

                        _ = pnlTags.Children.Add(control);
                    }
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
                UpdateTagList();
            }
            catch (Exception ex)
            {
                Globals.HandleError(ex);
            }
        }

        private void BaseWindow_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.Key)
                {
                    case Key.Escape:
                        dhMain.IsOpen = false;
                        break;
                }
            }
            catch (Exception ex)
            {
                Globals.HandleError(ex);
            }
        }
    }
}
