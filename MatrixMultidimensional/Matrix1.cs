namespace MatrixMultidimensional
{
    public class Matrix1
    {
        public static void Main()
        {
            Random rand = new Random(); //putting a number in the () in random gives it a set seed
            int rows = rand.Next(2, 6);
            int cols = rand.Next(2, 6);
            int[,] matrix = new int[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = rand.Next(0, 11);
                }
            }
            Console.WriteLine("Original matrix:");
            PrintMatrix(matrix);

            Console.WriteLine("Transposed matrix: ");
            PrintMatrix(TransposeMatrix(matrix));

        }
        public static void PrintMatrix(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            for(int i = 0; i < rows; i++) 
            { 
                for(int j = 0; j < cols; j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine(Environment.NewLine);
            }
        }
        public static int[,] TransposeMatrix(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            int[,] transposed = new int[cols, rows];
            for(int i=0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    transposed[j, i] = matrix[i, j];
                }
            }
            return transposed;
        }
    }
}
