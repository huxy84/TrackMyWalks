using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackMyWalks.Models;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace TrackMyWalks
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DistanceTravelledPage : ContentPage
    {
        WalkEntry walkItem;

        public DistanceTravelledPage(WalkEntry walkItem)
        {
            InitializeComponent();

            this.walkItem = walkItem;

            // Instantiate our map object
            var trailMap = new Map();
            // Place a pin on the map for the chosen walk type

            var mapPosition = new Position(walkItem.Latitude, walkItem.Longitude);

            trailMap.Pins.Add(new Pin
            {
                Type = PinType.Place,
                Label = walkItem.Title,
                Position = mapPosition
            });

            // Center the map around the list of walks entry's location
            trailMap.MoveToRegion(MapSpan.FromCenterAndRadius(mapPosition, Distance.FromKilometers(1.0)));

            var trailNameLabel = new Label()
            {
                FontSize = 18,
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.Black,
                Text = walkItem.Title
            };
            var trailDistanceTravelledLabel = new Label()
            {
                FontAttributes = FontAttributes.Bold,
                FontSize = 20,
                TextColor = Color.Black,
                Text = "Distance Travelled",
                HorizontalTextAlignment = TextAlignment.Center
            };

            var totalDistanceTaken = new Label()
            {
                FontAttributes = FontAttributes.Bold,
                FontSize = 20,
                TextColor = Color.Black,
                Text = $"{ walkItem.Distance } km",
                HorizontalTextAlignment = TextAlignment.Center
            };
            var totalTimeTakenLabel = new Label()
            {
                FontAttributes = FontAttributes.Bold,
                FontSize = 20,
                TextColor = Color.Black,
                Text = "Time Taken:",
                HorizontalTextAlignment = TextAlignment.Center
            };
            var totalTimeTaken = new Label()
            {
                FontAttributes = FontAttributes.Bold,
                FontSize = 20,
                TextColor = Color.Black,
                Text = "0h 0m 0s",
                HorizontalTextAlignment = TextAlignment.Center
            };

            var walksHomeButton = new Button
            {
                BackgroundColor = Color.FromHex("#008080"),
                TextColor = Color.White,
                Text = "End this Trail"
            };
            // Set up our event handler
            walksHomeButton.Clicked += (sender, e) =>
            {
                if (walkItem == null) return;
                Navigation.PopToRootAsync(true);
                walkItem = null;
            };

            this.Content = new ScrollView
            {
                Padding = 10,
                Content = new StackLayout
                {
                    Orientation = StackOrientation.Vertical,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    Children =
                    {
                        trailMap,
                        trailNameLabel,
                        trailDistanceTravelledLabel,
                        totalDistanceTaken,
                        totalTimeTakenLabel,
                        totalTimeTaken,
                        walksHomeButton
                    }
                }
            };
        }

        //private void walksHomeButton_Clicked(object sender, EventArgs e)
        //{
        //    if (walkItem == null)
        //        return;

        //    Navigation.PopToRootAsync(true);

        //    walkItem = null;
        //}
    }
}