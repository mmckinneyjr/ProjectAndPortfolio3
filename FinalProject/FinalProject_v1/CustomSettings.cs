using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_v1
{
    public class CustomSettings : EventArgs
    {
        private Settings Rsettings;

        public Settings rotateSetting { get; set; }

        public CustomSettings(Settings s) {
            rotateSetting = s;
        }

    }
}
