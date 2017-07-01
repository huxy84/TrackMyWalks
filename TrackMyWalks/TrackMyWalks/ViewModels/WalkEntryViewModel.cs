using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackMyWalks.ViewModels
{
    public class WalkEntryViewModel : WalkBaseViewModel
    {
        private string title;
        public string Title
        {
            get { return title; }
            set
            {
                if (title == value)
                    return;

                title = value;

                OnPropertyChanged();
                //SaveCommand.ChangeCanExecute();
            }
        }
    }
}