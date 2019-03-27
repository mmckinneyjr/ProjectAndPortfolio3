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


        public void newSettings(object sender, CustomSettings e) {
            settings.RotateSetting = e.rotateSetting.RotateSetting;
        }

        //Database Connection
        MySqlConnection conn = new MySqlConnection();
        DataTable contactsDataTable = new DataTable();
        string connectionString = DatabaseConnect.BuildConnectionString();

        Settings settings = new Settings();

        public void startSettings() {
            if (settings.RotateSetting == false)
            {
                HorizontalView();
            }
            else if (settings.RotateSetting == true)
            {
                VerticalView();
            }
        }


        public AddRecipeForm()
        {
            InitializeComponent();
            HandleClientWindowSize();
            conn = DatabaseConnect.Connect(connectionString);
            startSettings();

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



        }


        //Vertical
        private void VerticalView() {
            Size = new Size(353, 702);
            BackgroundImage = Properties.Resources.FinalBackground_newRecipe;
            menuStrip1.Size = new Size(25, 24);
            menuStrip1.Location = new Point(40, 47);

            settings.RotateSetting = false;

        }

        //Horizontal
        private void HorizontalView() {
            Size = new Size(702, 353);
            BackgroundImage = Properties.Resources.FinalBackground_newRecipeH;

            menuStrip1.Size = new Size(25, 24);
            menuStrip1.Location = new Point(40, 35);

            settings.RotateSetting = true;

        }

        private void rotateToolStripMenuItem_Click(object sender, EventArgs e) {
            if (settings.RotateSetting == false)  {
                HorizontalView();
            }
            else if (settings.RotateSetting == true) {
                VerticalView();
            }
        }

        private void button2_Click(object sender, EventArgs e) {
            Close();
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            Close();
        }

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


       

 
    }
    }

