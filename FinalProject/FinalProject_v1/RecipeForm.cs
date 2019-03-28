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


        public EventHandler<CustomEventArgs> UpdateMain;
        public EventHandler previousScreen;
        public EventHandler previousScreenHome;

        Recipe rec;

        Buttons buttons = new Buttons();
        public bool rotateView;
        public string addvisable = "";


        //Database Connection
        MySqlConnection conn = new MySqlConnection();
        DataTable contactsDataTable = new DataTable();
        string connectionString = DatabaseConnect.BuildConnectionString();


        public RecipeForm()
        {
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
        string getAPI_p1 = "https://www.food2fork.com/api/get?key=dcff82f824fc70f1d85597f6f4f1278d&rId=";
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

        //Get myrecipe book item
            public void MyRecipeHandler(object sender, CustomEventArgs e) {
            rec = new Recipe();


            rec.RecipeId = e.sendRecipe.RecipeId;
            label_title.Text = e.sendRecipe.Title;
            foreach (var i in e.sendRecipe.Ingredients) {
                listBox2.Items.Add(i);
            }
            pictureBox_recipeImage.Load(e.sendRecipe.ImageLink);
            label_source.Text = e.sendRecipe.SourceLink;
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

        //Vertical
        private void VerticalView() {
            Size = new Size(353, 702);
            BackgroundImage = Properties.Resources.FinalBackgroundAdd;
            menuStrip1.Size = new Size(25, 24);
            menuStrip1.Location = new Point(40, 47);
            btn_new.Location = new Point(126, 599);
            btn_home.Location = new Point(28, 599);
            label1.Location = new Point(44, 311);
            listBox2.Location = new Point(47, 335);
            label2.Location = new Point(48,524);
            btn_back.Location = new Point(243, 54);
            pictureBox_recipeImage.Location = new Point(47, 162);
            label_source.Location = new Point(90, 524);
            label_title.Location = new Point(47, 100);
            pictureBox_recipeImage.Location = new Point(47, 162);
            btn_myRecipe.Location = new Point(221, 599);
            rotateView = false;
        }

        //Horizontal
        private void HorizontalView() {
            Size = new Size(702, 353);
            BackgroundImage = Properties.Resources.iPhoneXImage_H;
            menuStrip1.Size = new Size(25, 24);
            menuStrip1.Location = new Point(40, 35);
            btn_home.Location = new Point(200, 255);
            btn_new.Location = new Point(300, 255);
            label1.Location = new Point(370, 30);
            listBox2.Location = new Point(370, 55);
            btn_myRecipe.Location = new Point(400, 255);
            btn_back.Location = new Point(255, 35);
            pictureBox_recipeImage.Location = new Point(47,115);
            label2.Location = new Point(370, 228);
            label_source.Location = new Point(410,228);
            label_title.Location = new Point(47, 75);
            label_title.FlatStyle = FlatStyle.Flat;      
            rotateView = true;
        }

        //Written by Keith Webster. Used with permission. Not to be distributed.
        //Place this inside the class space in the form you would like to size.
        //Call this method AFTER InitializeComponent() inside the form's constructor.
        void HandleClientWindowSize()  {
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

            buttons.ButtonsTrans(btn_back);
            buttons.ButtonsTrans(btn_new);
            buttons.ButtonsTrans(btn_home);
            buttons.ButtonsTrans(btn_myRecipe);

         
        }

        //Back Button
        private void button1_Click(object sender, EventArgs e) {
            Close();
        }

        //Save to favorites button
        private void btn_search_Click(object sender, EventArgs e)  {
            SaveToCookBook();
            MessageBox.Show("Recipe has been added\r\nto your Cookbook");
        }

        //Add New Recipe Form
        private void button1_Click_1(object sender, EventArgs e) {
            AddRecipeForm newRecipe = new AddRecipeForm();
            newRecipe.rotateView = rotateView;
            newRecipe.ShowDialog();
            
            Close();
        }

        //Rotate Buttong
        private void rotateToolStripMenuItem_Click_1(object sender, EventArgs e)  {
            if (rotateView == true)  {
                HorizontalView();
            }
            else if (rotateView == false) {
                VerticalView();
            }
        }

        //Load form
        private void RecipeForm_Load_1(object sender, EventArgs e) {
            if (rotateView == true) {
                HorizontalView();
            }
            else if (rotateView == false) {
                VerticalView();
            }

            if (addvisable == "search") {
                btn_add.Visible = true;
            }
            else if (addvisable == "myRecipes") {
                btn_add.Visible = false;

            }
        }

        //Rotate button
        private void rotateToolStripMenuItem_Click(object sender, EventArgs e)  {
            if (rotateView == false)  {
                HorizontalView();
            }
            else if (rotateView == true)  {
                VerticalView();
            }

            if (UpdateMain != null) {
                Recipe rec = new Recipe();
                rec.ViewSettings = rotateView;
                UpdateMain(this, new CustomEventArgs(rec));
            }
        }

        //back to my recipe
        private void btn_myRecipe_Click(object sender, EventArgs e)  {
            if (previousScreen != null)  {
                previousScreen(this, new EventArgs());
            }
            Close();
        }

        //Exit application
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)  {
            Application.Exit();
        }

        private void btn_home_Click(object sender, EventArgs e)  {
            if (previousScreenHome != null)
            {
                previousScreenHome(this, new EventArgs());
            }
            Close();
        }
    }
}
