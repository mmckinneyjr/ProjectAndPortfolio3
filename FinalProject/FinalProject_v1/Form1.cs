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
        //List of selected stocks
        List<Recipe> StockList = new List<Recipe>();

        //Variables
        WebClient apiConnection = new WebClient();
        string searchAPI_p1 = "https://www.food2fork.com/api/search?key=f7e2b5345b1b1fe870b0c9e11f5f37d5&q=";
        string getAPI_p1 = "https://www.food2fork.com/api/get?key=f7e2b5345b1b1fe870b0c9e11f5f37d5&rId=";

        string searchAPI_p2;
        string getAPI_p2;

        public Form1() {
            InitializeComponent(); ;
            HandleClientWindowSize();
        }

        //Create Search API string
        private void SearchAPI() {
            string search = textBox1.Text;
            searchAPI_p2 = searchAPI_p1 + search;
        }

        //Create Get API string
        private void GetAPI()  {
            string get = ((Recipe)listBox1.SelectedItem).RecipeId;
            getAPI_p2 = getAPI_p1 + get;
        }

        //Pull Data from Search API
        private void ReadSearchData() {
            string apiSearchData = apiConnection.DownloadString(searchAPI_p2);

            JObject oCount = JObject.Parse(apiSearchData);

            for (int i = 0; i < int.Parse(oCount["count"].ToString()); i++) {
                JObject search = JObject.Parse(apiSearchData);
                Recipe stock = new Recipe();

                stock.Title = search["recipes"][i]["title"].ToString();
                stock.RecipeId = search["recipes"][i]["recipe_id"].ToString();
                stock.ImageLink = search["recipes"][i]["image_url"].ToString();

                listBox1.Items.Add(stock);
            }
        }

        //Pull Data from Ingredients API
        private void ReadIngredientsData() {

            Recipe stock = (Recipe)listBox1.SelectedItem;
            string apiData = apiConnection.DownloadString(getAPI_p2);
            JObject get = JObject.Parse(apiData);

            foreach (var i in get["recipe"]["ingredients"]) { 
                listBox2.Items.Add(i);
            }
        }


        //Search Button Click
        private void btn_search_Click(object sender, EventArgs e) {
            SearchAPI();
            ReadSearchData();
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)  {
            textBox1.Text = ((Recipe)listBox1.SelectedItem).Title;
            textBox2.Text = ((Recipe)listBox1.SelectedItem).RecipeId;
            pictureBox1.Load(((Recipe)listBox1.SelectedItem).ImageLink);

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
        }


    }
}
