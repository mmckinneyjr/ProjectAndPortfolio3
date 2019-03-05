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
        public EventHandler EditBtnVisiable;


        InputForm input;
        Movie m;
 
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
            if (listBox_like.SelectedItem != null)
            {
                SelectMovie += input.InsertMovieData;
                m = new Movie();
                if (SelectMovie != null && listBox_like.Focused == true)
                {
                    m = (Movie)listBox_like.SelectedItem;
                    SelectMovie(this, new CustomEventArgs(m));
                }

                EditBtnVisiable += input.EditBtnHandler;

                if (EditBtnVisiable != null)
                {
                    EditBtnVisiable(this, new EventArgs());
                }
                input.ShowDialog();
            }
        }

        //Open DISLIKE item
        private void listBox_dislike_DoubleClick(object sender, EventArgs e)  {
            if (listBox_dislike.SelectedItem != null)
            {
                SelectMovie += input.InsertMovieData;
                m = new Movie();
                if (SelectMovie != null && listBox_dislike.Focused == true)
                {
                    m = (Movie)listBox_dislike.SelectedItem;
                    SelectMovie(this, new CustomEventArgs(m));
                }
                EditBtnVisiable += input.EditBtnHandler;

                if (EditBtnVisiable != null)
                {
                    EditBtnVisiable(this, new EventArgs());
                }
                input.ShowDialog();
            }
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

        //Delete item
        private void btn_delete_Click(object sender, EventArgs e) {
            if (listBox_like.SelectedItem != null)  {
                listBox_like.Items.Remove(listBox_like.SelectedItem);
            }
            else if (listBox_dislike.SelectedItem != null) {
                listBox_dislike.Items.Remove(listBox_dislike.SelectedItem);
            }
        }

        //only allows one listbox to be selected
        private void listBox_dislike_Click(object sender, EventArgs e)  {
            listBox_like.SelectedItem = null;
        }
        //only allows one listbox to be selected
        private void listBox_like_Click(object sender, EventArgs e)  {
            listBox_dislike.SelectedItem = null;
        }


        //Move items left
        private void btn_moveL_Click(object sender, EventArgs e) {
            if (listBox_dislike.SelectedItem != null)
            {
                m = new Movie();
                m.like = ((Movie)listBox_dislike.SelectedItem).like = true;
                m.dislike = ((Movie)listBox_dislike.SelectedItem).dislike = false;
                listBox_like.Items.Add(listBox_dislike.SelectedItem);
                listBox_dislike.Items.Remove(listBox_dislike.SelectedItem);

                if (listBox_dislike.Items.Count > 0)
                {
                    listBox_dislike.SelectedIndex = 0;
                }
            }
        }

        //Movie items Right
        private void btn_moveR_Click(object sender, EventArgs e)  {
            if (listBox_like.SelectedItem != null)
            {
                m = new Movie();
                m.dislike = ((Movie)listBox_like.SelectedItem).dislike = true;
                m.like = ((Movie)listBox_like.SelectedItem).like = false;
                listBox_dislike.Items.Add(listBox_like.SelectedItem);
                listBox_like.Items.Remove(listBox_like.SelectedItem);

                if (listBox_like.Items.Count > 0)
                {
                    listBox_like.SelectedIndex = 0;
                }
            }
        }
    }
}
