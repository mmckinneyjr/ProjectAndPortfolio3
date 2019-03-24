using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net;

namespace FinalProject_v1
{
    public partial class RecipeForm : Form
    {
        Recipe rec;

        public RecipeForm()
        {
            InitializeComponent();
            HandleClientWindowSize();
        }

        WebClient apiConnection = new WebClient();
        string getAPI_p1 = "https://www.food2fork.com/api/get?key=f7e2b5345b1b1fe870b0c9e11f5f37d5&rId=";
        string getAPI_p2;

        //Create Get API string
        private void GetAPI() {
            string get = rec.RecipeId;
            getAPI_p2 = getAPI_p1 + get;
        }



        //Pull Data from Ingredients API
        private void ReadIngredientsData() {
            string apiData = apiConnection.DownloadString(getAPI_p2);
            JObject get = JObject.Parse(apiData);

            txtBox_title.Text = rec.Title;
            pictureBox_recipeImage.Load(rec.ImageLink);
            foreach (var i in get["recipe"]["ingredients"]) {
                listBox2.Items.Add(i);
            }
        }

        public void GetRecipeHandler(object sender, CustomEventArgs e) {
            rec = new Recipe();
            rec.RecipeId = e.sendRecipe.RecipeId;
            rec.Title = e.sendRecipe.Title;
            rec.ImageLink = e.sendRecipe.ImageLink;
            GetAPI();
            ReadIngredientsData();
        }












        //Written by Keith Webster. Used with permission. Not to be distributed.
        //Place this inside the class space in the form you would like to size.
        //Call this method AFTER InitializeComponent() inside the form's constructor.
        void HandleClientWindowSize()
        {
            //Modify ONLY these float values
            float HeightValueToChange = 1.3f;
            float WidthValueToChange = 6.0f;
            //DO NOT MODIFY THIS CODE
            int height = Convert.ToInt32(Screen.PrimaryScreen.WorkingArea.Size.Height /
            HeightValueToChange);
            int width = Convert.ToInt32(Screen.PrimaryScreen.WorkingArea.Size.Width /
            WidthValueToChange);
            if (height < Size.Height)
                height = Size.Height;
            if (width < Size.Width)
                width = Size.Width;
            this.Size = new Size(width, height);

            btn_back.FlatStyle = FlatStyle.Flat;
            btn_back.FlatAppearance.BorderSize = 0;
            btn_back.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btn_back.FlatAppearance.MouseDownBackColor = Color.Transparent;
        }

        private void button1_Click(object sender, EventArgs e)  {
            Close();
        }
    }
}
