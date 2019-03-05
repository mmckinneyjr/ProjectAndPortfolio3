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
    public partial class InputForm : Form
    {


        public EventHandler<CustomEventArgs> addNewMovie;


        public InputForm() {
            InitializeComponent();
            HandleClientWindowSize();
        }












        //Written by Keith Webster. Used with permission. Not to be distributed.
        //Place this inside the class space in the form you would like to size.
        //Call this method AFTER InitializeComponent() inside the form's constructor.
        void HandleClientWindowSize()  {
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

        //Save new item to listbox
        private void btn_new_Click(object sender, EventArgs e) {
            if (addNewMovie != null) {
                Movie m = new Movie();

                m.title = txtBox_title.Text;
                m.year = txtBox_year.Text;
                m.genre = txtBox_genre.Text;
                m.like = rdoBtn_like.Checked;
                m.dislike = rdoBtn_dislike.Checked;
                addNewMovie(this, new CustomEventArgs(m));
            }
        }

        //Open Existing Ship
        public void InsertMovieData(object sender, CustomEventArgs e) {
            txtBox_title.Text = e.movieModify.title;
            txtBox_year.Text = e.movieModify.year;
            txtBox_genre.Text = e.movieModify.genre;
            rdoBtn_like.Checked = e.movieModify.like;
            rdoBtn_dislike.Checked = e.movieModify.dislike;
        }




    }
}
