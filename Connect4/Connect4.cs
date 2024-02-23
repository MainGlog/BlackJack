
namespace Connect4
{
    public class Connect4
    {
        public const int ROWS = 6;
        public const int COLS = 7;
        public const char SYMBOL = 'O';
        
        public const ConsoleColor P1_COLOR = ConsoleColor.Red;
        public const ConsoleColor P2_COLOR = ConsoleColor.Yellow;
        public const ConsoleColor EMPTY_COLOR = ConsoleColor.Black;
        public static ConsoleColor[][] board = new ConsoleColor[ROWS][];
        public static bool p1Turn = true;

        public static void Main()
        {
            PrepareBoard();
            StartGamePrint();

            while (!HasEverySpotBeenUsed())
            {
                Console.Clear();
                char whosTurn = p1Turn ? '1' : '2'; //if p1Turn = true, whosTurn = 1, else whosTurn = 2 ? is the operator
                Console.WriteLine($"Player {whosTurn}'s turn. ");
                Console.Write(Environment.NewLine);
                PrintBoard();
                int column = GetPlayerMove();
                while(column != -1 && !PlacePiece(column))
                {
                    PrintWColor("Error: That column is full!", P1_COLOR);
                    Console.Write(Environment.NewLine); 
                    column = GetPlayerMove();
                }
                if (column == -1)
                {
                    whosTurn = p1Turn ? '2' : '1';
                    Console.WriteLine($"Player {whosTurn} won!");
                    return;
                }
                p1Turn = !p1Turn;
            }
            Console.Clear();
            Console.WriteLine("Game over! The board is full.");
            Console.Write(Environment.NewLine);
            PrintBoard();
        }
        public static void PrepareBoard()
        { 
            for(int i = 0; i < board.Length; i++)
            {
                board[i] = new ConsoleColor[COLS];
                for(int j = 0; j < board[i].Length; j++)
                {
                    board[i][j] = EMPTY_COLOR; //Initializing board with empty colors
                }
            }
        }
        public static bool HasEverySpotBeenUsed()
        {
            foreach (ConsoleColor[] row in board)
            {
                foreach (ConsoleColor element in row)
                {
                    if(element == EMPTY_COLOR)
                    {
                        return false; //A spot is empty
                    }
                }
            }
            return true;
        }
        public static void StartGamePrint()
        {
            Console.WriteLine("-----Connect 4-----");
            Console.Write("Player 1 will be ");
            PrintWColor(P1_COLOR.ToString().ToLower(), P1_COLOR);
            Console.WriteLine(".");

            Console.Write("Player 2 will be ");
            PrintWColor(P2_COLOR.ToString().ToLower(), P2_COLOR);
            Console.WriteLine(".");

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.WriteLine(Environment.NewLine);
            //ReadKey doesn't wait for enter
        }
        public static int GetPlayerMove()
        {
            Console.Write("Enter a column number to place your piece in or 'q' if a player has won: ");
            String input = Console.ReadLine();

            while (true)
            {

                if(int.TryParse(input, out int column)) 
                {
                    if(column < 1 || column > COLS) 
                    {
                        //Validation, out of bounds
                        Console.WriteLine("Please enter a valid column number: ");
                        input = Console.ReadLine();
                    }
                    else
                    {
                        return column - 1;
                    }
                }
                else 
                {
                    if (input.Equals("q", StringComparison.OrdinalIgnoreCase))
                    {
                        return -1;
                    }
                    else 
                    {
                        //Validation, not column or q
                        Console.WriteLine("Please enter a valid column number: ");
                        input = Console.ReadLine();
                    }
                }
            }
        }
        public static bool PlacePiece(int column)
        {
            for(int i = board.Length - 1; i >= 0; i--)  //Checks if space is empty in the column from the bottom up
            {
                if (board[i][column] == EMPTY_COLOR)
                {
                    board[i][column] = p1Turn? P1_COLOR : P2_COLOR;
                    return true; //Space is empty
                }
            }
            return false; //Space is not empty
        }
        public static void PrintWColor(String text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void PrintBoard()
        {
            int[] columnNumbers = Enumerable.Range(1, COLS).ToArray();
            Console.WriteLine(" " + String.Join(' ', columnNumbers));
            foreach(ConsoleColor[] rows in board)
            {
                Console.Write('|');
                foreach (ConsoleColor element in rows)
                {
                    PrintWColor(SYMBOL.ToString(), element);
                    Console.Write("|");
                }
                Console.Write(Environment.NewLine);
            }
            Console.WriteLine(new String('-', COLS * 2 + 1));
        }

    }
}
