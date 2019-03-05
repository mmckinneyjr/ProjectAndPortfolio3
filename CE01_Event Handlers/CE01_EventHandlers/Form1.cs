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

        public EventHandler<CustomEventArgs> SelectMovie;

        InputForm input;
        Movie m;
        int lbLike;
        int lbDislike;

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

        //Add movie to listBox button
        private void btn_new_Click(object sender, EventArgs e)  {
            input = new InputForm();
            input.AddNewMovie += AddMovieHandler;
            input.ShowDialog();
        }

        //Add movie to listBox handler
        private void AddMovieHandler(object sender, CustomEventArgs e)  {
            if (e.movieModify.like == true)  {
                listBox_like.Items.Add(e.movieModify);
            }
            else if (e.movieModify.dislike == true) {
                listBox_dislike.Items.Add(e.movieModify);
            }
            input.UpdateMovie += MovieDataUpdate;
        }

        //Open LIKE listbox item
        private void listBox_like_DoubleClick(object sender, EventArgs e)  {
            SelectMovie += input.InsertMovieData;
            m = new Movie();
            if (SelectMovie != null && listBox_like.Focused == true)  {
                m = (Movie)listBox_like.SelectedItem;
                SelectMovie(this, new CustomEventArgs(m));
            }
            input.ShowDialog();
        }

        //Open DISLIKE item
        private void listBox_dislike_DoubleClick(object sender, EventArgs e)  {
            SelectMovie += input.InsertMovieData;
            m = new Movie();
            if (SelectMovie != null && listBox_dislike.Focused == true) {
                m = (Movie)listBox_dislike.SelectedItem;
                SelectMovie(this, new CustomEventArgs(m));
            }
            input.ShowDialog();
        }


        //Update ListView
        private void MovieDataUpdate(object sender, CustomEventArgs e)  {
            if (e.movieModify.like == true) {
                int index = listBox_like.SelectedIndex;
                listBox_like.Items.RemoveAt(index);
                listBox_like.Items.Insert(index, e.movieModify);
            }
            if (e.movieModify.dislike == true) {
                int index = listBox_dislike.SelectedIndex;
                listBox_dislike.Items.RemoveAt(index);
                listBox_dislike.Items.Insert(index, e.movieModify);
            }
        }
    }
}
