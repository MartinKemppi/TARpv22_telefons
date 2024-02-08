using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TARpv22_telefon
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TimePage : ContentPage
    {
        private bool flag = false;
        private const int ProgressBarFillDurationInSeconds = 10;

        public TimePage()
        {
            InitializeComponent();
            Title = "TimePage leht";
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            lbl.Text = "Vajutatud";
        }

        public async void NaitaAeg()
        {
            while (flag)
            {
                Time_run.Text = DateTime.Now.ToString("F");
                await Task.Delay(1000);
            }
            progressBar.Progress = 0;
        }

        private void Time_run_Clicked(object sender, EventArgs e)
        {
            if (flag)
            {
                flag = false;
            }
            else
            {
                flag = true;
                progressBar.Progress = 0;
                _ = UpdateProgressBar();
                NaitaAeg();
            }
        }

        private async Task UpdateProgressBar()
        {
            double increment = 1.0 / (ProgressBarFillDurationInSeconds * 10);
            double currentProgress = 0;

            while (flag && currentProgress <= 1)
            {
                progressBar.Progress = currentProgress;
                currentProgress += increment;

                await Task.Delay(100);
            }
            progressBar.Progress = 0;
        }
    }
}
