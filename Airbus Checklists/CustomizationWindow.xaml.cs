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
using System.Windows.Shapes;
using Airbus_Checklists.Customization;
using System.ComponentModel;

namespace Airbus_Checklists
{
    public partial class CustomizationWindow : Window
    {
        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        public CustomizationWindow()
        {
            InitializeComponent();
            this.Background = sih.LoadBackgroundColor();
            BackgroundColorPreview.Fill = sih.LoadBackgroundColor();
        }

        SavedInfoHolder sih = new SavedInfoHolder();

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Color color = new Color();

            RedValuePreview.Text = RedSlider.Value.ToString();
            GreenValuePreview.Text = GreenSlider.Value.ToString();
            BlueValuePreview.Text = BlueSlider.Value.ToString();
            AlphaValuePreview.Text = AlphaSlider.Value.ToString();

            color.R = (byte)RedSlider.Value;
            color.G = (byte)GreenSlider.Value;
            color.B = (byte)BlueSlider.Value;
            color.A = (byte)AlphaSlider.Value;

            Brush bColor = (Brush)new SolidColorBrush(color);

            BackgroundColorPreview.Fill = bColor;
        }

        private void BackgroundSave_Click(object sender, RoutedEventArgs e)
        {
            sih.SaveBackgroundColor((float)AlphaSlider.Value, (float)RedSlider.Value, (float)GreenSlider.Value, (float)BlueSlider.Value);
        }
    }
}