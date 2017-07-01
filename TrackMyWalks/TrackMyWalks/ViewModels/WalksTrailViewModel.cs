using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackMyWalks.Models;

namespace TrackMyWalks.ViewModels
{
    public class WalksTrailViewModel : WalkBaseViewModel
    {
        WalkEntry walkEntry;
        public WalkEntry WalkEntry
        {
            get { return walkEntry; }
            set
            {
                walkEntry = value;
                OnPropertyChanged();
            }
        }

        public WalksTrailViewModel(WalkEntry walkEntry)
        {
            WalkEntry = walkEntry;
        }
    }
}