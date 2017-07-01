using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace TrackMyWalks.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            LoadApplication(new TrackMyWalks.App());
            // Work
            //Xamarin.FormsMaps.Init("29:FF:B4:E5:B1:84:E9:FE:AE:E9:D2:F4:5A:E9:29:B8:BA:04:50:8D");
            //Laptop
            Xamarin.FormsMaps.Init("52:CB:AB:99:56:36:6C:27:30:EA:58:7B:A5:75:D0:DA:66:32:A6:2F");
        }
    }
}
