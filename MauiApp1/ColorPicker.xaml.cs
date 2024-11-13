using System;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace MauiApp1
{
    public partial class ColorPicker : ContentPage
    {
        private string[] colorNames = { "Kirmizi", "Yesil", "Mavi", "Sari", "Mor", "Pembe", "Turuncu", "Gri", "Beyaz", "Siyah" };

        public ColorPicker()
        {
            InitializeComponent();
            redSlider.ValueChanged += ColorSlider_ValueChanged;
            greenSlider.ValueChanged += ColorSlider_ValueChanged;
            blueSlider.ValueChanged += ColorSlider_ValueChanged;

            UpdateColor();
        }

        private void ColorSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            UpdateColor();
        }

        private void UpdateColor()
        {
            byte red = (byte)redSlider.Value;
            byte green = (byte)greenSlider.Value;
            byte blue = (byte)blueSlider.Value;

            Color color = new Color(red, green, blue);
            colorCode.Text = $"Renk Kodu = #{red:X2}{green:X2}{blue:X2}";
            colorPreview.Color = color;
        }

        private void RandomButton_Clicked(object sender, EventArgs e)
        {
            Random random = new Random();
            redSlider.Value = random.Next(0, 256);
            greenSlider.Value = random.Next(0, 256);
            blueSlider.Value = random.Next(0, 256);
        }

        private async void ColorCode_Tapped(object sender, EventArgs e)
        {
            var colorValue = colorCode.Text.Replace("Renk Kodu = ", "");
            await Clipboard.SetTextAsync(colorValue);
            await DisplayAlert("Kopyalandi", "Renk kodu panoya kopyaland�.", "Tamam");
        }

        private async void ColorPickerButton_Clicked(object sender, EventArgs e)
        {
            string selectedColor = await DisplayActionSheet("Renk Se�ici", "�ptal", null, colorNames);

            if (!string.IsNullOrEmpty(selectedColor))
            {
                // Se�ilen rengi g�ncelle
                UpdateSelectedColor(selectedColor);
            }
        }

        private void UpdateSelectedColor(string selectedColor)
        {
            switch (selectedColor)
            {
                case "Kirmiz":
                    redSlider.Value = 255;
                    greenSlider.Value = 0;
                    blueSlider.Value = 0;
                    break;
                case "Yesil":
                    redSlider.Value = 0;
                    greenSlider.Value = 255;
                    blueSlider.Value = 0;
                    break;
                case "Mavi":
                    redSlider.Value = 0;
                    greenSlider.Value = 0;
                    blueSlider.Value = 255;
                    break;
                case "Sari":
                    redSlider.Value = 255;
                    greenSlider.Value = 255;
                    blueSlider.Value = 0;
                    break;
                case "Mor":
                    redSlider.Value = 128;
                    greenSlider.Value = 0;
                    blueSlider.Value = 128;
                    break;
                case "Pembe":
                    redSlider.Value = 255;
                    greenSlider.Value = 192;
                    blueSlider.Value = 203;
                    break;
                case "Turuncu":
                    redSlider.Value = 255;
                    greenSlider.Value = 165;
                    blueSlider.Value = 0;
                    break;
                case "Gri":
                    redSlider.Value = 128;
                    greenSlider.Value = 128;
                    blueSlider.Value = 128;
                    break;
                case "Beyaz":
                    redSlider.Value = 255;
                    greenSlider.Value = 255;
                    blueSlider.Value = 255;
                    break;
                case "Siyah":
                    redSlider.Value = 0;
                    greenSlider.Value = 0;
                    blueSlider.Value = 0;
                    break;
            }
        }
    }
}
