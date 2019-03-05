using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CE01_EventHandlers
{
    public class CustomEventArgs : EventArgs
    {
        private Movie movie;

        public Movie movieModify {
            get { return movie; }
            set { movie = value; }
        }

        public CustomEventArgs(Movie m)  {
            movieModify = m;
        }

    }
}
