using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CE01_EventHandlers
{
    public partial class Form1 : Form
    {
        ListViewItem lvi = new ListViewItem();


        public Form1()
        {
            InitializeComponent();
            HandleClientWindowSize();
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


        private void btn_new_Click_1(object sender, EventArgs e) {

            InputForm input = new InputForm();

            input.AddMovie += addMovieHandler;

            input.ShowDialog();

        }

        public void addMovieHandler(object sender, CustomEventArgs e) {
            MessageBox.Show("THIS WORKS4");
            lvi = new ListViewItem();
            lvi.Text = e.title;
            lvi.Tag = e.movieData;

            if (e.indexNum == 0) {
                listView_like.Items.Add(lvi);
            }

            else if (e.indexNum == 1) {
                listView_dislike.Items.Add(lvi);

            }
        }
    }
}
