namespace UsefulPredefinedMethods
{
    public class Program
    {
        public static void Main()
        {
            String helloWorld = "Hello, world!";
            String hello = helloWorld[..5];//range operator... not inclusive
            String hello2 = helloWorld.Substring(0, helloWorld.IndexOf(","));
            String world = helloWorld[(helloWorld.IndexOf(" ") + 1)..helloWorld.IndexOf('!')];

            PrintString(hello);
            PrintString(world);

            helloWorld = helloWorld.Replace('!', '.').Replace(",", String.Empty);
            //this function returns a string
            //This is known as chaining calls
            PrintString(helloWorld);


            String lookingFor = "hello";
            bool containsLookingFor = helloWorld.Contains(lookingFor, StringComparison.OrdinalIgnoreCase);
            if (containsLookingFor)
            {
                Console.WriteLine($"\"{helloWorld}\" does contain \"{lookingFor}\"");
            }
            else
            {
                Console.WriteLine($"\"{helloWorld}\" does not contain \"{lookingFor}\"");
            }

            Console.Write("Input an equation with two operands and 1 operator space separated: ");
            String equation = Console.ReadLine().Trim();
            String[] ops = equation.Split(' ');
            Console.WriteLine(ops);
            Console.WriteLine("Elements: " + String.Join("String.Empty", ops));
            double num1 = double.Parse(ops[0]);
            double num2 = Convert.ToDouble(ops[2]);//these are two of the exact same thing

            Console.WriteLine("The smallest number is " + Math.Min(num1, num2));
            //returns the smallest number between the two.
            Console.WriteLine("The largest number is " + Math.Max(num1, num2));
            Console.WriteLine("The difference between the two numbers is " + Math.Abs(num1 - num2));
            double quotient = num1 / num2;
            Console.WriteLine("The quotient rounded to the nearest integer is " + Math.Round(quotient));
            Console.WriteLine("The quotient rounded to the nearest tenth is " + Math.Round(quotient, 2));
            Console.WriteLine(Math.Ceiling(quotient));//rounding up
            Console.WriteLine(Math.Floor(quotient));//rounded down
            //
            List<int> list = new List<int>()
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10
            };
            //is the same as 
            list = Enumerable.Range(1, 10).ToList();

            int num = int.Parse(Console.ReadLine());
            //

            //
            //code to find the smallest or largest number in a list
            int smallestNum = list[0];

            foreach (int n in list)
            {
                smallestNum = (Math.Min(n, smallestNum));
            }
            //Above is the same as below
            smallestNum = list.Min();
            //

            //
            //Average number in a list
            double averageNumber = list.Average();
            //

            //
            //Find an index of an element
            int indexOfSmallestNum = list.IndexOf(smallestNum);
            //

            //
        }
        public static void PrintString(String str)
        {
            if (String.IsNullOrWhiteSpace(str)) return;


            Console.WriteLine(str)

            String[] numsAsStr = { "1", "2", "3" };
            int[] nums = Array.ConvertAll(numsAsStr, int.Parse);
        }

    }

}
