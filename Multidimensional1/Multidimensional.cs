namespace Multidimensional1
{
    public class Multidimensional
    {
        public static void Main()
        {
            //Multidimensional
            //MD arrays have to have arrays of the same size
            //Like a table
            int[,] numbers = new int[5, 4];
            //5 outer arrays of size 4
            //int[,] numbers = { { 1, 2, 5 }, { 3, 4, 7 }, { 8, 9, 10 } };
            //int[,,] numbers3d = new int[5,4,3];
            numbers[0,0] = 1;
            numbers[0,1] = 2;
            numbers[0,2] = 3;

            //Jagged arrays
            //Jagged is preffered to multidimensional
            int[][] numbers2 = new int[5][];
            //5 outer arrays of unspecified size
            //Only the number of arrays needs to be specified
            numbers2[0] = new int[7];
            numbers2[0][0] = 3; //array needs to be initialized before this can be done, as all values are null
            numbers2[1] = new int[3];

        }

    }
}
