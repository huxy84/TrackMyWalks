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
    public partial class WalksPage : ContentPage
    {
        public List<WalkEntry> WalkEntries { get; set; }

        public WalksPage()
        {
            InitializeComponent();

            //ToolbarItem newWalkItem = new ToolbarItem()
            //{
            //    Text = "Add Walk"
            //};

            //newWalkItem.Clicked += NewWalkItem_Clicked;

            //ToolbarItems.Add(newWalkItem);

            var margs = new WalkEntry()
            {
                Title = "10 Mile Brook Trail, Margaret River",
                Notes = "The 10 Mile Brook Trail in Rotary Park near Old Kate, a preserved steam engine at the northern edge of Margaret River.",
                Latitude = -33.9727604,
                Longitude = 115.0861599,
                Kilometers = 7.5,
                Distance = 0,
                Difficulty = "Medium",
                ImageUrl = "http://trailswa.com.au/media/cache/media/images/trails/_mid/FullSizeRender1_600_480_c1.jpg"
            };

            var giants = new WalkEntry()
            {
                Title = "Acient Empire Walk, Valley of the Giant",
                Notes = "The Ancient Empire is a 450m waslk trail that takes you around and through some of the giant tingle trees including the most popullat of the gnarled veterans, known as Grandma Tingle.",
                Latitude = -34.9749188,
                Longitude = 117.3560796,
                Kilometers = 450,
                Distance = 0,
                Difficulty = "Hard",
                ImageUrl = "http://trailswa.com.au/media/cache/media/images/trails/_mid/Ancient_Empire_534_480_c1.jpg"
            };

            var itemTemplate = new DataTemplate(typeof(ImageCell));
            itemTemplate.SetBinding(TextCell.TextProperty, "Title");
            itemTemplate.SetBinding(TextCell.DetailProperty, "Notes");
            itemTemplate.SetBinding(ImageCell.ImageSourceProperty, "ImageUrl");

            

            WalkEntries = new List<WalkEntry> { margs, giants };

            var walksList = new ListView
            {
                HasUnevenRows = true,
                ItemTemplate = itemTemplate,
                ItemsSource = WalkEntries,
                SeparatorColor = Color.FromHex("#ddd")
            };

            // Set up our event handler
            walksList.ItemTapped += (object sender,
            ItemTappedEventArgs e) =>
            {
                var item = (WalkEntry)e.Item;
                if (item == null) return;
                Navigation.PushAsync(new WalkTrailPage(item));
                item = null;
            };

            Content = walksList;
        }

        private void NewWalkItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new WalkEntryPage());
        }

        private void walksList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = (WalkEntry)e.Item;

            if (item == null)
                return;

            Navigation.PushAsync(new WalkTrailPage(item));

            item = null;
        }
    }
}