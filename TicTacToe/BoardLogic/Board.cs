using System.Linq;
namespace BoardLogic
{
    public class Board
    {
        public int[] Grid
        {
            get; set;
        }

        public Board()
        {
            // all grid positions are 0 by default. constructor.
            Grid = new int[9];
            for (int i = 0; i < Grid.Length; i++)
            {
                Grid[i] = 0;
            }
        }
        public bool isBoardFull()
        {
            /*for(int i = 0; i < Grid.Length; i++)
            {
                if (Grid[i] == 0)
                {
                    return false;
                }
            }
            foreach (int i in Grid)
            {
                if (i == 0)
                {
                    return false;
                }
            }
            return true;*/

            // one line 
            return !Grid.Contains(0);
            
        }

        public int checkForWinner()
        {
            // =============
            // | 0 | 1 | 2 |
            // | 3 | 4 | 5 |
            // | 6 | 7 | 8 |
            // =============
            // Visualization 

            // first 3 are row checks
            if (Grid[0] == Grid[1] && Grid[1] == Grid[2])
            {
                return Grid[0];
            }
            if (Grid[3] == Grid[4] && Grid[4] == Grid[5])
            {
                return Grid[3];
            }
            if (Grid[6] == Grid[7] && Grid[7] == Grid[8])
            {
                return Grid[6];
            }

            // next 3 are column checks
            if (Grid[0] == Grid[3] && Grid[3] == Grid[6])
            {
                return Grid[0];
            }
            if (Grid[1] == Grid[4] && Grid[4] == Grid[7])
            {
                return Grid[1];
            }
            if (Grid[2] == Grid[5] && Grid[5] == Grid[8])
            {
                return Grid[2];
            }

            // the 2 diagonals check
            if (Grid[0] == Grid[4] && Grid[4] == Grid[8])
            {
                return Grid[0];
            }
            if (Grid[2] == Grid[4] && Grid[4] == Grid[6])
            {
                return Grid[2];
            }

            // no winner currently
            return 0;
        }
        public int columnCheck(int i, int z)
        {
            // we check if one of 3 conditions are satisfied first
            // example (this is one column:
            // =====
            // | 0 |
            // | 3 |
            // | 6 |
            // we check if 0 and 3 are the same, OR, 3 and 6 are the same, OR, 0 and 6 are the same. If this is true we
            // will check if the value between them is 0 (which means the the computer should play there and win the game)
            if (Grid[i] == z && Grid[i + 3] == z || Grid[i] == z && Grid[i + 6] == z || Grid[i + 3] == z && Grid[i + 6] == z)
            {
                // for loop covers i, i+3 and i+6, which is the column. we've established that two of these positions are 2 (computer occupied)
                // so now we just search for a 0 (unplayed) in these three spots
                for(int j = i; j < 9; j += 3)
                {
                    if (Grid[j] == 0)
                    {
                        return j;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            // winning move not possible, return -1
            return -1;
        }

        // same as column check in terms of logic, but does rows instead
        public int rowCheck(int i, int z)
        {
            if (Grid[i] == z && Grid[i+1] == z || Grid[i] == z && Grid[i+2] == z || Grid[i+1] == z && Grid[i+2] == z)
            {
                for(int j = i; j < i+3; j++)
                {
                    if (Grid[j] == 0)
                    {
                        return j;
                    }
                    else
                    {
                        continue;
                    }
                }
            }

            return -1;
        }

        // checking the diagonals, same logic as row/column
        public int diagonalCheck(int i, int z)
        {
            if(i == 0)
            {
                if (Grid[0] == z && Grid[4] == z || Grid[0] == z && Grid[8] == z || Grid[4] == z && Grid[8] == z)
                {
                    for (int j = 0; j < 9; j += 4)
                    {
                        if (Grid[j] == 0)
                        {
                            return j;
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
            }
            if(i == 2)
            {
                if (Grid[2] == z && Grid[4] == z || Grid[2] == z && Grid[6] == z || Grid[4] == z && Grid[6] == z)
                {
                    for (int j = 2; j < 7; j += 2)
                    {
                        if (Grid[j] == 0)
                        {
                            return j;
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
            }
            return -1;
        }
    }
}
