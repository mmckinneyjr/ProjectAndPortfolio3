using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CE02_DatabaseConnectivity
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            HandleClientWindowSize();
        }

        ContactForm contactForm;

        int contactCount = 0;


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

        //Exit application
        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        //Add new contact
        private void btn_addNew_Click(object sender, EventArgs e) {
            contactForm = new ContactForm();

            contactForm.Show();
        }
    }
}
