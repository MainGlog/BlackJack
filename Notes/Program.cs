namespace Notes
{
    internal class Program
    {
        public enum Day
        {
            Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday
        }
        public enum Season
        {
            Spring, Summer, Fall, Winter 
        }
        static void Main(string[] args)
        {
            Season s = (Season)1;

            Console.WriteLine(s);
            (String fname, int age) name = GetInfo();
            Console.WriteLine((GetInfo()));
            Console.WriteLine((name.fname));
            Console.WriteLine(name.age);

            Day day = Day.Monday;

        }
        public static void TellItLikeItIs(Day day)
        {
            switch (day)
            {
                case Day.Monday:
                    Console.WriteLine("Mondays are bad.");
                    break;
                case Day.Friday:
                    Console.WriteLine("Fridays are better.");
                    break;
                case Day.Saturday:
                    Console.WriteLine("It's the weekend!");
                    break;
                case Day.Sunday:
                    Console.WriteLine("It's the weekend!");
                    break;
                
            }
        }
        public static (String fname, int age) GetInfo()
        {
            Console.WriteLine("What is your first name? ");
            String fName = Console.ReadLine();
            Console.WriteLine("What is your age?");
            int age = int.Parse(Console.ReadLine()!);
            return (fName, age);
        }
        
    }
}
