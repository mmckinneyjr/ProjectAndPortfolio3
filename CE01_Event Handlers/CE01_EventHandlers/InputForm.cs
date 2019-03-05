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


        public EventHandler<CustomEventArgs> AddMovie;
        Movie movie;

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

        private void btn_new_Click(object sender, EventArgs e) {

            movie = new Movie();
            if (AddMovie != null) {

                int checkIndex = 0;
                    if (rdoBtn_like.Checked)
                    checkIndex = 0;
                    else if (rdoBtn_dislike.Checked)
                    checkIndex = 1;


                    movie.title = txtBox_title.Text;
                    movie.year = txtBox_year.Text;
                    movie.genre = txtBox_genre.Text;
                    movie.indexNum = checkIndex;

                    AddMovie(this, new CustomEventArgs(txtBox_title.Text, checkIndex, movie));
    

                Close();
                
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
