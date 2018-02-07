﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//TODO: Implement win conditions, should do this in the gameboard class.
//TODO: Add Restart button and code in the menu.
//TODO: Add Rules button and messagebox in the menu.

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

                    //TODO: Check if player has won.

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

                    //TODO: Check if player has won.

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
            MessageBox.Show("This implementation of connect four was designed by Craig Wilson and Keiren Waddell");
        }
    }
}
