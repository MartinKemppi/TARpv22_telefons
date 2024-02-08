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
    public partial class StartPage : ContentPage
    {
        public StartPage()
        {
            //InitializeComponent();
            Button Entry_btn = new Button
            {
                Text = "Entry Leht",
                BackgroundColor = Color.Aqua,
                TextColor= Color.Navy
            };
            StackLayout st = new StackLayout
            { 
                Orientation = StackOrientation.Vertical,
                BackgroundColor = Color.FromRgb(32, 32, 255)
            };
            st.Children.Add(Entry_btn);
            Content= st;
            Entry_btn.Clicked += Entry_btn_Clicked;
        }

        private async void Entry_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EntryPage());
        }
    }
}