using System.Numerics;

namespace Recursion
{
    public class Recursion
    { 
        public static void Main()
        {
            Console.Write("Enter a number: ");
            int num = int.Parse(Console.ReadLine());
            int sum = SumFromOneToN(num);
            Console.WriteLine($"The sum from 1 to {num} is {sum}");
            //BigInteger is not fixed size
            BigInteger fact= Factorial(num);
            Console.WriteLine($"{num} factorial is {fact}");
           
            //Integer Overflow, basically changes all bits to 0 except for the signed bit, which makes it the negative max value
            int big = int.MaxValue;
            Console.WriteLine(big);
            big++;
            Console.WriteLine(big);
            uint big2 = uint.MaxValue;
            Console.WriteLine(big2);
            big2++;
            Console.WriteLine(big2);
        }
        public static int SumFromOneToN(int n)
        {
            if (n == 1)
            {
                return 1;
            }
            else 
            {
                return n + SumFromOneToN(n - 1);
            }
        }
        public static BigInteger Factorial(int n)
        {
            if (n == 1)
            {
                return 1;
            }
            else
            {
                return n * Factorial(n - 1);
            }
        }
    }
}
