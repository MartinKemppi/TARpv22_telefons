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
    public partial class StartPage1 : ContentPage
    {
        //List<ContentPage> pages = new List<ContentPage>() {
        //        new EntryPage(),
        //        new TimePage(),
        //        new BoxViewPage() };
        //List<string> Text = new List<string>() { "Ava Entryleht", "Ava Timeleht", "Ava Box leht" };
        //StackLayout st;

        //public StartPage1()
        //{
        //    //InitializeComponent();
        //    st = new StackLayout
        //    {
        //        Orientation = StackOrientation.Vertical,
        //        BackgroundColor = Color.AliceBlue
        //    };
        //    for (int i = 0; i < pages.Count; i++)
        //    {
        //        Button button = new Button
        //        {
        //            Text = Text[i],
        //            BackgroundColor = Color.AntiqueWhite,
        //            TextColor = Color.Black,
        //            TabIndex = i
        //        };
        //        st.Children.Add(button);
        //        button.Clicked += Ava_vajav_leht;
        //    }
        //    ScrollView sv = new ScrollView { Content = st };
        //    Content= sv;
        //}

        //private async void Ava_vajav_leht(object sender, EventArgs e)
        //{
        //    Button btn=(Button)sender;
        //    await Navigation.PushAsync(pages[btn.TabIndex]);
        //}
        StackLayout st;
        List<ContentPage> pages = new List<ContentPage>() { new EntryPage(), new TimePage(), new BoxViewPage(), new DateTimePage1(), new StepperSlider_Page(), new RGB_StepperSlider_Page() };
        Button btn;
        public StartPage1()
        {
            st = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                BackgroundColor = Color.LightGray,
            };
            foreach (ContentPage item in pages)
            {
                btn = new Button
                {
                    Text = "Ava " + item.Title
                };
                btn.Clicked += async (s, e) => await Navigation.PushAsync(item);
                st.Children.Add(btn);
            }
            Content = new ScrollView { Content = st };
        }
    }
    
}       