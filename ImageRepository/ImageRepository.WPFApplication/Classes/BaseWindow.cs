using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shell;

namespace ImageRepository.WPFApplication.Classes
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
                    GlassFrameThickness = SystemParameters.WindowResizeBorderThickness
                });

                TextElement.SetForeground(this, Application.Current.Resources["MaterialDesignBody"] as Brush);
                TextElement.SetFontWeight(this, FontWeights.Regular);
                TextElement.SetFontSize(this, 13);

                TextOptions.SetTextFormattingMode(this, TextFormattingMode.Ideal);
                TextOptions.SetTextRenderingMode(this, TextRenderingMode.Auto);

                this.Background = Application.Current.Resources["MaterialDesignPaper"] as Brush;
                this.FontFamily = Application.Current.Resources["MaterialDesignFont"] as FontFamily;

                this.WindowStyle = WindowStyle.None;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred creating instance: {ex}", ex);
            }
        }
    }
}
