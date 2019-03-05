using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CE01_EventHandlers
{
    public class Movie {
        
        public string title;
        public string year;
        public string genre;
        public bool like;
        public bool dislike;
        public int indexNum;

        public override string ToString() {
            return title;
        }
    }

    
}
