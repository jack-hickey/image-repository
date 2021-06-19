using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace ImageRepository.WPFApplication.Converters
{
    public class WindowStateToIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                if (value is WindowState state)
                {
                    switch (state)
                    {
                        case WindowState.Maximized:
                            return PackIconKind.WindowRestore;
                        default:
                            return PackIconKind.WindowMaximize;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred converting: {ex}");
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is PackIconKind kind)
            {
                switch (kind)
                {
                    case PackIconKind.WindowRestore:
                        return WindowState.Maximized;
                    default:
                        return WindowState.Normal;
                }
            }
            else
            {
                return WindowState.Normal;
            }
        }
    }
}
