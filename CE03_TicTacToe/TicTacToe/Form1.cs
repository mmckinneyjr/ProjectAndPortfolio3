using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class frmTicTacToe : Form
    {

        // NAME: Mark Mckinney
        // CLASS AND TERM: Project and Portfolio III - C201903
        // PROJECT: Tic Tac Toe

        Dictionary<Button, Square> Squares = new Dictionary<Button, Square>();
        Square[] SquaresData = new Square[9];

        public void InitializeSquares() {
            Squares.Add(r1c1button, SquaresData[0] = new Square());
            Squares.Add(r1c2button, SquaresData[1] = new Square());
            Squares.Add(r1c3button, SquaresData[2] = new Square());
            Squares.Add(r2c1button, SquaresData[3] = new Square());
            Squares.Add(r2c2button, SquaresData[4] = new Square());
            Squares.Add(r2c3button, SquaresData[5] = new Square());
            Squares.Add(r3c1button, SquaresData[6] = new Square());
            Squares.Add(r3c2button, SquaresData[7] = new Square());
            Squares.Add(r3c3button, SquaresData[8] = new Square());
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
                if (Squares[r1c1button].IsX == true && Squares[r1c2button].IsX == true && Squares[r1c3button].IsX == true) { MessageBox.Show("X has WON!"); }
                else if (Squares[r2c1button].IsX == true && Squares[r2c2button].IsX == true && Squares[r2c3button].IsX == true) { MessageBox.Show("X has WON!"); }
                else if (Squares[r3c1button].IsX == true && Squares[r3c2button].IsX == true && Squares[r3c3button].IsX == true) { MessageBox.Show("X has WON!"); }
                else if (Squares[r1c1button].IsX == true && Squares[r2c1button].IsX == true && Squares[r3c1button].IsX == true) { MessageBox.Show("X has WON!"); }
                else if (Squares[r1c2button].IsX == true && Squares[r2c2button].IsX == true && Squares[r3c2button].IsX == true) { MessageBox.Show("X has WON!"); }
                else if (Squares[r1c3button].IsX == true && Squares[r2c3button].IsX == true && Squares[r3c3button].IsX == true) { MessageBox.Show("X has WON!"); }
                else if (Squares[r1c1button].IsX == true && Squares[r2c2button].IsX == true && Squares[r3c3button].IsX == true) { MessageBox.Show("X has WON!"); }
                else if (Squares[r3c1button].IsX == true && Squares[r2c2button].IsX == true && Squares[r1c3button].IsX == true) { MessageBox.Show("X has WON!"); }
                else if (Squares[r1c3button].IsX == true && Squares[r2c3button].IsX == true && Squares[r3c3button].IsX == true) { MessageBox.Show("X has WON!"); }

                //O winner combos
                else if (Squares[r1c1button].IsO == true && Squares[r1c2button].IsO == true && Squares[r1c3button].IsO == true) { MessageBox.Show("O has WON!"); }
                else if (Squares[r2c1button].IsO == true && Squares[r2c2button].IsO == true && Squares[r2c3button].IsO == true) { MessageBox.Show("O has WON!"); }
                else if (Squares[r3c1button].IsO == true && Squares[r3c2button].IsO == true && Squares[r3c3button].IsO == true) { MessageBox.Show("O has WON!"); }
                else if (Squares[r1c1button].IsO == true && Squares[r2c1button].IsO == true && Squares[r3c1button].IsO == true) { MessageBox.Show("O has WON!"); }
                else if (Squares[r1c2button].IsO == true && Squares[r2c2button].IsO == true && Squares[r3c2button].IsO == true) { MessageBox.Show("O has WON!"); }
                else if (Squares[r1c3button].IsO == true && Squares[r2c3button].IsO == true && Squares[r3c3button].IsO == true) { MessageBox.Show("O has WON!"); }
                else if (Squares[r1c1button].IsO == true && Squares[r2c2button].IsO == true && Squares[r3c3button].IsO == true) { MessageBox.Show("O has WON!"); }
                else if (Squares[r3c1button].IsO == true && Squares[r2c2button].IsO == true && Squares[r1c3button].IsO == true) { MessageBox.Show("O has WON!"); }
                else if (Squares[r1c3button].IsO == true && Squares[r2c3button].IsO == true && Squares[r3c3button].IsO == true) { MessageBox.Show("O has WON!"); }

                //All squares are fill with no winner
                else if(Squares[r1c1button].IsEmpty == false &&
                   Squares[r1c2button].IsEmpty == false &&
                   Squares[r1c3button].IsEmpty == false &&
                   Squares[r2c1button].IsEmpty == false &&
                   Squares[r2c2button].IsEmpty == false &&
                   Squares[r2c3button].IsEmpty == false &&
                   Squares[r3c1button].IsEmpty == false &&
                   Squares[r3c2button].IsEmpty == false &&
                   Squares[r3c3button].IsEmpty == false) { MessageBox.Show("It's a Draw"); }        
        }

        //Exit application
        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            Application.Exit();
        }
    }
}
    

