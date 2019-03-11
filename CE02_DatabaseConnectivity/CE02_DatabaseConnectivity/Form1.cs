using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;

namespace CE02_DatabaseConnectivity
{
    public partial class Form1 : Form
    {

        ContactForm contactForm;
        Contact contact;
        int contactCount = 0;
        int currentRow = 0;

        MySqlConnection conn = new MySqlConnection();
        DataTable contactsDataTable = new DataTable();
        string connectionString = Connection.BuildConnectionString();

        public Form1()  {
            InitializeComponent();
            HandleClientWindowSize();

            conn = Connection.Connect(connectionString);

            RetrieveData();
    
        }

        //Method to retrieve data
        private bool RetrieveData() {
            contactsDataTable.Clear();
            string sql = "SELECT contactId, firstName, lastName, phoneNumber, emailAddress, relation FROM MyContacts ORDER BY firstName ASC;";
            MySqlDataAdapter adr = new MySqlDataAdapter(sql, conn);
            adr.Fill(contactsDataTable);
            int contactCount = contactsDataTable.Select().Length;

            PopulateToListView();

            conn.Close();
            return true;

        }








        //Populate listview
        private void PopulateToListView()
        {

            for (int i = 0; i < contactsDataTable.Select().Length; i++)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = $"{contactsDataTable.Rows[i]["firstName"].ToString()} {contactsDataTable.Rows[i]["lastName"].ToString()}";

                switch (contactsDataTable.Rows[i]["relation"].ToString())
                {
                    case "Family": { lvi.ImageIndex = 0; } break;
                    case "Friend": { lvi.ImageIndex = 1; } break;
                    case "Business": { lvi.ImageIndex = 2; } break;
                    case "Other": { lvi.ImageIndex = 3; } break;
                }


                lvi.Tag = contactsDataTable.Rows[i];
                listView1.Items.Add(lvi);
            }

            contactCount = contactsDataTable.Select().Length;
        }























        //Add new contact
        private void btn_addNew_Click(object sender, EventArgs e)
        {
            contactForm = new ContactForm();

            contactForm.Show();
        }



   //Exit application
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }




        //Written by Keith Webster.  Used with permission.  Not to be distributed.  
        //Place this inside the class space in the form you would like to size.
        //Call this method AFTER InitializeComponent() inside the form's constructor.
        void HandleClientWindowSize()
        {
            //Modify ONLY these float values
            float HeightValueToChange = 1.3f;
            float WidthValueToChange = 6.0f;

            //DO NOT MODIFY THIS CODE
            int height = Convert.ToInt32(Screen.PrimaryScreen.WorkingArea.Size.Height / HeightValueToChange);
            int width = Convert.ToInt32(Screen.PrimaryScreen.WorkingArea.Size.Width / WidthValueToChange);
            if (height < Size.Height)
                height = Size.Height;
            if (width < Size.Width)
                width = Size.Width;
            this.Size = new Size(width, height);
            //this.Size = new Size(376, 720);

            fileToolStripMenu.Size = new Size (30,25);
            fileToolStripMenu.BackColor =  Color.Transparent;

            btn_addNew.FlatStyle = FlatStyle.Flat;
            btn_addNew.FlatAppearance.BorderSize = 0;
            btn_addNew.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btn_addNew.FlatAppearance.MouseDownBackColor = Color.Transparent;

            textBox1.Text = $"{contactCount} Contacts";

        }

    }
}
