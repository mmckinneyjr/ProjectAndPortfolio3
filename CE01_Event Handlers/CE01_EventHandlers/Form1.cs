using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

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
                if (listBox_like.Items.Count > 0)
                { listBox_like.SelectedIndex = 0; }

            }
            else if (listBox_dislike.SelectedItem != null) {
                listBox_dislike.Items.Remove(listBox_dislike.SelectedItem);
                if (listBox_dislike.Items.Count > 0)
                {
                    listBox_dislike.SelectedIndex = 0;
                }

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

        //Exit Application
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)  {
            Application.Exit();
        }

        //Save list to XML
        private void saveListToolStripMenuItem_Click(object sender, EventArgs e) {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "xml files (*.xml)|*.xml";
            if (dlg.ShowDialog() == DialogResult.OK)  {

                XmlWriterSettings settings = new XmlWriterSettings();
                settings.ConformanceLevel = ConformanceLevel.Document;
                settings.Indent = true;
                settings.CloseOutput = true;

                using (XmlWriter writer = XmlWriter.Create(dlg.OpenFile(), settings))  {
                    writer.WriteStartElement("MovieData-2KJ34KJHKJ234JKH23J4HKJ23K");

                    foreach (Movie item in listBox_like.Items)  {

                        writer.WriteStartElement("item");

                        writer.WriteElementString("title", item.title);
                        writer.WriteElementString("year", item.year);
                        writer.WriteElementString("genre", item.genre);
                        writer.WriteElementString("like", item.like.ToString());
                        writer.WriteElementString("dislike", item.dislike.ToString());

                        writer.WriteEndElement();
                    }
                    foreach (Movie item in listBox_dislike.Items)  {

                        writer.WriteStartElement("item");

                        writer.WriteElementString("title", item.title);
                        writer.WriteElementString("year", item.year);
                        writer.WriteElementString("genre", item.genre);
                        writer.WriteElementString("like", item.like.ToString());
                        writer.WriteElementString("dislike", item.dislike.ToString());

                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();
                }
            }
        }

        private void loadListToolStripMenuItem_Click(object sender, EventArgs e) {

            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "xml files (*.xml)|*.xml";
            if (dlg.ShowDialog() == DialogResult.OK) {
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.ConformanceLevel = ConformanceLevel.Document;
                settings.IgnoreComments = true;
                settings.IgnoreWhitespace = true;

                using (XmlReader reader = XmlReader.Create(dlg.OpenFile(), settings))
                {
                    while (reader.Read())  {

                        XmlDocument xml = new XmlDocument();
                        xml.Load(reader);
                        XmlNodeList nodeList;
                        XmlNode root = xml.DocumentElement;

                        if (root.Name != "MovieData-2KJ34KJHKJ234JKH23J4HKJ23K") {
                            MessageBox.Show("Your file is not supported by this application");
                            return;
                        }

                        nodeList = root.SelectNodes("item");
                        for (int i = 0; i < nodeList.Count; i++)  {
                            Movie movie = new Movie();

                            movie.title = nodeList[i].SelectSingleNode("title").InnerText;
                            movie.year = nodeList[i].SelectSingleNode("year").InnerText;
                            movie.genre = nodeList[i].SelectSingleNode("genre").InnerText;
                            movie.like = bool.Parse(nodeList[i].SelectSingleNode("like").InnerText);
                            movie.dislike = bool.Parse(nodeList[i].SelectSingleNode("dislike").InnerText);

                            if (movie.like == true)
                            {
                                listBox_like.Items.Add(movie);
                            }

                            else if (movie.dislike == true) {
                                listBox_dislike.Items.Add(movie);
                            }
                        }


                    }
                }
            }
        }
    }
}
