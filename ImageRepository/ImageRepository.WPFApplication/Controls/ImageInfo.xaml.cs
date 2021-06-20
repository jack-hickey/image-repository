using ImageRepository.WPFApplication.Classes.Helpers;
using System;
using System.Collections.Generic;
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
        public static DependencyProperty ImageProperty = DependencyProperty.Register("Image", typeof(ImageData), typeof(ImageInfo), new PropertyMetadata(new ImageData()));

        public ImageData Image
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

                this.Image = image;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred creating instance: {ex}");
            }
        }
    }
}
