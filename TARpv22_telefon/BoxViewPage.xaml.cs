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
    public partial class BoxViewPage : ContentPage
    {
        BoxView box;
        Label lbl;
        int click_kalk;
        public BoxViewPage()
        {
            //InitializeComponent();
            Title = "BoxView leht";
            int r=0, g=0, b=0;
            box = new BoxView
            {               
                Color = Color.FromRgb(r, g, b),
                CornerRadius = 10,
                WidthRequest= 200, HeightRequest= 400,
                HorizontalOptions= LayoutOptions.Center,
                VerticalOptions= LayoutOptions.CenterAndExpand
            };
            lbl = new Label
            {
                Text = "X korda vajutatud",
                BackgroundColor = Color.FromRgb(200, 32, 0),
                TextColor = Color.White,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            };
            TapGestureRecognizer tap = new TapGestureRecognizer();
            tap.Tapped += Tap_Tapped;
            box.GestureRecognizers.Add(tap);
            StackLayout st = new StackLayout { Children = { box,lbl } };
            Content = st;        
        }
        Random rnd;
        private void Tap_Tapped(object sender, EventArgs e)
        {
            rnd = new Random();
            box.Color = Color.FromRgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(255, 255));
            click_kalk++;
            lbl.Text = $"{click_kalk} korda vajutatud";

            if (click_kalk % 3 == 1)
            {
                box.WidthRequest = 400;
                box.HeightRequest = 600;
            }
            else if (click_kalk % 3 == 2)
            {
                box.WidthRequest = 600;
                box.HeightRequest = 800;
            }
            else
            {
                box.WidthRequest = 200;
                box.HeightRequest = 400;
            }
        }
    }
}