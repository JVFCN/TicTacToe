using System;

namespace 井字棋
{
    class Program
    {
        static int x, y;
        static int User = 1;
        static int Counter = 0;
        
        private static string[,] CheckerBoard = new String[3, 3]
        {
            { "0", "0", "0" },
            { "0", "0", "0" },
            { "0", "0", "0" }
        };

        static void PrintTwoDimensionalArray(string[,] Arr)
        {
            for (int i = 0; i < Arr.GetLength(0); i++)
            {
                for (int j = 0; j < Arr.GetLength(1); j++)
                {
                    Console.Write(Arr[i, j] + "  ");
                }

                Console.WriteLine();
            }
        }
        static bool CheckWinner(string[,] board, string player)
        {
            // 行
            for (int i = 0; i < board.GetLength(0); i++)
            {
                if (board[i, 0] == player && board[i, 1] == player && board[i, 2] == player)
                {
                    return true;
                }
            }

            // 列
            for (int j = 0; j < board.GetLength(1); j++)
            {
                if (board[0, j] == player && board[1, j] == player && board[2, j] == player)
                {
                    return true;
                }
            }

            // 对角线
            if (board[0, 0] == player && board[1, 1] == player && board[2, 2] == player)
            {
                return true;
            }

            // 对角线
            if (board[0, 2] == player && board[1, 1] == player && board[2, 0] == player)
            {
                return true;
            }

            return false;
        }
        static void DropChessPieces(int User, string Chessman)
        {
            Restart:
            Console.WriteLine($"\n输入棋子的放置点(玩家{User}[{Chessman}]):");
            x = int.Parse(Console.ReadLine()) - 1;
            y = int.Parse(Console.ReadLine()) - 1;

            Console.WriteLine("\n");
            if (x <= 2 && x >= 0 && y <= 2 && y >= 0 && CheckerBoard[x, y] == "0")
            {
                CheckerBoard[x, y] = Chessman;
                PrintTwoDimensionalArray(CheckerBoard);
                Counter++;
            }
            else
            {
                Console.WriteLine("落子不合理, 请重新落子!");
                goto Restart; 
            }
        }

        static void Main(string[] args)
        {
            Program.PrintTwoDimensionalArray(CheckerBoard);
            while (true)
            {
                if (User == 1)
                {
                    DropChessPieces(1, "V");
                }
                else
                {
                    DropChessPieces(2, "X");
                }
                if (Counter == 9)
                {
                    Console.WriteLine("平局!");
                    break;
                }

                if (CheckWinner(CheckerBoard, "V"))
                {
                    Console.WriteLine("玩家1获胜!");
                    break;
                }

                if (CheckWinner(CheckerBoard, "X"))
                {
                    Console.WriteLine("玩家2获胜!");
                    break;
                }
                User = (User % 2) + 1;
            }
        }
    }
}