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
        public PictureBox[][] possibleWins;
        public String winningPlayer;
        public bool hasWon = false;
        public bool draw = false;
        public int maxInARow = 4;

        public Form1()
        {
            InitializeComponent();
            allTiles = new PictureBox[16] { a1, a2, a3, a4, b1, b2, b3, b4, c1, c2, c3, c4, d1, d2, d3, d4 };
            var possibleWinOne = new PictureBox[4] { a1, a2, a3, a4 };
            var possibleWinTwo = new PictureBox[4] { b1, b2, b3, b4 };
            var possibleWinThree = new PictureBox[4] { c1, c2, c3, c4 };
            var possibleWinFour = new PictureBox[4] { d1, d2, d3, d4 };
            var possibleWinFive = new PictureBox[4] { a1, b1, c1, d1 };
            var possibleWinSix = new PictureBox[4] { a2, b2, c2, d2 };
            var possibleWinSeven = new PictureBox[4] { a3, b3, c3, d3 };
            var possibleWinEight = new PictureBox[4] { a4, b4, c4, d4 };
            var possibleWinNine = new PictureBox[4] { a1, b2, c3, d4 };
            var possibleWinTen = new PictureBox[4] { a4, b3, c2, d1 };

            possibleWins = new PictureBox[][] {
                possibleWinOne,
                possibleWinTwo,
                possibleWinThree,
                possibleWinFour,
                possibleWinFive,
                possibleWinSix,
                possibleWinSeven,
                possibleWinEight,
                possibleWinNine,
                possibleWinTen};
        }

        private void playerPicksPosition(object sender, EventArgs e)
        {
            if (hasWon || draw)
            {
                MessageBox.Show("Reset the game");
                return;
            }

            var tileToPlay = (PictureBox)sender;

            if (currentPlayer == "X" && tileToPlay.Tag == null)
            {
                tileToPlay.Image = Properties.Resources.x;
                tileToPlay.Tag = "X";

                if (checkForWin())
                {
                    hasWon = true;
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
                    hasWon = true;
                    MessageBox.Show("Player " + currentPlayer + " has won.");
                }

                if (thereIsADraw())
                {
                    MessageBox.Show("It's a draw");
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
            var validInARow = 0;
            for (var possibleWin = 0; possibleWin < possibleWins.Length; possibleWin++)
            {
                validInARow = 0;

                for (var index = 0; index < possibleWins[possibleWin].Length; index++)
                {
                    if ((String)possibleWins[possibleWin][index].Tag == currentPlayer)
                    {
                        validInARow++;
                        
                        if (validInARow >= maxInARow)
                        {
                            winningPlayer = currentPlayer;
                            return true;
                        }
                    }         
                }
            }
            return false;
        }

        public bool thereIsADraw()
        {
            bool allTilesTakenWithNoWin = true;

            for(var tile = 0; tile < allTiles.Length; tile++)
            {
                if (allTiles[tile].Tag == null)
                {
                    allTilesTakenWithNoWin = false;
                    return allTilesTakenWithNoWin;
                }
            }
            draw = true;
            return allTilesTakenWithNoWin;
        }

        private void resetBoard(object sender, EventArgs e)
        {
            for (var tile = 0; tile < allTiles.Length; tile++)
            {
                allTiles[tile].Tag = null;
                allTiles[tile].Image = null;
                allTiles[tile].Enabled = true;
                currentPlayer = "X";
                hasWon = false;
                draw = false;
                winningPlayer = null;
            }
        }
    }
}
