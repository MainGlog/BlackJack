using System.Diagnostics;
using System.Net.Security;
using System.Runtime.InteropServices;
namespace RPG
{
    internal class Program
    {
        public static readonly String[] CLASS_NAMES = { "Warrior", "Hunter", "Knight", "Sorcerer" };
        public static readonly List<String> STAT_NAMES = ["Level", "Health", "Speed", "Damage", "Dexterity", "Armor", "Magic"];
        public static readonly int[][] STATS = new int[CLASS_NAMES.Length][];
        public static int[] playerStats = new int[STAT_NAMES.Count];
        static void Main(string[] args)
        {
            DodgeAttack();
            LoadStats();
            LoadStats(GetClass());
        }
        public static void InitializeEnemiesForEncounter()
        {
            Random rand = new Random();
            int selector = rand.Next(0, 2);
            switch (selector)
            {
                case 0:
                    String enemyType = "Goblin";
                    EncounterInfo(InitializeGoblin(), enemyType);
                    break;
                case 1:
                    enemyType = "Skeleton";
                    EncounterInfo(InitializeSkeleton(), enemyType);
                    break;
                case 2:
                    enemyType = "Slime";
                    EncounterInfo(InitializeSlime(), enemyType);
                    break;
            }
        }
        public static void LoadStats()
        {
            //Loads base stats into the stats jagged array
            STATS[0] = new int[] { 4, 11, 12, 13, 13, 11, 9 };
            STATS[1] = new int[] { 4, 11, 11, 12, 14, 11, 9 };
            STATS[2] = new int[] { 5, 14, 10, 11, 11, 10, 9 };
            STATS[3] = new int[] { 3, 8, 8, 9, 11, 8, 15 };
        }
        public static void LoadStats(int classNum)
        {
            //Loads selected class stats into player stats
            switch (classNum)
            {
                case 0:
                    playerStats = STATS[0];
                    break;
                case 1:
                    playerStats = STATS[1];
                    break;
                case 2:
                    playerStats = STATS[2];
                    break;
                case 3:
                    playerStats = STATS[3];
                    break;
            }
        }
        public static int GetClass()
        {
            //Prints classes
            String classes = String.Empty;
            foreach (String name in CLASS_NAMES)
            {
                classes = String.Join(", ", CLASS_NAMES);
            }

            bool infoCheck = false; //Allows loop to repeat without saying invalid input if player chooses to show info
            while (true)
            {
                Console.WriteLine("Class Options:");
                Console.WriteLine(classes);
                Console.Write("Please enter the name of a class to choose or \"I: (class name)\" to view stats: ");
                String info = "I: "; //Easy way to determine if the player wants to see info on the class
                String classChoice = Console.ReadLine();
                for (int i = 0; i < CLASS_NAMES.Length; i++)
                {
                    if (classChoice.Equals(info + CLASS_NAMES[i], StringComparison.OrdinalIgnoreCase)) //Shows info on selected class
                    {
                        for (int j = 0; j < STAT_NAMES.Count; j++)
                        {
                            Console.Write(STAT_NAMES[j] + ": ");
                            Console.Write(STATS[i][j] + "   ");
                            infoCheck = true; //Will skip the invalid input section if the player asks for info
                        }
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                    }
                    if (classChoice.Equals(CLASS_NAMES[i], StringComparison.OrdinalIgnoreCase))
                    {
                        return i;
                    }
                }
                if (!infoCheck)
                {
                    Console.WriteLine("Invalid input.");
                    Console.WriteLine("Class Options:");
                    Console.WriteLine(classes);
                    Console.Write("Please enter the name of a class to choose or \"I: (class name)\" to view stats: ");
                }
            }
        }
        
        public static bool DodgeAttack()
        {
            Stopwatch sw = Stopwatch.StartNew();
            Random rand = new Random();
            bool dodgedEarly = false;
            char keyPressed = '\0';
            while(sw.ElapsedMilliseconds <= rand.Next(1000,5000))
            {
                if(sw.ElapsedTicks % 2500 == 0) Console.Write('-');
                if (Console.KeyAvailable) //Will only return true if something is pressed
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    keyPressed = key.KeyChar;
                    PrintWColor("!", ConsoleColor.Red);
                    Console.WriteLine("\nToo Early!");
                    dodgedEarly = true;
                    return false;
                }
            }
            sw.Reset();
            sw.Start();
            while (!dodgedEarly && sw.ElapsedMilliseconds <= 500)
            {
                if (Console.KeyAvailable) //Will only return true if something is pressed
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    keyPressed = key.KeyChar;
                    PrintWColor("!", ConsoleColor.Red);
                    Console.WriteLine("\nDodged!");
                    return true;
                }
                if (sw.ElapsedTicks % 2500 == 0) Console.Write('!');
            }
            if (keyPressed == '\0') Console.WriteLine("\nDodge Failed!");
            sw.Stop();
            return false;
        }
        public static int[] InitializeGoblin()
        {
            int level = playerStats[0] - 1;
            int[] gobStats = { level, 7 + (2 * level), 10 + (2 * level), 7 + (2 * level), 10 + (2 * level), 5 + (2 * level), 4 + (2 * level) };
            return gobStats;
        }
        public static int[] InitializeSkeleton()
        {
            int level = playerStats[0] - 1;
            int[] skeletonStats = { level, 4 + (level), 7 + (2 * level), 6 + (level), 10 + (level), 2 + (level), 3 + (level) };
            return skeletonStats;
        }
        public static int[] InitializeSlime()
        {
            int level = playerStats[0] - 1;
            int[] slimeStats = { level, 10 + (2 * level), 3 + level, 4 + (2 * level), 6 + (2 * level), 5 + level, 0 };
            return slimeStats;
        }
        public static void EncounterInfo(int[]enemyStats, String enemyType)
        {
            Console.WriteLine($"A level {enemyStats[0]} {enemyType} approaches. ");
            Console.WriteLine("Health: " + enemyStats[1]);
        }
        public static bool PlayerFirst(int[]enemyStats)
        {
            if (enemyStats[3] > playerStats[3])
            {
                return false;
            }
            return true;
        }
        public static void PrintWColor(String text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
