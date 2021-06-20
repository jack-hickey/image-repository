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
    /// Interaction logic for TagControl.xaml
    /// </summary>
    public partial class TagControl : UserControl
    {
        public static DependencyProperty TagNameProperty = DependencyProperty.Register("TagName", typeof(string), typeof(TagControl), new PropertyMetadata(""));

        public string TagName
        {
            get => GetValue(TagNameProperty).ToString();
            set => SetValue(TagNameProperty, value);
        }

        public TagControl()
        {
            InitializeComponent();
        }

        public TagControl(string tagName)
        {
            try
            {
                InitializeComponent();

                this.TagName = tagName;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred creating instance: {ex}");
            }
        }
    }
}
