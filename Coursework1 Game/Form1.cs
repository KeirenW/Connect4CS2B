using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coursework1_Game
{
    public partial class Form1 : Form
    {

        Button[,] gridBtn = new Button[7, 6];

        bool playerTurn = true;
        bool gameEnd = false;
        public Form1()
        {
            InitializeComponent();
            initGameBoard();
        }

        public void initGameBoard()
        {
            for (int x = 0; x < gridBtn.GetLength(0); x++)
            {
                for (int y = 0; y < gridBtn.GetLength(1); y++)
                {
                    gridBtn[x, y] = new Button();
                    gridBtn[x, y].SetBounds((60 * x) + 10, (60 * y) + 30, 45, 45);
                    gridBtn[x, y].Click += new EventHandler(this.buttonClicked);

                    Controls.Add(gridBtn[x, y]);

                }
            }
        }

        public void gameplay()
        {

        }

        void buttonClicked(Object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (playerTurn)
            {
                btn.BackColor = Color.Red;
                playerTurn = false;

            }
            else
            {
                btn.BackColor = Color.Yellow;
                playerTurn = true;

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
