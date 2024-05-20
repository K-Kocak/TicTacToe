using BoardLogic;
using System;
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
            // giving all our buttons a click event to call handleButtonClick and a number tag
            for(int i = 0; i < buttons.Length; i++)
            {
                buttons[i].Click += handleButtonClick;
                buttons[i].Tag = i;
            }
        }
        private void handleButtonClick(object sender, EventArgs e)
        {
            // clickedButton is the button we clicked, received from "sender"
            Button clickedButton = (Button)sender;
            // get the tag of the clicked Button        
            int gameSquareNumber = (int)clickedButton.Tag;
            // 1 indicates that grid point has been clicked by you, the player
            game.Grid[gameSquareNumber] = 1;
            // we call this function to place an X on the square we chose
            updateBoard();
            // full board check. if true disable all buttons (except new game)
            if(game.isBoardFull())
            {
                MessageBox.Show("The board is full. Draw.");
                disableAllButtons();
            }
            // board isn't full? check if we won
            else if(game.checkForWinner() == 1)
            {
                MessageBox.Show("Player human wins");
                disableAllButtons();
            }
            // board isn't full and we haven't won, so let the computer take its turn
            else
            {
                computerChoose();
            }        
        }
        // disables all buttons. yeah unpredictable behaviour.
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
            // computer checks if it can win
            for (int i = 0; i < 3; i++)
            {
                // i here goes 0, 1 and 2, which is the "top" of each column.
                int columnChecker = game.columnCheck(i, 2);
                // not equal -1 implies a winning move was found. the returned value from columnCheck is the position of the
                // winning move
                if (columnChecker != -1)
                {                   
                    computerWon(columnChecker);
                    return;
                }
            }

            // same as column check, but we now check rows. exact same logic
            for (int i = 0; i < 9; i += 3)
            {
                int rowChecker = game.rowCheck(i, 2);
                if (rowChecker != -1)
                {
                    computerWon(rowChecker);
                    return;
                }
            }           

            // checking the diagonals
            int diagonalChecker = game.diagonalCheck(0, 2);
            if (diagonalChecker != -1)
            {
                computerWon(diagonalChecker);
                return;
               
            }
            else
            {
                diagonalChecker = game.diagonalCheck(2, 2);
                if (diagonalChecker != -1)
                {
                    computerWon(diagonalChecker);
                    return;
                }
            }

            // now we check if the player can win on their next move, and the computer will play to prevent it
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
            
            if(!moveMade)
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

            if (!moveMade)
            {
                diagonalChecker = game.diagonalCheck(0, 1);
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
            //  No one can win = move randomly in an available spot
            if (!moveMade)
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
            // the board can never be full if the player plays first, so this is commented out.
            // we dont need to check if the computer has won, as this is accomplished at the start
            // of this method.
            /*if (game.isBoardFull())
            {
                MessageBox.Show("The board is full. Draw.");
                disableAllButtons();
            }
            else if (game.checkForWinner() == 2)
            {
                MessageBox.Show("Computer wins");
                disableAllButtons();
            }*/         
        }

        // computer has won the game
        private void computerWon(int positionPlayed)
        {
            Console.WriteLine($"Computer chose {positionPlayed}");
            game.Grid[positionPlayed] = 2;
            updateBoard();
            MessageBox.Show("Computer wins");
            disableAllButtons();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            updateBoard();
        }

        private void updateBoard()
        {
            for (int i = 0; i < game.Grid.Length; i++)
            {
                // check all board positions and update depending on their value
                if (game.Grid[i] == 0)
                {
                    buttons[i].Text = "";
                    buttons[i].Enabled = true;
                    buttons[i].BackColor = System.Drawing.Color.Transparent;
                }
                else if (game.Grid[i] == 1)
                {
                    buttons[i].Text = "X";
                    // disabling the button if its been pressed
                    buttons[i].Enabled = false;
                    buttons[i].BackColor = System.Drawing.Color.LightGreen;
                }
                else if (game.Grid[i] == 2)
                {
                    buttons[i].Text = "O";
                    // disabling the button if its been pressed
                    buttons[i].Enabled = false;
                    buttons[i].BackColor = System.Drawing.Color.RosyBrown;
                }
            }
        }

        // start new game button
        private void button10_Click(object sender, EventArgs e)
        {
            game = new Board();
            enableAllButtons();
            updateBoard();
        }

        // moved updateBoard out of this function for reuseability
        // want to enable all buttons? just call this function and done.
        private void enableAllButtons()
        {
            foreach (var item in buttons)
            {
                item.Enabled = true;
            }          
        }
    }
}
