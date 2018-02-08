using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coursework1_Game
{
    class GameBoard
    {
        /**
         * Checks the column that the user picked for their turn.
         * Returns: y value that the counter should be placed in.
         */
        public int checkColumn(int x, Button[,] btn)
        {
            for(int i=5;i>=0;i--)
            {
                if(btn[x,i].BackColor == Color.White)
                {
                    return i;
                }
            }
            return 999;
        }

    }
}
