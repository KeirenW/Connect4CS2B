using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//TODO: Implement win conditions - check after every turn.
//TODO: Check for full board after every turn - if full and no win annouce draw.

namespace Coursework1_Game
{
    public partial class gameWindow : Form
    {
        Button[,] gridBtn = new Button[7, 6];
        GameBoard board = new GameBoard();

        bool playerTurn = true;
        bool gameEnd = false;
        public gameWindow()
        {
            InitializeComponent();
            initGameBoard();
        }

        public void initGameBoard()
        {
            this.BackColor = Color.WhiteSmoke;

            //Add button grid for the game.
            for (int x = 0; x < gridBtn.GetLength(0); x++)
            {
                for (int y = 0; y < gridBtn.GetLength(1); y++)
                {
                    gridBtn[x, y] = new Button();
                    gridBtn[x, y].SetBounds((60 * x) + 10, (60 * y) + 30, 45, 45);
                    gridBtn[x, y].Name = Convert.ToString((x) + "," + (y));
                    gridBtn[x, y].BackColor = Color.White;
                    gridBtn[x, y].Click += new EventHandler(this.buttonClicked);

                    Controls.Add(gridBtn[x, y]);

                }
            }
        }


        /* public void checkWinnerColumn()
        {

            for (int col = 0; col < 7; col++)
            {
                int counter = 0;

                for (int row = 1; row < 6; row++)

                {
                    if (gridBtn[row, col].BackColor != Color.White && gridBtn[row, col] == gridBtn[row - 1, col])
                    {
                        counter++;
                    }

                    else
                    {
                        counter = 1;

                    }

                    if (counter >= 4)
                    {

                        MessageBox.Show("Winner!", "Results");
                        gameEnd = true;


                    }

                }



            }





        }

            */

        public void checkWinnerRow()
        {

            for (int row = 0; row < 6; row++)
            {

                int counter = 0;

                for (int col = 1; col < 7; col++)
                {

                    if (gridBtn[row, col].BackColor != Color.White && gridBtn[row, col] == gridBtn[row,col - 1])
                    {

                        counter++;

                    }
                    else
                    {

                        counter = 1;

                    }
                    if (counter == 3)
                    {

                        MessageBox.Show("Winner!", "Results");
                        gameEnd = true;

                    }

                }

            }



        }

        public void checkDiagRight()
        {

            for (int i = 0; i < 3; i++)
            {

                for (int j = 0; j > 2; j--)
                {

                    if (gridBtn[i, j] == gridBtn[i + 1, j + 1] && gridBtn[i, j] == gridBtn[i + 2, j + 2] && gridBtn[i, j] == gridBtn[i + 3, j + 3]
                    && gridBtn[i, j].BackColor != Color.White)
                    {

                        MessageBox.Show("Winner!", "Results");
                        gameEnd = true;

                    }

                }
            }





        }

        public void checkDiagLeft()
        {
            for (int i = 0; i < 3; i++)
            {

                for (int j = 6; j < 2; j--)
                {

                    if (gridBtn[i, j] == gridBtn[i + 1, j - 1] && gridBtn[i, j] == gridBtn[i + 2, j - 2] && gridBtn[i, j] == gridBtn[i + 3, j - 3]
                    && gridBtn[i, j].BackColor != Color.White)
                    {

                        MessageBox.Show("Winner!", "Results");
                        gameEnd = true;
                    }

                }

            }


        }

        public void checkWinner()
        {

            //checkWinnerColumn();
            checkWinnerRow();

            checkDiagLeft();
            checkDiagRight();



        }

        /**
         * Event handler for buttons
         */
        void buttonClicked(Object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (playerTurn)
            {
                //Check if space there is space in the column
                int x = (int)Char.GetNumericValue(btn.Name[0]);
                int counterY = board.checkColumn(x, gridBtn);
                if (counterY > 6)
                {
                    //Move invalid
                    Console.WriteLine("Move was invalid...");
                } else
                {
                    //Valid.. Place counter
                    gridBtn[x,counterY].BackColor = Color.Red;
                    currentTurn.BackgroundImage = Properties.Resources.YellowTurn;

                    //TODO: Check if player has won or baord is full.
                    checkWinner();
                    playerTurn = false;
                }

            } else
            {
                int x = (int)Char.GetNumericValue(btn.Name[0]);
                int counterY = board.checkColumn(x, gridBtn);
                if (counterY > 6)
                {
                    //Move invalid
                    Console.WriteLine("Move was invalid...");
                }
                else
                {
                    //Valid.. Place counter
                    gridBtn[x, counterY].BackColor = Color.Yellow;

                    //TODO: Check if player has won or baord is full.
                    checkWinner();
                    //Change image at bottom to next player
                    currentTurn.BackgroundImage = Properties.Resources.RedTurn;
                    playerTurn = true;
                }

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This implementation of connect four was designed by Craig Wilson and Keiren Waddell", "About");
        }

        private void rulesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "The aim of Connect 4 is to get 4 of your colour of counters in a row while stopping your opponent from doing the same." +
                " Your 4 counters can be horizontal, vertical or diagonal as long as they are in a row and not disrupted by the other colour."
                , "Rules"
            );
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < 7; ++i)
            {
                for(int j = 0; j < 6; ++j)
                {
                    gridBtn[i, j].BackColor = Color.White;
                }
            }
        }
    }
}
