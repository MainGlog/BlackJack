using System.Transactions;

namespace MatrixJagged
{
    public class Matrix2
    {
        public static void Main()
        {
            Random rand = new Random();
            int rows = rand.Next(2, 6);
            int cols = rand.Next(2, 6);
            int[][] matrix = new int[rows][];
            for(int i = 0; i < matrix.Length; i++) 
            {
                matrix[i] = new int[cols];
                for(int j = 0; j < matrix[i].Length; j++)
                {
                    matrix[i][j] = rand.Next(0, 10);
                }
            }
            Console.WriteLine("Original matrix: ");
            PrintMatrix(matrix);

            int[][] transposed = TransposeMatrix(matrix);
            Console.WriteLine("Transposed matrix: ");
            PrintMatrix(transposed);
            
        }
        public static void PrintMatrix(int[][] matrix)
        {
            foreach (int[] row in matrix) 
            {
                foreach (int element in row)
                {
                    Console.Write(element + "\t");
                }
                Console.Write(Environment.NewLine);
            }
        }
        public static int[][] TransposeMatrix(int[][] matrix)
        {
            int rows = matrix.Length;
            int cols = matrix[0].Length;
            int[][] transposed = new int[cols][];
            for (int i = 0; i < transposed.Length; i++)
            {
                transposed[i] = new int[rows];
            }
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    transposed[j][i] = matrix[i][j];
                }
            }
            return transposed;
        }
    }
}
