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
    /// Interaction logic for TitleBar.xaml
    /// </summary>
    public partial class TitleBar : UserControl
    {
        public static DependencyProperty WindowProperty = DependencyProperty.Register("MyWindow", typeof(Window), typeof(TitleBar), new PropertyMetadata(null));

        public Window MyWindow
        {
            get => (Window)GetValue(WindowProperty);
            set => SetValue(WindowProperty, value);
        }

        public static DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(TitleBar), new PropertyMetadata(""));

        public string Title
        {
            get => GetValue(TitleProperty).ToString();
            set => SetValue(TitleProperty, value);
        }

        public TitleBar()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred creating instance: {ex}");
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            MyWindow = Window.GetWindow(this);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SystemCommands.MinimizeWindow(MyWindow);
            }
            catch (Exception ex)
            {
                Globals.HandleError(ex);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                SystemCommands.CloseWindow(MyWindow);
            }
            catch (Exception ex)
            {
                Globals.HandleError(ex);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MyWindow.WindowState == WindowState.Maximized)
                {
                    SystemCommands.RestoreWindow(MyWindow);
                    btnRestore.ToolTip = "Maximize";
                }
                else
                {
                    SystemCommands.MaximizeWindow(MyWindow);
                    btnRestore.ToolTip = "Restore";
                }
            }
            catch (Exception ex)
            {
                Globals.HandleError(ex);
            }
        }
    }
}
