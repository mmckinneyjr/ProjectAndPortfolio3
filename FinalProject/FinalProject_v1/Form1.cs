using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using System.Net;
using MySql.Data.MySqlClient;
using System.Linq;


//NOTE THE FOOD2FORK API ONLY ALLOWS FOR 50 QUERIES A DAY

namespace FinalProject_v1
{
    public partial class Form1 : Form
    {

        //Local Variables
        Recipe recipe;
        Buttons buttons = new Buttons();
        public EventHandler<CustomEventArgs> sendRecipeId;
        public EventHandler<CustomEventArgs> sendMyRecipeId;

        public string selectedListBoxDisplay = "search";
        int screenSelection = 0;

        public bool rotateView = false;

        //Database Connection
        MySqlConnection conn = new MySqlConnection();
        DataTable favoritesDataTable = new DataTable();
        string connectionString = DatabaseConnect.BuildConnectionString();

        //API Connection & Connection String
        WebClient apiConnection = new WebClient();
        string searchAPI_p1 = "https://www.food2fork.com/api/search?key=dcff82f824fc70f1d85597f6f4f1278d&q=";
        string searchAPI_p2;

        public Form1() {
            InitializeComponent(); ;
            HandleClientWindowSize();
            conn = DatabaseConnect.Connect(connectionString);
            //RetrieveData();
        }

        //Create Search API string
        private void SearchAPI() {
            string search = textBox1.Text;
            searchAPI_p2 = searchAPI_p1 + search;
        }

        //Pull Data from Search API
        private void ReadSearchData() {
            label_noResults.Text = "";
            listBox1.Items.Clear();
            string apiSearchData = apiConnection.DownloadString(searchAPI_p2);
            JObject rCount = JObject.Parse(apiSearchData);

            if (int.Parse(rCount["count"].ToString()) == 0) {
                label_noResults.Text = "No Results Found";
            }

            else {
                for (int i = 0; i < int.Parse(rCount["count"].ToString()); i++) {
                    JObject search = JObject.Parse(apiSearchData);
                    Recipe r = new Recipe();

                    r.Title = search["recipes"][i]["title"].ToString();
                    r.RecipeId = search["recipes"][i]["recipe_id"].ToString();
                    r.ImageLink = search["recipes"][i]["image_url"].ToString();
                    r.SourceLink = search["recipes"][i]["source_url"].ToString();

                    listBox1.Items.Add(r);
                }
            }
        }

        //Search Button Click
        private void btn_search_Click(object sender, EventArgs e) {
            btn_search.Visible = true;
            listBox1.Visible = true;
            listBox2.Visible = false;
            SearchAPI();
            ReadSearchData();

        }

        //Open a search recipe item
        private void listBox1_DoubleClick(object sender, EventArgs e)  {     
            
        
                RecipeForm recipeForm = new RecipeForm();
                sendRecipeId += recipeForm.GetRecipeHandler;
                recipeForm.previousScreen += btn_myRecipes_Click;
     
            recipe = new Recipe();

            recipeForm.addvisable = selectedListBoxDisplay;

            textBox1.Text = ((Recipe)listBox1.SelectedItem).Title;

                if (sendRecipeId != null) {
                    sendRecipeId(this, new CustomEventArgs((Recipe)listBox1.SelectedItem));
                }
                recipeForm.rotateView = rotateView;
                recipeForm.UpdateMain += rotateToolStripMenuItem_Click;
            recipeForm.previousScreenHome += button1_Click;
            recipeForm.addvisable = "search";
            recipeForm.ShowDialog();

        }

        //Open a my recipe item
        private void listBox2_DoubleClick(object sender, EventArgs e) {
            RecipeForm recipeForm = new RecipeForm();
            recipe = new Recipe();

            recipeForm.addvisable = selectedListBoxDisplay;

            sendMyRecipeId += recipeForm.MyRecipeHandler;

            if (sendMyRecipeId != null)  {
                recipe.RecipeId = ((Recipe)listBox2.SelectedItem).RecipeId;
                recipe.Title = ((Recipe)listBox2.SelectedItem).Title;
                recipe.Ingredients = ((Recipe)listBox2.SelectedItem).Ingred.Split(',').ToList();
                recipe.ImageLink = ((Recipe)listBox2.SelectedItem).ImageLink;
                recipe.SourceLink = ((Recipe)listBox2.SelectedItem).SourceLink;
                sendMyRecipeId(this, new CustomEventArgs(recipe));

            }
            recipeForm.rotateView = rotateView;
            recipeForm.UpdateMain += rotateToolStripMenuItem_Click;
            recipeForm.previousScreenHome += button1_Click;
            recipeForm.addvisable = "myRecipes";
            recipeForm.ShowDialog();


        }

        //Vertical view
        private void VerticalView() {
            Size = new Size(353, 702);
            if (screenSelection == 0) { BackgroundImage = Properties.Resources.FinalBackground; }

            else if (screenSelection == 1) { BackgroundImage = Properties.Resources.FinalBackground_newRecipe; }
            else if (screenSelection == 2) { BackgroundImage = Properties.Resources.FinalBackground_myCookbook; }

            textBox1.Location = new Point(72, 107);
            btn_search.Size = new Size(256, 32);
            btn_search.Location = new Point(42, 541);
            listBox1.Size = new Size(258, 355);
            listBox1.Location = new Point(42, 166);
            listBox2.Size = new Size(258, 355);
            listBox2.Location = new Point(42, 166);
            menuStrip1.Size = new Size(25, 24);
            menuStrip1.Location = new Point(40, 47);

            btn_newRecipe.Location = new Point(126, 599);
            btn_Home.Location = new Point(28, 599);
            btn_myRecipes.Location = new Point(221, 599);

            btn_clear.Location = new Point(266, 100);
            label_noResults.Location = new Point(88, 297);

            rotateView = false;
        }

        //Horizontal view
        private void HorizontalView()  {
            Size = new Size(702, 353);
            if (screenSelection == 0) { BackgroundImage = Properties.Resources.iPhoneXImageH; }
            else if (screenSelection == 1) { BackgroundImage = Properties.Resources.FinalBackground_newRecipeH; }
            else if (screenSelection == 2) { BackgroundImage = Properties.Resources.iPhoneXImage_myCookbookH; }

            textBox1.Location = new Point(70, 85);
            btn_search.Location = new Point(45, 205);
            listBox1.Location = new Point(345, 40);
            listBox1.Size = new Size(290, 200);
            listBox2.Location = new Point(345, 40);
            listBox2.Size = new Size(290, 200);
            menuStrip1.Size = new Size(25, 24);
            menuStrip1.Location = new Point(40, 35);

            btn_Home.Location = new Point(200, 255);
            btn_newRecipe.Location = new Point(300, 255);
            btn_myRecipes.Location = new Point(400, 255);

            btn_clear.Location = new Point(270, 78);
            label_noResults.Location = new Point(415, 100);

            rotateView = true;
        }

        //Written by Keith Webster. Used with permission. Not to be distributed.
        //Place this inside the class space in the form you would like to size.
        //Call this method AFTER InitializeComponent() inside the form's constructor.
        void HandleClientWindowSize() {
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

            buttons.ButtonsTrans(btn_clear);
            buttons.ButtonsTrans(btn_Home);
            buttons.ButtonsTrans(btn_newRecipe);
            buttons.ButtonsTrans(btn_myRecipes);
        }


        //Rotate screen button
        private void rotateToolStripMenuItem_Click(object sender, EventArgs e)  {
            if (rotateView == false) {
                HorizontalView();
            }
            else if (rotateView == true)  {
                VerticalView();
            }
        }





        //New recipe Button
        private void button2_Click(object sender, EventArgs e)  {
            screenSelection = 1;
            AddRecipeForm newRecipe = new AddRecipeForm();
            newRecipe.rotateView = rotateView;
            newRecipe.UpdateMain += rotateToolStripMenuItem_Click;
            newRecipe.previousScreen += btn_myRecipes_Click;
            newRecipe.previousScreenHome += button1_Click;
            newRecipe.ShowDialog();
        }

        //My recipe button
        private void btn_myRecipes_Click(object sender, EventArgs e) {
            selectedListBoxDisplay = "myRecipes";
            

            screenSelection = 2;

            if (rotateView == false) { BackgroundImage = Properties.Resources.FinalBackground_myCookbook; }
            else if (rotateView == true) { BackgroundImage = Properties.Resources.iPhoneXImage_myCookbookH; }
            btn_clear.Visible = false;
            textBox1.Visible = false;
            btn_search.Visible = false;
            listBox1.Visible = false;
            listBox2.Visible = true;
            listBox2.Items.Clear();
            favoritesDataTable.Clear();

            string sql = "SELECT recipeId, title, ingredients, imageUrl, sourceUrl FROM Recipes;";

            MySqlDataAdapter adr = new MySqlDataAdapter(sql, conn);

            adr.Fill(favoritesDataTable);
            conn.Close();


            for (int i = 0; i < favoritesDataTable.Select().Length; i++) {
                Recipe r = new Recipe();

                r.RecipeId = favoritesDataTable.Rows[i]["recipeId"].ToString();
                r.Title = favoritesDataTable.Rows[i]["title"].ToString();
                r.Ingred = favoritesDataTable.Rows[i]["ingredients"].ToString();
                r.ImageLink = favoritesDataTable.Rows[i]["imageUrl"].ToString();
                r.SourceLink = favoritesDataTable.Rows[i]["sourceUrl"].ToString();

                listBox2.Items.Add(r);
            }

            
        }

        //Home Button
        private void button1_Click(object sender, EventArgs e) {
            screenSelection = 0;

            if (rotateView == false) { BackgroundImage = Properties.Resources.FinalBackground; }
            else if (rotateView == true) { BackgroundImage = Properties.Resources.iPhoneXImageH; }
            textBox1.Visible = true;
            btn_clear.Visible = true;
            btn_search.Visible = true;
            listBox1.Visible = true;
            listBox2.Visible = false;
        }


        //Clear search field and listbox items
        private void button2_Click_1(object sender, EventArgs e) {
            textBox1.Text = "";
            listBox1.Items.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)  {
            if (rotateView == true)  {
                HorizontalView();
            }
            else if (rotateView == false) {
                VerticalView();
            }
        }

        //Exit application
        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
