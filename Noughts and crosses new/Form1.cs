using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Noughts_and_crosses_new
{
    public partial class Form1 : Form
    {
        string cross = "X";
        string nought = "O";
        string currentSymbol;
        bool computerPlayerEnabled = false;
        Random random = new Random();

        Button[,] grid;

        public Form1()
        {
            InitializeComponent();
            currentSymbol = cross;

            grid = new Button[,] { { btn00, btn10, btn20},
                                    { btn01, btn11, btn21 },
                                    { btn02, btn12, btn22 } };

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    grid[i, j].Text = "";
                }
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int x_coord = int.Parse(btn.Name[3].ToString());
            int y_coord = int.Parse(btn.Name[4].ToString());

            if (btn.Text == string.Empty)
            {
                //btn.Text = currentSymbol;
                btn.Text = cross;

                if (WinCheck(cross))
                {
                    MessageBox.Show(currentSymbol + " has won!");
                    ClearBoard();
                    currentSymbol = cross;
                    return;
                }

                SwitchSymbol();
                PlayComputerMove();

                if (WinCheck(nought))
                {
                    MessageBox.Show("The computer has won!");
                    ClearBoard();
                    currentSymbol = cross;
                    return;
                }
            }
        }

        private bool WinCheck(string mark)
        {
            // Check for vertical lines
            for (int i = 0; i < 3; i++)
            {
                if (grid[i, 0].Text == mark && grid[i, 1].Text == mark && grid[i, 2].Text == mark)
                {
                    return true;
                }
            }

            // Check for horizontal lines
            for (int i = 0; i < 3; i++)
            {
                if (grid[0, i].Text == mark && grid[1, i].Text == mark && grid[2, i].Text == mark)
                {
                    return true;
                }
            }

            // Check for upwards diagonal line
            if (grid[2, 0].Text == mark && grid[1, 1].Text == mark && grid[0, 2].Text == mark)
            {
                return true;
            }

            // Check for downwards diagonal line
            if (grid[0, 0].Text == mark && grid[1, 1].Text == mark && grid[2, 2].Text == mark)
            {
                return true;
            }

            foreach (Button button in grid)
            {
                if (button.Text == string.Empty)
                {

                }
            }

            return false;
        }

        private void ClearBoard()
        {
            foreach (Button button in grid)
            {
                button.ResetText();
            }
        }

        private void SwitchSymbol()
        {
            currentSymbol = currentSymbol == cross ? nought : cross;
        }

        private void PlayComputerMove()
        {
            Button possibleMove = grid[random.Next(0, grid.GetLength(0)), random.Next(0, grid.GetLength(1))];

            while (possibleMove.Text != string.Empty)
            {
                possibleMove = grid[random.Next(0, grid.GetLength(0)), random.Next(0, grid.GetLength(1))];
            }

            possibleMove.Text = nought;
        }
    }
}
