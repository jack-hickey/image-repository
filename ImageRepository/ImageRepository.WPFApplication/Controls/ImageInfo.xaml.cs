using ImageRepository.WPFApplication.Classes.Helpers;
using ImageRepository.WPFApplication.Windows;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ImageRepository.WPFApplication.Controls
{
    /// <summary>
    /// Interaction logic for ImageInfo.xaml
    /// </summary>
    public partial class ImageInfo : UserControl
    {
        public static DependencyProperty ImageProperty = DependencyProperty.Register("CurrentImage", typeof(ImageData), typeof(ImageInfo), new PropertyMetadata(new ImageData()));

        public ImageData CurrentImage
        {
            get => (ImageData)GetValue(ImageProperty);
            set => SetValue(ImageProperty, value);
        }

        public ImageInfo()
        {
            InitializeComponent();
        }

        public ImageInfo(ImageData image)
        {
            try
            {
                InitializeComponent();

                CurrentImage = image;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred creating instance: {ex}");
            }
        }

        private void UpdateImage()
        {
            try
            {
                byte[] rawData = Convert.FromBase64String(CurrentImage.Data);
                imgImage.Source = Globals.GetImage(rawData);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred updating image: {ex}");
            }
        }

        private void CopyImage()
        {
            try
            {
                Clipboard.SetImage(imgImage.Source as BitmapSource);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred copying image: {ex}");
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                UpdateImage();
            }
            catch (Exception ex)
            {
                Globals.HandleError(ex);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CopyImage();
            }
            catch (Exception ex)
            {
                Globals.HandleError(ex);
            }
        }

        private void imgImage_MouseUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                (Application.Current.MainWindow as LandingPage).PreviewImage(imgImage.Source);
            }
            catch (Exception ex)
            {
                Globals.HandleError(ex);
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                (Application.Current.MainWindow as LandingPage).PreviewImage(imgImage.Source);
            }
            catch (Exception ex)
            {
                Globals.HandleError(ex);
            }
        }
    }
}
