using System.Net.WebSockets;

namespace Exceptions2
{
    public class Program
    {
        public static void Main()
        {
            Console.Write("Enter number of male dancers: ");
            int men = int.Parse(Console.ReadLine()!);

            Console.Write("Enter number of female dancers: ");
            int women = int.Parse(Console.ReadLine()!);

            try
            {
                if (men == 0 && women == 0)
                {
                    throw new NotEnoughDancersException("Dances are canceled due to mass absence.");
                }
                if (men == 0)
                {
                    throw new NotEnoughMaleDancersException("Dances are canceled because no men showed up.");
                }
                if (women == 0)
                {
                    throw new NotEnoughFemaleDancersException("Dances are canceled because no women showed up.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetType().Name); //gives us the class of the exception
                Console.WriteLine(ex.Message);
                Environment.Exit(1); //Any non-zero exit value means an error, the program did not end naturally
            }

            Console.WriteLine("Begin dance.");
        }
    }
}
