using System.Diagnostics.Metrics;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace Messing_Around
{
    public class Prob
    {
        public static void Main()
        {
            IsPalindrome(95159);
            Console.Write("Enter a string to have it separated by spaces: ");
            Console.WriteLine(SpaceOutString(Console.ReadLine()));
            Gcd(32, 8);
            GetMiddle("FixedTest");
            ToScottishScreaming("Lorem Ipsum");
            //Greater than One
            Console.Write("Enter a fraction as two numbers separated by \"/\" to see if its value is greater than one: ");
            bool result = GreaterThanOne(Console.ReadLine());
            if(result) 
            {
                Console.WriteLine("This fraction is greater than one");
            }
            else
            {
                Console.WriteLine("This fraction is smaller than one");
            }
            //Largest Number in Groups of Arrays
            double[][] tempo = {[-34, -54, -74], [-32, -2, -65], [-54, 7, -43]};
            double[] ints = LargestNumbers(tempo);
            

            //Count letters and digits in a given string
            Console.Write("Enter a string to see the number of integers and characters:");
            CountCharsAndNumsInString(Console.ReadLine());
            

            //The Collatz Conjecture
            Console.Write("Enter a number to return how many steps it takes to get to 1 with the Collatz Conjecture: ");
            Console.WriteLine(CollatzConjecture(int.Parse(Console.ReadLine()), 0));


            //Find the Bomb
            Console.Write("Enter a string to find a bomb: ");
            FindTheBomb(Console.ReadLine());

            //Capital Indices
            Console.Write("Enter a string to find the indices of capital letters: ");
            IndexOfCapitals(Console.ReadLine());
            Console.WriteLine(Environment.NewLine);

            //Invert case type
            Console.Write("Enter a string to change case types: ");
            Console.WriteLine(ReverseCase(Console.ReadLine()));
            Console.WriteLine(Environment.NewLine);

            //Spongebob type
            Console.Write("Enter a string to be mocked: ");
            Console.WriteLine(SpongebobText(Console.ReadLine()));
            Console.WriteLine(Environment.NewLine);

            //List of Y multiples of X
            Console.Write("Enter two numbers, x and y separated by a space, to get a list of y multiples of x: ");
            String temp = Console.ReadLine().Trim();
            String[] temp2 = temp.Split(' ');
            int x = int.Parse(temp2[0]);
            int y = int.Parse(temp2[1]);
            int[] MultipleArray = new int[y];
            MultipleArray = ArrayOfMultiples(x, y);
            Console.WriteLine(String.Join(", ", MultipleArray));
            Console.WriteLine(Environment.NewLine);
            
        }
        public static bool IsPalindrome(int num)
        {
            
            String numAsString = num.ToString();
            
                for (int i = 0; i < numAsString.Length/2; i++)
                {
                    for (int j = numAsString.Length - 1; j >= 0; j--)
                    {
                        if (!numAsString[j].Equals(numAsString[i]))
                        {
                            return false;
                        }
                    }
                }
                return true;       
        }
        public static String SpaceOutString(String s)
        {
            Char[] chars = s.ToCharArray();
            String b = String.Join(" ", chars);
            return b;

        }
        public static int Gcd(int n1, int n2)
        {
            List<int> list = new List<int>();
            int gcd = 0;
            if (n1 > n2)
            {
                for (int i = 1; i <= n1; i++)
                {
                    //Finds common denominators
                    if (n1 % i == 0 && n2 % i == 0)
                    {
                        list.Add(i);
                    }
                }
                for (int i = 0; i < list.Count; i++)
                {
                    //Sorts to find greatest
                    int temp = list[i];
                    temp = Math.Max(list[i], temp);
                    gcd = temp;
                }
            }
            else
            {
                for (int i = 1; i <= n2; i++)
                {
                    if (n1 % i == 0 && n2 % i == 0)
                    {
                        list.Add(i);
                    }
                }
                for (int i = 0; i < list.Count; i++)
                {
                    int temp = list[i];
                    temp = Math.Max(list[i], temp);
                    gcd = temp;
                }
            }
            return gcd;
        }
        public static int[] CountPosSumNeg(double[] arr)
        {
            int counter = 0;
            List<double> list = new List<double>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > 0)
                {
                    counter++;
                }
                else
                {
                    list.Add(arr[i]);
                }

            }
            int[] array = {(int)list.Sum(), counter };
            return array;
        }
        public static bool ValidatePin(string pin)
        {
            if (pin.Length == 4 || pin.Length == 6)
            {
                if (int.TryParse(pin, out int bungo)) return true;
            }
            return false;
        }
        public static int HammingDistance(string str1, string str2)
        {
            int counter = 0;
            for(int i = 0; i < str1.Length; i++) 
            {
                if (str1.Equals((str2[i], StringComparison.OrdinalIgnoreCase)))
                {
                    counter++;
                }
            }
            return counter;
        }
        public static string GetMiddle(string str)
        { 
            if(str.Length%2 == 0)
            {
                return str.Substring(str.Length / 2 - 1, 2);
            }
            else
            {
                return str.Substring(str.Length / 2, 1);
            }
        }
        public static string ToScottishScreaming (string str)
        {
            return Regex.Replace(str.ToUpper(), "[AIOU]", "E");            
        }
        public static bool GreaterThanOne(string str)
        {
            String[]temp = str.Split("/");
            double op1 = double.Parse(temp[0]);
            double op2 = double.Parse(temp[1]);
            if(op1/op2 > 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static double[] LargestNumbers(double[][] ints)
        {
            double[] numbers = new double[ints.Length];
            for (int i = 0; i < ints.Length; i++)
            {
                double temp = ints[i][0];
                for (int j = 0; j < ints[i].Length; j++)
                {
                    temp = Math.Max(ints[i][j], temp);
                    numbers[i] = temp;
                }
            }
            return numbers;
        }

        public static void CountCharsAndNumsInString(string str)
        {
            int numOfInts = 0;
            int charNum = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (int.TryParse(str.Substring(i, 1), out int tempo))
                {
                    numOfInts++;
                }
                else
                {
                    charNum++;
                }
            }
            int[] temp = { numOfInts, charNum };
            Console.WriteLine($"Number of integers: {numOfInts} {Environment.NewLine}Number of characters: {charNum}");
        }
        public static int CollatzConjecture(int n, int counter)
        {
            while (n != 1)
            {
                if (int.IsEvenInteger(n))
                {
                    n = n / 2;
                    counter++;
                    CollatzConjecture(n, counter);
                }
                else if (int.IsOddInteger(n))
                {
                    n = n * 3 + 1;
                    counter++;
                    CollatzConjecture(n, counter);
                }
            }
            return counter;
        }
        
        public static void FindTheBomb(string s)
        {
            if (s.Contains("bomb"))
            {
                Console.WriteLine("Duck!!!");
            }
            else
            {
                Console.WriteLine("There is no bomb, relax.");
            }
        }
        public static void IndexOfCapitals(string s)
        {
            List<int> Indices = new List<int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (char.IsUpper(s[i]))
                {
                    Indices.Add(i);
                }
            }
            Console.WriteLine(String.Join(", ", Indices));
        }
        public static String ReverseCase(String s)
        {
            String[] s2 = new string[s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                if (char.IsUpper(s[i]))
                {
                    s2[i] = s[i].ToString().ToLower();

                }
                else
                {
                    s2[i] = s[i].ToString().ToUpper();
                }
            }
            return String.Join(String.Empty, s2);

        }
        public static String SpongebobText(String s)
        {
            String[] s2 = new string[s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                if (int.IsEvenInteger(i))
                {
                    s2[i] = s[i].ToString().ToUpper();
                }
                if (int.IsOddInteger(i))
                {
                    s2[i] = s[i].ToString().ToLower();
                }
            }
            return String.Join(String.Empty, s2);

        }
        public static int[] ArrayOfMultiples(int num, int length)
        {
            int[] Multiples = new int [length];
            for (int i = 0; i < length; i++)
            {
                Multiples[i] = (num * (i + 1));
            }
            return Multiples;
        }
        
        
        
        
        
    }
}