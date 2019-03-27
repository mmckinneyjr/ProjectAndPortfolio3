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
using MySql.Data.MySqlClient;
using System.IO;

namespace FinalProject_v1
{
    public partial class RecipeForm : Form
    {
        Recipe rec;
        Settings settings = new Settings();




        //Database Connection
        MySqlConnection conn = new MySqlConnection();
        DataTable contactsDataTable = new DataTable();
        string connectionString = DatabaseConnect.BuildConnectionString();


        public RecipeForm() {
            InitializeComponent();
            HandleClientWindowSize();
            conn = DatabaseConnect.Connect(connectionString);
        }

        //SQL to write data to database
        private void SaveToCookBook() {

            string sql = "INSERT INTO Recipes(recipeId, title, ingredients, imageUrl, sourceUrl) VALUES(@_recipeId, @_title, @_ingredients, @_imageUrl, @_sourceUrl);";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = null;

            cmd.Parameters.AddWithValue("@_recipeId", rec.RecipeId);
            cmd.Parameters.AddWithValue("@_title", rec.Title);


            cmd.Parameters.AddWithValue("@_ingredients", String.Join(", ", rec.Ingredients.ToArray()));
            cmd.Parameters.AddWithValue("@_imageUrl", rec.ImageLink);
            cmd.Parameters.AddWithValue("@_sourceUrl", rec.SourceLink);


            rdr = cmd.ExecuteReader();
            conn.Close();
        }


        //API connection
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

            label_title.Text = rec.Title;
            pictureBox_recipeImage.Load(rec.ImageLink);
            label_source.Text = rec.SourceLink;

            foreach (var i in get["recipe"]["ingredients"]) {
                listBox2.Items.Add(i);
                rec.Ingredients.Add(i.ToString());
            }

            rec.Ingred = get["recipe"]["ingredients"].ToString();
        }

        //Get Recipe Handler
        public void GetRecipeHandler(object sender, CustomEventArgs e) {
            rec = new Recipe();
            rec.RecipeId = e.sendRecipe.RecipeId;
            rec.Title = e.sendRecipe.Title;
            rec.ImageLink = e.sendRecipe.ImageLink;
            rec.SourceLink = e.sendRecipe.SourceLink;
            rec.Ingredients = new List<string>();

            GetAPI();
            ReadIngredientsData();
        }

    










            //Written by Keith Webster. Used with permission. Not to be distributed.
            //Place this inside the class space in the form you would like to size.
            //Call this method AFTER InitializeComponent() inside the form's constructor.
            void HandleClientWindowSize()
        {

            StartPosition = FormStartPosition.Manual;
            this.Left = 600;
            this.Top = 100;

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

        private void btn_search_Click(object sender, EventArgs e) {
            SaveToCookBook();
        }




        //Vertical
        private void VerticalView() {
            menuStrip1.Size = new Size(25, 24);
            menuStrip1.Location = new Point(40, 47);
        }

        //Horizontal
        private void HorizontalView() {
            menuStrip1.Size = new Size(25, 24);
            menuStrip1.Location = new Point(40, 35);
        }

        private void rotateToolStripMenuItem_Click(object sender, EventArgs e) {
            if (settings.RotateSetting == false)
            {
                HorizontalView();
            }
            else if (settings.RotateSetting == true)
            {
                VerticalView();
            }
        }

        private void button1_Click_1(object sender, EventArgs e) {
            Close();
            AddRecipeForm newRecipe = new AddRecipeForm();
            newRecipe.ShowDialog();
        }
    }
}
