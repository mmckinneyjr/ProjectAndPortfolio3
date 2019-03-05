using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CE01_EventHandlers
{
    public class CustomEventArgs :EventArgs
    {

        public string title;
        public int indexNum;
        public Movie movieData;

        //Custom EventArg
        public CustomEventArgs(string _title, int _index, object _movieData)  {
            title = _title;
            indexNum = _index;
            movieData = (Movie)_movieData;
        }

    }
}
