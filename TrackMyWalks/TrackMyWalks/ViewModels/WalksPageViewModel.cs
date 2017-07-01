using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackMyWalks.Models;
using Xamarin.Forms;

namespace TrackMyWalks.ViewModels
{
    public class WalksPageViewModel : WalkBaseViewModel
    {
        string _notes;
        public string Notes
        {
            get { return _notes; }
            set
            {
                _notes = value;
                OnPropertyChanged();
            }
        }
        double _latitude;
        public double Latitude
        {
            get { return _latitude; }
            set
            {
                _latitude = value;
                OnPropertyChanged();
            }
        }
        double _longitude;
        public double Longitude
        {
            get { return _longitude; }
            set
            {
                _longitude = value;
                OnPropertyChanged();
            }
        }
        double _kilometers;
        public double Kilometers
        {
            get { return _kilometers; }
            set
            {
                _kilometers = value;
                OnPropertyChanged();
            }
        }
        string _difficulty;
        public string Difficulty
        {
            get { return _difficulty; }
            set
            {
                _difficulty = value;
                OnPropertyChanged();
            }
        }

        double _distance;
        public double Distance
        {
            get { return _distance; }
            set
            {
                _distance = value;
                OnPropertyChanged();
            }
        }
        string _imageUrl;
        public string ImageUrl
        {
            get { return _imageUrl; }
            set
            {
                _imageUrl = value;
                OnPropertyChanged();
            }
        }

        Command _saveCommand;
        public Command SaveCommand
        {
            get
            {
                return _saveCommand ?? (_saveCommand = new
                Command(ExecuteSaveCommand, ValidateFormDetails));
            }
        }

        string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged();
                SaveCommand.ChangeCanExecute();
            }
        }

        // method to check for any form errors
        bool ValidateFormDetails()
        {
            return !string.IsNullOrWhiteSpace(Title);
        }

        void ExecuteSaveCommand()
        {
            var newWalkItem = new WalkEntry
            {
                Title = this.Title,
                Notes = this.Notes,
                Latitude = this.Latitude,
                Longitude = this.Longitude,
                Kilometers = this.Kilometers,
                Difficulty = this.Difficulty,
                Distance = this.Distance,
                ImageUrl = this.ImageUrl
            };
            // Here, we will save the details entered in a later chapter.
        }

        private ObservableCollection<WalkEntry> walkEntries;

        public ObservableCollection<WalkEntry> WalkEntries
        {
            get { return walkEntries; }
            set
            {
                if (walkEntries == value)
                    return;

                walkEntries = value;

                OnPropertyChanged();
            }
        }

        public WalksPageViewModel()
        {
            Title = "New Walk";
            Difficulty = "Easy";
            Distance = 1.0;

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

            WalkEntries = new ObservableCollection<WalkEntry> { margs, giants };
        }
    }
}