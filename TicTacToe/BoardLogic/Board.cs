using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

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
            Grid = new int[9];
            for (int i = 0; i < Grid.Length; i++)
            {
                Grid[i] = 0;
            }
        }

        public bool isBoardFull()
        {
            bool isFull = true;
            for(int i = 0; i < Grid.Length; i++)
            {
                if (Grid[i] == 0)
                {
                    isFull = false;
                }
            }
            return isFull;
        }

        public int checkForWinner()
        {
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
            if (Grid[0] == Grid[4] && Grid[4] == Grid[8])
            {
                return Grid[0];
            }
            if (Grid[2] == Grid[4] && Grid[4] == Grid[6])
            {
                return Grid[2];
            }
            return 0;

        }

        public int columnCheck(int i, int z)
        {
            if (Grid[i] == z && Grid[i + 3] == z || Grid[i] == z && Grid[i + 6] == z || Grid[i + 3] == z && Grid[i + 6] == z)
            {
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

            return -1;
        }

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
