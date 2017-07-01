using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackMyWalks.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TrackMyWalks
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WalkTrailPage : ContentPage
    {
        //WalkEntry walkItem;

        public WalkTrailPage(WalkEntry walkItem)
        {
            //this.walkItem = walkItem;
            InitializeComponent();

            var beginTrailWalk = new Button
            {
                BackgroundColor = Color.FromHex("#008080"),
                TextColor = Color.White,
                Text = "Begin this Trail"
            };
            // Set up our event handler
            beginTrailWalk.Clicked += (sender, e) =>
            {
                if (walkItem == null)
                    return;

                Navigation.PushAsync(new DistanceTravelledPage(walkItem));

                Navigation.RemovePage(this);

                walkItem = null;
            };

            var walkTrailImage = new Image()
            {
                Aspect = Aspect.AspectFill,
                Source = walkItem.ImageUrl
            };

            var trailNameLabel = new Label()
            {
                FontSize = 28,
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.Black,
                Text = walkItem.Title
            };
            var trailKilometersLabel = new Label()
            {
                FontAttributes = FontAttributes.Bold,
                FontSize = 12,
                TextColor = Color.Black,
                Text = $"Length: { walkItem.Kilometers } km"
            };
            var trailDifficultyLabel = new Label()
            {
                FontAttributes = FontAttributes.Bold,
                FontSize = 12,
                TextColor = Color.Black,
                Text = $"Difficulty: { walkItem.Difficulty } "
            };
            var trailFullDescription = new Label()
            {
                FontSize = 11,
                TextColor = Color.Black,
                Text = $"{ walkItem.Notes }",
                HorizontalOptions = LayoutOptions.FillAndExpand
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
                        walkTrailImage,
                        trailNameLabel,
                        trailKilometersLabel,
                        trailDifficultyLabel,
                        trailFullDescription,
                        beginTrailWalk
                        }
                }
            };
        }

        //private void beginTrailWalk_Clicked(object sender, EventArgs e)
        //{
        //    if (walkItem == null)
        //        return;

        //    Navigation.PushAsync(new DistanceTravelledPage(walkItem));
        //    Navigation.RemovePage(this);
        //    walkItem = null;
        //}
    }
}