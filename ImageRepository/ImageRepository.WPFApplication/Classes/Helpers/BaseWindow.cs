using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shell;

namespace ImageRepository.WPFApplication.Classes.Helpers
{
    public class BaseWindow : Window
    {
        public BaseWindow()
        {
            try
            {
                WindowChrome.SetWindowChrome(this, new WindowChrome()
                {
                    CornerRadius = SystemParameters.WindowCornerRadius,
                    CaptionHeight = SystemParameters.CaptionHeight,
                    ResizeBorderThickness = SystemParameters.WindowResizeBorderThickness,
                    GlassFrameThickness = new Thickness(1)
                });

                TextElement.SetForeground(this, Application.Current.Resources["MaterialDesignBody"] as Brush);
                TextElement.SetFontWeight(this, FontWeights.Regular);
                TextElement.SetFontSize(this, 13);

                TextOptions.SetTextFormattingMode(this, TextFormattingMode.Ideal);
                TextOptions.SetTextRenderingMode(this, TextRenderingMode.Auto);

                Background = Application.Current.Resources["MaterialDesignPaper"] as Brush;
                FontFamily = Application.Current.Resources["MaterialDesignFont"] as FontFamily;

                Style = Application.Current.Resources["SmartWindow"] as Style;

                WindowStyle = WindowStyle.None;
                WindowStartupLocation = WindowStartupLocation.CenterScreen;

                StateChanged += (_, __) => { UpdatePadding(); };
                Initialized += (_, __) => { UpdatePadding(); };
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred creating instance: {ex}", ex);
            }
        }

        private void UpdatePadding()
        {
            try
            {
                Padding = WindowState == WindowState.Maximized
                    ? new Thickness(SystemParameters.WindowResizeBorderThickness.Top + 3)
                    : new Thickness(0);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred updating padding: {ex}");
            }
        }
    }
}
