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
    public partial class StepperSlider_Page : ContentPage
    {
        Label lbl;
        Slider sld;
        public StepperSlider_Page()
        {
            //InitializeComponent();
            Title = "StepperSlider_Page leht";
            lbl = new Label()
            {
                Text = "...",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            sld = new Slider
            {
                Minimum = 0,
                Maximum = 100,
                Value = 30,
                MinimumTrackColor = Color.White,
                MaximumTrackColor = Color.Black,
                ThumbColor = Color.Red
            };
            sld.ValueChanged += Sld_ValueChanged;
            StackLayout st = new StackLayout
            {
                Children = { sld, lbl }
            };
            Content = st;
        }

        private void Sld_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            lbl.Text = String.Format("Valitud: {0:F1}", e.NewValue);
            lbl.FontSize = e.NewValue;
            lbl.Rotation = e.NewValue;
        }
    }
}
