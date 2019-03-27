using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_v1
{
    public class Recipe
    {
        string title;
        string recipeId;
        string imageLink;
        string sourceLink;
        List<string> ingredients;
        string ingred;

        public string Title {
            get { return title; }
            set { title = value; }
        }

        public string RecipeId {
            get { return recipeId; }
            set { recipeId = value; }
        }

        public string ImageLink  {
            get { return imageLink; }
            set { imageLink = value; }
        }

        public string SourceLink  {
            get { return sourceLink; }
            set { sourceLink = value; }
        }

        public List<string> Ingredients  {
            get { return ingredients; }
            set { ingredients = value; }
        }

        public string Ingred {
            get { return ingred; }
            set { ingred = value; }
        }

        public override string ToString() {
            return title;
        }
    }
}
