using ImageRepository.WPFApplication.Classes.Helpers;
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

                this.CurrentImage = image;
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
                byte[] rawData = Convert.FromBase64String(this.CurrentImage.Data);
                this.imgImage.Source = Globals.GetImage(rawData);
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
                Clipboard.SetImage(this.imgImage.Source as BitmapSource);
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
                this.UpdateImage();
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
                this.CopyImage();
            }
            catch (Exception ex)
            {
                Globals.HandleError(ex);
            }
        }
    }
}
