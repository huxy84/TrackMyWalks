using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackMyWalks.Models;

namespace TrackMyWalks.ViewModels
{
    public class DistTravelledViewModel : WalkBaseViewModel
    {
        private WalkEntry walkEntry;

        public WalkEntry WalkEntry
        {
            get { return walkEntry; }
            set
            {
                walkEntry = value;
                OnPropertyChanged();
            }
        }

        double _travelled;
        public double Travelled
        {
            get { return _travelled; }
            set
            {
                _travelled = value;
                OnPropertyChanged();
            }
        }
        double _hours;
        public double Hours
        {
            get { return _hours; }
            set
            {
                _hours = value;
                OnPropertyChanged();
            }
        }
        double _minutes;
        public double Minutes
        {
            get { return _minutes; }
            set
            {
                _minutes = value;
                OnPropertyChanged();
            }
        }

        double _seconds;
        public double Seconds
        {
            get { return _seconds; }
            set
            {
                _seconds = value;
                OnPropertyChanged();
            }
        }
        public string TimeTaken
        {
            get
            {
                return string.Format("{0:00}:{1:00}:{2:00}", this.Hours,
                this.Minutes, this.Seconds);
            }
        }
        public DistTravelledViewModel(WalkEntry walkEntry)
        {
            this.Hours = 0;
            this.Minutes = 0;
            this.Seconds = 0;
            this.Travelled = 100;
            WalkEntry = walkEntry;
        }
    }
}