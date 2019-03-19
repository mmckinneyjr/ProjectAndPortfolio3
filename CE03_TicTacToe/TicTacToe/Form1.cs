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

        //Switch color to blue
        private void blueToolStripMenuItem_Click(object sender, EventArgs e) {
            blueToolStripMenuItem.Checked = true;
            redToolStripMenuItem.Checked = false;

        }



        //Switch color to red
        private void redToolStripMenuItem_Click(object sender, EventArgs e) {
            blueToolStripMenuItem.Checked = false;
            redToolStripMenuItem.Checked = true;

        }



        //Exit application
        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            Application.Exit();
        }
    }
}
    

