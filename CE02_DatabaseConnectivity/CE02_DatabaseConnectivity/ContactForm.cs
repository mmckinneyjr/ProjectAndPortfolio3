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
    public partial class ContactForm : Form
    {
        public ContactForm()
        {
            InitializeComponent();
            HandleClientWindowSize();
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

            btn_deleteContact.FlatStyle = FlatStyle.Flat;
            btn_deleteContact.FlatAppearance.BorderSize = 0;
            btn_deleteContact.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btn_deleteContact.FlatAppearance.MouseDownBackColor = Color.Transparent;

            btn_cancel.FlatStyle = FlatStyle.Flat;
            btn_cancel.FlatAppearance.BorderSize = 0;
            btn_cancel.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btn_cancel.FlatAppearance.MouseDownBackColor = Color.Transparent;
        }

        //Cancel Button
        private void btn_cancel_Click(object sender, EventArgs e)  {
            Close();
        }

        //Delete button
        private void btn_deleteContact_Click(object sender, EventArgs e)  {
            Close();
        }
    }
}
