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
    public partial class AddRecipeForm : Form
    {


        public EventHandler<CustomEventArgs> UpdateMain;
        public EventHandler previousScreen;
        public EventHandler previousScreenHome;

        Buttons buttons = new Buttons();
        public bool rotateView;


        //Database Connection
        MySqlConnection conn = new MySqlConnection();
        DataTable contactsDataTable = new DataTable();
        string connectionString = DatabaseConnect.BuildConnectionString();

        public AddRecipeForm()
        {
            InitializeComponent();
            HandleClientWindowSize();
            conn = DatabaseConnect.Connect(connectionString);
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

            buttons.ButtonsTrans(btn_myRecipes);
            buttons.ButtonsTrans(btn_home);
            buttons.ButtonsTrans(btn_back);


        }

        //Vertical
        private void VerticalView()
        {
            Size = new Size(353, 702);
            BackgroundImage = Properties.Resources.FinalBackground_newRecipe;
            menuStrip1.Size = new Size(25, 24);
            menuStrip1.Location = new Point(40, 47);
            btn_search.Size = new Size(256, 32);
            btn_search.Location = new Point(42, 541);
            label1.Location = new Point(42, 181);
            txtBox_title.Location = new Point(44, 196);
            label2.Location = new Point(42, 231);
            txtBox_ingredients.Location = new Point(44, 246);
            label3.Location = new Point(42, 279);
            txtBox_directions.Location = new Point(44, 295);
            label4.Location = new Point(42, 331);
            txtBox_imageUrl.Location = new Point(44, 345);
            label5.Location = new Point(42, 381);
            txtBox_sourceUrl.Location = new Point(44, 395);
            btn_back.Location = new Point(243, 54);
            label6.Location = new Point(102, 234);
            label7.Location = new Point(104, 383);

            btn_home.Location = new Point(28, 599);
            btn_myRecipes.Location = new Point(221, 599);

            rotateView = false;


        }

        //Horizontal
        private void HorizontalView()
        {
            Size = new Size(702, 353);
            BackgroundImage = Properties.Resources.FinalBackground_newRecipeH;

            menuStrip1.Size = new Size(25, 24);
            menuStrip1.Location = new Point(40, 35);
            btn_search.Location = new Point(45, 205);

            label1.Location = new Point(372, 40);
            txtBox_title.Location = new Point(374, 55);
            label2.Location = new Point(372, 80);
            txtBox_ingredients.Location = new Point(374, 95);
            label3.Location = new Point(372, 120);
            txtBox_directions.Location = new Point(374, 135);
            label4.Location = new Point(372, 160);
            txtBox_imageUrl.Location = new Point(374, 175);
            label5.Location = new Point(372, 200);
            txtBox_sourceUrl.Location = new Point(374, 215);
            btn_back.Location = new Point(255, 35);
            label6.Location = new Point(432, 83);
            label7.Location = new Point(440, 203);

            btn_home.Location = new Point(200, 255);
            btn_myRecipes.Location = new Point(400, 255);

            rotateView = true;

        }

        //Rotate view button
        private void rotateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rotateView == false)
            {
                HorizontalView();
            }
            else if (rotateView == true)
            {
                VerticalView();
            }

            if (UpdateMain != null)
            {
                Recipe rec = new Recipe();
                rec.ViewSettings = rotateView;
                UpdateMain(this, new CustomEventArgs(rec));
            }
        }

        //Home Button
        private void button2_Click(object sender, EventArgs e)
        {
            if (previousScreenHome != null)
            {
                previousScreenHome(this, new EventArgs());
            }
            Close();
        }

        //Cancel Button
        private void btn_back_Click(object sender, EventArgs e)
        {
            Close();
        }

        //Check for new recipeID 
        private void btn_search_Click(object sender, EventArgs e)
        {
            string sql = "INSERT INTO Recipes (recipeId, title, ingredients, imageUrl, sourceUrl, directions) VALUES(@ID, @title, @ingredients, @imageurl, @sourceURL, @directions);";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = null;

            cmd.Parameters.AddWithValue("@ID", IdGenerator(rdr));
            cmd.Parameters.AddWithValue("@title", txtBox_title.Text);
            cmd.Parameters.AddWithValue("@ingredients", txtBox_ingredients.Text);
            cmd.Parameters.AddWithValue("@imageurl", txtBox_imageUrl.Text);
            cmd.Parameters.AddWithValue("@sourceURL", txtBox_sourceUrl.Text);
            cmd.Parameters.AddWithValue("@directions", txtBox_directions.Text);

            rdr = cmd.ExecuteReader();

            conn.Close();

            MessageBox.Show("Your Recipe Has Been Added");
        }

        //Random Recipe Id generator
        public string IdGenerator(MySqlDataReader r)
        {
            Random random = new Random();
            int length = 6;
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            string RandomString = new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());

            string rand = RandomString;
            string valID = rand;
            string test = "";

            string sqlID = "SELECT recipeId FROM Recipes WHERE recipeId = @randID";
            MySqlCommand cmd = new MySqlCommand(sqlID, conn);

            cmd.Parameters.AddWithValue("@randID", RandomString);

            r = cmd.ExecuteReader();

            while (r.Read())
            {
                test = r.GetString("recipeId");

                if (test != rand)
                {
                    valID = rand;
                }

                else
                {
                    while (test == rand)
                    {
                        rand = RandomString;
                        valID = rand;
                    }
                }
            }

            r.Close();
            return valID + "c";
        }


        //Load form
        private void AddRecipeForm_Load_1(object sender, EventArgs e)
        {
            if (rotateView == true)
            {
                HorizontalView();
            }
            else if (rotateView == false)
            {
                VerticalView();
            }
        }

        private void btn_myRecipes_Click(object sender, EventArgs e)
        {
            if (previousScreen != null)
            {
                previousScreen(this, new EventArgs());
            }
            Close();

        }
    }
}

