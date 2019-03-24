using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_v1
{
    public class CustomEventArgs : EventArgs {

        private Recipe recipe;

        public Recipe sendRecipe {
            get { return recipe; }
            set { recipe = value; }
        }

        public CustomEventArgs(Recipe r) {
            sendRecipe = r;
        }
    }
}
