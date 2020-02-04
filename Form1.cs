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
            var tileToPlay = (PictureBox)sender;

            if (currentPlayer == "X" && tileToPlay.Tag == null)
            {
                tileToPlay.Image = Properties.Resources.x;
                tileToPlay.Tag = "X";

                if (checkForWin())
                {
                    MessageBox.Show("Player " + currentPlayer + " has won.");
                }

                if (thereIsADraw())
                {
                    MessageBox.Show("It's a draw");
                }

                currentPlayer = "O";
                changingTurnLabel.Text = "O";
            }
            else if (currentPlayer == "O" && tileToPlay.Tag == null)
            {
                tileToPlay.Image = Properties.Resources.o;
                tileToPlay.Tag = "O";

                if (checkForWin())
                {
                    MessageBox.Show("Player " + currentPlayer + " has won.");
                }

                currentPlayer = "X";
                changingTurnLabel.Text = "X";
            }
            else
            {
                MessageBox.Show("This tile is taken, choose another tile.");
            }
        }

        private bool checkForWin()
        {
            if ((String)a1.Tag == "X" && (String)a2.Tag == "X" && (String)a3.Tag == "X" && (String)a4.Tag == "X" ||
                ((String)b1.Tag == "X" && (String)b2.Tag == "X" && (String)b3.Tag == "X" && (String)b4.Tag == "X") ||
                ((String)c1.Tag == "X" && (String)c2.Tag == "X" && (String)c3.Tag == "X" && (String)c3.Tag == "X") ||
                ((String)a1.Tag == "X" && (String)b1.Tag == "X" && (String)c1.Tag == "X" && (String)d1.Tag == "X") ||
                ((String)a2.Tag == "X" && (String)b2.Tag == "X" && (String)c2.Tag == "X" && (String)d2.Tag == "X") ||
                ((String)a3.Tag == "X" && (String)b3.Tag == "X" && (String)c3.Tag == "X" && (String)d3.Tag == "X") ||
                ((String)a1.Tag == "X" && (String)b2.Tag == "X" && (String)c3.Tag == "X" && (String)d4.Tag == "X") ||
                ((String)a4.Tag == "X" && (String)b3.Tag == "X" && (String)c2.Tag == "X" && (String)d1.Tag == "X"))
            {
                winningPlayer = "X";
                hasWon = true;
                return hasWon;
            }

            else if ((String)a1.Tag == "O" && (String)a2.Tag == "O" && (String)a3.Tag == "O" && (String)a4.Tag == "O" ||
                ((String)b1.Tag == "O" && (String)b2.Tag == "O" && (String)b3.Tag == "O" && (String)b4.Tag == "O") ||
                ((String)c1.Tag == "O" && (String)c2.Tag == "O" && (String)c3.Tag == "O" && (String)c3.Tag == "O") ||
                ((String)a1.Tag == "O" && (String)b1.Tag == "O" && (String)c1.Tag == "O" && (String)d1.Tag == "O") ||
                ((String)a2.Tag == "O" && (String)b2.Tag == "O" && (String)c2.Tag == "O" && (String)d2.Tag == "O") ||
                ((String)a3.Tag == "O" && (String)b3.Tag == "O" && (String)c3.Tag == "O" && (String)d3.Tag == "O") ||
                ((String)a1.Tag == "O" && (String)b2.Tag == "O" && (String)c3.Tag == "O" && (String)d4.Tag == "O") ||
                ((String)a4.Tag == "O" && (String)b3.Tag == "O" && (String)c2.Tag == "O" && (String)d1.Tag == "O"))
            {
                winningPlayer = "O";
                hasWon = true;
                return hasWon;
            }
            else
            {
                return hasWon;
            }
        }

        public bool thereIsADraw()
        {
            for(var tile = 0; tile < allTiles.Length; tile++)
            {
                if (allTiles[tile].Tag == null)
                {
                    return false;
                }
            }

            return true;
        }

        private void resetBoard(object sender, EventArgs e)
        {
            for (var tile = 0; tile < allTiles.Length; tile++)
            {
                allTiles[tile].Tag = null;
                allTiles[tile].Image = null;
                currentPlayer = "X";
                hasWon = false;
                winningPlayer = null;
            }
        }

    }
}
