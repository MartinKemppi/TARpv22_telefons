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
    public partial class EntryPage : ContentPage
    {
        Label lbl;
        Editor editor;
        public EntryPage()
        {
            //InitializeComponent();
            Title = "Entry leht";
            Button Entry_btn = new Button
            {
                Text = "Tagasi Start lehele",
                BackgroundColor = Color.Orange,
                TextColor = Color.Black
            };
            Button TimePage_btn = new Button
            {
                Text = "TimePage lehele",
                BackgroundColor = Color.Orange,
                TextColor = Color.Black
            };
            Button BoxViewPage_btn = new Button
            {
                Text = "BoxViewPage lehele",
                BackgroundColor = Color.Orange,
                TextColor = Color.Black
            };
            lbl = new Label
            {
                Text = "Mingi tekst",
                BackgroundColor = Color.FromRgb(200, 32, 0),
                TextColor = Color.Black
            };
            editor = new Editor
            {
                Placeholder="Sisesta siia teksti",
                PlaceholderColor= Color.Black,
                BackgroundColor= Color.Cyan,
                TextColor = Color.Black,
                HorizontalOptions= LayoutOptions.Center,
            };
            StackLayout st = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                BackgroundColor = Color.FromRgb(32, 32, 255),
                Children= {lbl,editor,Entry_btn,TimePage_btn,BoxViewPage_btn},
                VerticalOptions= LayoutOptions.FillAndExpand,
            };
            
            Content = st;
            Entry_btn.Clicked += Entry_btn_Clicked;
            TimePage_btn.Clicked += TimePage_btn_Clicked;
            BoxViewPage_btn.Clicked += BoxViewPage_btn_Clicked;
            editor.TextChanged += Editor_TextChanged;
        }

        private async void BoxViewPage_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BoxViewPage());
        }

        private async void TimePage_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TimePage());
        }
        private void Editor_TextChanged(object sender, TextChangedEventArgs e)
        {
            lbl.Text = editor.Text;
        }

        private async void Entry_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}