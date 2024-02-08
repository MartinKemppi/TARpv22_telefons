using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TARpv22_telefon
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RGB_StepperSlider_Page : ContentPage
    {
        Slider redSlider, greenSlider, blueSlider;
        Label colorLabel;
        BoxView colorBox;
        Button rndColor;
        Stepper increaseStepper, decreaseStepper;
        public RGB_StepperSlider_Page()
        {
            //InitializeComponent();
            Title = "RGB leht";
            BackgroundColor = Color.LightGray;
            colorLabel = new Label
            {
                FontSize = 24,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            colorBox = new BoxView
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                WidthRequest = 100,
                HeightRequest = 100
            };
            redSlider = new Slider
            {
                Minimum = 0,
                Maximum = 255,
                Value = 0,
                MinimumTrackColor = Color.Red
            };           
            greenSlider = new Slider
            {
                Minimum = 0,
                Maximum = 255,
                Value = 0,
                MinimumTrackColor = Color.Green
            };           
            blueSlider = new Slider
            {
                Minimum = 0,
                Maximum = 255,
                Value = 0,
                MinimumTrackColor = Color.Blue
            };
            rndColor = new Button
            {
                Text = "Random color",
                HorizontalOptions = LayoutOptions.Center,
                Margin = new Thickness(0, 20, 0, 0)
            };
            increaseStepper = new Stepper
            {
                Minimum = 40,
                Maximum = 200,
                Value = 100,
                Increment = 10,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };

            StackLayout stackLayout = new StackLayout
            {
                Children = { colorLabel, colorBox, redSlider, greenSlider, blueSlider, rndColor, increaseStepper },
                Padding = new Thickness(20)
            };

            redSlider.ValueChanged += OnColorChanged;
            greenSlider.ValueChanged += OnColorChanged;
            blueSlider.ValueChanged += OnColorChanged;
            rndColor.Clicked += async (sender, e) => await OnRandomColorButtonClicked(sender, e);
            increaseStepper.ValueChanged += OnIncreaseStepperValueChanged;

            Content = stackLayout;
            UpdateColor();
        }

        void OnColorChanged(object sender, ValueChangedEventArgs e)
        {
            UpdateColor();
        }

        void UpdateColor()
        {
            int redValue = (int)redSlider.Value;
            int greenValue = (int)greenSlider.Value;
            int blueValue = (int)blueSlider.Value;

            Color color = Color.FromRgb(redValue, greenValue, blueValue);
            colorLabel.Text = $"RGB: ({redValue}, {greenValue}, {blueValue})";
            colorLabel.TextColor = color;

            colorBox.Color = color;
        }
        async Task OnRandomColorButtonClicked(object sender, EventArgs e)
        {
            Random random = new Random();
            int redValue = random.Next(256);
            int greenValue = random.Next(256);
            int blueValue = random.Next(256);

            await AnimateSliders(redValue, greenValue, blueValue);

            int boxWidth = random.Next(100, 301);
            int boxHeight = random.Next(100, 301);
            colorBox.WidthRequest = boxWidth;
            colorBox.HeightRequest = boxHeight;

            UpdateColor();
        }

        async Task AnimateSliders(int redValue, int greenValue, int blueValue)
        {
            await Device.InvokeOnMainThreadAsync(async () =>
            {
                int steps = 10;
                double redStep = (redValue - redSlider.Value) / steps;
                double greenStep = (greenValue - greenSlider.Value) / steps;
                double blueStep = (blueValue - blueSlider.Value) / steps;

                for (int i = 0; i < steps; i++)
                {
                    redSlider.Value += redStep;
                    greenSlider.Value += greenStep;
                    blueSlider.Value += blueStep;

                    await Task.Delay(50);
                }
            });
        }

        void OnIncreaseStepperValueChanged(object sender, ValueChangedEventArgs e)
        {
            double stepValue = e.NewValue;
            colorBox.WidthRequest = stepValue;
            colorBox.HeightRequest = stepValue;
        }
    }
}