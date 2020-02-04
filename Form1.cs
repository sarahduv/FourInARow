using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FourInARow
{
    public partial class Form1 : Form
    {
        public String currentPlayer = "X";
        public PictureBox[] allTiles;
        public String winningPlayer;
        public bool hasWon = false;
        public Form1()
        {
            InitializeComponent();
            allTiles = new PictureBox[16] { a1, a2, a3, a4, b1, b2, b3, b4, c1, c2, c3, c4, d1, d2, d3, d4 };
        }

        private void playerPicksPosition(object sender, EventArgs e)
        {

        }
    }
}
