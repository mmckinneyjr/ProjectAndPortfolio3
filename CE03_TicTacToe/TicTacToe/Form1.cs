using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Xml;


namespace TicTacToe
{
    public partial class frmTicTacToe : Form
    {

        // NAME: Mark Mckinney
        // CLASS AND TERM: Project and Portfolio III - C201903
        // PROJECT: Tic Tac Toe

        Dictionary<Button, Square> Squares = new Dictionary<Button, Square>();

        public void InitializeSquares() {
            Squares.Add(r1c1button, new Square());
            Squares.Add(r1c2button, new Square());
            Squares.Add(r1c3button, new Square());
            Squares.Add(r2c1button, new Square());
            Squares.Add(r2c2button, new Square());
            Squares.Add(r2c3button, new Square());
            Squares.Add(r3c1button, new Square());
            Squares.Add(r3c2button, new Square());
            Squares.Add(r3c3button, new Square());
        }


        public frmTicTacToe() {
            InitializeComponent();
            InitializeSquares();
        }


        //X menu selection
        private void xToolStripMenuItem_Click(object sender, EventArgs e) {
            xToolStripMenuItem.Checked = true;
            oToolStripMenuItem.Checked = false;
        }

        //O menu selection
        private void oToolStripMenuItem_Click(object sender, EventArgs e) {
            xToolStripMenuItem.Checked = false;
            oToolStripMenuItem.Checked = true;
        }

        //Select a square method
        private void MarkSelectionMethod(Button selectedButton) {

            if (xToolStripMenuItem.Checked == false && oToolStripMenuItem.Checked == false) {
                MessageBox.Show("Please Select \"X\" or \"O\" first");
            }

            else {

                oToolStripMenuItem.Enabled = false;
                xToolStripMenuItem.Enabled = false;

                if (Squares[selectedButton].IsEmpty == true) {

                    if (xToolStripMenuItem.Checked == true && blueToolStripMenuItem.Checked == true)  {
                        Squares[selectedButton].IsEmpty = false;
                        Squares[selectedButton].IsBlue = true;
                        Squares[selectedButton].IsRed = false;
                        Squares[selectedButton].IsX = true;
                        Squares[selectedButton].IsO = false;
                        selectedButton.BackgroundImage = blueImages.Images[1];
                    }
                    else if (oToolStripMenuItem.Checked == true && blueToolStripMenuItem.Checked == true) {
                        Squares[selectedButton].IsEmpty = false;
                        Squares[selectedButton].IsBlue = true;
                        Squares[selectedButton].IsRed = false;
                        Squares[selectedButton].IsX = false;
                        Squares[selectedButton].IsO = true;
                        selectedButton.BackgroundImage = blueImages.Images[0];
                    }
                    else if (xToolStripMenuItem.Checked == true && redToolStripMenuItem.Checked == true)  {
                        Squares[selectedButton].IsEmpty = false;
                        Squares[selectedButton].IsBlue = false;
                        Squares[selectedButton].IsRed = true;
                        Squares[selectedButton].IsX = true;
                        Squares[selectedButton].IsO = false;
                        selectedButton.BackgroundImage = redImages.Images[1];
                    }
                    else if (oToolStripMenuItem.Checked == true && redToolStripMenuItem.Checked == true) {
                        Squares[selectedButton].IsEmpty = false;
                        Squares[selectedButton].IsBlue = false;
                        Squares[selectedButton].IsRed = true;
                        Squares[selectedButton].IsX = false;
                        Squares[selectedButton].IsO = true;
                        selectedButton.BackgroundImage = redImages.Images[0];
                    }
                }
                else { MessageBox.Show("That space has already been take\r\nPlease make another selection"); }
            }

            if (xToolStripMenuItem.Checked == true && oToolStripMenuItem.Checked == false) {
                xToolStripMenuItem.Checked = false;
                oToolStripMenuItem.Checked = true;
            }

            else if (xToolStripMenuItem.Checked == false && oToolStripMenuItem.Checked == true) {
                xToolStripMenuItem.Checked = true;
                oToolStripMenuItem.Checked = false;
            }

            Winner();
        }

        //Square buttons
        private void r1c1button_Click(object sender, EventArgs e) { MarkSelectionMethod(r1c1button); }
        private void r1c2button_Click(object sender, EventArgs e) { MarkSelectionMethod(r1c2button); }
        private void r1c3button_Click(object sender, EventArgs e) { MarkSelectionMethod(r1c3button); }
        private void r2c1button_Click(object sender, EventArgs e) { MarkSelectionMethod(r2c1button); }
        private void r2c2button_Click(object sender, EventArgs e) { MarkSelectionMethod(r2c2button); }
        private void r2c3button_Click(object sender, EventArgs e) { MarkSelectionMethod(r2c3button); }
        private void r3c1button_Click(object sender, EventArgs e) { MarkSelectionMethod(r3c1button); }
        private void r3c2button_Click(object sender, EventArgs e) { MarkSelectionMethod(r3c2button); }
        private void r3c3button_Click(object sender, EventArgs e) { MarkSelectionMethod(r3c3button); }

        //Switch color to blue
        private void blueToolStripMenuItem_Click(object sender, EventArgs e) {
            blueToolStripMenuItem.Checked = true;
            redToolStripMenuItem.Checked = false;

            foreach (var b in Squares) {

                if (b.Value.IsX) {
                    b.Key.BackgroundImage = blueImages.Images[1];
                }
                else if (b.Value.IsO) {
                    b.Key.BackgroundImage = blueImages.Images[0];
                }
            }
        }


        //Switch color to red
        private void redToolStripMenuItem_Click(object sender, EventArgs e) {
            blueToolStripMenuItem.Checked = false;
            redToolStripMenuItem.Checked = true;

            foreach (var r in Squares) {

                if (r.Value.IsX) {
                    r.Key.BackgroundImage = redImages.Images[1];
                }
                else if (r.Value.IsO) {
                    r.Key.BackgroundImage = redImages.Images[0];
                }
            }
        }


        //Winner Logic Combinations
        private void Winner() {

                 //x winner combos
                 if (Squares[r1c1button].IsX == true && Squares[r1c2button].IsX == true && Squares[r1c3button].IsX == true) { MessageBox.Show("X has WON!\r\n\r\nClick OK to start a new game"); NewGame(); }
            else if (Squares[r2c1button].IsX == true && Squares[r2c2button].IsX == true && Squares[r2c3button].IsX == true) { MessageBox.Show("X has WON!\r\n\r\nClick OK to start a new game"); NewGame(); }
            else if (Squares[r3c1button].IsX == true && Squares[r3c2button].IsX == true && Squares[r3c3button].IsX == true) { MessageBox.Show("X has WON!\r\n\r\nClick OK to start a new game"); NewGame(); }
            else if (Squares[r1c1button].IsX == true && Squares[r2c1button].IsX == true && Squares[r3c1button].IsX == true) { MessageBox.Show("X has WON!\r\n\r\nClick OK to start a new game"); NewGame(); }
            else if (Squares[r1c2button].IsX == true && Squares[r2c2button].IsX == true && Squares[r3c2button].IsX == true) { MessageBox.Show("X has WON!\r\n\r\nClick OK to start a new game"); NewGame(); }
            else if (Squares[r1c3button].IsX == true && Squares[r2c3button].IsX == true && Squares[r3c3button].IsX == true) { MessageBox.Show("X has WON!\r\n\r\nClick OK to start a new game"); NewGame(); }
            else if (Squares[r1c1button].IsX == true && Squares[r2c2button].IsX == true && Squares[r3c3button].IsX == true) { MessageBox.Show("X has WON!\r\n\r\nClick OK to start a new game"); NewGame(); }
            else if (Squares[r3c1button].IsX == true && Squares[r2c2button].IsX == true && Squares[r1c3button].IsX == true) { MessageBox.Show("X has WON!\r\n\r\nClick OK to start a new game"); NewGame(); }
            else if (Squares[r1c3button].IsX == true && Squares[r2c3button].IsX == true && Squares[r3c3button].IsX == true) { MessageBox.Show("X has WON!\r\n\r\nClick OK to start a new game"); NewGame(); }

            //O winner combos
            else if (Squares[r1c1button].IsO == true && Squares[r1c2button].IsO == true && Squares[r1c3button].IsO == true) { MessageBox.Show("O has WON!\r\n\r\nClick OK to start a new game"); NewGame(); }
            else if (Squares[r2c1button].IsO == true && Squares[r2c2button].IsO == true && Squares[r2c3button].IsO == true) { MessageBox.Show("O has WON!\r\n\r\nClick OK to start a new game"); NewGame(); }
            else if (Squares[r3c1button].IsO == true && Squares[r3c2button].IsO == true && Squares[r3c3button].IsO == true) { MessageBox.Show("O has WON!\r\n\r\nClick OK to start a new game"); NewGame(); }
            else if (Squares[r1c1button].IsO == true && Squares[r2c1button].IsO == true && Squares[r3c1button].IsO == true) { MessageBox.Show("O has WON!\r\n\r\nClick OK to start a new game"); NewGame(); }
            else if (Squares[r1c2button].IsO == true && Squares[r2c2button].IsO == true && Squares[r3c2button].IsO == true) { MessageBox.Show("O has WON!\r\n\r\nClick OK to start a new game"); NewGame(); }
            else if (Squares[r1c3button].IsO == true && Squares[r2c3button].IsO == true && Squares[r3c3button].IsO == true) { MessageBox.Show("O has WON!\r\n\r\nClick OK to start a new game"); NewGame(); }
            else if (Squares[r1c1button].IsO == true && Squares[r2c2button].IsO == true && Squares[r3c3button].IsO == true) { MessageBox.Show("O has WON!\r\n\r\nClick OK to start a new game"); NewGame(); }
            else if (Squares[r3c1button].IsO == true && Squares[r2c2button].IsO == true && Squares[r1c3button].IsO == true) { MessageBox.Show("O has WON!\r\n\r\nClick OK to start a new game"); NewGame(); }
            else if (Squares[r1c3button].IsO == true && Squares[r2c3button].IsO == true && Squares[r3c3button].IsO == true) { MessageBox.Show("O has WON!\r\n\r\nClick OK to start a new game"); NewGame(); }

            //All squares are fill with no winner
            else if(Squares[r1c1button].IsEmpty == false &&
                   Squares[r1c2button].IsEmpty == false &&
                   Squares[r1c3button].IsEmpty == false &&
                   Squares[r2c1button].IsEmpty == false &&
                   Squares[r2c2button].IsEmpty == false &&
                   Squares[r2c3button].IsEmpty == false &&
                   Squares[r3c1button].IsEmpty == false &&
                   Squares[r3c2button].IsEmpty == false &&
                   Squares[r3c3button].IsEmpty == false) { MessageBox.Show("It's a Draw\r\n\r\nClick OK to start a new game"); NewGame(); }
        

        }

        //Exit application
        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            Application.Exit();
        }


        //New Game Fuction
        private void NewGame() {
            xToolStripMenuItem.Enabled = true;
            oToolStripMenuItem.Enabled = true;
            xToolStripMenuItem.Checked = false;
            oToolStripMenuItem.Checked = false;
            blueToolStripMenuItem.Checked = true;
            redToolStripMenuItem.Checked = false;

            foreach (var s in Squares)  {
                s.Value.IsEmpty = true;
                s.Value.IsBlue = false;
                s.Value.IsRed = false;
                s.Value.IsX = false;
                s.Value.IsO = false;
            }

            r1c1button.BackgroundImage = null;
            r1c2button.BackgroundImage = null;
            r1c3button.BackgroundImage = null;
            r2c1button.BackgroundImage = null;
            r2c2button.BackgroundImage = null;
            r2c3button.BackgroundImage = null;
            r3c1button.BackgroundImage = null;
            r3c2button.BackgroundImage = null;
            r3c3button.BackgroundImage = null;
        }

        //Start New game button
        private void toolStripButton1_Click(object sender, EventArgs e) {
            NewGame();
        }

        private void saveGameToolStripMenuItem_Click(object sender, EventArgs e) {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "xml files (*.xml)|*.xml";
            if (dlg.ShowDialog() == DialogResult.OK)  {

                XmlWriterSettings settings = new XmlWriterSettings();
                settings.ConformanceLevel = ConformanceLevel.Document;
                settings.Indent = true;
                settings.CloseOutput = true;

                using (XmlWriter writer = XmlWriter.Create(dlg.OpenFile(), settings)) {
                    writer.WriteStartElement("TicTackToe-8324592348");

                    foreach (var s in Squares)  {
                        writer.WriteStartElement("square");
                        writer.WriteElementString("squareName", s.Key.Name);
                        writer.WriteElementString("isEmpty", s.Value.IsEmpty.ToString());
                        writer.WriteElementString("isBlue", s.Value.IsBlue.ToString());
                        writer.WriteElementString("isRed", s.Value.IsRed.ToString());
                        writer.WriteElementString("isX", s.Value.IsX.ToString());
                        writer.WriteElementString("isO", s.Value.IsO.ToString());  
                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();
                }
            }
        }
    }
}
    

