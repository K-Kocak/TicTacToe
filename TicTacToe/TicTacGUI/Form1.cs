using BoardLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacGUI
{
    public partial class Form1 : Form
    {
        Board game = new Board();
        Button[] buttons = new Button[9];
        Random rand = new Random();
        
        public Form1()
        {
            InitializeComponent();
            game = new Board();
            buttons[0] = button1;
            buttons[1] = button2;
            buttons[2] = button3;
            buttons[3] = button4;
            buttons[4] = button5;
            buttons[5] = button6;
            buttons[6] = button7;
            buttons[7] = button8;
            buttons[8] = button9;

            for(int i = 0; i < buttons.Length; i++)
            {
                buttons[i].Click += handleButtonClick;
                buttons[i].Tag = i;
            }
        }

        private void handleButtonClick(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            //MessageBox.Show($"Button {clickedButton.Tag} was clicked");
            int gameSquareNumber = (int)clickedButton.Tag;
            game.Grid[gameSquareNumber] = 1;

            updateBoard();

            if(game.isBoardFull() == true)
            {
                MessageBox.Show("The board is full");
                disableAllButtons();
            }
            else if(game.checkForWinner() == 1)
            {
                MessageBox.Show("Player human wins");
                disableAllButtons();
            }
            else
            {
                computerChoose();
            }
            
        }

        private void disableAllButtons()
        {
            foreach(var item in buttons)
            {
                item.Enabled = false;
            }
        }

        private void computerChoose()
        {
            bool moveMade = false;
            // ------------------ Computer checks if it can win
            for (int i = 0; i < 3; i++)
            {
                int columnChecker = game.columnCheck(i, 2);
                if (columnChecker != -1)
                {
                    Console.WriteLine($"Computer chose {columnChecker}");
                    game.Grid[columnChecker] = 2;
                    moveMade = true;
                }
            }
            if (moveMade == false)
            {
                for (int i = 0; i < 9; i += 3)
                {
                    int rowChecker = game.rowCheck(i, 2);
                    if (rowChecker != -1)
                    {
                        Console.WriteLine($"Computer chose {rowChecker}");
                        game.Grid[rowChecker] = 2;
                        moveMade = true;
                    }
                }
            }
            if (moveMade == false)
            {
                int diagonalChecker = game.diagonalCheck(0, 2);
                if (diagonalChecker != -1)
                {
                    Console.WriteLine($"Computer chose {diagonalChecker}");
                    game.Grid[diagonalChecker] = 2;
                    moveMade = true;
                }
                else
                {
                    diagonalChecker = game.diagonalCheck(2, 2);
                    if (diagonalChecker != -1)
                    {
                        Console.WriteLine($"Computer chose {diagonalChecker}");
                        game.Grid[diagonalChecker] = 2;
                        moveMade = true;
                    }
                }
            }
            // ------------------------Computer checks if the player can win
            if (moveMade == false)
            {
                for (int i = 0; i < 3; i++)
                {
                    int columnChecker = game.columnCheck(i, 1);
                    if (columnChecker != -1)
                    {
                        Console.WriteLine($"Computer chose {columnChecker}");
                        game.Grid[columnChecker] = 2;
                        moveMade = true;
                    }
                }
            }
            if(moveMade == false)
            {
                for (int i = 0; i < 9; i += 3)
                {
                    int rowChecker = game.rowCheck(i, 1);
                    if (rowChecker != -1)
                    {
                        Console.WriteLine($"Computer chose {rowChecker}");
                        game.Grid[rowChecker] = 2;
                        moveMade = true;
                    }
                }
            }
            if (moveMade == false)
            {
                int diagonalChecker = game.diagonalCheck(0, 1);
                if (diagonalChecker != -1)
                {
                    Console.WriteLine($"Computer chose {diagonalChecker}");
                    game.Grid[diagonalChecker] = 2;
                    moveMade = true;
                }
                else
                {
                    diagonalChecker = game.diagonalCheck(2, 1);
                    if (diagonalChecker != -1)
                    {
                        Console.WriteLine($"Computer chose {diagonalChecker}");
                        game.Grid[diagonalChecker] = 2;
                        moveMade = true;
                    }
                }
            }
            // -- No one can win = move randomly in an available spot
            if (moveMade == false)
            {
                int computerTurn = rand.Next(9);

                while (game.Grid[computerTurn] != 0)
                {
                    computerTurn = rand.Next(9);


                }
                Console.WriteLine($"Computer chose {computerTurn}");
                game.Grid[computerTurn] = 2;
            }

                updateBoard();

                if (game.isBoardFull() == true)
                {
                    MessageBox.Show("The board is full");
                    disableAllButtons();
                }
                else if (game.checkForWinner() == 2)
                {
                    MessageBox.Show("Computer wins");
                    disableAllButtons();
                }

            
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {
            updateBoard();
        }

        private void updateBoard()
        {
            for (int i = 0; i < game.Grid.Length; i++)
            {
                if (game.Grid[i] == 0)
                {
                    buttons[i].Text = "";
                    buttons[i].Enabled = true;

                }
                else if (game.Grid[i] == 1)
                {
                    buttons[i].Text = "X";
                    buttons[i].Enabled = false;

                }
                else if (game.Grid[i] == 2)
                {
                    buttons[i].Text = "O";
                    buttons[i].Enabled = false;

                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            game = new Board();
            enableAllButtons();
        }

        private void enableAllButtons()
        {
            foreach (var item in buttons)
            {
                item.Enabled = true;
            }

            updateBoard();
        }
    }
}
