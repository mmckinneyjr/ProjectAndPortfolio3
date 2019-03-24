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
    public partial class Form1 : Form
    {
        RecipeForm recipeForm;
        Recipe recipe;

        public EventHandler<CustomEventArgs> sendRecipeId;

        //API Connection & Connection String
        WebClient apiConnection = new WebClient();
        string searchAPI_p1 = "https://www.food2fork.com/api/search?key=f7e2b5345b1b1fe870b0c9e11f5f37d5&q=";
        string searchAPI_p2;

        public Form1() {
            InitializeComponent(); ;
            HandleClientWindowSize();
        }

        //Create Search API string
        private void SearchAPI() {
            string search = textBox1.Text;
            searchAPI_p2 = searchAPI_p1 + search;
        }

        //Pull Data from Search API
        private void ReadSearchData() {
            listBox1.Items.Clear();
            string apiSearchData = apiConnection.DownloadString(searchAPI_p2);
            JObject rCount = JObject.Parse(apiSearchData);

            for (int i = 0; i < int.Parse(rCount["count"].ToString()); i++) {
                JObject search = JObject.Parse(apiSearchData);
                Recipe r = new Recipe();

                r.Title = search["recipes"][i]["title"].ToString();
                r.RecipeId = search["recipes"][i]["recipe_id"].ToString();
                r.ImageLink = search["recipes"][i]["image_url"].ToString();

                listBox1.Items.Add(r);
            }
        }

        //Search Button Click
        private void btn_search_Click(object sender, EventArgs e) {
            SearchAPI();
            ReadSearchData();
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)  {
            recipeForm = new RecipeForm();
            sendRecipeId += recipeForm.GetRecipeHandler;
            recipe = new Recipe();

            textBox1.Text = ((Recipe)listBox1.SelectedItem).Title;
            pictureBox1.Load(((Recipe)listBox1.SelectedItem).ImageLink);  

            if (sendRecipeId != null) {
                sendRecipeId(this, new CustomEventArgs((Recipe)listBox1.SelectedItem));
            }

            recipeForm.Show();
         
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
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)

        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_search_Click(this, new EventArgs());
            }
        }
    }
}
