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



        public frmTicTacToe() {
            InitializeComponent();
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
        private void blueToolStripMenuItem_Click(object sender, EventArgs e)
        {
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
    

