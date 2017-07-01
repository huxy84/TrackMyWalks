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
    public partial class WalkEntryPage : ContentPage
    {
        public WalkEntryPage()
        {
            var walkTitle = new EntryCell
            {
                Label = "Title",
                Placeholder = "Trail Title"
            };

            InitializeComponent();
        }
    }
}