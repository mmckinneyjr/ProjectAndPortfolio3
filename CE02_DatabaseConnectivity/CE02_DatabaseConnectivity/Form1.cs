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
            string sql = "SELECT ID, FirstName, LastName, PhoneNumber, Email, Relation FROM MyContacts ORDER BY FirstName ASC;";
            MySqlDataAdapter adr = new MySqlDataAdapter(sql, conn);
            adr.Fill(contactsDataTable);
            int contactCount = contactsDataTable.Select().Length;

            PopulateToListView();
            PopulateFields();

            conn.Close();
            return true;
        }

        //Populate listview
        private void PopulateToListView() {
            listView1.Clear();
            for (int i = 0; i < contactsDataTable.Select().Length; i++) { 
                ListViewItem lvi = new ListViewItem();
                contact = new Contact();
            lvi.Text = $"{contactsDataTable.Rows[i]["FirstName"].ToString()} {contactsDataTable.Rows[i]["LastName"].ToString()}";

                contact.ContactId = int.Parse(contactsDataTable.Rows[i]["ID"].ToString());
                contact.FirstName = contactsDataTable.Rows[i]["FirstName"].ToString();
                contact.LastName = contactsDataTable.Rows[i]["LastName"].ToString();
                contact.PhoneNumber = contactsDataTable.Rows[i]["PhoneNumber"].ToString();
                contact.EmailAddress = contactsDataTable.Rows[i]["Email"].ToString();
                contact.Relationship = contactsDataTable.Rows[i]["Relation"].ToString();


                switch (contact.Relationship) {
                    case "Family": { contact.RelationshipIndex = 0; } break;
                    case "Friend": { contact.RelationshipIndex = 1; } break;
                    case "Business": { contact.RelationshipIndex = 2; } break;
                    case "Other": { contact.RelationshipIndex = 3; } break;
                }

                lvi.ImageIndex = contact.RelationshipIndex;

                lvi.Tag = contact;

                listView1.Items.Add(lvi);


            }
            listView1.Items[currentRow].Selected = true;

            contactCount = contactsDataTable.Select().Length;
            textBox1.Text = $"Contacts {contactCount}";

        }

        //Exit application
        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        //Populate Screen Fields
        private void PopulateFields() {
            txtBox_firstName.Text = contactsDataTable.Rows[currentRow]["FirstName"].ToString();
            txtBox_lastName.Text = contactsDataTable.Rows[currentRow]["LastName"].ToString();
            txtBox_phoneNumber.Text = contactsDataTable.Rows[currentRow]["PhoneNumber"].ToString();
            txtBox_emailAddress.Text = contactsDataTable.Rows[currentRow]["Email"].ToString();
            cmboBox_relation.Text = contactsDataTable.Rows[currentRow]["Relation"].ToString();
        }

        //Written by Keith Webster.  Used with permission.  Not to be distributed.  
        //Place this inside the class space in the form you would like to size.
        //Call this method AFTER InitializeComponent() inside the form's constructor.
        void HandleClientWindowSize()  {
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

            btn_deleteContact.FlatStyle = FlatStyle.Flat;
            btn_deleteContact.FlatAppearance.BorderSize = 0;
            btn_deleteContact.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btn_deleteContact.FlatAppearance.MouseDownBackColor = Color.Transparent;

            btn_clear.FlatStyle = FlatStyle.Flat;
            btn_clear.FlatAppearance.BorderSize = 0;
            btn_clear.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btn_clear.FlatAppearance.MouseDownBackColor = Color.Transparent;

            btn_update.FlatStyle = FlatStyle.Flat;
            btn_update.FlatAppearance.BorderSize = 0;
            btn_update.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btn_update.FlatAppearance.MouseDownBackColor = Color.Transparent;

            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button1.FlatAppearance.MouseDownBackColor = Color.Transparent;

            button2.FlatStyle = FlatStyle.Flat;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button2.FlatAppearance.MouseDownBackColor = Color.Transparent;

            button3.FlatStyle = FlatStyle.Flat;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button3.FlatAppearance.MouseDownBackColor = Color.Transparent;

            button4.FlatStyle = FlatStyle.Flat;
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button4.FlatAppearance.MouseDownBackColor = Color.Transparent;

        }

        //Save to print
        private void saveToPrintToolStripMenuItem_Click(object sender, EventArgs e) {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.FileName = "ContactList.txt";
            saveFile.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (saveFile.ShowDialog() == DialogResult.OK) {
                using (StreamWriter str = new StreamWriter(saveFile.OpenFile())) {

                    str.WriteLine("My Contacts");
                    str.WriteLine($"{DateTime.Now.ToString()}\r\n");

                    for (int x = 0; x < listView1.Items.Count; x++) {                  
                        str.WriteLine(((Contact)listView1.Items[x].Tag).SaveOutput());
                        str.WriteLine("");
                    }                   
                }
            }
        }

        //First Button
        private void button1_Click(object sender, EventArgs e)  {
            currentRow = 0;
            PopulateFields();
        }

        //Previous button
        private void button2_Click(object sender, EventArgs e)  {
            if (currentRow > 0) {
                currentRow--;
                PopulateFields();
                listView1.Items[currentRow].Selected = true;
            }

            else {
                currentRow = contactsDataTable.Select().Length - 1;
                PopulateFields();
            }

        }

        //Next Button
        private void button3_Click(object sender, EventArgs e) {
            if (currentRow < contactsDataTable.Select().Length - 1 ) {
                currentRow++;
                PopulateFields();
            }

            else {
                currentRow = 0;
                PopulateFields();
            }
        }

        //Last Button
        private void button4_Click(object sender, EventArgs e)  {
            currentRow = contactsDataTable.Select().Length - 1;
            PopulateFields();
        }

     

















    }
}
