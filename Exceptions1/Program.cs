using System.Net.Quic;

namespace Exceptions1
{
    public class Program
    {
        public static void Main()
        {
            int[] numbers = Enumerable.Range(1, 5).ToArray();

            try //Any error-prone code should go in a try-catch block
            {
                int number = numbers[5];
            }
            catch //Catch is required if try exists
            {
                Console.WriteLine("An exception was thrown! No additional details.");
            }

            int numToIndex = -1;

            try
            {
                int number = numbers[numToIndex];
            }
            catch (IndexOutOfRangeException ex) when (numToIndex >= numbers.Length || numToIndex < 0)
            //ex is an instance of IndexOOR class
            {
                Console.WriteLine("There was an index out of range exception!");
                Console.WriteLine(ex.Message);
            }
            catch //In case any other exceptions are thrown
            {
                Console.WriteLine("An exception was thrown! No additional details.");
            }
            finally //Optional, will always occur regardless of an exception or not.
            {
                Console.WriteLine(Environment.NewLine);
            }


            try
            {
                GetElementFromArray();
            }
            catch (FormatException ex)
            {
                Console.WriteLine("There was a format exception!");
                Console.WriteLine(ex.Message);
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("There was an index out of range exception!");
                Console.WriteLine(ex.Message);
            }
            catch(Exception ex) //Catch-all
            {
                Console.WriteLine("There was an exception.");
                Console.WriteLine(ex.Message);
            }

            try
            {
                DoDivision();
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex) //Useful for finding info about unconsidered errors
            {
                Console.WriteLine("Exception throw. No additional details.");
            }
        }
        private static void GetElementFromArray()
        {
            String[] array = { "hello", "world", "foo", "bar", "baz" };
            
            Console.WriteLine("Select an element from the array via its index.");
            Console.WriteLine("Elements: ");
            Console.WriteLine(String.Join("\t", Enumerable.Range(0, array.Length)));
            Console.WriteLine(String.Join("\t", array));

            Console.Write("Input an index: ");

            int index = int.Parse(Console.ReadLine()!); ///Possible format exception
            Console.WriteLine(array[index]); //Possible index out of range exception
        }

        private static void DoDivision()
        {
            Console.Write("Input two integers to divide, separated by a space: ");
            String[] input = Console.ReadLine()!.Split(' ');

            int numerator = int.Parse(input[0]); //Possible format exception
            int denominator = int.Parse(input[1]); //Possible format exception
            int quotient = numerator / denominator; //Possible divide by zero exception
            Console.WriteLine("Result: " + quotient);
        }
    }
}
