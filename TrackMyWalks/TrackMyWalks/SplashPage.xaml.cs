using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TrackMyWalks
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SplashPage : ContentPage
    {
        public SplashPage()
        {
            InitializeComponent();

            var splashLayout = new AbsoluteLayout()
            {
                HeightRequest = 600
            };

            var image = new Image()
            {
                Source = ImageSource.FromFile("icon.png"),
                Aspect = Aspect.AspectFill,
            };

            AbsoluteLayout.SetLayoutFlags(image, AbsoluteLayoutFlags.All);
            AbsoluteLayout.SetLayoutBounds(image, new Rectangle(0f, 0f, 1f, 1f));

            splashLayout.Children.Add(image);

            Content = new StackLayout()
            {
                Children = { splashLayout }
            };
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Delay for a few seconds on the splash screen
            await Task.Delay(3000);

            // Instantiate a NavigationPage with the MainPage
            NavigationPage navPage = new NavigationPage(new WalksPage())
            {
                Title = "Track My Walks"
            };

            Application.Current.MainPage = navPage;
        }
    }
}